using Shared;
using UnityEngine;

namespace Levels
{
    public class RendererChanged : MonoBehaviour
    {
        [SerializeField] private Color[] _colors;
        [SerializeField] private Material _material;
        [SerializeField] private Game _game;

        private int _colorValue;
        private int _startColorIndex = 0;
        private string _shadedName = "_ColorDim";

        private void OnEnable()
        {
            _game.ColorReseted += OnColorReseted;
        }

        private void OnDisable()
        {
            _game.ColorReseted -= OnColorReseted;
        }

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

        public void OnColorReseted()
        {
            _colorValue = _startColorIndex;
            _material.color = _colors[_colorValue];
            SetShaded();
        }

        private void SetShaded()
        {
            float value = 0.66f;
            Color.RGBToHSV(_colors[_colorValue], out float h, out float s, out float v);
            Color color = Color.HSVToRGB(h, s, value);
            _material.SetColor(_shadedName, color);
        }
    }
}