using System;

namespace Scripts.Logic
{
    public interface IHealth
    {
        int MaxHP { get; }
        int CurrentHP { get; }

        event Action HealthChanged;

        void TakeDamage(int damage);
    }
}