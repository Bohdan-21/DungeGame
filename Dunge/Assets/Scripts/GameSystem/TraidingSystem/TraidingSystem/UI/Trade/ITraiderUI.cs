using Scripts.GameSystem.TraidingSystem.TraidingSystem.Handler;
using Scripts.UI.GameUI.UIHandler;

namespace Scripts.GameSystem.TraidingSystem.TraidingSystem.UI.Trade
{
    public interface ITraiderUI : UIMarker
    {
        void Hide();
        void Show(ITradingHandler buyer, ITradingHandler salesman);
    }
}