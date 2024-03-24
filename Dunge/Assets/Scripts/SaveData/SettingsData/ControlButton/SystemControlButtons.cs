using System;
using UnityEngine;

namespace Scripts.SaveData.SettingsData.ControlButton
{
    [Serializable]
    public class SystemControlButtons
    {
        public KeyCode PauseButton;

        public SystemControlButtons()
        {
            PauseButton = KeyCode.None;
        }

        public SystemControlButtons(SystemControlButtons systemControlButtons)
        {
            PauseButton = systemControlButtons.PauseButton;
        }
    }
}
