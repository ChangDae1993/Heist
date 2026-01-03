using System;
using System.Collections.Generic;

namespace properties
{
    public enum WeaponType
    {
        Gun = 1001,
        Book = 1002,
        Garlic = 1003,
        Meteor = 1004
    }

    public enum MonsterType
    {
        A = 2001,
        B = 2002
        // 임시입니다. 몬스터 종류 어케해야할 지 몰라서
    }

    #region 무기

    [Serializable]
    public struct WeaponRoot
    {
        public List<WeaponGroup> weapons;
    }

    [Serializable]
    public struct WeaponGroup
    {
        public string weaponType;
        public List<Weapons> levels;

        public WeaponType WeaponTypeEnum => Enum.Parse<WeaponType>(weaponType);
    }

    [Serializable]
    public struct Weapons
    {
        public float damage;
        public float coolTime;
        public float speed;
        public float duration;
        public float scale;
        public int count;
    }
    #endregion
}

