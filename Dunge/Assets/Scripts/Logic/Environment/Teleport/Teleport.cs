using Scripts.Infrastructure.StateMachine;
using Scripts.Logic;
using Scripts.Services.AudioService.SoundService;
using Scripts.Services.PlayerProgressService;
using Scripts.StaticData.SystemConfigData;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Scripts.Logic.Environment.Teleport
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

        private void UpdateDungeLevel()
        {
            if (IsStartLocation)
            {
                _progressService.PlayerProgress.LevelData.NextLoadRoom = _globalSettings.FightRoom;
                _progressService.PlayerProgress.LevelData.LevelDunge = 1;
            }
            else
            {
                _progressService.PlayerProgress.LevelData.NextLoadRoom = "";
                _progressService.PlayerProgress.LevelData.LevelDunge++;
            }
        }
    }
}