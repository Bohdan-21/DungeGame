using Scripts.Player;
using Scripts.StaticData.ItemStaticData.Interface;
using System;
using UnityEngine;

namespace Scripts.StaticData.ItemStaticData.Item
{
    [CreateAssetMenu(fileName = "HealingItem", menuName = "StaticData/Item/HealingItem")]
    public class HealingItem : ItemData, IUsing
    {
        [SerializeField] private int _numberHealingPoints;

        public void Use(PlayerBehaviour playerBehaviour) => 
            playerBehaviour.Health.Heal(_numberHealingPoints);
    }
}
