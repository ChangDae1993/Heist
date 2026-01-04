using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UIElements;

public class Meteor : Weapon
{
    List<properties.Weapons> meteors = new List<properties.Weapons>();

    private float   duration;
    private float   timer;
    private int     count;
    private bool    isTimer;
    private Vector4 groundSize;
    private void Awake()
    {
        meteors = JsonLoader.GetWeaponData(properties.WeaponType.Meteor);
    }

    void Start()
    {
        count = 0;
        isTimer = true;
        groundSize = GameManager.Instance.GetGroundSize();
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
        if (Input.GetKeyDown(KeyCode.Z))
        {
            levelUp();
        }
    }

    IEnumerator Fire()
    {
        float cool;
        cool = duration / count;

        for (int i = 0; i < count; i++)
        {
            MeteorObj meteor = ObjectPool.Instance.Get(attackObj).GetComponent<MeteorObj>();

            meteor.Init(damage);
            float posX = Random.Range(groundSize.x, groundSize.y);
            float posZ = Random.Range(groundSize.z, groundSize.w);
            meteor.transform.position = new Vector3(posX,10,posZ);
            meteor.transform.rotation = Quaternion.identity;
            meteor.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            meteor.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;

            yield return new WaitForSeconds(cool);
        }
        isTimer = true;
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
