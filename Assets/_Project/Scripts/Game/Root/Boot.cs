using System;
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
        private InputHandler _inputHandler;
        private AudioPlayer _audioPlayer;
        
        private void Start()
        {
            _inputHandler = new InputHandler();
            _audioPlayer = new AudioPlayer(_audioSource, _gameplayConfig);
            _player.Init(_gameplayConfig, _hud, _inputHandler, _audioPlayer);
            
            StartGame();
        }

        private void Update()
        {
            _inputHandler.Update();
        }

        private void StartGame()
        {
            new GameStateMachine(_gameplayConfig, _player, _inputHandler, this, _hud).EnterIn<BootState>();
        }
    }
}