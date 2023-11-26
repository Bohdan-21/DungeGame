using System;
using UnityEngine;

namespace Scripts.GameSystem.ExperienceSystem.Player
{

    public class PlayerExperience : MonoBehaviour
    {
        public static PlayerExperience Instance;

        public event Action PlayerLevelUpEvent;

        public int currentLevel = 0;
        public int currentExp = 0;
        public int expNeedForLevelUp = 600;
        public float numberForMultiplyForUpdateExpNeedForLevelUp = 3;

        private void Awake()
        {
            Instance = this;
        }

        public void AddExperience(int experience)
        {
            int maxAddedExperience = HowMuchExperienceCanAdd(experience);

            if (experience == maxAddedExperience)
                currentExp += experience;
            else
            {
                experience -= maxAddedExperience;

                currentExp += maxAddedExperience;

                UpLevel();

                AddExperience(experience);
            }
        }

        private int HowMuchExperienceCanAdd(int experience)
        {
            if (currentExp + experience >= expNeedForLevelUp)
            {
                return expNeedForLevelUp - currentExp;
            }
            else
                return experience;
        }

        private void UpLevel()
        {
            currentLevel++;
            currentExp = 0;
            expNeedForLevelUp = (int)(expNeedForLevelUp * numberForMultiplyForUpdateExpNeedForLevelUp);
            Debug.Log("Level up");
            PlayerLevelUpEvent?.Invoke();
        }
    }
}
