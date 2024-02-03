using ScringloGames.ColorClash.Runtime.Health;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Conditions
{
    /// <summary>
    /// Applies Damage Over Time to affected object.
    /// </summary>
    public class DOTCondition : Condition
    {
        /// <summary>
        /// Damage dealt per tick
        /// </summary>
        private float Damage;
        private HealthHandler AffectedHealth;
        
        /// <summary>
        /// Creates instance of DOTCondition
        /// </summary>
        /// <param name="damage">Damage per tick.</param>
        public DOTCondition(float damage)
        {
            this.Damage = damage;
        }
        
        public override void OnApplied(ConditionBank bank)
        {
            Debug.Log("Applied DOT");
            this.AffectedHealth = bank.GetComponent<HealthHandler>();
        }

        public override void OnTicked(ConditionBank bank, float deltaTime)
        {
            this.AffectedHealth.TakeDamage((int)this.Damage);
        }
    }
}
