using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public abstract class ScreenMenu : MonoBehaviour
{
    [SerializeField] protected CanvasGroup _canvasGroup;
    [SerializeField] protected Button _settingsButton;
    [SerializeField] protected Button _exitButton;
    [SerializeField] protected Button _restartButton;

    private void OnEnable()
    {
        _settingsButton.onClick.AddListener(OnSettingsButtonClick);
        _exitButton.onClick.AddListener(OnExitButtonClick);
        _restartButton.onClick.AddListener(OnRestartButtonClick);
    }

    private void OnDisable()
    {
        _settingsButton.onClick.RemoveListener(OnSettingsButtonClick);
        _exitButton.onClick.RemoveListener(OnExitButtonClick);
        _restartButton.onClick.RemoveListener(OnRestartButtonClick);
    }

    public void OnSettingsButtonClick()
    {
        print("Настройки");
    }

    public void OnExitButtonClick()
    {
        print("Выход");
    }

    public void OnRestartButtonClick()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
