using Scripts.LanguageLocalization;
using Scripts.Services.AudioService.SoundService;
using Scripts.Services.LanguageService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.LanguageLocalization
{
    class LanguageSelector : MonoBehaviour
    {
        private ILanguageService _languageSettings;
        private ISoundsButtonActionPlayer _soundsButtonActionPlayer;

        [Inject]
        private void Construct(ILanguageService languageSettings, ISoundsButtonActionPlayer soundsButtonActionPlayer)
        {
            _languageSettings = languageSettings;
            _soundsButtonActionPlayer = soundsButtonActionPlayer;
        }

        public void UpdateLanguage(string language)
        {
            if (language == Language.RU.ToString())
                _languageSettings.UpdateLanguage(Language.RU);
            else if (language == Language.ENG.ToString())
                _languageSettings.UpdateLanguage(Language.ENG);
            PlaySoundButtonPress();
        }

        private void PlaySoundButtonPress() =>
            _soundsButtonActionPlayer.PlayButtonPressSound();
    }
}
