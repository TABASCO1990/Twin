using TMPro;
using UnityEngine;

public class ResultStage : MonoBehaviour
{
    [SerializeField] private PlayerRank _playerRank;
    [SerializeField] private TMP_Text _rank;

    private void OnEnable()
    {
        _playerRank.RatingChanged += OnRatingChanged;
    }

    private void OnDisable()
    {
        _playerRank.RatingChanged -= OnRatingChanged;
    }

    private void OnRatingChanged(int ranting)
    {
        _rank.text = ranting.ToString();     
    }
}
