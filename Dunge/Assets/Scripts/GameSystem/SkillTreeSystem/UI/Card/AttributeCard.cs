using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using Scripts.GameSystem.SkillTreeSystem.Type;
using Scripts.GameSystem.SkillTreeSystem.Logic;
using Scripts.GameSystem.SkillTreeSystem.Data;

namespace Scripts.GameSystem.SkillTreeSystem.UI.Card
{
    public class AttributeCard : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI AttributeName;
        [SerializeField] private TextMeshProUGUI AttributeBaseSkillName;
        [SerializeField] private TextMeshProUGUI AttributeLevel;
        [SerializeField] private Button AttributeLevelUpButton;

        private AttributeType _attributeType;
        private SkillTreeHandler _skillTreeData;
        private Action _refreshEvent;

        public void Initialize(AttributeData attributeData, SkillTreeHandler skillTreeData, Action refreshEvent)
        {
            _attributeType = attributeData.GetAttributeType();
            _skillTreeData = skillTreeData;
            _refreshEvent = refreshEvent;

            AttributeName.text = attributeData.GetAttributeType().ToString();
            AttributeBaseSkillName.text = attributeData.GetBaseSkillType().ToString();
            AttributeLevel.text = attributeData.GetAttributeLevel().ToString();

            AttributeLevelUpButton.interactable = _skillTreeData.CanUpgrateAttribute(_attributeType);
        }

        public void ClickLevelUp()
        {
            Debug.Log("Click to up level for attribute:" + _attributeType.ToString().ToUpper());

            _skillTreeData.UpgrateAttribute(_attributeType);

            _refreshEvent.Invoke();
        }
    }
}