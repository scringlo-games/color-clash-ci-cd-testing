using System.Collections;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Spawning
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField]
        private GameObject prefabToSpawn;
        [SerializeField]
        private float interval = 10f;

        private void OnEnable()
        {
            this.StartCoroutine(this.SpawnPrefab());
        }

        private IEnumerator SpawnPrefab()
        {
            Instantiate(this.prefabToSpawn, this.transform.position, Quaternion.identity, null);

            yield return new WaitForSeconds(this.interval);
            yield return this.SpawnPrefab();
        }
    }
}
