using System.Collections;
using System.Collections.Generic;
using ScringloGames.ColorClash.Runtime.Conditions;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime
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
                condition.ApplyTo(otherGameObject, conditionDamage);
            }
            DealDamageAndDestroy(otherGameObject);
        }
    }
}
