namespace ScringloGames.ColorClash.Runtime.Conditions
{
    public class ApplyAOEConditionToOtherOnCollisionEnter : ApplyConditionToOtherOnCollisionEnter
    {
        protected override Condition GetCondition()
        {
            return new AOECondition()
            {
                Duration = 2f,
            };
        }
    }
}
