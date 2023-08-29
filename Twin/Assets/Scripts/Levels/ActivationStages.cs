using System;
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
        _currentStage = Progress.Inststance.PlayerInfo._countActiveStages;
    }

    private void _countStageActive()
    {
        Progress.Inststance.PlayerInfo._countActiveStages = Math.Max(Progress.Inststance.PlayerInfo._countActiveStages, CurrentStage);

#if !UNITY_EDITOR && UNITY_WEBGL
        Progress.Inststance.Save();
#endif
    }

    public void SetActivatedStages(int count)
    {
        _launchers[count].enabled = true;
        _launchers[count].SetButtonSprite(_spriteActive);
    }

    public void InitializeStage()
    {
        if (_locations._numberLevel == _currentStage)
        {
            _currentStage++;

            if (_currentStage < _launchers.Length)
            {
                _countStageActive();
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
