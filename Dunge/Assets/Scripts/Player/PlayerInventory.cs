using Scripts.GameMechanic.ItemSystem;
using Scripts.Infrastructure.Audio;
using Scripts.SaveData;
using Scripts.SaveData.Storage;
using Scripts.Services.PlayerProgressService;
using Scripts.StaticData.GameConfigData.Item;
using Scripts.StaticData.GameConfigData.Item.Interface;
using Scripts.StaticData.GameConfigData.Item.Item;
using System;
using UnityEngine;
using Zenject;

namespace Scripts.Player
{
    public class PlayerInventory : MonoBehaviour, IPlayerProgressLoader
    {
        [SerializeField] private PlayerBehaviour _playerBehaviour;
        [SerializeField] private StorageHandler _storageHandler;

        private ISoundsGameActionPlayer _soundPlayer;
        private ItemCollection _itemCollection;

        public event Action UpdateInventoryEvent;

        [Inject]
        private void Construct(ISoundsGameActionPlayer soundPlayer, ItemCollection itemCollection, 
                               IPlayerProgressService progressService)
        {
            _soundPlayer = soundPlayer;
            _itemCollection = itemCollection;

            progressService.AddProgressUpdater(this);
        }

        private void Start() => 
            _storageHandler.UpdateStorageDataEvent += UpdateStorageData;

        private void OnDestroy() => 
            _storageHandler.UpdateStorageDataEvent -= UpdateStorageData;


        public StorageHandler GetStorage() =>
            _storageHandler;

        public int GetItemCount(TypeItem typeItem)
        {
            ItemCount itemCount = _storageHandler.GetItem(typeItem);

            if (itemCount != null)
                return itemCount.GetItemCount();
            return 0;
        }

        public void AddItem(ItemMarker itemMarker)
        {
            _storageHandler.AddItem(itemMarker.TypeItem, 1);

            itemMarker.PickUp();

            UpdateInventoryEvent?.Invoke();
        }

        public void Use(TypeItem itemType)
        {
            ItemData itemData = _itemCollection.GetItem(itemType);

            if(itemData != null && itemData is IUsing usingItem)
            {
                if (_storageHandler.TryTakeItem(itemType, 1))
                {
                    usingItem.Use(_playerBehaviour);

                    UpdateInventoryEvent?.Invoke();
                }
            }
        }

        private void PlaySound() =>
            _soundPlayer.PlayUseItemSound();

        private void UpdateStorageData() => 
            UpdateInventoryEvent?.Invoke();

        public void LoadProgress(PlayerProgress playerProgress) => 
            _storageHandler = new StorageHandler(playerProgress.StorageData);

        public void UpdateProgress(PlayerProgress playerProgress) => 
            playerProgress.StorageData = new StorageData(_storageHandler.GetStorageData());
    }
}