using UnityEngine;
using Zenject;
using TMPro;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using Scripts.LanguageLocalization.Service;

namespace Scripts.UI.NameLocation
{
    public class NameLocationUI : MonoBehaviour, INameLocationUI
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private TextMeshProUGUI _nameLocationText;
        
        private ILanguageSettings _languageSettings;

        [Inject]
        private void Construct(ILanguageSettings languageSettings)
        {
            _languageSettings = languageSettings;
        }

        public void ShowNameLocation()
        {
            SetActiveForRootComponent(true);

            _canvasGroup.alpha = 0;

            _nameLocationText.text = SceneManager.GetActiveScene().name;

            StartCoroutine(DelayShow());
        }

        private IEnumerator DelayShow()
        {
            yield return new WaitForSeconds(2);

            while (_canvasGroup.alpha < 1)
            {
                _canvasGroup.alpha += 0.05f;
                yield return new WaitForSeconds(0.03f);
            }

            yield return new WaitForSeconds(0.5f);

            yield return DelayHide();
        }

        private IEnumerator DelayHide()
        {
            while (_canvasGroup.alpha > 0)
            {
                _canvasGroup.alpha -= 0.05f;
                yield return new WaitForSeconds(0.03f);
            }

            SetActiveForRootComponent(false);
        }

        private void SetActiveForRootComponent(bool active) => 
            _canvasGroup.gameObject.SetActive(active);
    }
}