using Scripts.GameSystem.LevelGeneration.Level;

namespace Scripts.GameSystem.LevelGeneration.ConnectionStrategies
{
    public class DeadEndConnectionStrategy : ConnectionStrategy
    {
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
