using System;
using UnityEngine;

namespace Scripts.GameSystem.LevelGeneration.DataChunk
{
    [Serializable]
    public class ConnectionPoint
    {
        public bool isPointConnect;
        public Transform pointForConnect;
    }
}
