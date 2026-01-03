using System.Collections.Generic;
using properties;
using UnityEngine;
using UnityEngine.InputSystem;

public class Book : Weapon
{
    public float radius = 5f;
    private float angle;
    private List<BookObj> bookObjs = new List<BookObj>();
    private List<properties.Weapons> books = new List<Weapons>();

    private void Awake()
    {
        books = JsonLoader.GetWeaponData(properties.WeaponType.Book);
    }
    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            levelUp();
        }

        UpdateBookPositions();
        angle += speed * Time.deltaTime;
    }

    void UpdateBookPositions()
    {
        int count = bookObjs.Count;
        if (count == 0) return;

        for (int i = 0; i < count; i++)
        {
            float offset = 360f / count * i;
            float currentAngle = angle + offset;
            float rad = currentAngle * Mathf.Deg2Rad;

            Vector3 pos = new Vector3(Mathf.Cos(rad), 0, Mathf.Sin(rad)) * radius;

            bookObjs[i].SetPosition(transform.position + pos);
        }
    }

    public override void levelUp()
    {
        if (level + 1 < books.Count)
        {
            level++;
            speed = books[level].speed;
            damage = books[level].damage;
        }
        AddBooks();
    }

    private void AddBooks()
    {
        BookObj book = ObjectPool.Instance.Get(attackObj).GetComponent<BookObj>();
        bookObjs.Add(book);
        foreach (BookObj child in bookObjs)
        {
            child.Init(damage);
        }
    }
}