using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Scripts.Services.InteruptService
{
    public class InteruptService : IInteruptService
    {
        private List<IInteruptHandler> _interuptHandlers = new List<IInteruptHandler>();

        public void AddInteruptHandler(IInteruptHandler handler) =>
            _interuptHandlers.Add(handler);

        public void RemoveInteruptHandler(IInteruptHandler handler) =>
            _interuptHandlers.Remove(handler);

        public void Continue()
        {
            Time.timeScale = 1;

            foreach (IInteruptHandler handler in _interuptHandlers)
                handler.Continue();
        }

        public void Pause()
        {
            Time.timeScale = 0;

            foreach (IInteruptHandler handler in _interuptHandlers)
                handler.Interupt();
        }
    }
}
