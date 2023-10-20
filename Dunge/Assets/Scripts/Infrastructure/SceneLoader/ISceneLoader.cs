using System;

namespace Scripts.Infrastructure.SceneLoader
{
    public interface ISceneLoader
    {
        void LoadScene(string sceneName, Action OnLoaded = null);
    }
}