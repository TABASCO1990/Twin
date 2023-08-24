using UnityEngine;
using UnityEngine.Events;

public class ActivationStages : MonoBehaviour
{
    [SerializeField] private Launcher[] _launchers;
    [SerializeField] private Locations _locations;
    [SerializeField] private Sprite _spriteActive;

    private int _currentStage;

    public event UnityAction<int> StageChanged;

    public int CurrentStage => _currentStage;

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
                _launchers[_currentStage].SetButtonSprite(_spriteActive);
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
