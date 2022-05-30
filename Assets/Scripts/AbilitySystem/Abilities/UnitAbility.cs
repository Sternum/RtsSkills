using System.Linq;
using UnityEngine;

namespace AbilitySystem.Abilities
{
    [CreateAssetMenu(fileName = "Unit Ability", menuName = "Abilities/Unit Ability", order = 0)]
    public class UnitAbility : Ability
    {
        [SerializeField] private TargetStrategy targetStrategy;
        [SerializeField] private FilterStrategy[] filterStrategies;
        [SerializeField] private EffectStrategy[] effectStrategies;
        
        public override void Use(GameObject user)
        {
            AbilityData abilityData = new AbilityData(user);
            abilityData.Range = range;
            targetStrategy.StartTargeting(abilityData, () => { TargetDetectet(abilityData);});
        }

        private void TargetDetectet(AbilityData abilityData)
        {
            foreach (FilterStrategy filterStrategy in filterStrategies)
            {
                abilityData.Targets = filterStrategy.StartFilter(abilityData.Targets);
            }
            
            foreach (EffectStrategy effectStrategy in effectStrategies)
            {
                effectStrategy.StartEffect(abilityData);
            }   
        }
    }
}