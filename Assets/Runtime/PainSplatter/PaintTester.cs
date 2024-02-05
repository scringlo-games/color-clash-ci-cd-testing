using System;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.PainSplatter
{
    public class PaintTester : MonoBehaviour
    {
        public Camera mainCamera;
        private UnityEngine.Vector2 mousePos;
        public event Action<UnityEngine.Vector3> SpawnSprite;

        void Update()
        {
            this.mousePos = UnityEngine.Input.mousePosition;
            if (UnityEngine.Input.GetButtonDown("Fire1"))
            {
                this.SpawnSprite?.Invoke(this.mainCamera.ScreenToWorldPoint(this.mousePos));
                Debug.Log("test fired");
            }
        }


       
    }
}
