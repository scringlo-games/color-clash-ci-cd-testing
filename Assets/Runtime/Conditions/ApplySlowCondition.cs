using System.Collections;
using System.Collections.Generic;
using ScringloGames.ColorClash.Runtime.Conditions;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime
{
    public class ApplySlowCondition : MonoBehaviour
    {
        public void ApplyTo(GameObject gameObject, float slowPercent, float duration)
        {
            if (gameObject.TryGetComponent<ConditionBank>(out ConditionBank bank))
            {
                var condition = new SlowCondition(slowPercent)
                {
                    Duration = duration,
                };
                bank.Apply(condition);
            }
        } 
    }
}
