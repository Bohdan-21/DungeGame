using UnityEngine;

namespace Scripts.StaticData.GameStaticData
{
    [CreateAssetMenu(fileName = "GameStaticData", menuName = "StaticData/GameStaticData")]
    public class GameStaticData : ScriptableObject
    {
        public GameObject GUI;

        public GameObject DeathUI;

        public GameObject GamePause;

        public GameObject GameCamera;

        public GameObject PlayerPrefab;

        public GameObject DeathVFX;

        public GameObject SkillTreeUI;

        public GameObject PlayerStatsUI;

        public GameObject PlayerExperienceTrackerUI;
    }
}
