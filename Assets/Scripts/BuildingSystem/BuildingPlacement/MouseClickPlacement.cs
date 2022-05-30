using System.Collections;
using Controlls;
using UnityEngine;

namespace BuildingSystem.BuildingPlacement
{
    [CreateAssetMenu(fileName = "Mouse Click", menuName = "Building/Targeting/On Mouse Click", order = 0)]
    public class MouseClickPlacement : BuildingPlacementStrategy
    {
        public override void StartBuildingPlacement(BuildingData buildingData)
        {
            BuildingPanel.Instance.ClosePanel();
            SelectionComponent.Instance.enabled = false;
            buildingData.User.GetComponent<MonoBehaviour>().StartCoroutine(PlacingBuilding(buildingData));
        }

        private IEnumerator PlacingBuilding(BuildingData buildingData)
        {
            GameObject ghostPrefab = Instantiate(buildingData.BuildingGhost);
            while(true)
            {
                RaycastHit hit;
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity, LayerMask.GetMask("Ground")))
                {
                    ghostPrefab.transform.position = hit.point;
                    
                    if (Input.GetMouseButtonDown(0))
                    {
                        GameObject building = Instantiate(buildingData.BuildingPrefab);
                        building.transform.position = hit.point;
                        Destroy(ghostPrefab);
                        break;
                    }
                    if (Input.GetMouseButtonDown(1))
                    {
                        Destroy(ghostPrefab);
                        break;
                    };
                }
                yield return null;
            }
            SelectionComponent.Instance.enabled = true;
        }
    }
}