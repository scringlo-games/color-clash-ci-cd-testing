using System;
using ScringloGames.ColorClash.Runtime.Health;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Damage
{
    public class InflictDamageOnCollisionEnter : MonoBehaviour
    {
        [SerializeField]
        private string tagFilter;
        [SerializeField]
        private int damageToInflict;
        
        private void OnCollisionEnter2D(Collision2D collision)
        {
            var other = collision.collider;
            var healthHandler = other.GetComponent<HealthHandler>();

            if (healthHandler == null)
            {
                return;
            }

            if (!other.CompareTag(this.tagFilter))
            {
                return;
            }

            healthHandler.TakeDamage(this.damageToInflict);
        }
    }
}
