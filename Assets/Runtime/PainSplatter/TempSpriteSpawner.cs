using System.Collections;
using System.Collections.Generic;
using PlasticGui.WorkspaceWindow;
using ScringloGames.ColorClash.Runtime.Shared;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime
{
    public class TempSpriteSpawner : MonoBehaviour
    {
    
        private Vector3 angle;
        public GameObject spawnObj;
        public ProjectileHitScript
        
        private int spriteCount;
        private float timeAlive;
        
        
        void OnEnable()
        {
            Spawner.SpawnSprite += OnNewSprite;
        }
        void OnDisable()
        {
            Spawner.SpawnSprite -= OnNewSprite;
        }
        void OnNewSprite(UnityEngine.Vector3 targetPos)
        {
           GameObject newObj = Instantiate(spawnObj,targetPos, Quaternion.Euler(angle));
           newObj.GetComponent<SpriteRenderer>().sortingOrder = spriteCount++;
           Debug.Log($"sprite count: {spriteCount}");
        }
    
    }
}
