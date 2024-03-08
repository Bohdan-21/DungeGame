using Scripts.Infrastructure.Audio;
using Scripts.Infrastructure.StateMachine;
using Scripts.Logic;
using Scripts.Services.PlayerProgressService;
using Scripts.StaticData.SystemConfigData;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Scripts.GameMechanic.Teleport
{
    public class Teleport : MonoBehaviour
    {
        private ISoundsGameActionPlayer _soundPlayer;
        private IPlayerProgressService _progressService;
        private ProjectGlobalSettings _globalSettings;
        private GameStateMachine _gameStateMachine;

        public TriggerObserver Observer;
        public bool IsStartLocation;

        [Inject]
        private void Construct(GameStateMachine gameStateMachine, IPlayerProgressService progressService,
            ProjectGlobalSettings globalSettings, ISoundsGameActionPlayer soundPlayer)
        {
            _gameStateMachine = gameStateMachine;
            _progressService = progressService;
            _globalSettings = globalSettings;
            _soundPlayer = soundPlayer;
        }

        private void Start()
        {
            Observer.TriggerEnter += TriggerEnter;
        }

        private void TriggerEnter(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                UpdateDungeLevel();
                LoadWinState();
            }
        }

        private void LoadWinState()
        {
            _soundPlayer.PlayTeleportSound();

            _gameStateMachine.Enter<WinState>();
        }


        /// <summary>
        /// TODO: recheck this
        /// </summary>
        private void UpdateDungeLevel()
        {
            if (!IsStartLocation)
            {
                if (IsCurrentLevelMaxLevelDunge())
                    ResetLevelDunge();
                else
                    UpdateCurrentAndMaxLevelDunge();
            }
        }

        private void UpdateCurrentAndMaxLevelDunge()
        {
            _progressService.PlayerProgress.LevelData.CurrentDungeLevel++;
            _progressService.PlayerProgress.LevelData.MaxReachedDungeLevel++;
        }

        private void ResetLevelDunge()
        {
            _progressService.PlayerProgress.LevelData.CurrentDungeLevel = 0;
        }

        private bool IsCurrentLevelMaxLevelDunge()
        {
            Debug.Log("Current:" + _progressService.PlayerProgress.LevelData.CurrentDungeLevel.ToString());
            Debug.Log("Maximum:" + _globalSettings.DungeLevels.Count.ToString());

            return _progressService.PlayerProgress.LevelData.CurrentDungeLevel + 1 == _globalSettings.DungeLevels.Count;
        }
    }
}