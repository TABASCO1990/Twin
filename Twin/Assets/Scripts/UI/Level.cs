using TMPro;
using UnityEngine;

namespace UI
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private Levels.Locations _location;
        [SerializeField] private TMP_Text _stage;

        private void OnEnable()
        {
            _location.StageInitialised += OnStageChanged;
        }

        private void OnDisable()
        {
            _location.StageInitialised -= OnStageChanged;
        }

        private void OnStageChanged(int stage)
        {
            _stage.text = (stage + 1).ToString();
        }
    }
}