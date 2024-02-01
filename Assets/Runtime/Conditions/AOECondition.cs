using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using PlasticPipe.PlasticProtocol.Messages;
using ScringloGames.ColorClash.Runtime.Conditions;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;

namespace ScringloGames.ColorClash.Runtime
{
    public class AOECondition : Condition
    {   private float AOERadius = 2f;
        
        public override void OnApplied(ConditionBank bank)
        {
            Debug.Log($"applied condition onto: {bank.name}");
            //Sets the Duration of this condition to 2 seconds.
            Duration = 2f;

            //gets the position of the object that this conditionbank is on. 
            UnityEngine.Vector3 thisPos = bank.transform.position;

            //stores an array of Colliders within a radius of this object.
            Collider2D[] colliders = Physics2D.OverlapCircleAll(thisPos, AOERadius);

            //foreach loop goes through each collider found, checks for if each object has a ConditionBank component, if it does,
            //then it stores that bank in a variable, and then checks the list of conditions that the ConditionBank has.
        Point:
            foreach(Collider2D target in colliders)
            {
                if(target.GetComponent<ConditionBank>() != null)
                {
                    ConditionBank targetBank = target.GetComponent<ConditionBank>();
                    foreach(Condition targetCond in targetBank.Conditions)
                    {
                        //if any of the conditions on the current ConditionBank are the AOECondtion, it will skip this object
                        //and start checking the next object in the list.
                        if(targetCond is AOECondition)
                        {
                            goto Point;
                        }
                    } 
                    //if none of the conditions on the current ConditiobBank are the AOECondition, this foreach loop will apply
                    //all of the conditions on THIS object onto the ConditionBank of the next object. 
                    foreach(Condition thisCond in bank.Conditions)
                    {
                        targetBank.Apply(thisCond);
                    }
                }
            }
        }
    }
}
