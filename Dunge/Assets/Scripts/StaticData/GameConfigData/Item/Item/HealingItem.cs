using Scripts.Player;
using Scripts.StaticData.GameConfigData.Item.Interface;
using System;
using UnityEngine;

namespace Scripts.StaticData.GameConfigData.Item.Item
{
    [CreateAssetMenu(fileName = "HealingItem", menuName = "StaticData/GameConfigData/Item/HealingItem")]
    public class HealingItem : ItemData, IUsing
    {
        [SerializeField] private int _numberHealingPoints;

        public void Use(PlayerBehaviour playerBehaviour) =>
            playerBehaviour.Health.Heal(_numberHealingPoints);
    }
}
