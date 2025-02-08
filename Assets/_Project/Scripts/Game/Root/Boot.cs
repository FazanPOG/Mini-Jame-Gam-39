using _Project.Audio;
using _Project.Gameplay;
using _Project.UI;
using UnityEngine;

namespace _Project.Root
{
    public class Boot : MonoBehaviour
    {
        [SerializeField] private GameplayConfig _gameplayConfig;
        [SerializeField] private Player _player;
        [SerializeField] private HUD _hud;
        [SerializeField] private AudioSource _audioSource;

        private GameStateMachine _gameStateMachine;
        private AudioPlayer _audioPlayer;
        
        private void Start()
        {
            _audioPlayer = new AudioPlayer(_audioSource, _gameplayConfig);
            _player.Init(_gameplayConfig, _hud, _audioPlayer);
            
            StartGame();
        }

        private void StartGame()
        {
            new GameStateMachine(_gameplayConfig, _player, this).EnterIn<BootState>();
        }
    }
}