using ScringloGames.ColorClash.Runtime.Conditions;
using ScringloGames.ColorClash.Runtime.Health;
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
        [SerializeField] private float conditionDamage = 1;
        [SerializeField] private int hitDamage = 1;
        [SerializeField] private float duration = 2.0f;
        
        protected override void ApplyProjectileEffects(GameObject otherGameObject)
        {
            if (this.gameObject.TryGetComponent(out ApplyDOTCondition condition))
            {
                condition.ApplyTo(otherGameObject, this.conditionDamage, duration);
            }
            // We don't want projectiles destroying projectiles, if they can collide.
            if (otherGameObject.GetComponent<ProjectileHitScript>() == null)
            {
                Destroy(this.gameObject);
            }
        }

        protected override void IfHasHealth(GameObject otherGameObject)
        {
            otherGameObject.GetComponent<HealthHandler>().TakeDamage(hitDamage);
        }
    }
}
