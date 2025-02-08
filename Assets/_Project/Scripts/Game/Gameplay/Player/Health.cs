using System;

namespace _Project.Gameplay
{
    public class Health
    {
        private readonly int _maxHealth;

        public int Amount { get; private set; }
        public int MaxHealth => _maxHealth;

        public event Action<int> OnHealthChanged;
        public event Action OnDied;
        
        public Health(int maxHealth)
        {
            _maxHealth = maxHealth;
            Amount = _maxHealth;
        }

        public void TakeDamage(int damage)
        {
            if(damage < 0)
                throw new ArgumentException();

            if (Amount <= damage)
            {
                Amount = 0;
                OnDied?.Invoke();
                return;
            }
            
            Amount -= damage;

            OnHealthChanged?.Invoke(Amount);
        }

        public void Heal(int heal)
        {
            if(heal < 0)
                throw new ArgumentException();

            if (heal + Amount >= _maxHealth)
                Amount = _maxHealth;
            else
                Amount += heal;
            
            OnHealthChanged?.Invoke(Amount);
        }
    }
}