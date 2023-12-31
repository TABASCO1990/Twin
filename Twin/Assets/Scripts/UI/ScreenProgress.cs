using TMPro;
using UnityEngine;

namespace UI
{
    public class ScreenProgress : MonoBehaviour
    {
        [SerializeField] private TMP_Text[] _scoreStage;
        [SerializeField] private TMP_Text _sumScoreSelectedScreen;
        [SerializeField] private TMP_Text _sumScoreGameScreen;
        [SerializeField] private TMP_Text _sumScoreLevelCompleteScreen;
        [SerializeField] private Shared.Progress _progress;

        private void OnEnable()
        {
            _progress.CalculateScore += OnCalculateScore;
        }

        private void OnDisable()
        {
            _progress.CalculateScore -= OnCalculateScore;
        }

        private void OnCalculateScore(int score, int index, int sumscore)
        {
            _scoreStage[index].text = score.ToString();
            _sumScoreSelectedScreen.text = sumscore.ToString();
            _sumScoreGameScreen.text = sumscore.ToString();
            _sumScoreLevelCompleteScreen.text = sumscore.ToString();
        }
    }
}
