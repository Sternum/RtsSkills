using Units;
using UnityEngine;

namespace AbilitySystem.Effects
{
    [CreateAssetMenu(fileName = "Unlucky Effect", menuName = "Abilities/Effects/StatusEffects/Unlucky", order = 0)]
    public class UnluckyEffect : StatusEffect
    {
        [SerializeField] private int luck; 
        
        public override void SetStatus(UnitStats stats)
        {
            stats.Luck -= luck;
        }
    }
}