using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Conditions
{
    /// <summary>
    /// Applies DOT condition.
    /// </summary>
    public class ApplyDOTCondition : MonoBehaviour
    {
        private float damageMult = 1.0f;
        /// <summary>
        /// If object has a bank, applies DOT.
        /// </summary>
        /// <param name="obj">The object that receives condition</param>
        public void ApplyTo(GameObject obj)
        {
            if (obj.TryGetComponent<ConditionBank>(out ConditionBank bank))
            {
                bank.Apply(new DOTCondition(damageMult));
            }
        }
    }
}
