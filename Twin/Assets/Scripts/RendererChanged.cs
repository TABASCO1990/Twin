using UnityEngine;
using UnityEditor;

public class RendererChanged : MonoBehaviour
{
    [SerializeField] private Color[] _colors;
    [SerializeField] private Material _material;

    private int colorValue;
    private int startColorIndex = 0;
     

    private void Start()
    {
        _material.color = _colors[startColorIndex];
    }

    public void SetColor()
    {
        colorValue++;

        if (colorValue > _colors.Length - 1)
        {
            colorValue = startColorIndex;
        }

        _material.color = _colors[colorValue];
        _material.SetColor("_ColorDim", Color.red);



    }

}
