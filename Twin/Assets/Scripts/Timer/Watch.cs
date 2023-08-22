using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Watch : MonoBehaviour
{
    [SerializeField] private TMP_Text _time;
    [SerializeField] private Image _fill;
    [SerializeField] private Color _colorRed;
    [SerializeField] private Color _colorYellow;
    [SerializeField] private Color _currentColor;

    [SerializeField] private Clock _clock;

    private const float TimeBeLow = 10f;
    private const float TimeLow = 5f;
    private bool _isYellowTimer = true;
    private bool _isRedTimer = true;
    private bool _isGreenTimer = true;

    public event UnityAction ShakeButtonAds;

    private void Awake()
    {
        _currentColor = _fill.color;
    }

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