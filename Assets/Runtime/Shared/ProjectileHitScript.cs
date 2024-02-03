using ScringloGames.ColorClash.Runtime.Conditions;
using ScringloGames.ColorClash.Runtime.Health;
using ScringloGames.ColorClash.Runtime.PlayerCharacter;
using UnityEditor.Build;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Shared
{
    /// <summary>
    /// Damageless projectile abstract. Customize by overriding ApplyProjectileEffect.
    /// </summary>
    public abstract class ProjectileHitScript : MonoBehaviour
    {
        public void OnCollisionEnter2D(Collision2D other)
        {
            //We don't want paint hurting the player.
            if (other.gameObject.GetComponent<PlayerInputHandler>() != null)
            {
                Destroy(this.gameObject);
                return;
            }
            //If it can take effects or damage, projectiles should affect it.
            if (other.gameObject.GetComponent<ConditionBank>() != null) 
            {
                this.ApplyProjectileEffects(other.gameObject);
            }

            if (other.gameObject.GetComponent<HealthHandler>() != null)
            {
                this.IfHasHealth(other.gameObject);
            }
            
            if (other.gameObject.GetComponent<ProjectileHitScript>() == null)
            {
                Destroy(this.gameObject); 
            }
        }
        /// <summary>
        /// Override with projectile effects.
        /// </summary>
        /// <param name="otherGameObject">What this affects.</param>
        protected abstract void ApplyProjectileEffects(GameObject otherGameObject);
        
        /// <summary>
        /// Override.
        /// </summary>
        /// <param name="otherGameObject">What this affects.</param>
        protected abstract void IfHasHealth(GameObject otherGameObject);
    }
}
