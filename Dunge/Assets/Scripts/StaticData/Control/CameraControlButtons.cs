using System;
using UnityEngine;

namespace Scripts.StaticData.Control
{
    [Serializable]
    public class CameraControlButtons
    {
        public KeyCode RotateToLeftButton;
        public KeyCode RotateToRightButton;

        public KeyCode ZoomInButton;
        public KeyCode ZoomOutButton;
    }
}
