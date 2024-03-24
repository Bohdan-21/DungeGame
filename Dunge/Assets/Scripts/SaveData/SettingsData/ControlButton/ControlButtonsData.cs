using System;
using UnityEngine;

namespace Scripts.SaveData.SettingsData.ControlButton
{
    [Serializable]
    public class ControlButtonsData
    {
        public PlayerControlButtons PlayerControlButtons;

        public CameraControlButtons CameraControlButtons;

        public SystemControlButtons SystemControlButtons;

        public KeyCode TradeButton;

        public ControlButtonsData()
        {
            PlayerControlButtons = new PlayerControlButtons();
            CameraControlButtons = new CameraControlButtons();
            SystemControlButtons = new SystemControlButtons();
            TradeButton = KeyCode.None;
        }

        public ControlButtonsData(ControlButtonsData controlButtons)
        {
            PlayerControlButtons = new PlayerControlButtons(controlButtons.PlayerControlButtons);
            CameraControlButtons = new CameraControlButtons(controlButtons.CameraControlButtons);
            SystemControlButtons = new SystemControlButtons(controlButtons.SystemControlButtons);
            TradeButton = controlButtons.TradeButton;
        }
    }
}
