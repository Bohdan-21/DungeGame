using System;
using UnityEngine;

namespace Scripts.SaveData.SettingsData.ControlButton
{
    [Serializable]
    public class InventoryControlButtons
    {
        public KeyCode UseFirstItemButton;
        public KeyCode UseSecondItemButton;
        public KeyCode UseThirdItemButton;

        public InventoryControlButtons()
        {
            UseFirstItemButton = UseSecondItemButton = UseThirdItemButton = KeyCode.None;
        }

        public InventoryControlButtons(InventoryControlButtons inventoryControlButtons)
        {
            UseFirstItemButton = inventoryControlButtons.UseFirstItemButton;
            UseSecondItemButton = inventoryControlButtons.UseSecondItemButton;
            UseThirdItemButton = inventoryControlButtons.UseThirdItemButton;
        }
    }
}
