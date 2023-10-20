using System.Collections.Generic;

namespace Scripts.Services.InteruptService
{
    public interface IInteruptService
    {
        void AddInteruptHandler(IInteruptHandler handler);
        void RemoveInteruptHandler(IInteruptHandler handler);

        void Continue();
        void Pause();
    }
}