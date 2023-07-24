using UnityEngine;

public class ColorChanged : MonoBehaviour
{
    [SerializeField] private Color[] _colors;
    [SerializeField] private Material _material;

    private int colorValue;
    private int startColorIndex = 0;

    private void Start()
    {
        _material.color = _colors[colorValue];
    }

    public void SetColor()
    {
        colorValue++;

        if (colorValue > _colors.Length - 1)
        {
            colorValue = startColorIndex;
        }

        _material.color = _colors[colorValue];
    }
}
