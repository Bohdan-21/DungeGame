using Scripts.Services.AudioService.SoundService;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Scripts.UI.License
{
    public class LicenseUI : MonoBehaviour, ILicenseUI
    {
        private ISoundsButtonActionPlayer _soundPlayer;

        [Inject]
        private void Construct(ISoundsButtonActionPlayer soundPlayer)
        {
            _soundPlayer = soundPlayer;
        }

        private void Start()
        {
            gameObject.SetActive(false);
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);

            _soundPlayer.PlayButtonPressSound();
        }
    }
}