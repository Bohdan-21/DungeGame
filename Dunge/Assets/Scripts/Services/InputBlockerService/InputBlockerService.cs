using System.Collections.Generic;

namespace Scripts.Services.InputBlockerService
{
    /// <summary>
    /// blocking subscribe component when open Inventory or another panel
    /// not to be confused with permanent blocking as in pause
    /// </summary>
    public class InputBlockerService : IInputBlockerService
    {
        private List<IInputBlockerHandler> _blockerHandlers = new List<IInputBlockerHandler>();
        private bool _isInputBlock = false;

        public void AddHandler(IInputBlockerHandler blockerHandler)
        {
            _blockerHandlers.Add(blockerHandler);
        }

        public void RemoveHandler(IInputBlockerHandler blockerHandler)
        {
            _blockerHandlers.Remove(blockerHandler);
        }

        public void BlockAllInput()
        {
            if (_isInputBlock)
                return;

            foreach (IInputBlockerHandler blockerHandler in _blockerHandlers)
                blockerHandler.BlockInput();
            _isInputBlock = true;
        }

        public void UnBlockAllInput()
        {
            if (_isInputBlock)
            {
                foreach (IInputBlockerHandler blockerHandler in _blockerHandlers)
                    blockerHandler.UnBlockInput();
                _isInputBlock = false;
            }
        }
    }
}
