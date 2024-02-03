using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Conditions
{
    public class ConditionTest : MonoBehaviour
    {
        private AOECondition cond;
        private ConditionBank bank;

        void Start()
        {
            this.bank = this.GetComponent<ConditionBank>();
            this.cond = new AOECondition();
        }
        void Update()
        {
            if(UnityEngine.Input.GetKeyDown(KeyCode.F))
            {
                this.bank.Apply(this.cond);
            }
        }
    }
}
