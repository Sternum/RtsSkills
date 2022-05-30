using UnityEngine;

namespace BuildingSystem
{
    [UnityEngine.CreateAssetMenu(fileName = "Building", menuName = "Building/Building", order = 0)]
    public class Building : UnityEngine.ScriptableObject
    {
        [SerializeField] private string Name;
        [SerializeField] private int cost;
        [SerializeField] private Sprite sprite;
        [SerializeField] private GameObject prefab;
        [SerializeField] private GameObject ghost;
        [SerializeField] private BuildingPlacementStrategy buildingPlacementStrategy;
        public string Name1 => Name;

        public int Cost => cost;

        public Sprite Sprite => sprite;

        public GameObject Prefab => prefab;
        
        public void StartBuilding(GameObject user)
        {
            BuildingData buildingData = new BuildingData(prefab, ghost, user);
            buildingPlacementStrategy.StartBuildingPlacement(buildingData);
        }
    }
}