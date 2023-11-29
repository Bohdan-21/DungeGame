using System;

namespace Scripts.SaveData.Experience
{
    [Serializable]
    public class PlayerExperienceData
    {
        public int currentLevel;
        public int currentExp;
        public int expNeedForLevelUp;
        public float numberForMultiplyForUpdateExpNeedForLevelUp;

        public PlayerExperienceData()
        {
            currentLevel = currentExp = expNeedForLevelUp = 0;
            numberForMultiplyForUpdateExpNeedForLevelUp = 0;
        }

        public PlayerExperienceData(PlayerExperienceData experienceData)
        {
            currentLevel = experienceData.currentLevel;
            currentExp = experienceData.currentExp;
            expNeedForLevelUp = experienceData.expNeedForLevelUp;
            numberForMultiplyForUpdateExpNeedForLevelUp = experienceData.numberForMultiplyForUpdateExpNeedForLevelUp;
        }
    }
}
