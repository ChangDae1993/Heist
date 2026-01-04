using System.Collections.Generic;
using properties;
using UnityEngine;

public static class JsonLoader
{
    public static Dictionary<properties.WeaponType, List<properties.Weapons>> weaponDatas = new Dictionary<properties.WeaponType, List<properties.Weapons>>();
   
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void Load()
    {
        TextAsset[] files = Resources.LoadAll<TextAsset>("");

        foreach (TextAsset file in files)
        {
            if (file.name == "Weapons")
            {
                LoadWeapons(file);
            }
            else if (file.name == "Monsters")
            {
                LoadMonsters();
            }
        }

        void LoadWeapons(TextAsset json)
        {
            var root = JsonUtility.FromJson<WeaponRoot>(json.text);

            weaponDatas.Clear();

            foreach (var group in root.weapons)
            {
                weaponDatas[group.WeaponTypeEnum] = group.levels;
            }
        }

        void LoadMonsters()
        {

        }
    }

    public static List<properties.Weapons> GetWeaponData(WeaponType type)
    {
        if(weaponDatas.ContainsKey(type))
        {
            return weaponDatas[type];
        }
        return null;
    }
}
