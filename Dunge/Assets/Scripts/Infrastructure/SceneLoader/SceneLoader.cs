using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UnityEngine.SceneManagement;
using Scripts.UI.Curtain;

namespace Scripts.Infrastructure.SceneLoader
{
    public class SceneLoader : MonoBehaviour, ISceneLoader
    {
        private const float WaitingTime = 0.5f;

        private ICurtain _curtain;

        [Inject]
        private void Construct(ICurtain curtain)
        {
            _curtain = curtain;
        }

        public void LoadScene(string sceneName, Action OnLoaded = null)
        {
            StartCoroutine(LoadSceneAsync(sceneName, OnLoaded));
        }

        private IEnumerator LoadSceneAsync(string sceneName, Action onLoaded = null)
        {
            _curtain.Show();

            yield return new WaitForSeconds(WaitingTime);

            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);

            while (!asyncOperation.isDone)
                yield return null;

            onLoaded?.Invoke();

            yield return new WaitForSeconds(WaitingTime);
        }
    }
}