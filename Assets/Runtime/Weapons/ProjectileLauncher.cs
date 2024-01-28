using UnityEngine;

/*
 * Fires given object, with a public velocity, distance from origin and cooldown, up.
 */

namespace ScringloGames.ColorClash.Runtime.Weapons
{
    public class ProjectileLauncher : MonoBehaviour
    {
        // Velocity
        [SerializeField] private float launchVelocity = 1.0f;
        [SerializeField] private GameObject objectLaunched;
        [SerializeField] private GameObject fireFrom;

        public void Launch()
        {
            var newProjectile = 
                Instantiate(this.objectLaunched, this.fireFrom.transform.position, this.transform.rotation);
            Vector2 launchSpeed = this.transform.up * this.launchVelocity;
            newProjectile.GetComponent<Rigidbody2D>().velocity = launchSpeed;
        }

    }
}
