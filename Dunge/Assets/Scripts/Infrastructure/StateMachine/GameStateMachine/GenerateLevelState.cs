using Scripts.GameSystem.LevelGeneration;
using UnityEngine;

namespace Scripts.Infrastructure.StateMachine
{
    public class GenerateLevelState : IState
    {
        private GameStateMachine _levelStateMachine;
        private ILevelCreator _levelCreator;

        public GenerateLevelState(GameStateMachine levelStateMachine, ILevelCreator levelCreator)
        {
            _levelStateMachine = levelStateMachine;
            _levelCreator = levelCreator;
        }

        public void Enter()
        {
            _levelCreator.CompleteCreateLevelEvent += CompleteGenerateLevel;

            _levelCreator.CreateLevel();

            Debug.Log("Начало генерации.");
        }

        private void CompleteGenerateLevel()
        {
            _levelStateMachine.Enter<InitializeLevelState>();
        }

        public void Exit()
        {
            _levelCreator.CompleteCreateLevelEvent -= CompleteGenerateLevel;

            Debug.Log("Конец генерации.");
        }
    }
}
