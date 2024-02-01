using System.Collections;
using System.Collections.Generic;
using ScringloGames.ColorClash.Runtime.Conditions;
using ScringloGames.ColorClash.Runtime.Health;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime
{
    /// <summary>
    /// Applies Damage Over Time to affected object
    /// </summary>
    public class DOTCondition : Condition
    {
        /// <summary>
        /// Damage dealt per tick
        /// </summary>
        private float DamageMult;
        private HealthHandler AffectedHealth;
        
        /// <summary>
        /// Creates instance of DOTCondition
        /// </summary>
        /// <param name="damageMult">Damage multiplier per tick.</param>
        public DOTCondition(float damageMult)
        {
            DamageMult = damageMult;
        }
        
        public override void OnApplied(ConditionBank bank)
        {
            Debug.Log("Applied DOT");
            AffectedHealth = bank.GetComponent<HealthHandler>();
        }

        public override void OnTicked(ConditionBank bank, float deltaTime)
        {
            float TickDamage = DamageMult * deltaTime;
            AffectedHealth.TakeDamage((int)TickDamage);
        }
    }
}
