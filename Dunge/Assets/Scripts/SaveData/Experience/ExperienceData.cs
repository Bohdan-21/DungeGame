using System;

namespace Scripts.SaveData.Experience
{
    [Serializable]
    public class ExperienceData
    {
        public int currentLevel;
        public int currentExp;
        public int expNeedForLevelUp;
        public float numberForMultiplyForUpdateExpNeedForLevelUp;

        public ExperienceData()
        {
            currentLevel = currentExp = expNeedForLevelUp = 0;
            numberForMultiplyForUpdateExpNeedForLevelUp = 0;
        }

        public ExperienceData(ExperienceData experienceData)
        {
            currentLevel = experienceData.currentLevel;
            currentExp = experienceData.currentExp;
            expNeedForLevelUp = experienceData.expNeedForLevelUp;
            numberForMultiplyForUpdateExpNeedForLevelUp = experienceData.numberForMultiplyForUpdateExpNeedForLevelUp;
        }
    }
}
