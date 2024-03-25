namespace Scripts.Services.InputBlockerService
{
    public interface IInputBlockerService
    {
        void AddHandler(IInputBlockerHandler blockerHandler);
        void RemoveHandler(IInputBlockerHandler blockerHandler);
        
        void BlockAllInput();
        void UnBlockAllInput();
    }
}