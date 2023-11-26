using Scripts.GameSystem.SkillTreeSystem.Logic;
using Scripts.GameSystem.SkillTreeSystem.UI.Spawner;
using System;
using UnityEngine;

namespace Scripts.GameSystem.SkillTreeSystem.UI
{
    public class SkillTreeUI : MonoBehaviour
    {
        public SkillTreeHandler _skillTreeData;
        public KeyCode keyCode;

        [SerializeField] private GameObject RootComponentSkillTreeUI;
        [SerializeField] private PointDisplayer _pointDisplayer;
        [SerializeField] private SkillSpawner _skillSpawner;
        [SerializeField] private AttributeSpawner _attributeSpawner;

        private bool _isShow = true;

        private void Start()
        {
            _skillTreeData = SkillTreeHandler.Instance;
            Hide();
        }

        public void Update()
        {
            if (Input.GetKeyDown(keyCode))
            {
                if (_isShow)
                    Hide();
                else
                    Show();
            }
        }


        private void Show()
        {
            _isShow = true;

            RootComponentSkillTreeUI.SetActive(_isShow);

            _pointDisplayer.ShowSkillPoint(_skillTreeData.GetCountSkillPoint(), _skillTreeData.GetCountAttributePoint());

            _skillSpawner.SpawnSkillCards(_skillTreeData, RefreshUI);
            _attributeSpawner.SpawnAttributeCards(_skillTreeData, RefreshUI);
        }

        private void Hide()
        {
            _isShow = false;

            RootComponentSkillTreeUI.SetActive(_isShow);

            _skillSpawner.ClearAll();
            _attributeSpawner.ClearAll();
        }

        private void RefreshUI()
        {
            Hide();
            Show();
        }
    }
}