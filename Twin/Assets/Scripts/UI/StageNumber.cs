using TMPro;
using UnityEngine;

namespace UI
{
    public class StageNumber : MonoBehaviour
    {
        [SerializeField] private Levels.StageSelector _activationStages;
        [SerializeField] private TMP_Text _number;

        private void OnEnable()
        {
            _activationStages.StageChanged += OnStageChanged;
        }

        private void OnDisable()
        {
            _activationStages.StageChanged -= OnStageChanged;
        }

        private void OnStageChanged(int number)
        {
            _number.text = number.ToString();
        }
    }
}
