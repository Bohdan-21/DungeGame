using Scripts.Enemy;
using Scripts.NPC.Spawn;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.GameSystem.LevelGeneration.DataChunk
{
    public class ChunkData : MonoBehaviour
    {
        public Transform RootPoint;

        public List<ConnectionPoint> connectionPoints;

        public List<EnemySpawnPoint> EnemySpawnPoints;

        public List<NPCSpawnPoint> NPCSpawnPoints;

        private List<GameObject> _createdCharacter = new List<GameObject>();

        public void Show()
        {
            if (gameObject.activeSelf)
                return;

            SetActiveForCreatedCharacter(true);

            gameObject.SetActive(true);
        }

        public void Hide()
        {
            if (!gameObject.activeSelf)
                return;

            SetActiveForCreatedCharacter(false);

            gameObject.SetActive(false);
        }

        public void AddCreatedCharacter(GameObject character)
        {
            _createdCharacter.Add(character);
        }

        private void SetActiveForCreatedCharacter(bool isActive)
        {
            foreach (GameObject character in _createdCharacter)
                character.SetActive(isActive);
        }
    }
}   