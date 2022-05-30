using UnityEngine;

namespace AbilitySystem
{
    public abstract class Ability : ScriptableObject
    {
        [SerializeField] protected string name;
        [SerializeField] protected string desc;
        [SerializeField] protected Sprite sprite;
        [SerializeField] protected float range;

        public string Name => name;

        public string Desc => desc;
        public Sprite Sprite => sprite;

        public float Range => range;

        public abstract void Use(GameObject user);
    }
}