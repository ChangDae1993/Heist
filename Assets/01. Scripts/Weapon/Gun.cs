using UnityEngine;
using properties;
using System.Collections.Generic;

public class Gun : Weapon
{
    private float timer;
    private List<properties.Weapons> guns = new List<Weapons>();

    void Awake()
    {
        guns = JsonLoader.GetWeaponData(WeaponType.Gun);
    }
    void Start()
    {
        InitWeapon(this);
        levelUp();
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
        level++;
        
        if (guns.Count <= level)
            return;

        coolTime = guns[level].coolTime;
        damage = guns[level].damage;
        speed = guns[level].speed;
    }
}
