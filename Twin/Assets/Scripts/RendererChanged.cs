using UnityEngine;

public class RendererChanged : MonoBehaviour
{
    [SerializeField] private Color[] _colors;
    [SerializeField] private Material _material;

    private int colorValue;
    private int startColorIndex = 0;
    private string shadedName = "_ColorDim";  

    private void Start()
    {
        _material.color = _colors[startColorIndex];
        SetShaded();
    }

    public void SetColor()
    {
        colorValue++;

        if (colorValue > _colors.Length - 1)
        {
            colorValue = startColorIndex;
        }

        _material.color = _colors[colorValue];
        SetShaded();
    }

    private void SetShaded()
    {
        float _value = 0.66f;

        Color.RGBToHSV(_colors[colorValue], out float H, out float S, out float V);
        Color color = Color.HSVToRGB(H, S, _value);
        _material.SetColor(shadedName, color);       
    }
}
