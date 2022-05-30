using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AbilitySystem;
using Units.so;
using UnityEngine;
using UnityEngine.Events;

namespace Controlls
{
    public class AbilityPanel : MonoBehaviour
    {
        [SerializeField] private AbilitySlot[] abilitySlots;

        public void SetAbilities(Ability[] abilities, GameObject user)
        {
            for (int i = 0; i < abilitySlots.Length; i++)
            {
                if (i < abilities.Length)
                {
                    abilitySlots[i].SetAbility(abilities[i], user);
                }
                else
                {
                    abilitySlots[i].ClearSlot();
                }
            }
        }

        public void ClearAllSlots()
        {
            foreach (AbilitySlot abilitySlot in abilitySlots)
            {
                    abilitySlot.ClearSlot();
            }
        }
        
    }
}