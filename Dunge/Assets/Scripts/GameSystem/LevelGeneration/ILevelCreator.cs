using System;

namespace Scripts.GameSystem.LevelGeneration
{
    public interface ILevelCreator
    {
        event Action CompleteCreateLevelEvent;

        void CreateLevel();
    }
}