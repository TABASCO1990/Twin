using UnityEngine;

public class RendererChanged : MonoBehaviour
{
    [SerializeField] private Color[] _colors;
    [SerializeField] private Material _material;

    private int _colorValue;
    private int _startColorIndex = 0;
    private string _shadedName = "_ColorDim";  

    private void Start()
    {
        _material.color = _colors[_startColorIndex];
        SetShaded();
    }

    public void SetColor()
    {
        _colorValue++;

        if (_colorValue > _colors.Length - 1)
        {
            _colorValue = _startColorIndex;
        }

        _material.color = _colors[_colorValue];
        SetShaded();
    }

    public void ResetColors()
    {
        _colorValue = _startColorIndex;
        _material.color = _colors[_colorValue];
        SetShaded();
    }

    private void SetShaded()
    {
        float _value = 0.66f;
        Color.RGBToHSV(_colors[_colorValue], out float H, out float S, out float V);
        Color color = Color.HSVToRGB(H, S, _value);
        _material.SetColor(_shadedName, color);       
    }  
}
