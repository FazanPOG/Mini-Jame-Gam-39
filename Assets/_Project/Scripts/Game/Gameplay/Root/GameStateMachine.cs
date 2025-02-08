using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Project.Gameplay
{
    public class GameStateMachine
    {
        private readonly Dictionary<Type, IGameState> _states;

        private IGameState _currentState;

        public event Action<IGameState> OnGameStateChanged;
        
        public GameStateMachine(GameplayConfig config, Player player, MonoBehaviour context)
        {
            _states = new Dictionary<Type, IGameState>()
            {
                [typeof(BootState)] = new BootState(this),
                [typeof(GameLoopState)] = new GameLoopState(config, player, context, this),
                [typeof(LoseState)] = new LoseState(),
            };
        }

        public void EnterIn<T>() where T : IGameState
        {
            if(_states.TryGetValue(typeof(T), out IGameState newState) == false)
                throw new Exception($"State does not exist: {typeof(T)}");
            
            _currentState?.Exit();
            _currentState = newState;
            _currentState.Enter();
        }

        public bool IsGameLoopState()
        {
            return _currentState?.GetType() == typeof(GameLoopState);
        }
    }
}