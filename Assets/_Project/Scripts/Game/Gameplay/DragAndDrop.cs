using _Project.UI;
using UnityEngine;

namespace _Project.Gameplay
{
    public class DragAndDrop
    {
        private readonly Camera _camera;
        private readonly HUD _hud;
        private readonly float _interactDistance;

        private DraggableObject _draggableObject;
        private bool _isDragging;

        public DragAndDrop(Camera camera, InputHandler inputHandler, HUD hud, float interactDistance)
        {
            _camera = camera;
            _hud = hud;
            _interactDistance = interactDistance;

            inputHandler.OnLeftMouseButtonKey += OnLeftMouseButtonKey;
            inputHandler.OnLeftMouseButtonKeyUp += OnLeftMouseButtonKeyUp;
        }

        public void ThrowRay()
        {
            Ray ray = new Ray(_camera.transform.position, _camera.transform.forward);
            if (Physics.Raycast(ray, out RaycastHit hit, _interactDistance))
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
    }
}