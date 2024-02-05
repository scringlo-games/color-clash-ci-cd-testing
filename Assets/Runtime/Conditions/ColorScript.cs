using System.Linq;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Conditions
{
    /// <summary>
    /// Sets color to lerp between all stored colors.
    /// </summary>
    public class ColorScript : MonoBehaviour
    {
        private ConditionBank conditionBank;
        private SpriteRenderer spriteRenderer;
        private bool disableOnDisable = false;
        
        private void OnEnable()
        {
            if (this.TryGetComponent(out ConditionBank conditionBank) && 
                this.TryGetComponent(out SpriteRenderer spriteRenderer))
            {
                disableOnDisable = true;
                this.conditionBank = conditionBank;
                this.spriteRenderer = spriteRenderer;
                conditionBank.Applied += this.OnAppliedOrExpired;
                conditionBank.Expired += this.OnAppliedOrExpired;
            }
        }

        private void OnDisable()
        {
            if (disableOnDisable)
            {
                conditionBank.Applied -= this.OnAppliedOrExpired;
                conditionBank.Expired -= this.OnAppliedOrExpired;
            }
        }

        private void OnAppliedOrExpired(Condition obj)
        {
            UpdateColor();
        }

        private void UpdateColor()
        {
            var redCounter = conditionBank.Conditions
                .OfType<DOTCondition>()
                .Count();
            var blueCounter = conditionBank.Conditions
                .OfType<SlowCondition>()
                .Count();
            Color newColor = new Color();
            if (redCounter > 0 && blueCounter > 0)
            {
                newColor = new Color(255, 0, 255, 255);
            }
            else if (redCounter <= 0 && blueCounter > 0)
            {
                newColor = Color.blue;
            }
            else if (redCounter > 0 && blueCounter <= 0)
            {
                newColor = Color.red;
            }
            else
            {
                newColor = Color.white;
            }

            spriteRenderer.color = newColor;
        }
    }
}
