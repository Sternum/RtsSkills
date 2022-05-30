using System.Linq;
using Units;
using UnityEngine;

namespace AbilitySystem.Effects
{
    public abstract class StatusEffect : EffectStrategy
    {

        [SerializeField] protected float duration;

        public float Duration => duration;

        public override void StartEffect(AbilityData abilityData)
        {
            foreach (GameObject target in abilityData.Targets)
            {
                target.GetComponent<StatusEffectComponent>().AddStatus(this);
            }
        }

        public abstract void SetStatus(UnitStats stats);
    }
}