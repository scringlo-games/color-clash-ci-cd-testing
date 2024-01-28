using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.PlayerCharacter
{
    public class DetachTransformsOnEnable : MonoBehaviour
    {
        [SerializeField]
        private Transform[] transformsToDetach;
        
        private void OnEnable()
        {
            foreach (var toDetach in this.transformsToDetach)
            {
                toDetach.SetParent(null);
            }
        }
    }
}
