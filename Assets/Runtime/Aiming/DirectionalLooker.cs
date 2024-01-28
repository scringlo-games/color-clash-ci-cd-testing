using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.PlayerCharacter
{
    public class DirectionalLooker : MonoBehaviour
    {
        public Vector2 Direction { get; set; }

        private void Update()
        {
            this.transform.rotation = Quaternion.LookRotation(Vector3.forward, this.Direction);
        }
    }
}
