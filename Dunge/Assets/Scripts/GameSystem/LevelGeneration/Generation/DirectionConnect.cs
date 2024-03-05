using UnityEngine;

namespace Scripts.GameSystem.LevelGeneration.Generation
{
    public class DirectionConnect
    {
        public bool IsConnected;
        public Vector3 Direction;

        public DirectionConnect(bool isConnected, Vector3 direction)
        {
            IsConnected = isConnected;
            Direction = direction;
        }
    }
}