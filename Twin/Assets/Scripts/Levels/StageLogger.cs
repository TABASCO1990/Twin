using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class StageLogger : MonoBehaviour
{
    [SerializeField] private StageScreen _stageScreen;
    [SerializeField] private int _number;
    [SerializeField] private Locations _location;


    public void InitiateNumber()
    {
        SetData();
    }

    private void SetData()
    {
        _location.SetNumberStage(_number);
        _stageScreen.SetButtonStage(GetComponent<Button>());
    }
}
