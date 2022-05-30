using System.Collections;
using BuildingSystem;
using Units;
using UnityEngine;

namespace AbilitySystem.Abilities
{
    [CreateAssetMenu(fileName = "Building Ability", menuName = "Abilities/Building Ability", order = 0)]
    public class BuildingAbility : Ability
    {
        [SerializeField] private Building[] buildings;
        public override void Use(GameObject user)
        {
            BuildingPanel.Instance.SetBuildings(buildings, user);
        }

    }
}