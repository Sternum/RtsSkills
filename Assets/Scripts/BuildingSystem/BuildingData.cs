using UnityEngine;

namespace BuildingSystem
{
    public class BuildingData
    {
        private GameObject buildingPrefab;
        private GameObject buildingGhost;
        private GameObject user;

        public BuildingData(GameObject buildingPrefab, GameObject buildingGhost, GameObject user)
        {
            this.buildingPrefab = buildingPrefab;
            this.buildingGhost = buildingGhost;
            this.user = user;
        }

        public GameObject BuildingPrefab => buildingPrefab;

        public GameObject BuildingGhost => buildingGhost;
        public GameObject User => user;
    }
}