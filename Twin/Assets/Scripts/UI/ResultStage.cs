using TMPro;
using UnityEngine;

namespace UI
{
    public class ResultStage : MonoBehaviour
    {
        [SerializeField] private PlayerRank _playerRank;
        [SerializeField] private Clock _clock;
        [SerializeField] private TMP_Text _rank;
        [SerializeField] private TMP_Text _time;

        private void OnEnable()
        {
            _clock.FixedTime += OnFixedTime;
            _playerRank.RatingChanged += OnRatingChanged;
        }

        private void OnDisable()
        {
            _clock.FixedTime -= OnFixedTime;
            _playerRank.RatingChanged -= OnRatingChanged;
        }

        private void OnRatingChanged(int ranting)
        {
            _rank.text = ranting.ToString();
        }

        private void OnFixedTime(int time)
        {
            _time.text = _clock.RemainingTime.ToString();
        }
    }
}