using System.Collections;
using System.Collections.Generic;
using ScringloGames.ColorClash.Runtime.Conditions;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;

namespace ScringloGames.ColorClash.Runtime
{
    public class ConditionTest : MonoBehaviour
    {
        private AOECondition cond;
        private ConditionBank bank;

        void Start()
        {
            bank = this.GetComponent<ConditionBank>();
            cond = new AOECondition();
        }
        void Update()
        {
            if(UnityEngine.Input.GetKeyDown(KeyCode.F))
            {
                bank.Apply(cond);
            }
        }
    }
}
