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
        [SerializeField] private float DamageMult = 1;
        private HealthHandler AffectedHealth;
        
        public override void OnApplied(ConditionBank bank)
        {
            AffectedHealth = bank.GetComponent<HealthHandler>();
        }

        public override void OnTicked(ConditionBank bank, float deltaTime)
        {
            float TickDamage = DamageMult * deltaTime;
            AffectedHealth.TakeDamage((int)TickDamage);
        }
    }
}
