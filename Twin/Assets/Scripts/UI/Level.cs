using TMPro;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private Locations _location;
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
        _stage.text = (stage+1).ToString();
    }
}
