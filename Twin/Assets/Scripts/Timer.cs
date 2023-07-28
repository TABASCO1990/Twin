using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
        ChangeTimeColor(_startColorTimer);
        BeginTime(_duration);
    }

    private void Update()
    {
        UpdateTimer();
    }

    public void ResetTime()
    {
        _remainingDuration = _duration;
        ChangeTimeColor(_startColorTimer);
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
            SetColor();
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

    private void SetColor()
    {
        if (_time.text == TimeBeLow.ToString())
            ChangeTimeColor(Color.yellow);
        else if(_time.text == TimeLow.ToString())
            ChangeTimeColor(_colorLowTime);
    }

    private void ChangeTimeColor(Color color)
    {
        _time.color = color;
        _fill.color = color;
    }
}

