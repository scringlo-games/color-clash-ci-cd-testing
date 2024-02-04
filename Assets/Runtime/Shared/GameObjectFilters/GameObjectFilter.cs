using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Shared.GameObjectFilters
{
    public abstract class GameObjectFilter : ScriptableObject
    {
        public abstract bool Evaluate(GameObject gameObject);
    }
}
