using System;
using UnityEngine;

namespace Scripts.SaveData.SettingsData.ControlButton
{
    [Serializable]
    public class CameraControlButtons
    {
        public KeyCode RotateToLeftButton;
        public KeyCode RotateToRightButton;

        public KeyCode ZoomInButton;
        public KeyCode ZoomOutButton;

        public CameraControlButtons()
        {
            RotateToLeftButton = RotateToRightButton = ZoomInButton = ZoomOutButton = KeyCode.None;
        }

        public CameraControlButtons(CameraControlButtons cameraControlButtons)
        {
            RotateToLeftButton = cameraControlButtons.RotateToLeftButton;
            RotateToRightButton = cameraControlButtons.RotateToRightButton;
            ZoomInButton = cameraControlButtons.ZoomInButton;
            ZoomOutButton = cameraControlButtons.ZoomOutButton;
        }
    }
}
