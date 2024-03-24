using Scripts.Infrastructure.StateMachine.MenuStateMachine;
using Scripts.Services.AudioService.MusicService;
using UnityEngine;
using Zenject;

public class MenuBootstrapper : MonoBehaviour
{
    private MenuStateMachine _menuStateMachine;
    private IBackgroundAudioPlayer _audioPlayer;

    [Inject]
    private void Construct(MenuStateMachine menuStateMachine, StartMenuState startMenuState, 
        CreateNewPlayerProgressState createNewPlayerProgressState, 
        LoadPlayerProgressState loadPlayerProgressState, 
        IBackgroundAudioPlayer audioPlayer)
    {
        _menuStateMachine = menuStateMachine;

        _menuStateMachine.AddState(startMenuState);
        _menuStateMachine.AddState(createNewPlayerProgressState);
        _menuStateMachine.AddState(loadPlayerProgressState);

        _audioPlayer = audioPlayer;
    }

    private void Awake()
    {
        _menuStateMachine.Enter<StartMenuState>();

        _audioPlayer.StartPlayBackgroundMusic();
    }
}
