using System;
using UnityEngine;

namespace Scripts.SaveData.SettingsData.ControlButton
{
    [Serializable]
    public class AnotherControlButtons
    {
        public KeyCode InteractButton;

        public AnotherControlButtons()
        {
            InteractButton = KeyCode.None;
        }

        public AnotherControlButtons(AnotherControlButtons anotherControlButtons)
        {
            InteractButton = anotherControlButtons.InteractButton;
        }
    }
}