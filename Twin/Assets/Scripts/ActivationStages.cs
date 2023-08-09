using UnityEngine;
using UnityEngine.Events;

public class ActivationStages : MonoBehaviour
{
    [SerializeField] private Launcher[] _launchers;
    [SerializeField] private Locations _locations;
    public event UnityAction<int> StageChanged;

    private int _currentStage;

    private void Start()
    {
        _launchers[_currentStage].enabled = true;
    }

    public void InitializeStage()
    {
        if (_locations._numberLevel == _currentStage)
        {
            _currentStage++;

            if (_currentStage < _launchers.Length)
            {
                _launchers[_currentStage].enabled = true;
            }
            else
            {
                print("Поздравляем! Вы прошли эту игру.");
            }
        }
        else
        {
            print("Это старый уровень.");
        }

        StageChanged?.Invoke(_locations._numberLevel + 1);
    }
}
