using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseScreen : ScreenMenu
{
    [SerializeField] private Button _pauseButton;
    [SerializeField] private GameObject _joysticField;

    public void OnContinueButtonClick()
    {
        _canvasGroup.alpha = 0;
        Time.timeScale = 1;
        _pauseButton.gameObject.SetActive(true);
        _joysticField.SetActive(true);
    }
}
