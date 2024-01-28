using System;
using ScringloGames.ColorClash.Runtime.Health;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Death
{
    public class DeathHandler : MonoBehaviour
    {
        [SerializeField]
        private HealthHandler healthHandler;
        public event Action Killed;

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
                this.Killed?.Invoke();
            }
        }
    }
}
