using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using Scripts.GameSystem.SkillTreeSystem.Type;
using Scripts.SaveData.SkillTree;
using Scripts.GameSystem.SkillTreeSystem.Handler;

namespace Scripts.GameSystem.SkillTreeSystem.UI.Card
{
    public class SkillCard : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI SkillName;
        [SerializeField] private TextMeshProUGUI SkillLevel;
        [SerializeField] private Button SkillLevelUpButton;

        private SkillType _skillType;
        private PlayerSkillTreeHandler _skillTreeData;
        private Action _refreshEvent;

        public void Initialize(SkillData skillData, string localizationText, PlayerSkillTreeHandler skillTreeData, Action refreshEvent)
        {
            _skillType = skillData.GetSkillType();
            _skillTreeData = skillTreeData;
            _refreshEvent = refreshEvent;

            SkillName.text = localizationText;
            SkillLevel.text = skillData.GetSkillLevel().ToString();

            SkillLevelUpButton.interactable = _skillTreeData.CanUpgrateSkill(_skillType);
        }

        public void ClickLevelUp()
        {
            Debug.Log("Click to up level for skill:" + _skillType.ToString().ToUpper());

            _skillTreeData.UpgrateSkill(_skillType);

            _refreshEvent.Invoke();
        }
    }
}