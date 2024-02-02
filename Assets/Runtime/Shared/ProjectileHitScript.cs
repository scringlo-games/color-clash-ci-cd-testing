using ScringloGames.ColorClash.Runtime.Health;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Shared
{
    public class ProjectileHitScript : MonoBehaviour
    {
        [SerializeField] private new string tag;
        [SerializeField] private int damage;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.CompareTag(this.tag))
            {
                var healthHandler = collision.collider.GetComponent<HealthHandler>();
                if (healthHandler != null)
                {
                    healthHandler.TakeDamage(this.damage);
                }
            }
            
            // Is the other object we hit also a projectile? Is not, destroy this
            var otherProjectile = collision.collider.GetComponent<ProjectileHitScript>();

            if (otherProjectile == null)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
