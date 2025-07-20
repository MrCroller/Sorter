using UnityEngine;

namespace Sorter
{
    public static class UIExtension
    {
        public static Color SetAlpha(this SpriteRenderer spriteRenderer, float alpha)
        {
            var normalize = Mathf.Clamp01(alpha);
            var oldColor = spriteRenderer.color;
            return new(oldColor.r, oldColor.g, oldColor.b, normalize);
        }

    }
}
