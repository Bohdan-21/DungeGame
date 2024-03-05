using Scripts.GameSystem.LevelGeneration.DataChunk;
using Scripts.GameSystem.LevelGeneration.Level;
using UnityEngine;

namespace Scripts.GameSystem.LevelGeneration.ConnectionStrategies
{
    public abstract class ConnectionStrategy : MonoBehaviour
    {
        public TypeChunkConnection TypeChunkConnection;

        public abstract bool CanConnect(TypeConnectionForCell typeConnectionForCell);

        protected bool IsLockedConnect(TypeConnection typeConnection) =>
            typeConnection == TypeConnection.LockedForConnect;

        protected bool IsNeedConnect(TypeConnection typeConnection) =>
            typeConnection == TypeConnection.NeededForConnect;

        protected bool IsFreeConnect(TypeConnection typeConnection) =>
            typeConnection == TypeConnection.FreeForConnect;
    }
}
