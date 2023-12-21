using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Timer
{
    public class Watch : MonoBehaviour
    {
        private const float TimeBeLow = 10f;
        private const float TimeLow = 5f;

        [SerializeField] private TMP_Text _time;
        [SerializeField] private Image _fill;
        [SerializeField] private Color _colorRed;
        [SerializeField] private Color _colorYellow;
        [SerializeField] private Color _currentColor;
        [SerializeField] private Clock _clock;

        private bool _isYellowTimer = true;
        private bool _isRedTimer = true;
        private bool _isGreenTimer = true;

        public event Action ShakeButtonAds;

        private void OnEnable()
        {
            _clock.ChangedTime += OnChangedTime;
        }

        private void OnDisable()
        {
            _clock.ChangedTime -= OnChangedTime;
        }

        private void OnChangedTime(int second)
        {
            _time.text = second.ToString();
            _fill.fillAmount = Mathf.InverseLerp(0, _clock.Duration, second);
            SetColor(second);
        }

        private void SetColor(int second)
        {
            if (second > TimeBeLow && _isGreenTimer)
            {
                ChangeColor(_currentColor);
                _isGreenTimer = false;
                _isYellowTimer = true;
                _isRedTimer = false;
            }
            else if (second <= TimeBeLow && second > TimeLow && _isYellowTimer && _isRedTimer == false)
            {
                ChangeColor(_colorYellow);
                ShakeButtonAds?.Invoke();
                _isGreenTimer = true;
                _isYellowTimer = false;
                _isRedTimer = true;
            }
            else if (second <= TimeLow && _isRedTimer && _isYellowTimer == false)
            {
                ChangeColor(_colorRed);
                ShakeButtonAds?.Invoke();
                _isGreenTimer = true;
                _isYellowTimer = true;
                _isRedTimer = false;
            }
        }

        private void ChangeColor(Color color)
        {
            _time.color = color;
            _fill.color = color;
        }
    }
}