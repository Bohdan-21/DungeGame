using UnityEngine;
using Scripts.Services.PlayerProgressService;
using Scripts.Infrastructure.StateMachine;
using Scripts.StaticData.SystemConfigData;
using Zenject;
using Scripts.Services.InputBlockerService;

namespace Scripts.UI.TeleportingUI
{
    class TeleportingMenu : MonoBehaviour, ITeleportingMenu
    {
		private IPlayerProgressService _progressService;
		private GameStateMachine _gameStateMachine;		
		private ProjectGlobalSettings _projectGlobalSettings;
        private IInputBlockerService _inputBlockerService;

        [Inject]
		private void Construct(GameStateMachine gameStateMachine, IPlayerProgressService progressService, 
							   ProjectGlobalSettings projectGlobalSettings, IInputBlockerService inputBlockerService)
		{
			_progressService = progressService;
			_gameStateMachine = gameStateMachine;
			_projectGlobalSettings = projectGlobalSettings;
			_inputBlockerService = inputBlockerService;
		}
		
		public void Start()
		{
			HideMenu();
		}
		
        public void ShowMenu()
        {
			_inputBlockerService.BlockAllInput();
            this.gameObject.SetActive(true);
        }

        public void HideMenu()
        {
			_inputBlockerService.UnBlockAllInput();
			this.gameObject.SetActive(false);
        }

        public void GoToVillage()
        {
			_inputBlockerService.UnBlockAllInput();
			_progressService.PlayerProgress.LevelData.NextLoadRoom = _projectGlobalSettings.StartRoom;
			_gameStateMachine.Enter<ReloadLevelState>();
        }

        public void GoToNextLevel()
        {
			_inputBlockerService.UnBlockAllInput();
			_progressService.PlayerProgress.LevelData.NextLoadRoom = _projectGlobalSettings.FightRoom;
			_gameStateMachine.Enter<ReloadLevelState>();
        }
    }
}
