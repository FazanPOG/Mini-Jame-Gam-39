using UnityEngine;

namespace _Project.Gameplay
{
    [CreateAssetMenu(menuName = "_Project/Configs/Gameplay", order = 0)]
    public class GameplayConfig : ScriptableObject
    {
        [Header("Player")]
        [SerializeField, Range(1f, 600f)] private float _playerLifeTime;
        [SerializeField, Range(1f, 15f)] private float _walkSpeed;
        [SerializeField, Range(1f, 15f)] private float _interactDistance;
        
        [Space(10)]
        [Header("Environment")] 
        [SerializeField, Range(1f, 100f)] private int _windowHeal;

        [Space(10)] 
        [Header("SFX")] 
        [SerializeField] private AudioClip _slowHeartBeatClip;
        [SerializeField] private AudioClip _fastHeartBeatClip;
        [SerializeField] private AudioClip _lowHPClip;
        [SerializeField] private AudioClip _deathClip;
        [SerializeField] private AudioClip _healClip;
        
        public float PlayerLifeTime => _playerLifeTime;
        public float WalkSpeed => _walkSpeed;
        public float InteractDistance => _interactDistance;
        public int WindowHeal => _windowHeal;

        public AudioClip SlowHeartBeatClip => _slowHeartBeatClip;

        public AudioClip FastHeartBeatClip => _fastHeartBeatClip;

        public AudioClip LowHpClip => _lowHPClip;

        public AudioClip DeathClip => _deathClip;
        public AudioClip HealClip => _healClip;
    }
}