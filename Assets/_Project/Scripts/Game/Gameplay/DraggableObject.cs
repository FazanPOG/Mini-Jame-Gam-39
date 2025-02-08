using UnityEngine;

namespace _Project.Gameplay
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(BoxCollider))]
    public class DraggableObject : MonoBehaviour
    {
        private Rigidbody _rigidbody;
        private Camera _camera;
        private Vector3 _velocity = Vector3.zero;
        private bool _isDragging;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _camera = Camera.main;
        }

        private void FixedUpdate()
        {
            if (_isDragging)
            {
                Vector3 targetPosition = _camera.transform.position + _camera.transform.forward * 2f;

                Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, targetPosition, ref _velocity, 0.175f);
        
                _rigidbody.MovePosition(smoothedPosition);
            }
        }
        
        public void Drag()
        {
            _rigidbody.isKinematic = true;
            _isDragging = true;
        }

        public void Drop()
        {
            _rigidbody.isKinematic = false;
            _isDragging = false;
        }
    }
}