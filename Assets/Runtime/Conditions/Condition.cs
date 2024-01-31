namespace ScringloGames.ColorClash.Runtime.Conditions
{
    public abstract class Condition
    {
        public bool IsTicking { get; private set; }
        public float Duration { get; set; }
        public float Time { get; protected set; }

        protected Condition()
        {
            this.Time = this.Duration;
        }
        
        public virtual void OnApplied(ConditionBank bank)
        {
        }

        public virtual void OnTicked(ConditionBank bank, float deltaTime)
        {
        }

        public virtual void OnRemoved(ConditionBank bank)
        {
        }
    }
}
