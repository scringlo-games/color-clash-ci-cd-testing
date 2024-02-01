using System.Collections;
using System.Collections.Generic;
using ScringloGames.ColorClash.Runtime.Conditions;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime
{
    /// <summary>
    /// Applies DOT condition.
    /// </summary>
    public class ApplyDOTCondition : MonoBehaviour
    {
        /// <summary>
        /// If object has a bank, applies DOT.
        /// </summary>
        /// <param name="obj">The object that recieves condition</param>
        public void ApplyTo(GameObject obj)
        {
            if (obj.TryGetComponent<ConditionBank>(out ConditionBank bank))
            {
                bank.Apply(new DOTCondition());
            }
        }
    }
}
