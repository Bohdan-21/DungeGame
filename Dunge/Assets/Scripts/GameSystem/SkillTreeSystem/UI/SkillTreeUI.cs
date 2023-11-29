using Scripts.GameSystem.SkillTreeSystem.Handler;
using Scripts.GameSystem.SkillTreeSystem.UI.Spawner;
using Scripts.Player;
using System;
using UnityEngine;
using Zenject;

namespace Scripts.GameSystem.SkillTreeSystem.UI
{
    public class SkillTreeUI : MonoBehaviour
    {
        public KeyCode keyCode;

        [SerializeField] private PlayerSkillTreeHandler _skillTreeHandler;

        [SerializeField] private GameObject RootComponentSkillTreeUI;
        [SerializeField] private PointDisplayer _pointDisplayer;
        [SerializeField] private SkillSpawner _skillSpawner;
        [SerializeField] private AttributeSpawner _attributeSpawner;

        private bool _isShow = true;

        [Inject]
        private void Construct(PlayerBehaviour playerBehaviour)
        {
            _skillTreeHandler = playerBehaviour.SkillTreeHandler;
        }

        private void Start()
        {
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

            _pointDisplayer.ShowSkillPoint(_skillTreeHandler.GetCountSkillPoint(), _skillTreeHandler.GetCountAttributePoint());

            _skillSpawner.SpawnSkillCards(_skillTreeHandler, RefreshUI);
            _attributeSpawner.SpawnAttributeCards(_skillTreeHandler, RefreshUI);
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