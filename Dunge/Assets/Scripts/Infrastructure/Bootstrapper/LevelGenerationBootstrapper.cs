using Scripts.GameSystem.LevelGeneration.Baker;
using Scripts.GameSystem.LevelGeneration.Generation;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scripts.Infrastructure.Bootstrapper
{
    public class LevelGenerationBootstrapper : MonoBehaviour
    {
        public float TimeBeforeStartGenerateLevel = 3f;

        public LevelGeneretion levelGeneretion;
        public LevelBaker levelBaker;

        private void Start()
        {
            StartCoroutine(DelayGenerationLevel());
        }

        private IEnumerator DelayGenerationLevel()
        {
            yield return new WaitForSeconds(TimeBeforeStartGenerateLevel);

            Debug.Log("Start Generate Level");

            yield return levelGeneretion.GenerateLevel();

            Debug.Log("End Generate Level");

            Debug.Log("Start Bake Level");

            yield return levelBaker.BakeLevel();

            Debug.Log("End Bake Level");
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