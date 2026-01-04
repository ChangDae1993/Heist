using System.Collections.Generic;
using System.IO;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{

    [SerializeField] protected Scanner scanner;
    [SerializeField] protected GameObject attackObj;

    protected float coolTime;
    protected float damage;
    protected float speed;
    protected int level = -1;

    private List<Weapon> weapons = new List<Weapon>();
    private void Start()
    {
        scanner = GetComponentInParent<Scanner>();
    }
    protected void InitWeapon(Weapon weapon)
    {
        switch(weapon)
        {
            case Gun:
                break;
        }

        weapons.Add(weapon);
    }
    public void AlllevelUp()
    {
        foreach (Weapon weapon in weapons)
        {
            weapon.levelUp();
        }
    }

    public abstract void levelUp();
}
