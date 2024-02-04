using System;
using ScringloGames.ColorClash.Runtime.Health;
using ScringloGames.ColorClash.Runtime.Shared;
using ScringloGames.ColorClash.Runtime.Shared.GameObjectFilters;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Damage
{
    public class DamageOtherOnCollisionEnter : MonoBehaviour
    {
        [SerializeField]
        private GameObjectFilterSet filter;
        [SerializeField]
        [Tooltip("The amount of damage to inflict to the other object.")]
        private int damageToInflict;
        
        private void OnCollisionEnter2D(Collision2D collision)
        {
            var other = collision.collider;

            if (!this.filter.Evaluate(other.gameObject))
            {
                return;
            }
            
            var healthHandler = other.GetComponent<HealthHandler>();

            if (healthHandler == null)
            {
                return;
            }

            healthHandler.TakeDamage(this.damageToInflict);
        }
    }
}
