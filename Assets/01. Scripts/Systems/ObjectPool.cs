using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance { get; private set; }

    private Dictionary<GameObject, List<GameObject>> pools
        = new Dictionary<GameObject, List<GameObject>>();

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public GameObject Get(GameObject prefab)
    {
        if (!pools.TryGetValue(prefab, out var pool))
        {
            pool = new List<GameObject>();
            pools.Add(prefab, pool);
        }

        foreach (var obj in pool)
        {
            if (!obj.activeSelf)
            {
                obj.SetActive(true);
                return obj;
            }
        }

        GameObject newObj = Instantiate(prefab);
        pool.Add(newObj);
        return newObj;
    }

    public void Release(GameObject obj)
    {
        obj.SetActive(false);
    }
}