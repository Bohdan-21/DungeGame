using Scripts.Data.SaveData;
using Scripts.GameMechanic.Item;
using Scripts.Infrastructure.Audio;
using Scripts.Logic;
using Scripts.Services.PlayerProgressService;
using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Scripts.Player
{
    public class PlayerInventory : MonoBehaviour, IPlayerProgressLoader
    {
        public Dictionary<TypeItem, int> _storage { get; private set; } = new Dictionary<TypeItem, int>();
        public event Action UpdateInventory;

        private PlayerHealth Health;
        private ISoundsGameActionPlayer _soundPlayer;

        private HealBehaviour healing = new HealBehaviour();

        [Inject]
        private void Construct(PlayerBehaviour player, IPlayerProgressService progressService, 
                               ISoundsGameActionPlayer soundPlayer)
        {
            Health = player.Health;
            _soundPlayer = soundPlayer;

            progressService.AddProgressUpdater(this);
        }

        public void AddItem(Item item)
        {
            if (_storage.TryGetValue(item.TypeItem, out int count))
                _storage[item.TypeItem] = count + 1;
            else
                return;

            item.PickUp();

            UpdateInventory?.Invoke();
        }

        public void Use(TypeItem item)
        {
            if (_storage.TryGetValue(item, out int count))
            {
                if (count == 0)
                    return;

                _storage[item] = count - 1;
                healing.Healing(item, Health);
                
                PlaySound();

                UpdateInventory?.Invoke();
            }
        }

        private void PlaySound() => 
            _soundPlayer.PlayUseItemSound();

        public int GetCount(TypeItem item)
        {
            if (_storage.TryGetValue(item, out int count))
                return count;
            return 0;
        }

        public void LoadProgress(PlayerProgress playerProgress)
        {
            for(int i = 0; i < playerProgress.Inventory.StorageTypeItem.Count; i++)
            {
                TypeItem typeItem = playerProgress.Inventory.StorageTypeItem[i];
                int count = playerProgress.Inventory.StorageCountItem[i];

                _storage.Add(typeItem, count);
            }

            UpdateInventory?.Invoke();
        }

        public void UpdateProgress(PlayerProgress playerProgress)
        {
            foreach(KeyValuePair<TypeItem, int> value in _storage)
            {
                playerProgress.Inventory.StorageTypeItem.Add(value.Key);
                playerProgress.Inventory.StorageCountItem.Add(value.Value);
            }

            Debug.Log("Данные инвентаря записаны");
        }
    }
}