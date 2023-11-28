using System;
using UnityEngine;

namespace Scripts.SaveData
{
    [Serializable]
    public class PlayerState
    {
        public int CurrentHP;

        public int MaxHP;

        public PlayerState() : this(100, 100) { }

        public PlayerState(int currentHP, int maxHP)
        {
            CurrentHP = currentHP;
            MaxHP = maxHP;
        }
    }
}