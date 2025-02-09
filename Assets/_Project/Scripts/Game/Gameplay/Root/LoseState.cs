using _Project.UI;
using UnityEngine.SceneManagement;

namespace _Project.Gameplay
{
    public class LoseState : IGameState
    {
        private readonly InputHandler _inputHandler;
        private readonly Player _player;
        private readonly HUD _hud;

        public LoseState(InputHandler inputHandler, Player player, HUD hud)
        {
            _inputHandler = inputHandler;
            _player = player;
            _hud = hud;
        }

        public void Enter()
        {
            _player.DisableMovement();
            _hud.ShowReloadGameView();
            
            _inputHandler.OnReloadGameButtonKeyDown += OnReloadGame;
        }

        private void OnReloadGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void Exit()
        {
            _inputHandler.OnReloadGameButtonKeyDown -= OnReloadGame;
        }
    }
}