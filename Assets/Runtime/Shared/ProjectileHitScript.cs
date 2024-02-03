using ScringloGames.ColorClash.Runtime.Health;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Shared
{
    public abstract class ProjectileHitScript : MonoBehaviour
    {
        [SerializeField] private int damage;
    
        public void OnCollisionEnter2D(Collision2D other)
        {
            this.ApplyProjectileEffects(other.gameObject);
        }

        protected abstract void ApplyProjectileEffects(GameObject otherGameObject);

        protected void DealDamageAndDestroy(GameObject obj)
        {
            if (obj.TryGetComponent<HealthHandler>(out HealthHandler healthHandler))
            {
                if (healthHandler != null)
                {
                    healthHandler.TakeDamage(this.damage);
                }
            
                // Is the other object we hit also a projectile? Is not, destroy this
                var otherProjectile = collision.collider.GetComponent<ProjectileHitScript>();

                if (otherProjectile == null)
                {
                    Destroy(this.gameObject);
                }
            }
            Destroy(this.gameObject);
        }
    }
}
