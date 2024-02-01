using System.Collections;
using System.Collections.Generic;
using ScringloGames.ColorClash.Runtime.Death;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ScringloGames.ColorClash.Runtime
{
    public class ResetSceneOnDeath : MonoBehaviour
    {
       public DeathHandler death;
       void OnEnable()
       {
            death.Killed += ResetScene;
       }
       void OnDisable()
       {
            death.Killed -= ResetScene;
       }
       void ResetScene()
       {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
       }
    }
}
