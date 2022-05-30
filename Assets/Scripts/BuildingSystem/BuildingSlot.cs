using UnityEngine;
using UnityEngine.UI;

namespace BuildingSystem
{
    public class BuildingSlot : MonoBehaviour
    {
        [SerializeField] private Button buildingSlotButton;
        [SerializeField] private Image sprite;
        private Building building;
        private GameObject user;

        private void Awake()
        {
            buildingSlotButton.onClick.AddListener(StartBuild);
        }

        private void StartBuild()
        {
            building.StartBuilding(user);
        }

        public void SetSlot(Building building, GameObject user)
        {
            this.building = building;
            this.sprite.sprite = building.Sprite;
            this.user = user;
        }

        public void ClearSlot()
        {
            building = null;
            sprite.sprite = null;
        }
            
    }
}