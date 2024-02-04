using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

namespace ScringloGames.ColorClash.Runtime.Shared.GameObjectFilters
{
    [Serializable]
    public struct GameObjectFilterSet
    {
        [FormerlySerializedAs("operator")]
        [SerializeField]
        private Operation operation;
        [SerializeField]
        private List<Entry> entries;

        public bool Evaluate(GameObject gameObject)
        {
            return this.operation switch
            {
                Operation.TrueForAll => this.entries.All(e => e.Evaluate(gameObject)),
                Operation.TrueForAny => this.entries.Any(e => e.Evaluate(gameObject)),
                _ => throw new ArgumentOutOfRangeException()
            };
        }
        
        private enum Operation
        {
            TrueForAll,
            TrueForAny,
        }

        [Serializable]
        private struct Entry
        {
            [SerializeField]
            private GameObjectFilter filter;
            [SerializeField]
            private bool negate;

            public bool Evaluate(GameObject gameObject)
            {
                return this.filter.Evaluate(gameObject) ^ this.negate;
            }
        }
    }
}
