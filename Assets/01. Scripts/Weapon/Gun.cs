using UnityEngine;

public class Gun : Weapon
{
    private float timer;
    

    void Awake()
    {
    }
    void Start()
    {
        InitWeapon(this);
        damage = 1;
        speed = 3;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > coolTime)
        {
            Fire();
            timer = 0;
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            levelUp();
        }
    }
    void Fire()
    {
        if (scanner.getNearestTrans())
        {
            Bullet bullet = ObjectPool.Instance.Get(attackObj).GetComponent<Bullet>();
            bullet.Init(speed, damage);
            bullet.transform.position = this.transform.position;
            bullet.GetComponent<Bullet>().SetTarget(scanner.getNearestTrans());
        }
    }
    public override void levelUp()
    {
        damage++;
        speed++;

        //배열에 접근해서 해야 함
    }
}
