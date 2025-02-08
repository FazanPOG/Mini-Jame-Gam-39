using _Project.Gameplay;
using _Project.UI;
using UnityEngine;

namespace _Project.Root
{
    public class Boot : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private HUD _hud;

        private void Start()
        {
            _player.Init(_hud);
        }
    }
}