using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locations : MonoBehaviour
{
    [SerializeField] private Level[] _levels;

    private int _numberLevel;

    public int NumberLevel => _numberLevel;

    public Level GetLevel()
    {
        _levels[0].gameObject.SetActive(true);
        Level level = _levels[0];
        return level;
    }   
}
