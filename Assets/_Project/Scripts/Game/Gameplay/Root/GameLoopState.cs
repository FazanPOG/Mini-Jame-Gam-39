using System.Collections;
using UnityEngine;

namespace _Project.Gameplay
{
    public class GameLoopState : IGameState
    {
        private readonly GameplayConfig _gameplayConfig;
        private readonly Player _player;
        private readonly MonoBehaviour _context;
        private readonly GameStateMachine _gameStateMachine;
        private readonly int _damageEverySecond;
        
        private bool _onPlay;
        
        public GameLoopState(
            GameplayConfig gameplayConfig, 
            Player player, 
            MonoBehaviour context,
            GameStateMachine gameStateMachine)
        {
            _gameplayConfig = gameplayConfig;
            _player = player;
            _context = context;
            _gameStateMachine = gameStateMachine;
            _damageEverySecond = Mathf.FloorToInt(_player.Health.MaxHealth / _gameplayConfig.PlayerLifeTime);
        }
        
        public void Enter()
        {
            _onPlay = true;
            _player.StartHeartBeat();
            
            _player.Health.OnDied += OnPlayerDied;

            _context.StartCoroutine(GameLoop());
        }

        private IEnumerator GameLoop()
        {
            while (_onPlay)
            {
                yield return new WaitForSeconds(1f);
                _player.Health.TakeDamage(_damageEverySecond);
            }
        }

        private void OnPlayerDied()
        {
            _onPlay = false;
            _player.StopHeartBeat();
            
            _gameStateMachine.EnterIn<LoseState>();
        }

        public void Exit()
        {
            _player.Health.OnDied -= OnPlayerDied;
        }
    }
}