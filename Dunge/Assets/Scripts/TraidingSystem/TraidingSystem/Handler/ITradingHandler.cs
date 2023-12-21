using Scripts.SaveData.Storage;
using Scripts.TraidingSystem.BalanceSubsystem;

namespace Scripts.GameSystem.TraidingSystem.TraidingSystem.Handler
{
    public interface ITradingHandler
    {
        Storage GetStorage();

        Balance GetBalance();
    }
}