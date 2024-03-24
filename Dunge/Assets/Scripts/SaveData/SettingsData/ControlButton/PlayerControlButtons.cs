using System;

namespace Scripts.SaveData.SettingsData.ControlButton
{
    [Serializable]
    public class PlayerControlButtons
    {
        public AttackControlButtons AttackControlButtons;

        public InventoryControlButtons InventoryControlButtons;

        public AnotherControlButtons AnotherControlButtons;

        public PlayerControlButtons()
        {
            AttackControlButtons = new AttackControlButtons();
            InventoryControlButtons = new InventoryControlButtons();
            AnotherControlButtons = new AnotherControlButtons();
        }

        public PlayerControlButtons(PlayerControlButtons playerControlButtons)
        {
            AttackControlButtons = new AttackControlButtons(playerControlButtons.AttackControlButtons);
            InventoryControlButtons = new InventoryControlButtons(playerControlButtons.InventoryControlButtons);
            AnotherControlButtons = new AnotherControlButtons(playerControlButtons.AnotherControlButtons);
        }
    }
}
