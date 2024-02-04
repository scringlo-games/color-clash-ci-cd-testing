using ScringloGames.ColorClash.Runtime.Conditions;
using ScringloGames.ColorClash.Runtime.Health;
using ScringloGames.ColorClash.Runtime.PlayerCharacter;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Shared
{
    /// <summary>
    /// Damageless projectile abstract. Customize by overriding ApplyProjectileEffect.
    /// </summary>
    public abstract class ProjectileHitScript : MonoBehaviour
    {
        private float pitchVariation = 0.2f;
        public void OnCollisionEnter2D(Collision2D other)
        {
            
            //We don't want paint hurting the player.
            if (other.gameObject.GetComponent<PlayerInputHandler>() != null)
            {
                if (this.TryGetComponent(out AudioSource audioSource))
                {
                    audioSource.pitch = (pitchVariation * Random.value) + 1.0f;
                    audioSource.Play();
                }
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
