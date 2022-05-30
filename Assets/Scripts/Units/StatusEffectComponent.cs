using System;
using System.Collections.Generic;
using AbilitySystem.Effects;
using System.Linq;
using UnityEngine;


namespace Units
{
    public class StatusEffectComponent : MonoBehaviour
    {
        private Dictionary<StatusEffect, float> effects = new Dictionary<StatusEffect, float>();
        public Action OnStatusEffectsChange;
        
        public void AddStatus(StatusEffect effect)
        {
            effects.Add(effect, effect.Duration);
            OnStatusEffectsChange?.Invoke();
        }

        public void RemoveStatus(StatusEffect effect)
        {
            effects.Remove(effect);
            OnStatusEffectsChange?.Invoke();
        }

        public UnitStats CalculateStats(UnitStats stats)
        {
            foreach (StatusEffect effect in effects.Keys)
            {
                effect.SetStatus(stats);
            }

            return stats;
        }

        private void ProcessCooldown()
        {
            foreach (StatusEffect effect in effects.Keys.Reverse())
            {
                effects[effect] -= Time.deltaTime;
                if (effects[effect] <= 0.0f)
                {
                    RemoveStatus(effect);
                }
                
            }
        }

        private void Update()
        {
            ProcessCooldown();
        }
    }
}