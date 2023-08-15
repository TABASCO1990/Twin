using UnityEngine;
using DG.Tweening;
using TMPro;

[RequireComponent(typeof(CanvasGroup))]
[RequireComponent(typeof(TMP_Text))]
public class IncreaseTime : MonoBehaviour
{
    [SerializeField] private Player _player;

    private TMP_Text _time;
    private CanvasGroup _canvasGroupTime;
    private float _duration = 0.3f;
    private float _targetValue = 1.0f;
    private int _countLoops = 2;

    private void OnEnable()
    {
        _player.TimeChanged += OnTimeChanged;
    }

    private void OnDisable()
    {
        _player.TimeChanged -= OnTimeChanged;
    }

    private void Start()
    {
        _canvasGroupTime = GetComponent<CanvasGroup>();
        _time = GetComponent<TMP_Text>();
    }

    public void OnTimeChanged(float value)
    {
        _time.text = "+" + value;
        _canvasGroupTime.DOFade(_targetValue, _duration).SetLoops(_countLoops, LoopType.Yoyo);
    }
}
