using System;
using ScringloGames.ColorClash.Runtime.Health;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Shared
{
    public class ProjectileHitScript : MonoBehaviour
    {
        [SerializeField] private new string tag;
        [SerializeField] private int damage;
        public event Action<UnityEngine.Vector3> OnDestroyGetPos;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.CompareTag(this.tag))
            {
                var healthHandler = collision.collider.GetComponent<HealthHandler>();
                if (healthHandler != null)
                {
                    healthHandler.TakeDamage(this.damage);
                }
            }
            Destroy(this.gameObject);
        }
        void OnDestroy()
        {
            OnDestroyGetPos?.Invoke(this.transform.position);
        }
    }
}
