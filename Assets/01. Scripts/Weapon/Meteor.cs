using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UIElements;

public class Meteor : Weapon
{
    List<properties.Weapons> meteors = new List<properties.Weapons>();

    private int count;
    private float duration;
    private float timer;
    private bool isTimer;
    private void Awake()
    {
        meteors = JsonLoader.GetWeaponData(properties.WeaponType.Meteor);
    }

    void Start()
    {
        count = 0;
        isTimer = true;
    }

    void Update()
    {
        if (isTimer && level > -1)
        {
            timer += Time.deltaTime;
            if (timer > coolTime)
            {
                StartCoroutine(Fire());
                timer = 0;
                isTimer = false;
            }
        }
    }

    IEnumerator Fire()
    {
        float cool;
        cool = duration / count;

        for (int i = 0; i < count; i++)
        {
            MeteorObj meteor = ObjectPool.Instance.Get(attackObj).GetComponent<MeteorObj>();

            meteor.Init();
            meteor.transform.position = this.transform.position;
            yield return new WaitForSeconds(cool);
        }
    }
    public override void levelUp()
    {
        if (level + 1 >= meteors.Count)
            return;

        level++;

        damage = meteors[level].damage;
        count = meteors[level].count;
        coolTime = meteors[level].coolTime;
        duration = meteors[level].duration;
    }
}
