using Scripts.GameSystem.LevelGeneration.Baker;
using Scripts.GameSystem.LevelGeneration.Generation;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scripts.GameSystem.LevelGeneration
{
    public class LevelCreator : MonoBehaviour, ILevelCreator
    {
        public LevelGeneretion levelGeneretion;
        public LevelBaker levelBaker;

        public event Action CompleteCreateLevelEvent;

        public void CreateLevel()
        {
            StartCoroutine(DelayCreateLevel());
        }

        private IEnumerator DelayCreateLevel()
        {
            Debug.Log("Start Generate Level");

            yield return levelGeneretion.GenerateLevel();

            Debug.Log("End Generate Level");

            Debug.Log("Start Bake Level");

            levelBaker.BakeLevel();

            Debug.Log("End Bake Level");

            CompleteCreateLevelEvent?.Invoke();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}