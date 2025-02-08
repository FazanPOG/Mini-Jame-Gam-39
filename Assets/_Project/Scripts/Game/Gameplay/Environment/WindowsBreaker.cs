using System;
using _Project.UI;
using UnityEngine;

namespace _Project.Gameplay
{
    public class WindowsBreaker
    {
        private readonly Camera _camera;
        private readonly float _interactDistance;
        private readonly HUD _hud;

        private BreakableWindow _window;

        public event Action OnWindowBroken;
        
        public WindowsBreaker(Camera camera, InputHandler inputHandler, HUD hud, float interactDistance)
        {
            _camera = camera;
            _hud = hud;
            _interactDistance = interactDistance;

            inputHandler.OnLeftMouseButtonKeyDown += OnLeftMouseButtonKeyDown;
        }

        private void OnLeftMouseButtonKeyDown()
        {
            if (_window != null)
            {
                _window.breakWindow();
                _window.MoveMetalCover();
                OnWindowBroken?.Invoke();
            }
        }

        public void ThrowRay()
        {
            Ray ray = new Ray(_camera.transform.position, _camera.transform.forward);
            if (Physics.Raycast(ray, out RaycastHit hit, _interactDistance))
            {
                if (hit.collider.TryGetComponent(out BreakableWindow window))
                {
                    _window = window;
                    _hud.ShowCursor();
                }
                else
                {
                    _window = null;
                }
            }
            else
            {
                _window = null;
            }
        }
    }
}