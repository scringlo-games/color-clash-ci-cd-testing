using System;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Weapons
{
    public class ProjectileSwapper : MonoBehaviour
    {
        [SerializeField]
        private GameObject[] projectiles;
        [SerializeField]
        private ProjectileLauncher launcher;
        
        public int CurrentIndex { get; private set; }
        public event Action Swapped;

        public void SwapTo(int index)
        {
            if (index > this.projectiles.Length || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            
            this.CurrentIndex = index;
            this.launcher.ObjectToLaunch = this.projectiles[index];
            this.Swapped?.Invoke();
        }
    }
}
