using Scripts.GameSystem.TraidingSystem.BalanceSubsystem.Handler;
using Scripts.SaveData.StorageData;

namespace Scripts.GameSystem.TraidingSystem.TraidingSystem.Handler
{
    public interface ITradingHandler
    {
        Storage GetStorage();

        Balance GetBalance();
    }
}