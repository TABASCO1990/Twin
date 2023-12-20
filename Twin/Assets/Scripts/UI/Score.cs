using TMPro;
using UnityEngine;

namespace UI
{
    public class Score : MonoBehaviour
    {
        [SerializeField] private Player.Player _player;
        [SerializeField] private TMP_Text _score;
        [SerializeField] private TMP_Text _scoreCount;

        private void Awake()
        {
            _score.text = "0";
        }

        private void OnEnable()
        {
            _player.ScoreChanging += OnScoreChanged;
            _player.ScoreCountChanging += OnScoreCountChanged;
        }

        private void OnDisable()
        {
            _player.ScoreChanging -= OnScoreChanged;
            _player.ScoreCountChanging -= OnScoreCountChanged;
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
}
