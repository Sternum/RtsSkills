using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Controlls;
using Units;
using UnityEngine;
using UnityEngine.AI;

namespace AbilitySystem.Targeting
{
    [CreateAssetMenu(fileName = "Single Target", menuName = "Abilities/Targeting/Single Target", order = 0)]
    public class SingleTarget : TargetStrategy
    {
        public override void StartTargeting(AbilityData abilityData, Action callback)
        {
            UnitComponent unitComponent = abilityData.User.GetComponent<UnitComponent>();
            unitComponent.StartCoroutine(Targeting(abilityData, callback));
        }

        private IEnumerator Targeting(AbilityData abilityData, Action callback)
        {
            SelectionComponent.Instance.enabled = false;
            while (!abilityData.IsCancelled)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    abilityData.Targets = GetTarget();
                    if (abilityData.Targets.Count() > 0)
                    {
                        SelectionComponent.Instance.enabled = true;
                        abilityData.TargetPoint = abilityData.Targets.First().transform;
                        abilityData.StartCoroutine(MoveTowardTarget(abilityData.Targets.First().transform, abilityData, callback));
                        
                        break;   
                    }
                }
                if (Input.GetMouseButtonDown(1))
                {
                    abilityData.IsCancelled = true;
                }
                yield return null;
            }
            SelectionComponent.Instance.enabled = true;
        }

        private IEnumerator MoveTowardTarget(Transform target, AbilityData data, Action callback)
        {
            NavMeshAgent agent = data.User.GetComponent<NavMeshAgent>();
            if (null == agent) yield break;
            while (Vector3.Distance(target.position, data.User.transform.position) > data.Range)
            {
                agent.SetDestination(data.TargetPoint.position);
                yield return null;
            }
            agent.ResetPath();
            callback();
        }
        
        private GameObject[] GetTarget()
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity, LayerMask.GetMask("Units")))
            {
                return new GameObject[] {hit.collider.gameObject};
            }
            return null;
        }
    }
}