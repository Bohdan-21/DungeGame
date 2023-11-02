using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Scripts.StaticData.ControlButton
{
    [CreateAssetMenu(fileName = "ControlButtons", menuName = "StaticData/ControlButtons")]
    [Serializable]
    public class ControlButtons : ScriptableObject
    {
        public PlayerControlButtons PlayerControlButtons;

        public CameraControlButtons CameraControlButtons;

        public SystemControlButtons SystemControlButtons;
    }
}
