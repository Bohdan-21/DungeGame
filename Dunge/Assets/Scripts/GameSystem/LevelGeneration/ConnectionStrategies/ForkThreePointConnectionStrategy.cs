using Scripts.GameSystem.LevelGeneration.Level;

namespace Scripts.GameSystem.LevelGeneration.ConnectionStrategies
{
    public class ForkThreePointConnectionStrategy : ConnectionStrategy
    {
        public ForkThreePointConnectionStrategy()
        {
            TypeChunkConnection = DataChunk.TypeChunkConnection.ForkConnectionThreePoint;
        }

        public override bool CanConnect(TypeConnectionForCell typeConnectionForCell)
        {
            if (typeConnectionForCell.NeedConnectCount == 2)
                return true;
            else if (typeConnectionForCell.NeedConnectCount == 1)
            {
                if (typeConnectionForCell.MaxConnectCount == 2 || typeConnectionForCell.MaxConnectCount == 3)
                    return true;
            }
            else if (typeConnectionForCell.NeedConnectCount == 0)
            {
                if (typeConnectionForCell.MaxConnectCount == 2 || typeConnectionForCell.MaxConnectCount == 3)
                    return true;
            }

            return false;
        }
    }
}
