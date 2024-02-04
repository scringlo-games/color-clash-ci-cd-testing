using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Shared
{
    public static class LayerMaskExtensions
    {
        public static bool IncludesLayer(this LayerMask layerMask, int layer)
        {
            return (layerMask.value & 1 << layer) > 0;
        }
    }
}
