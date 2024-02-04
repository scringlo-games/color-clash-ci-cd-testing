using ScringloGames.ColorClash.Runtime.Weapons;
using UnityEngine;
using UnityEngine.UI;

namespace ScringloGames.ColorClash.Runtime.UI
{
    public class WeaponSwapHUD : MonoBehaviour
    {
        [SerializeField]
        private ProjectileSwapper swapper;
        [SerializeField]
        private Image redDarkener;
        [SerializeField]
        private Image blueDarkener;
        [SerializeField]
        private Image yellowDarkener;

        private void OnEnable()
        {
            this.swapper.Swapped += this.OnSwapped;
        }

        private void OnDisable()
        {
            this.swapper.Swapped -= this.OnSwapped;
        }
        
        private void OnSwapped()
        {
            switch (this.swapper.CurrentIndex)
            {
                case 0:
                    this.redDarkener.gameObject.SetActive(false);
                    this.blueDarkener.gameObject.SetActive(true);
                    this.yellowDarkener.gameObject.SetActive(true);
                    break;
                case 1:
                    this.redDarkener.gameObject.SetActive(true);
                    this.blueDarkener.gameObject.SetActive(false);
                    this.yellowDarkener.gameObject.SetActive(true);
                    break;
                case 2:
                    this.redDarkener.gameObject.SetActive(true);
                    this.blueDarkener.gameObject.SetActive(true);
                    this.yellowDarkener.gameObject.SetActive(false);
                    break;
                default:
                    this.redDarkener.gameObject.SetActive(true);
                    this.blueDarkener.gameObject.SetActive(true);
                    this.yellowDarkener.gameObject.SetActive(true);
                    break;
            }
        }
    }
}
