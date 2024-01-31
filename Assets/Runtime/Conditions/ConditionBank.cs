﻿using System;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Conditions
{
    /// <summary>
    /// Responsible for managing a set of conditions on a specific entity. This class will maintain a list of
    /// conditions that the entity has, execute the abstracted logic of those conditions, decrement the time of those
    /// conditions and automatically remove them when expired.
    /// </summary>
    public class ConditionBank : MonoBehaviour
    {
        /// <summary>
        /// Applies the specified condition to this entity.
        /// </summary>
        /// <param name="condition">The condition to be applied.</param>
        /// <exception cref="NotImplementedException"></exception>
        public void Apply(Condition condition)
        {
            throw new NotImplementedException();
        }
    }
}
