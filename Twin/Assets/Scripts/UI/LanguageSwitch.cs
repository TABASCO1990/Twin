using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanguageSwitch : MonoBehaviour
{
    [SerializeField] private Sprite[] _flags;
    [SerializeField] private Image _imageFlag;

    private int indexFlag;

    private void Start()
    {
        indexFlag = 0;
    }

    public void NextLanguage()
    {
        indexFlag++;

        for (int i = 0; i < _flags.Length; i++)
        {
            _imageFlag.sprite = _flags[indexFlag];
        }

        print(indexFlag);
    }

    public void PreviousLanguage()
    {
        indexFlag--;

        for (int i = 0; i < _flags.Length; i++)
        {
            _imageFlag.sprite = _flags[indexFlag];
        }

        print(indexFlag);
    }
}
