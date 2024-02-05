using System.Collections;
using System.Collections.Generic;
using PlasticGui.WorkspaceWindow;
using ScringloGames.ColorClash.Runtime.Shared;
using UnityEngine;
using ScringloGames.ColorClash.Runtime;
using UnityEditor.SearchService;


namespace ScringloGames.ColorClash.Runtime
{
    public class TempSpriteSpawner : MonoBehaviour
    {
    
        private Vector3 angle;
        [SerializeField] private GameObject spawnObj;
        private static int spriteCount;

        void OnDisable()
        {
            CreateNewSprite(this.transform.position);
        }
        public void CreateNewSprite(UnityEngine.Vector3 targetPos)
        {
            /*creates a new instance of the given prefab, then finds the spriterenderer component on the prefab and increments the sorting 
            order by one, ensuring that paint decals are rendered in the correct order. */
            angle = new UnityEngine.Vector3 (0f,0f, Random.Range(-90f, 90f));
            GameObject newObj = Instantiate(spawnObj,targetPos, Quaternion.Euler(angle));
            newObj.GetComponent<SpriteRenderer>().sortingOrder = spriteCount++;
            Debug.Log($"decal pos: {newObj.transform.position}");
            Debug.Log($"sprite count: {spriteCount}");
        }
    
    }
}
