using System;
using _Project.UI;
using UnityEngine;

namespace _Project.Gameplay
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private float _interactDistance = 2f;
        
        private DragAndDrop _dragAndDrop;
        private InputHandler _inputHandler;
        private WindowsBreaker _windowsBreaker;
        
        public void Init(HUD hud)
        {
            _inputHandler = new InputHandler();
            _dragAndDrop = new DragAndDrop(_camera, _inputHandler, hud, _interactDistance);
            _windowsBreaker = new WindowsBreaker(_camera, _inputHandler, hud, _interactDistance);
        }

        private void Update()
        {
            _inputHandler.Update();
        }

        private void FixedUpdate()
        {
            _dragAndDrop.ThrowRay();
            _windowsBreaker.ThrowRay();
        }
        
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawRay(transform.position, _camera.transform.forward * _interactDistance);
        }
    }
}
