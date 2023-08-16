using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    private const float TimeBeLow = 10f;
    private const float TimeLow = 5f;

    [SerializeField] private Image _fill;
    [SerializeField] private TMP_Text _time;
    [SerializeField] private Color _colorLowTime;
    [SerializeField] private int _duration;
    [SerializeField] private float _remainingDuration;
    [SerializeField] private Player _player;

    private Color _startColorTimer;
    private bool _isYellowTimer = true;
    private bool _isRedTimer = true;
    private bool _isGreenTimer = true;

    public event UnityAction SizeChanged;

    private void OnEnable()
    {
        _player.TimeChanged += OnTimeChanged;
    }

    private void OnDisable()
    {
        _player.TimeChanged -= OnTimeChanged;
    }

    private void Awake()
    {
        _startColorTimer = _fill.color;
        ChangeColor(_startColorTimer);
        BeginTime(_duration);
    }

    private void Update()
    {
        UpdateTimer();
    }

    public void ResetTime()
    {
        _remainingDuration = _duration;
        ChangeColor(_startColorTimer);
    }

    private void BeginTime(int second)
    {
        _remainingDuration = second;
    }

    private void UpdateTimer()
    {
        if (_remainingDuration >= 0)
        {
            _remainingDuration -= Time.deltaTime;
            _time.text = Mathf.Round(_remainingDuration).ToString();
            _fill.fillAmount = Mathf.InverseLerp(0, _duration, _remainingDuration);
            SetProperty();
        }
        else
        {
            EndTime();
        }
    }

    private void EndTime()
    {
        if (_remainingDuration <= 0)
            _player.Die();
    }

    private void OnTimeChanged(float time)
    {
        if (_remainingDuration + time > _duration)
            _remainingDuration = _duration;
        else
            _remainingDuration += time;
    }

    private void SetProperty()
    {
        if(_remainingDuration > TimeBeLow && _isGreenTimer)
        {
            ChangeColor(_startColorTimer);
            _isGreenTimer = false;
            _isYellowTimer = true;
            _isRedTimer = false;
        }
        else if (_remainingDuration <= TimeBeLow && _remainingDuration > TimeLow && _isYellowTimer && _isRedTimer == false)
        {
            ChangeColor(Color.yellow);
            SizeChanged?.Invoke();
            _isGreenTimer = true;
            _isYellowTimer = false;
            _isRedTimer = true;         
        }
        else if (_remainingDuration <= TimeLow && _isRedTimer && _isYellowTimer == false)
        {
            ChangeColor(_colorLowTime);
            SizeChanged?.Invoke();
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

