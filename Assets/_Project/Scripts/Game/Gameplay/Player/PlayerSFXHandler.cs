using System;
using System.Collections;
using _Project.Audio;
using UnityEngine;

namespace _Project.Gameplay
{
    public class PlayerSFXHandler
    {
        private readonly AudioPlayer _audioPlayer;
        private readonly Health _playerHealth;
        private readonly MonoBehaviour _context;

        private Coroutine _coroutine;
        private int _previousHP;
        private bool _onLowfHP;
        
        public PlayerSFXHandler(
            AudioPlayer audioPlayer, 
            Health playerHealth, 
            MonoBehaviour context)
        {
            _audioPlayer = audioPlayer;
            _playerHealth = playerHealth;
            _context = context;
            _previousHP = _playerHealth.Amount;
            
            _playerHealth.OnHealthChanged += OnHealthChanged;
            _playerHealth.OnDied += OnDied;
        }

        public void StartHeartBeat()
        {
            _coroutine = _context.StartCoroutine(HeartBeat());
        }

        public void StopHeartBeat()
        {
            if(_coroutine == null)
                throw new Exception();
            
            _context.StopCoroutine(_coroutine);
        }
        
        private IEnumerator HeartBeat()
        {
            while (true)
            {
                if(_onLowfHP)
                {
                    _audioPlayer.PlayFastHeartBeatSFX();
                    yield return new WaitForSeconds(1.5f);
                }
                else
                {
                    _audioPlayer.PlaySlowHeartBeatSFX();
                    yield return new WaitForSeconds(3f);
                }

            }
        }
        
        private void OnHealthChanged(int hp)
        {
            if ((float)hp / _playerHealth.MaxHealth > 0.6f)
                _onLowfHP = false;
            else
                _onLowfHP = true;

            if (_previousHP < hp)
                _audioPlayer.PlayHealSFX();
            
            _previousHP = hp;
        }

        private void OnDied()
        {
            _audioPlayer.PlayDeathSFX();
        }
    }
}