using System.Collections;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Shared
{
    public class DestroySelfOnCollisionEnter : DestroyOnCollisionEnter
    {
        protected override GameObject GetDestroyTarget(Collision2D collision)
        {
            return this.gameObject;
        }
    }
}
