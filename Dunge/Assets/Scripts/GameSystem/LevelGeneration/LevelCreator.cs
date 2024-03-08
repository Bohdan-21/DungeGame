using Scripts.GameSystem.LevelGeneration.Baker;
using Scripts.GameSystem.LevelGeneration.Generation;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scripts.Infrastructure.Bootstrapper
{
    public class LevelCreator : MonoBehaviour
    {
        public LevelGeneretion levelGeneretion;
        public LevelBaker levelBaker;

        private void Start()
        {
            DelayGenerationLevel();
        }

        private void DelayGenerationLevel()
        {
            Debug.Log("Start Generate Level");

            StartCoroutine(levelGeneretion.GenerateLevel());

            Debug.Log("End Generate Level");

            Debug.Log("Start Bake Level");

            levelBaker.BakeLevel();

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