using Scripts.GameMechanic.ItemSystem;
using Scripts.Services.ControlButtonService;
using Scripts.Services.InputBlockerService;
using Scripts.Services.InputService;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Scripts.Player
{
    class PlayerInventoryUI : MonoBehaviour, IInputBlockerHandler
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
        private IInputBlockerService _inputBlockerService;
        private bool _isInputBlock;

        [Inject]
        private void Construct(PlayerBehaviour playerBehaviour, IInputService inputService,
                               IControlButtonService controlButtons, IInputBlockerService inputBlockerService)
        {
            _inventory = playerBehaviour.Inventory;
            _inputService = inputService;
            _inputBlockerService = inputBlockerService;

            UseFirstItemButton = controlButtons.ControlButtons.PlayerControlButtons.InventoryControlButtons.UseFirstItemButton;
            UseSecondItemButton = controlButtons.ControlButtons.PlayerControlButtons.InventoryControlButtons.UseSecondItemButton;
            UseThirdItemButton = controlButtons.ControlButtons.PlayerControlButtons.InventoryControlButtons.UseThirdItemButton;
        }
        
        private void Start()
        {
            _isInputBlock = false;

            _inventory.UpdateInventoryEvent += InventoryUpdateUI;
            _inputBlockerService.AddHandler(this);
            
            InventoryUpdateUI();
        }

        private void OnDestroy()
        {
            _inventory.UpdateInventoryEvent -= InventoryUpdateUI;

            _inputBlockerService.RemoveHandler(this);
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
            if (_isInputBlock)
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

        public void BlockInput()
        {
            _isInputBlock = true;
        }

        public void UnBlockInput()
        {
            _isInputBlock = false;
        }
    }
}