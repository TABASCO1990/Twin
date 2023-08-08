using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ActivationStages : MonoBehaviour
{
    [SerializeField] private Launcher[] _launchers;

    private int _currentStage = 0;

    private void Start()
    {
        _launchers[_currentStage].enabled = true;
    }

    public void InitializeStage()
    {
        if (_currentStage < _launchers.Length) //Пофиксить
        {
            _currentStage++;
            _launchers[_currentStage].enabled = true;
        }
    }
}
