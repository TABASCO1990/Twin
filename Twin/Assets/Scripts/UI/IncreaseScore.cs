using UnityEngine;
using DG.Tweening;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class IncreaseScore : MonoBehaviour
{
    [SerializeField] private Player _player;

    private TMP_Text _score;
    private float _duration = 0.3f;
    private int _countLoops = 2;

    private void Awake()
    {
        _score = GetComponent<TMP_Text>();
    }

    private void OnEnable()
    {
        _player.ScoreChanged += OnScoreChanged;
    }

    private void OnDisable()
    {
        _player.ScoreChanged -= OnScoreChanged;
    }

    public void OnScoreChanged(int value)
    {
        _score.DOColor(Color.white, _duration).SetLoops(_countLoops, LoopType.Yoyo);
    }
}
