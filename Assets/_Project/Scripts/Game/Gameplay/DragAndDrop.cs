using System;
using _Project.UI;
using UnityEngine;

namespace _Project.Gameplay
{
    public class DragAndDrop : MonoBehaviour
    {
        [SerializeField] private float _dragDistance;

        private HUD _hud;
        private DraggableObject _draggableObject;
        private Camera _camera;
        private bool _isInit;
        private bool _isDragging;

        private void Awake() => _camera = Camera.main;

        public void Init(InputHandler inputHandler, HUD hud)
        {
            _hud = hud;
            
            inputHandler.OnLeftMouseButtonKey += OnLeftMouseButtonKey;
            inputHandler.OnLeftMouseButtonKeyUp += OnLeftMouseButtonKeyUp;

            _isInit = true;
        }

        private void FixedUpdate()
        {
            if(_isInit == false)
                return;

            ThrowRay();
        }
        
        private void ThrowRay()
        {
            Ray ray = new Ray(_camera.transform.position, _camera.transform.forward);
            if (Physics.Raycast(ray, out RaycastHit hit, _dragDistance))
            {
                if (hit.collider.TryGetComponent(out DraggableObject draggableObject))
                {
                    _draggableObject = draggableObject;
                    _hud.ShowCursor();
                }
                else
                {
                    CancelDrag();
                }
            }
            else
            {
                CancelDrag();
            }
        }

        private void CancelDrag()
        {
            if (_isDragging == false)
            {
                _draggableObject = null;
                _hud.HideCursor();
            }
        }

        private void OnLeftMouseButtonKey()
        {
            if (_draggableObject != null)
            {
                _draggableObject.Drag();
                _isDragging = true;
            }
        }

        private void OnLeftMouseButtonKeyUp()
        {
            if (_draggableObject != null)
                _draggableObject.Drop();
            
            _draggableObject = null;
            _isDragging = false;
        }
        
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawRay(transform.position, Camera.main.transform.forward * _dragDistance);
        }
    }
}