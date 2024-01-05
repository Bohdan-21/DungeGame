using Scripts.GameMechanic.ItemSystem;
using Scripts.Infrastructure.Audio;
using Scripts.SaveData;
using Scripts.SaveData.StorageData;
using Scripts.Services.PlayerProgressService;
using Scripts.StaticData.ItemStaticData;
using Scripts.StaticData.ItemStaticData.Interface;
using Scripts.StaticData.ItemStaticData.Item;
using System;
using UnityEngine;
using Zenject;

namespace Scripts.Player
{
    public class PlayerInventory : MonoBehaviour, IPlayerProgressLoader
    {
        [SerializeField] private PlayerBehaviour _playerBehaviour;
        [SerializeField] private Storage _storage;

        private ISoundsGameActionPlayer _soundPlayer;
        private ItemCollection _itemCollection;

        public event Action UpdateInventory;

        [Inject]
        private void Construct(ISoundsGameActionPlayer soundPlayer, ItemCollection itemCollection, 
                               IPlayerProgressService progressService)
        {
            _soundPlayer = soundPlayer;
            _itemCollection = itemCollection;

            progressService.AddProgressUpdater(this);
        }

        public Storage GetStorage() =>
            _storage;

        public int GetItemCount(TypeItem typeItem)
        {
            ItemCount itemCount = _storage.GetItem(typeItem);

            if (itemCount != null)
                return itemCount.GetItemCount();
            return 0;
        }

        public void AddItem(ItemMarker itemMarker)
        {
            _storage.AddItem(itemMarker.TypeItem, 1);

            itemMarker.PickUp();

            UpdateInventory?.Invoke();
        }

        public void Use(TypeItem itemType)
        {
            ItemData itemData = _itemCollection.GetItem(itemType);

            if(itemData != null && itemData is IUsing usingItem)
            {
                if (_storage.TryTakeItem(itemType, 1))
                {
                    usingItem.Use(_playerBehaviour);

                    UpdateInventory?.Invoke();
                }
            }
        }

        private void PlaySound() =>
            _soundPlayer.PlayUseItemSound();

        public void LoadProgress(PlayerProgress playerProgress) => 
            _storage = new Storage(playerProgress.Storage);

        public void UpdateProgress(PlayerProgress playerProgress) => 
            playerProgress.Storage = new Storage(_storage);
    }
}