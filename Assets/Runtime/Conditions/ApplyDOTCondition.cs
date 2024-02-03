using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Conditions
{
    /// <summary>
    /// Applies DOT condition.
    /// Requires another script to activate.
    /// </summary>
    public class ApplyDOTCondition : MonoBehaviour
    {
        /// <summary>
        /// If object has a bank, applies DOT.
        /// </summary>
        /// <param name="obj">The object that receives condition</param>
        public void ApplyTo(GameObject obj, float damage, float duration)
        {
            if (obj.TryGetComponent<ConditionBank>(out ConditionBank bank))
            {
                var condition = new DOTCondition(damage)
                {
                    Duration = duration,
                };
                bank.Apply(condition);
            }
        }
    }
}
