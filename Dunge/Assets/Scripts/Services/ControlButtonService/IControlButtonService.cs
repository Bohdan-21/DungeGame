using Scripts.SaveData.SettingsData.ControlButton;

namespace Scripts.Services.ControlButtonService
{
    public interface IControlButtonService
    {
        ControlButtonsData ControlButtons { get; }
    }
}