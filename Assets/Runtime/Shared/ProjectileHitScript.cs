using ScringloGames.ColorClash.Runtime.Health;
using UnityEngine;

public abstract class ProjectileHitScript : MonoBehaviour
{
    [SerializeField] private int damage;
    
    public void OnCollisionEnter2D(Collision2D other)
    {
        ApplyProjectileEffects(other.gameObject);
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
        }
        Destroy(this.gameObject);
    }
}
