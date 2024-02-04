using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Conditions
{
    public class ConditionTester : MonoBehaviour
    {
        private void Start()
        {
            var condition = new MyCondition()
            {
                Duration = 10f,
            };
            var bank = this.GetComponent<ConditionBank>();
            
            bank.Apply(condition);
        }

        public class MyCondition : Condition
        {
            public override void OnTicked(ConditionBank bank, float deltaTime)
            {
                Debug.Log($"Ticked!");
            }
        }
    }
}
