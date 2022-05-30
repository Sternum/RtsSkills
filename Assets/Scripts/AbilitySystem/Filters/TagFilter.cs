using System.Collections.Generic;
using UnityEngine;

namespace AbilitySystem.Filters
{
    [CreateAssetMenu(fileName = "Tag Filter", menuName = "Abilities/Filters/Tag Filter", order = 0)]
    public class TagFilter : FilterStrategy
    {
        [SerializeField] private string tag;
        
        public override IEnumerable<GameObject> StartFilter(IEnumerable<GameObject> objectsToFilter)
        {
            foreach (GameObject gameObject in objectsToFilter)
            {
                if (gameObject.CompareTag(tag))
                {
                    yield return gameObject;
                }
            }
        }
    }
}