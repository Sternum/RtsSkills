using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BuildingSystem
{
    public class BuildingPanel : MonoBehaviour
    {
        [SerializeField] private BuildingSlot slotPrefab;
        [SerializeField] private Transform slotsContainer;
        [SerializeField] private List<BuildingSlot> buildingSlots;
        [SerializeField] private GameObject container; 
        private static BuildingPanel instance;

        public static BuildingPanel Instance => instance;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }

            buildingSlots = new List<BuildingSlot>();
        }

        public void SetBuildings(IEnumerable<Building> buildings, GameObject user)
        {
            ClearBuildings();
            foreach (Building building in buildings)
            {
                BuildingSlot slot = Instantiate(slotPrefab);
                slot.SetSlot(building, user);
                slot.GetComponent<RectTransform>().SetParent(slotsContainer);
                buildingSlots.Add(slot);
            }   
            container.SetActive(true);
            StartCoroutine(CheckForClose());
        }

        public void ClosePanel()
        {
            ClearBuildings();
            container.SetActive(false);
        }
        
        public void ClearBuildings()
        {
            foreach (BuildingSlot slot in buildingSlots)
            {
                Destroy(slot.gameObject);
            }
            buildingSlots.Clear();
        }

        private IEnumerator CheckForClose()
        {
            while (gameObject.activeSelf)
            {
                if (Input.GetMouseButton(1))
                {
                   ClosePanel();
                   break;
                }
                yield return null;
            }
        }
    }
}