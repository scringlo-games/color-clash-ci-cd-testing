using System;
using System.Collections;
using ScringloGames.ColorClash.Runtime.Health;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Death
{
    public class DeathHandler : MonoBehaviour
    {
        [SerializeField]
        private float destroyDelay = 0.25f;
        [SerializeField]
        private HealthHandler healthHandler;
        public event Action Killed;

        public void Kill()
        {
            this.Killed?.Invoke();
            this.StartCoroutine(this.DestroyAfterDelay());
        }

        private IEnumerator DestroyAfterDelay()
        {
            yield return new WaitForSeconds(this.destroyDelay);
            Destroy(this.gameObject);
        }
        
        private void OnEnable()
        {
            this.healthHandler.HealthChanged += this.OnHealthChanged;
        }

        private void OnDisable()
        {
            this.healthHandler.HealthChanged -= this.OnHealthChanged;
        }

        //Checks if health is below or equal to zero, then invokes the 'OnKilled' event if the condition is met.
        private void OnHealthChanged(int health)
        {
            if (health <= 0)
            {
                this.Kill();
            }
        }
    }
}
