using System;
using _Project.Audio;
using _Project.UI;
using UnityEngine;
using UnityEngine.Rendering;

namespace _Project.Gameplay
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private FirstPersonController _fpsController;
        [SerializeField] private Camera _camera;
        [SerializeField] private VolumeProfile _volumeProfile;
        [Space(10)]
        [SerializeField, TextArea(0, 5)] private string DEBUG_STRING;
        
        private GameplayConfig _gameplayConfig;
        private DragAndDrop _dragAndDrop;
        private WindowsBreaker _windowsBreaker;
        private PlayerVFXHandler _vfxHandler;
        private PlayerSFXHandler _sfxHandler;
        private float _interactDistance;
        
        public Health Health { get; private set; }

        public void Init(GameplayConfig gameplayConfig, HUD hud, InputHandler inputHandler, AudioPlayer audioPlayer)
        {
            _gameplayConfig = gameplayConfig;
            
            _interactDistance = _gameplayConfig.InteractDistance;
            _fpsController.walkSpeed = _gameplayConfig.WalkSpeed;
            
            _dragAndDrop = new DragAndDrop(_camera, inputHandler, hud, _gameplayConfig.InteractDistance);
            _windowsBreaker = new WindowsBreaker(_camera, inputHandler, hud, _gameplayConfig.InteractDistance);
            _vfxHandler = new PlayerVFXHandler(_volumeProfile);
            Health = new Health(100);
            _sfxHandler = new PlayerSFXHandler(audioPlayer, Health, this);

            _windowsBreaker.OnWindowBroken += OnWindowBroken;
            Health.OnHealthChanged += OnHealthChanged;
        }

        public void StopHeartBeat() => _sfxHandler.StopHeartBeat();

        public void StartHeartBeat() => _sfxHandler.StartHeartBeat();

        public void DisableMovement() => _fpsController.playerCanMove = false;

        private void OnWindowBroken()
        {
            Health.Heal(_gameplayConfig.WindowHeal);
        }

        private void OnHealthChanged(int hp)
        {
            float value = 1 - (float)hp / Health.MaxHealth;
            _vfxHandler.SetVignetteIntensityValue(value);
        }

        private void Update()
        {
            UpdateDebugString();
        }

        private void FixedUpdate()
        {
            _dragAndDrop.ThrowRay();
            _windowsBreaker.ThrowRay();
        }

        private void UpdateDebugString()
        {
            DEBUG_STRING = "";
            DEBUG_STRING = $"Health: {Health.Amount} \n" +
                           $"Vignette value: {_vfxHandler.VignetteValue} \n";
        }

        private void OnDestroy()
        {
            _vfxHandler.Dispose();
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawRay(transform.position, _camera.transform.forward * _interactDistance);
        }
    }
}
