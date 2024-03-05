using Scripts.GameSystem.LevelGeneration.Level;

namespace Scripts.GameSystem.LevelGeneration.ConnectionStrategies
{
    public class ForkFourPointConnectionStrategy : ConnectionStrategy
    {
        public override bool CanConnect(TypeConnectionForCell typeConnectionForCell)
        {
            if (typeConnectionForCell.NeedConnectCount == 3)
                return true;
            else if (typeConnectionForCell.NeedConnectCount == 2 || typeConnectionForCell.NeedConnectCount == 1 ||
                     typeConnectionForCell.NeedConnectCount == 0)
            {
                if (typeConnectionForCell.MaxConnectCount == 3)
                    return true;
            }
            return false;
        }
    }
}
