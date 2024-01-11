using Scripts.GameSystem.TraidingSystem.BalanceSubsystem.Handler;
using Scripts.SaveData.Storage;

namespace Scripts.GameSystem.TraidingSystem.TraidingSystem.Handler
{
    public interface ITradingHandler
    {
        StorageHandler GetStorage();

        Balance GetBalance();
    }
}