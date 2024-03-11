using Scripts.GameSystem.LevelGeneration.Level;

namespace Scripts.GameSystem.LevelGeneration.ConnectionStrategies
{
    public class ForwardConnectionStrategy : ConnectionStrategy
    {
        public ForwardConnectionStrategy()
        {
            TypeChunkConnection = DataChunk.TypeChunkConnection.ForwardConnection;
        }

        public override bool CanConnect(TypeConnectionForCell typeConnectionForCell)
        {
            if (typeConnectionForCell.NeedConnectCount == 1 && IsNeedConnect(typeConnectionForCell.ForwardConnection))
                return true;
            else if (typeConnectionForCell.NeedConnectCount == 0)
            {
                if (typeConnectionForCell.MaxConnectCount == 1 || typeConnectionForCell.MaxConnectCount == 2)
                {
                    if (IsFreeConnect(typeConnectionForCell.ForwardConnection))
                        return true;
                }
                else if (typeConnectionForCell.MaxConnectCount == 3)
                    return true;
            }
            return false;
        }
    }
}
