using Scripts.GameSystem.LevelGeneration.Grid;

namespace Scripts.GameSystem.LevelGeneration.ConnectionStrategies
{
    public class DeadEndConnectionStrategy : ConnectionStrategy
    {
        public DeadEndConnectionStrategy()
        {
            TypeChunkConnection = DataChunk.TypeChunkConnection.DeadEndConnection;
        }

        public override bool CanConnect(TypeConnectionForCell typeConnectionForCell)
        {
            if (typeConnectionForCell.NeedConnectCount == 0)
                return true;
            if (typeConnectionForCell.MaxConnectCount == 0)
                return true;
            return false;
        }
    }
}
