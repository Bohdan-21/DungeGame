using System;
using UnityEngine;

namespace Scripts.GameSystem.LevelGeneration.DataChunk
{
    [Serializable]
    public class ConnectionPoint : MonoBehaviour
    {
        public bool IsPointConnect;
        public Transform PointForConnect;

        private void OnValidate()
        {
            PointForConnect = gameObject.transform;
            IsPointConnect = false;
        }
    }
}
