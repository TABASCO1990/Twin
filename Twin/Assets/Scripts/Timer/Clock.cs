using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Clock : MonoBehaviour
{
    [SerializeField] private int _duration;
    [SerializeField] private int _currentTime;
    [SerializeField] private Player _player;

    private Coroutine _corotineTimer;

    public event UnityAction<int> ChangedTime;
    public int Duration => _duration;

    private void Awake()
    {
        _currentTime = _duration;
    }

    private void OnEnable()
    {
        _player.TimeChanged += OnTimeChanged;
        _player.LevelCompleted += OnLevelComplete;
    }

    private void OnDisable()
    {
        _player.TimeChanged -= OnTimeChanged;
        _player.LevelCompleted -= OnLevelComplete;
    }

    private IEnumerator UpdateTime()
    {
        ChangedTime?.Invoke(_currentTime);

        while (_currentTime > 0)
        {
            yield return new WaitForSeconds(1f);
            _currentTime--;
            ChangedTime?.Invoke(_currentTime);
        }
        yield return null;

        _player.Die();
    }

    private void OnLevelComplete()
    {
        StopCoroutine(UpdateTime());
    }

    private void OnTimeChanged(float time)
    {
        _currentTime += (int)time;

        if (_currentTime > _duration)
        {
            _currentTime = _duration;
        }

        ChangedTime?.Invoke(_currentTime);
    }

    public void ResetTime()
    {
        _currentTime = _duration;
        StartTime();
    }

    private void StartTime()
    {
        if (_corotineTimer != null)
        {
            StopCoroutine(_corotineTimer);
        }

        _corotineTimer = StartCoroutine(UpdateTime());
    }
}
