using UnityEngine;
using UnityEngine.Events;

public class ActivationStages : MonoBehaviour
{
    [SerializeField] private Launcher[] _launchers;
    [SerializeField] private Locations _locations;
    [SerializeField] private Sprite _spriteActive;

    private int _countActiveSprites;
    private int _currentStage;

    public event UnityAction<int> StageChanged;

    public int CurrentStage => _currentStage;

    private void Start()
    {
        _launchers[_currentStage].enabled = true;
    }

    public void ActiveSprites(int count)
    {
        for (int i = 0; i < count; i++)
        {
            _launchers[i].enabled = true;
            _launchers[i].SetButtonSprite(_spriteActive);
        }
        
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
                _countActiveSprites++;
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
