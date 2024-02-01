using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime
{
    public class PaintTester : MonoBehaviour
    {
        public Camera mainCamera;
        public UnityEngine.Vector2 mousePos;
        public event Action<UnityEngine.Vector3> SpawnSprite;

        void Update()
        {
            this.mousePos = UnityEngine.Input.mousePosition;
            if (UnityEngine.Input.GetButtonDown("Fire1"))
            {
                SpawnSprite?.Invoke(mainCamera.ScreenToWorldPoint(mousePos));
            }
        }


       
    }
}
