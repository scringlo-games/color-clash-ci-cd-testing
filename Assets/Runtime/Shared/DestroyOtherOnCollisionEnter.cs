using System.Collections;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Shared
{
    public class DestroyOtherOnCollisionEnter : DestroyOnCollisionEnter
    {
        protected override GameObject GetDestroyTarget(Collision2D collision)
        {
            return collision.collider.gameObject;
        }
    }
}
