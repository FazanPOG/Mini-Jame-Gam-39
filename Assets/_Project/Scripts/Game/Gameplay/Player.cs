using _Project.UI;
using UnityEngine;

namespace _Project.Gameplay
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private DragAndDrop _dragAndDrop;
        [SerializeField] private InputHandler _inputHandler;
        
        public void Init(HUD hud)
        {
            _dragAndDrop.Init(_inputHandler, hud);
        }
    }
}