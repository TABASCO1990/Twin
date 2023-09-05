using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartInstruction : MonoBehaviour
{
    [SerializeField] private GameObject _navigation;
    [SerializeField] private GameObject _hintTimer;

    public static StartInstruction Instance;

    private void Start()
    {
        Instance = this;
    }

    public void ShowInfo()
    {
        StartCoroutine(SetManual());
    }

    IEnumerator SetManual()
    {       
        _navigation.SetActive(true);
        _hintTimer.SetActive(true);
        yield return new WaitForSeconds(3f); 
        _navigation.SetActive(false);
        _hintTimer.SetActive(false);
    }
}
