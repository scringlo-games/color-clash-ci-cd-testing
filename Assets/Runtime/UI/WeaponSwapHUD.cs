using System;
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
        }

        private void OnDisable()
        {
        }
    }
}
