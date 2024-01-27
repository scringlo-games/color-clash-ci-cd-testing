using UnityEngine;
using UnityEngine.UI;

namespace ScringloGames.ColorClash.Runtime.PlayerCharacter
{
    public class HealthDisplay : MonoBehaviour
    {
        [field: SerializeField]
        private HealthHandler healthHandler;
        [SerializeField]
        private Image healthImageComponent;

        private void OnEnable()
        {
            this.healthHandler.HealthChanged += this.HealthVisual;
        }

        private void OnDisable()
        {
            this.healthHandler.HealthChanged -= this.HealthVisual;
        }
        //divides the current health by max health to return a float value between 0 - 1. This value is then used to 
        //set the fill amount of the indicator image.
        private void HealthVisual(int amount)
        {
            float fill = (float)amount/(float)this.healthHandler.MaxHealth;
            this.healthImageComponent.fillAmount = fill;
        }
    }
}
