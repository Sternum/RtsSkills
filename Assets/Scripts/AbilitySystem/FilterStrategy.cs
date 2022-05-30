using System.Collections.Generic;
using UnityEngine;

namespace AbilitySystem
{
    public abstract class FilterStrategy : ScriptableObject
    {
        public abstract IEnumerable<GameObject> StartFilter(IEnumerable<GameObject> objectsToFilter);
    }
}