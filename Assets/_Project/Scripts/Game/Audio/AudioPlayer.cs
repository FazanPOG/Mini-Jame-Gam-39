using _Project.Gameplay;
using UnityEngine;

namespace _Project.Audio
{
    public class AudioPlayer
    {
        private readonly AudioSource _audioSource;
        private readonly GameplayConfig _gameplayConfig;

        public AudioPlayer(AudioSource audioSource, GameplayConfig gameplayConfig)
        {
            _audioSource = audioSource;
            _gameplayConfig = gameplayConfig;
        }

        public void PlaySlowHeartBeatSFX(float volumeScale = 1f) => PlaySFXOneShot(_gameplayConfig.SlowHeartBeatClip);
        public void PlayFastHeartBeatSFX(float volumeScale = 1f) => PlaySFXOneShot(_gameplayConfig.FastHeartBeatClip);
        public void PlayLowHPSFX(float volumeScale = 1f) => PlaySFXOneShot(_gameplayConfig.LowHpClip);

        public void PlayDeathSFX(float volumeScale = 1f) => PlaySFXOneShot(_gameplayConfig.DeathClip);

        public void PlayHealSFX(float volumeScale = 1f) => PlaySFXOneShot(_gameplayConfig.HealClip); 

        private void PlaySFXOneShot(AudioClip clip, float volumeScale = 1f)
        {
            _audioSource.PlayOneShot(clip, volumeScale);
        }
    }
}