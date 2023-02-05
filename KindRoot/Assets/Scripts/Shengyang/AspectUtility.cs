using UnityEngine;

public class AspectUtility
{
    public static Rect AdjustRect(Rect rect, float aspect)
    {
        float windowAspect = (float)Screen.width / (float)Screen.height;
        float scaleHeight = windowAspect / aspect;
        rect.width *= scaleHeight;
        rect.y *= (1.0f - scaleHeight) / 2.0f;

        return rect;
    }
}