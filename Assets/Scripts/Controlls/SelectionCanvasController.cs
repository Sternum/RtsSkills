using BuildingSystem;
using Units;
using UnityEngine;
using UnityEngine.UI;

namespace Controlls
{
    public class SelectionCanvasController : MonoBehaviour
    {
        [SerializeField]
        private AbilityPanel abilityPanel;
        [SerializeField] private Image unitAvatar;
        [SerializeField] private Text unitName;
        [SerializeField] private Text luckiLabel;
        [SerializeField] private Text healthLabel;
        [SerializeField] private Text damageLabel;

        private GameObject selectedUnit;
        private UnitStatsComponent unitStatsComponent;
        private HealthComponent healthComponent;
        public void SetSelectedUnit(GameObject gameObject)
        {
            if (selectedUnit != null)
            {
                UnSelectUnit();
            }
            selectedUnit = gameObject;
            InitUnitInfo();
            InitStatsInfo();
            InitHealthInfo();
            InitAbilityInfo();
            this.gameObject.SetActive(true);
        }

        private void InitUnitInfo()
        {
            UnitComponent unitComponent = selectedUnit.GetComponent<UnitComponent>();
            unitAvatar.sprite = unitComponent.unitData.Sprite;
            unitName.text = unitComponent.unitData.Name;
        }

        private void InitStatsInfo()
        {
            unitStatsComponent = selectedUnit.GetComponent<UnitStatsComponent>();
            UnitStats unitStats = unitStatsComponent.GetStats();
            UpdateStats(unitStats);
            unitStatsComponent.OnStatsUpdated += UpdateStats;
        }

        private void InitHealthInfo()
        {
            healthComponent = selectedUnit.GetComponent<HealthComponent>();
            healthComponent.OnHealthChanged += UpdateHealth;
            UpdateHealth(healthComponent.CurrentHealth, healthComponent.MAXHealth);
        }

        private void InitAbilityInfo()
        {
            AbilityComponent abilityComponent = selectedUnit.GetComponent<AbilityComponent>();
            abilityPanel.SetAbilities(abilityComponent.Abilities, selectedUnit);
        }

        private void UpdateHealth(int currentHealth, int maxHealth)
        {
            healthLabel.text = currentHealth + "/" + maxHealth;
        }
        
        private void UpdateStats(UnitStats stats)
        {
            luckiLabel.text = stats.Luck.ToString();
            damageLabel.text = stats.Damage.ToString();
        }

        public void UnSelectUnit()
        {
            selectedUnit = null;
            unitAvatar.sprite = null;
            unitName.text = null;
            unitStatsComponent.OnStatsUpdated -= UpdateStats;
            healthComponent.OnHealthChanged -= UpdateHealth;
            abilityPanel.ClearAllSlots();
            BuildingPanel.Instance.ClosePanel();
            this.gameObject.SetActive(false);
        }

    }
}