using AbilitySystem;
using UnityEngine;

namespace Units.so.Unit
{
    [CreateAssetMenu(fileName = "Unit Data", menuName = "Units/new Unit", order = 0)]
    public class UnitData : ScriptableObject
    {
        [SerializeField] private string name;
        [SerializeField] private Sprite sprite;
        [SerializeField] private int unitMaxHealth;
        [SerializeField] private UnitStats unitStats;
        [SerializeField] private Ability[] unitAbilties;
        public string Name => name;

        public Sprite Sprite => sprite;

        public int UnitMaxHealth => unitMaxHealth;
        
        public UnitStats UnitStats => unitStats;

        public Ability[] UnitAbilties => unitAbilties;
    }
}