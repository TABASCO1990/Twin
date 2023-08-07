using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locations : MonoBehaviour
{
    [SerializeField] private Stage[] _stages;

    private int _numberLevel;

    public Stage GetStage()
    {
        _stages[0].gameObject.SetActive(true);
        Stage level = _stages[0];
        return level;
    }  
    
    public void SetNumberStage(int number)
    {
        _numberLevel = number;
    }
}
