using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Shared.GameObjectFilters
{
    [CreateAssetMenu(menuName = "Scriptables/Collision Filters/IsPlayer")]
    public class IsPlayer : GameObjectFilter
    {
        public override bool Evaluate(GameObject gameObject)
        {
            return gameObject.CompareTag("Player");
        }
    }
}
