using Scripts.Enemy;
using Scripts.GameSystem.LevelGeneration.Level;
using Scripts.NPC.Spawn;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.GameSystem.LevelGeneration.Settings
{
    public class LevelSettings : MonoBehaviour
    {
        public Transform PlayerSpawnPoint;

        public LevelGrid levelGrid;
    }
}