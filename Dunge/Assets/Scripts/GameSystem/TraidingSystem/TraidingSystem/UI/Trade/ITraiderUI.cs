using Scripts.GameSystem.TraidingSystem.TraidingSystem.Handler;

namespace Scripts.GameSystem.TraidingSystem.TraidingSystem.UI.Trade
{
    public interface ITraiderUI
    {
        void Hide();
        void Show(ITradingHandler buyer, ITradingHandler salesman);
    }
}