using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.PlayerCharacter
{
    /// <summary>
    /// Responsible for interfacing between the thing telling it to move and the actual mechanism for moving
    /// (in this case a Rigidbody2D).
    /// </summary>
    public class DirectionalMover : MonoBehaviour
    {
        [SerializeField]
        private float accelerationIncrement;
        [SerializeField]
        private float speedCeiling = 10f;
        [SerializeField]
        [Range(0, 1)]
        private float friction = 0.025f;
        [Header("Dependencies")]
        [SerializeField]
        private new Rigidbody2D rigidbody2D;

        public Vector2 Velocity { get; private set; }
        public bool IsAccelerating { get; set; }
        public Vector2 Direction { get; set; }
        public Vector2 Acceleration { get; private set; }

        private void Update()
        {
            if (this.IsAccelerating)
            {
                // Apply acceleration
                this.Acceleration += this.Direction * this.accelerationIncrement;
            }
            else
            {
                // This is a hacky trick to get very quick-and-dirty friction working
                this.Acceleration = Vector2.Lerp(this.Acceleration, Vector2.zero, this.friction);
            }
            
            // Don't let acceleration go beyond the ceiling
            this.Acceleration = Vector2.ClampMagnitude(this.Acceleration, this.speedCeiling);
            
            // We are setting velocity directly rather than adding acceleration since we want to make sure we have
            // really tight control over how much acceleration can be applied; without this we have to do some fancy
            // dot-product math if we want to limit the player's velocity contribution from acceleration
            this.Velocity = this.Acceleration;
        }

        private void FixedUpdate()
        {
            // We do this in FixedUpdate to make sure that we are respecting Unity's physics time step and so we don't
            // get weird framerate-dependent speed changes.
            this.rigidbody2D.MovePosition(this.rigidbody2D.position + this.Velocity * Time.fixedDeltaTime);
        }

        public void StartAccelerating()
        {
            this.IsAccelerating = true;
        }

        public void StopAccelerating()
        {
            this.IsAccelerating = false;
        }
    }
}
