using ScringloGames.ColorClash.Runtime.Conditions;
using ScringloGames.ColorClash.Runtime.Shared;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Weapons
{
    /// <summary>
    /// Makes self deal Damage
    /// Requires ApplyDOTCondition.
    /// </summary>
    public class DOTProjectile : ProjectileHitScript
    {
        private float conditionDamage = 1;
        
        protected override void ApplyProjectileEffects(GameObject otherGameObject)
        {
            if (this.gameObject.TryGetComponent(out ApplyDOTCondition condition))
            {
                condition.ApplyTo(otherGameObject, this.conditionDamage);
            }
            this.DealDamageAndDestroy(otherGameObject);
        }
    }
}
