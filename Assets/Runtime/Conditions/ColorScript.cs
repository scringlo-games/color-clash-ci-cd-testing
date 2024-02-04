using System;
using System.Collections.Generic;
using ScringloGames.ColorClash.Runtime.Conditions;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime
{
    /// <summary>
    /// Sets color to lerp between all stored colors.
    /// </summary>
    public class ColorScript : MonoBehaviour
    {
        private ConditionBank conditionBank;
        private List<Color32> colorList;
        
        private void OnEnable()
        {
            if (this.TryGetComponent(out ConditionBank conditionBank))
            {
                this.conditionBank = conditionBank;
                
            }
        }
        
        private void GetAverageColor()
        {
            foreach (Condition condition in conditionBank.Conditions)
            {
                if (condition is SlowCondition s)
                {
                    
                }
            }
        }
    }
}
