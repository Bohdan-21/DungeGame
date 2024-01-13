using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Scripts.StaticData.SystemConfigData.ControlButton
{
    [CreateAssetMenu(fileName = "ControlButtons", menuName = "StaticData/SystemConfigData/ControlButtons")]
    [Serializable]
    public class ControlButtons : ScriptableObject
    {
        public PlayerControlButtons PlayerControlButtons;

        public CameraControlButtons CameraControlButtons;

        public SystemControlButtons SystemControlButtons;

        public KeyCode TradeButton;
    }
}
