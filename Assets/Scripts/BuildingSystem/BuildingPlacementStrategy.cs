using UnityEngine;

namespace BuildingSystem
{
    [CreateAssetMenu(fileName = "FILENAME", menuName = "MENUNAME", order = 0)]
    public abstract class BuildingPlacementStrategy : ScriptableObject
    {
        public abstract void StartBuildingPlacement(BuildingData buildingData);
    }
}