namespace _Project.Gameplay
{
    public class BootState : IGameState
    {
        private readonly GameStateMachine _gameStateMachine;

        public BootState(GameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }
        
        public void Enter()
        {
            _gameStateMachine.EnterIn<GameLoopState>();
        }

        public void Exit()
        {
            
        }
    }
}