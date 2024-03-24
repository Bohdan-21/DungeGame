using Scripts.SaveData.SettingsData;
using Scripts.Services.AudioService;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scripts.Services.SettingsService
{
    public class SettingsServiceHandler : ISettingsServiceHandler
    {
        private List<ISettingService> _settingServices = new List<ISettingService>();

        public SettingsData SettingsData { get; set; }

        public void AddService(ISettingService service)
        {
            _settingServices.Add(service);
        }

        public void RemoveService(ISettingService service)
        {
            _settingServices.Remove(service);
        }

        public void AllertAllUpdateSettings()
        {
            foreach (ISettingService service in _settingServices)
            {
                service.UpdateSettings(SettingsData);
            }
        }

        public void AllertAllLoadSettings()
        {
            foreach (ISettingService service in _settingServices)
            {
                service.LoadSettings(SettingsData);
            }
        }
    }
}
