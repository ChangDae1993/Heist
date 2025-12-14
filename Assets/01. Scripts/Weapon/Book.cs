using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Book : Weapon
{
    public float radius = 5f;
    public float rotateSpeed = 150f;

    private float angle;
    private List<BookObj> books = new List<BookObj>();

    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            levelUp();
        }

        UpdateBookPositions();
        angle += rotateSpeed * Time.deltaTime;
    }

    void UpdateBookPositions()
    {
        int count = books.Count;
        if (count == 0) return;

        for (int i = 0; i < count; i++)
        {
            float offset = 360f / count * i;
            float currentAngle = angle + offset;
            float rad = currentAngle * Mathf.Deg2Rad;

            Vector3 pos = new Vector3(Mathf.Cos(rad), 0, Mathf.Sin(rad)) * radius;

            books[i].SetPosition(transform.position + pos);
        }
    }

    void AddBook()
    {
        BookObj book = ObjectPool.Instance.Get(attackObj).GetComponent<BookObj>();
        books.Add(book);
        foreach(BookObj child in books)
        {
            child.Init(damage);
        }
    }

    public override void levelUp()
    {
        damage += 1;
        AddBook();
    }
}