using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _score;
    [SerializeField] private TMP_Text _scoreCount;

    private void Awake()
    {
        _score.text = "0";
    }

    private void OnEnable()
    {
        _player.ScoreChanged += OnScoreChanged;
        _player.ScoreCountChanged += OnScoreCountChanged;
    }

    private void OnDisable()
    {
        _player.ScoreChanged -= OnScoreChanged;// Почемуто небыло
        _player.ScoreCountChanged -= OnScoreCountChanged;
    }

    private void OnScoreChanged(int score)
    {
        _score.text = score.ToString();
    }

    private void OnScoreCountChanged(int count)
    {
        _scoreCount.text = count.ToString();
    }
}
