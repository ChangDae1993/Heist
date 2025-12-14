using System.Collections.Generic;
using NUnit.Framework.Interfaces;
using UnityEngine;

[System.Serializable]
public struct TestData
{
    public int a;
    public int b;
}

[System.Serializable]
public struct Test2Data
{
    public string a;
    public List<int> b;
    public float c;
}

public static class JsonLoader
{
    //public static T Load<T> (string fileName)
    //{
    //    TextAsset[] files = Resources.LoadAll<TextAsset>("");

    //    foreach (TextAsset file in files)
    //    {
    //        if(file.name == "")
    //        {

    //        }
    //        else if (file.name == "")
    //        {
                
    //        }
    //    }


    //void LoadTest()
    //{
    //    TextAsset json = Resources.Load<TextAsset>("test");
    //    TestData data = JsonUtility.FromJson<TestData>(json.text);

    //    Debug.Log($"test.json ¡æ a: {data.a}, b: {data.b}");
    //}

    //void LoadTest2()
    //{
    //    TextAsset json = Resources.Load<TextAsset>("test2");
    //    Test2Data data = JsonUtility.FromJson<Test2Data>(json.text);

    //    Debug.Log($"test2.json ¡æ a: {data.a}, c: {data.c}");
    //    Debug.Log($"b count: {data.b.Count}");
    //}
}
