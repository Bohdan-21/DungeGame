using Scripts.Data.SaveData;
using Scripts.QuestSystem.QuestVariation;
using Scripts.QuestSystem.QuestVariation.BaseQuest;
using Scripts.QuestSystem.QuestVariation.Data;
using System;
using UnityEngine;

namespace Scripts.Extension
{
    public static class Extensions
    {
        public static string ToJson(this object obj)
        {
            return JsonUtility.ToJson(obj);
        }

        public static T FromJson<T>(this string json)
        {
            return JsonUtility.FromJson<T>(json);
        }
    }
}
