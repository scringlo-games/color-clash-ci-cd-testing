using UnityEngine;

/*
 * Activates Projectile Launcher on a timer
 */

namespace ScringloGames.ColorClash.Runtime.Weapons
{
    public class AttackBehavior : MonoBehaviour
    {
        // Cooldown
        [SerializeField]
        private float cooldownTimer = 10;
        [Header("Dependencies")]
        [SerializeField] private ProjectileLauncher projectileLauncher;
        private bool timerOn;
        private float timer;

        private bool isFiring;

        private void Start()
        {
            this.timer = this.cooldownTimer;
        }

        public void Attack(bool amIFiring)
        {
            this.isFiring = amIFiring;
        }

        private void Update()
        {
            if (!this.timerOn && this.isFiring)
            {
                this.projectileLauncher.Launch();
                this.timerOn = true;
            } else
            {
                //Counts timer and resets
                if (this.timer <= 0)
                {
                    this.timerOn = false;
                    this.timer = this.cooldownTimer;
                }
                else
                {
                    this.timer -= Time.deltaTime;
                }
            }
        }
        
    }
}
