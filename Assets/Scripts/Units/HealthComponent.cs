using System;
using UnityEngine;

namespace Units
{
    public class HealthComponent : MonoBehaviour, IHealable
    {
        private int currentHealth;
        private int maxHealth;
        public Action<int, int> OnHealthChanged;

        public int CurrentHealth => currentHealth;

        public int MAXHealth => maxHealth;
        
        public void ApplyDamage(int damage)
        {
            currentHealth -= damage;
            if (currentHealth <= 0)
            {
                currentHealth = 0;
                //TODO: Unit Death;
            }
            OnHealthChanged?.Invoke(currentHealth, maxHealth);
        }

        public void InitialiazeHealth(int maxHealth)
        {
            this.maxHealth = maxHealth;
            currentHealth = maxHealth;
        }

        public void ApplyHeal(int heal)
        {
            currentHealth += heal;
            if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }
            OnHealthChanged?.Invoke(currentHealth, maxHealth);
        }
    }
}