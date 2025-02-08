using System;
using UnityEngine;

namespace _Project.Gameplay
{
    public class InputHandler
    {
        public event Action OnLeftMouseButtonKey;
        public event Action OnLeftMouseButtonKeyDown;
        public event Action OnLeftMouseButtonKeyUp;
        
        public void Update()
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                OnLeftMouseButtonKey?.Invoke();
            }

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                OnLeftMouseButtonKeyDown?.Invoke();
            }

            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                OnLeftMouseButtonKeyUp?.Invoke();
            }
        }
    }
}