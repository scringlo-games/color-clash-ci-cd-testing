using ScringloGames.ColorClash.Runtime.Death;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ScringloGames.ColorClash.Runtime.Shared
{
    public class ResetSceneOnDeath : MonoBehaviour
    {
       public DeathHandler death;

       private void OnEnable()
       {
            this.death.Killed += this.ResetScene;
       }

       private void OnDisable()
       {
            this.death.Killed -= this.ResetScene;
       }

       private void ResetScene()
       {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
       }
    }
}
