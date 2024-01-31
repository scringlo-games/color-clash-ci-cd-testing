namespace ScringloGames.ColorClash.Runtime.Conditions
{
    /// <summary>
    /// Responsible for encapsulating behaviour that is common between all conditions and for defining a signature
    /// that can be used to treat conditions in the same way by certain systems (such as ConditionBank). Inheritors
    /// should override the OnApplied, OnTicked, and OnExpired methods in order to define condition-specific behavior.
    /// </summary>
    public abstract class Condition
    {
        /// <summary>
        /// Determines the duration for which the condition should continue to be active.
        /// </summary>
        public float Duration { get; set; }
        /// <summary>
        /// The remaining time for which the condition will continue to be active. This will be initialized at Duration
        /// and decremented every frame. When this value reaches zero, the condition will be automatically removed.
        /// </summary>
        public float Time { get; protected set; }
        
        protected Condition()
        {
            this.Time = this.Duration;
        }
        
        /// <summary>
        /// Invoked when the condition is first applied to an entity.
        /// </summary>
        /// <param name="bank">The ConditionBank that invokes this callback.</param>
        public virtual void OnApplied(ConditionBank bank)
        {
        }
        
        /// <summary>
        /// Invoked every "tick", as determined by the settings defined in the ConditionBank.
        /// </summary>
        /// <param name="bank">The ConditionBank that invokes this callback.</param>
        /// <param name="deltaTime">The interval in seconds from the last frame to the current one (Read Only).</param>
        public virtual void OnTicked(ConditionBank bank, float deltaTime)
        {
        }

        /// <summary>
        /// Invoked when the condition is removed from an entity.
        /// </summary>
        /// <param name="bank">The ConditionBank that invokes this callback.</param>
        public virtual void OnExpired(ConditionBank bank)
        {
        }
    }
}
