using UnityEngine;
using Random = UnityEngine.Random;

namespace _Project.Gameplay
{
    public class HumanAnimation : MonoBehaviour
    {
        private const string Randomizer = nameof(Randomizer);
        
        [SerializeField] private Animator _animator;

        private void Awake()
        {
            int randomValue = Random.Range(1, 7);
            _animator.SetInteger(Randomizer, randomValue);
        }
    }
}