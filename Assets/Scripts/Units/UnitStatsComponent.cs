using System;
using UnityEngine;

namespace Units
{
    public class UnitStatsComponent : MonoBehaviour
    {
        private int baseLucky;
        private int baseDamage;
        private StatusEffectComponent statusEffectComponent;
        public Action<UnitStats> OnStatsUpdated;
        
        private void Awake()
        {
            statusEffectComponent = GetComponent<StatusEffectComponent>();
            statusEffectComponent.OnStatusEffectsChange += EffectUpdated;
        }
        private void OnDestroy()
        {
            statusEffectComponent.OnStatusEffectsChange -= EffectUpdated;
        }

        private void EffectUpdated()
        {
            OnStatsUpdated?.Invoke(GetStats());
        }
        
        public UnitStats GetStats()
        {
            UnitStats unitStats = new UnitStats(gameObject);
            unitStats.Luck = baseLucky;
            unitStats.Damage = baseDamage;
            return statusEffectComponent.CalculateStats(unitStats);
        }

        public void InitializeStats(UnitStats stats)
        {
            baseLucky = stats.Luck;
            baseDamage = stats.Damage;
        }
        
    }
}