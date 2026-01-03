using UnityEngine;
using properties;
using System.Collections.Generic;

public class Garlic : Weapon
{
    List<properties.Weapons> garlics = new List<properties.Weapons>();
    
    public bool IsTimer
    {
        set => isTimer = value;
    }

    private float timer;
    private float duration;
    private float scale;
    private bool isTimer;

    private void Awake()
    {
        garlics = JsonLoader.GetWeaponData(properties.WeaponType.Garlic);
    }
    void Start()
    {
        isTimer = true;
    }
    void Update()
    {
        if (isTimer && level > -1)
        {
            timer += Time.deltaTime;
            if (timer > coolTime)
            {
                Create();
                timer = 0;
                isTimer = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            levelUp();
        }
    }

    private void Create()
    {
        GarlicObj garlicObj = ObjectPool.Instance.Get(attackObj).GetComponent<GarlicObj>();
        
        if(garlicObj.transform.parent != transform)
            garlicObj.transform.parent = transform;
        
        garlicObj.Init(this, damage, scale, duration);
        garlicObj.transform.position = this.transform.position;
    }
    public override void levelUp()
    {
        if (level + 1 >= garlics.Count)
            return;

        level++;
        coolTime = garlics[level].coolTime;
        duration = garlics[level].duration;
        scale = garlics[level].scale;
    }
}
