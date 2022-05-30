using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AbilitySystem
{
    public class AbilityData
    {
        private GameObject user;
        private Transform targetPoint;
        private IEnumerable<GameObject> targets;
        private bool isCancelled = false;
        private float range = 3.5f;

        public AbilityData(GameObject user)
        {
            this.user = user;
        }

        public GameObject User => user;

        public Transform TargetPoint
        {
            get => targetPoint;
            set => targetPoint = value;
        }

        public IEnumerable<GameObject> Targets
        {
            get => targets;
            set => targets = value;
        }

        public bool IsCancelled
        {
            get => isCancelled;
            set => isCancelled = value;
        }

        public float Range
        {
            get => range;
            set => range = value;
        }

        public void StartCoroutine(IEnumerator coroutine)
        {
            user.GetComponent<MonoBehaviour>().StartCoroutine(coroutine);
        }
    }
}