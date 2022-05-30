using System;
using Units;
using UnityEngine;

namespace Controlls
{
    public class SelectionComponent: MonoBehaviour
    {
        [SerializeField]
        private SelectionCanvasController selectionPanel;

        private static SelectionComponent instance;

        public static SelectionComponent Instance => instance;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
        }

        public void SelectUnit(GameObject unit)
        {
            selectionPanel.SetSelectedUnit(unit);
        }
        
        public void HandlePlayerSelection()
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity, LayerMask.GetMask("Units")))
                {
                    if (hit.collider != null)
                    {
                        SelectUnit(hit.collider.gameObject);
                    }
                }
            }
        }

        public void HandlePlayerUnselection()
        {
            if (Input.GetMouseButtonDown(1))
            {
                selectionPanel.UnSelectUnit();
            }
        }

        private void Update()
        {
            HandlePlayerSelection();
            HandlePlayerUnselection();
        }
    }
}