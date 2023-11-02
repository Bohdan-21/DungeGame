using Scripts.GameMechanic.Item;
using Scripts.Services.InputService;
using Scripts.Services.InteruptService;
using Scripts.StaticData.ControlButton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Scripts.Player
{
    class PlayerInventoryUI : MonoBehaviour, IInteruptHandler
    {
        private KeyCode UseFirstItemButton;
        private KeyCode UseSecondItemButton;
        private KeyCode UseThirdItemButton;

        private const string NameSmallHealth = "SMALL";
        private const string NameMiddleHealth = "MIDDLE";
        private const string NameLargeHealth = "LARGE";
        
        public List<ItemUpdater> ItemUpdaters;
        
        private PlayerInventory Inventory;
        private IInputService _inputService;
        private IInteruptService _interuptService;

        private bool _isInterupt;
        
        [Inject]
        private void Construct(PlayerBehaviour player, IInputService inputService, IInteruptService interuptService,
                               ControlButtons controlButtons)
        {
            Inventory = player.Inventory;
            _inputService = inputService;
            _interuptService = interuptService;

            UseFirstItemButton = controlButtons.PlayerControlButtons.InventoryControlButtons.UseFirstItemButton;
            UseSecondItemButton = controlButtons.PlayerControlButtons.InventoryControlButtons.UseSecondItemButton;
            UseThirdItemButton = controlButtons.PlayerControlButtons.InventoryControlButtons.UseThirdItemButton;
        }
        
        private void Start()
        {
            _isInterupt = false;

            Inventory.UpdateInventory += InventoryUpdateUI;
            _interuptService.AddInteruptHandler(this);

            InventoryUpdateUI();
        }

        private void OnDestroy()
        {
            Inventory.UpdateInventory -= InventoryUpdateUI;

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

            if (value == TypeItem.SMALL.ToString())
                Inventory.Use(TypeItem.SMALL);
            else if (value == TypeItem.MIDDLE.ToString()) 
                Inventory.Use(TypeItem.MIDDLE);
            else if (value == TypeItem.LARGE.ToString())
                Inventory.Use(TypeItem.LARGE);
        }

        private void InventoryUpdateUI()
        {
            foreach(ItemUpdater itemUpdater in ItemUpdaters)
                itemUpdater.UpdateCount(Inventory.GetCount(itemUpdater.TypeItem));
        }

        public void Interupt() =>
            _isInterupt = true;

        public void Continue() =>
            _isInterupt = false;
    }

}
