using Scripts.GameMechanic.ItemSystem;
using Scripts.Services.ControlButtonService;
using Scripts.Services.InputService;
using Scripts.Services.InteruptService;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Scripts.Player
{
    class PlayerInventoryUI : MonoBehaviour, IInteruptHandler
    {
        private KeyCode UseFirstItemButton;
        private KeyCode UseSecondItemButton;
        private KeyCode UseThirdItemButton;

        private const string NameSmallHealth = "SMALL_HEAL";
        private const string NameMiddleHealth = "MIDDLE_HEAL";
        private const string NameLargeHealth = "LARGE_HEAL";
        
        public List<ItemUpdater> ItemUpdaters;
        
        private PlayerInventory _inventory;
        private IInputService _inputService;
        private IInteruptService _interuptService;

        private bool _isInterupt;
        
        [Inject]
        private void Construct(PlayerBehaviour playerBehaviour, IInputService inputService, IInteruptService interuptService,
                               IControlButtonService controlButtons)
        {
            _inventory = playerBehaviour.Inventory;
            _inputService = inputService;
            _interuptService = interuptService;

            UseFirstItemButton = controlButtons.ControlButtons.PlayerControlButtons.InventoryControlButtons.UseFirstItemButton;
            UseSecondItemButton = controlButtons.ControlButtons.PlayerControlButtons.InventoryControlButtons.UseSecondItemButton;
            UseThirdItemButton = controlButtons.ControlButtons.PlayerControlButtons.InventoryControlButtons.UseThirdItemButton;
        }
        
        private void Start()
        {
            _isInterupt = false;

            _inventory.UpdateInventoryEvent += InventoryUpdateUI;
            _interuptService.AddInteruptHandler(this);

            InventoryUpdateUI();
        }

        private void OnDestroy()
        {
            _inventory.UpdateInventoryEvent -= InventoryUpdateUI;

            _interuptService.RemoveInteruptHandler(this);
        }


        private void Update()
        {
            if (_inputService.IsPress(UseFirstItemButton))
                UseItem(NameSmallHealth);
            else if (_inputService.IsPress(UseSecondItemButton))
                UseItem(NameMiddleHealth);
            else if (_inputService.IsPress(UseThirdItemButton))
                UseItem(NameLargeHealth);
        }

        public void UseItem(string value)
        {
            if (_isInterupt)
                return;

            if (value == TypeItem.SMALL_HEAL.ToString())
                _inventory.Use(TypeItem.SMALL_HEAL);
            else if (value == TypeItem.MIDDLE_HEAL.ToString()) 
                _inventory.Use(TypeItem.MIDDLE_HEAL);
            else if (value == TypeItem.LARGE_HEAL.ToString())
                _inventory.Use(TypeItem.LARGE_HEAL);
        }

        private void InventoryUpdateUI()
        {
            foreach(ItemUpdater itemUpdater in ItemUpdaters)
                itemUpdater.UpdateCount(_inventory.GetItemCount(itemUpdater.TypeItem));
        }

        public void Interupt() =>
            _isInterupt = true;

        public void Continue() =>
            _isInterupt = false;
    }

}
