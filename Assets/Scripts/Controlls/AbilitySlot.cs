using System;
using AbilitySystem;
using UnityEngine;
using UnityEngine.UI;

namespace Controlls
{
    public class AbilitySlot : MonoBehaviour
    {
        [SerializeField] private Image abilityImage;
        [SerializeField] private Button activateButton;
        private Ability ability;
        private GameObject user;

        private void Awake()
        {
            activateButton.onClick.AddListener(OnAbilityClick);
        }

        public void SetAbility(Ability ability, GameObject user)
        {
            this.ability = ability;
            this.user = user;
            abilityImage.sprite = ability.Sprite;
        }

        public void ClearSlot()
        {
            this.ability = null;
            this.user = null;
            abilityImage.sprite = null;
        }

        public void OnAbilityClick()
        {
            if(user != null) ability.Use(user);
        }
        
    }
}