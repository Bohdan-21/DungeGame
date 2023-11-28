using System;
using UnityEngine;

namespace Scripts.SaveData
{
    [Serializable]
    public class State
    {
        [Range(1, 100)]
        public int CurrentHP;

        [Range(1, 100)]
        public int MaxHP;

        public State() : this(100, 100) { }

        public State(int currentHP, int maxHP)
        {
            CurrentHP = currentHP;
            MaxHP = maxHP;
        }
    }
}