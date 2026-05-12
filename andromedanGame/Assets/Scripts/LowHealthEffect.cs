using UnityEngine;
using UnityEngine.UI;

public class LowHealthEffect : MonoBehaviour
{
    public Image overlay;

    private void Start()
    {
        SetOpacityPercent(0);
    }

    public void SetOpacityPercent(float percent)
    {
        if (overlay)
        {
            float calculatedAlpha = 15 * (percent / 100) / 255;

            Color c = overlay.color;
            c.a = calculatedAlpha;
            overlay.color = c;
        }
    }
}
