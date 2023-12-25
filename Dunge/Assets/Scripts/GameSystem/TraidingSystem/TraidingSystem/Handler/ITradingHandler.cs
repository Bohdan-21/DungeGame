using Scripts.GameSystem.TraidingSystem.BalanceSubsystem;
using Scripts.SaveData.Storage;

namespace Scripts.GameSystem.TraidingSystem.TraidingSystem.Handler
{
    public interface ITradingHandler
    {
        Storage GetStorage();

        Balance GetBalance();
    }
}