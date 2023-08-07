using UnityEngine;
using UnityEngine.UI;

public class StageLogger : MonoBehaviour
{
    [SerializeField] private StageScreen _stageScreen;
    [SerializeField] private int _number;
    [SerializeField] private Locations _location;

    public void InitiateNumber()
    {
        _location.SetNumberStage(_number);
        print("re");
    }
}
