using System;
using UnityEngine;

namespace Scripts.SaveData.SettingsData.ControlButton
{
    [Serializable]
    public class AttackControlButtons
    {
        public KeyCode AttackButton;

        public AttackControlButtons()
        {
            AttackButton = KeyCode.None;
        }

        public AttackControlButtons(AttackControlButtons attackControlButtons)
        {
            AttackButton = attackControlButtons.AttackButton;
        }
    }
}
