using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private Button _pauseButton;
    [SerializeField] private GameObject _joysticField;

    public void ActivtePausePanel(CanvasGroup panel)
    {
        panel.alpha = 1;
        _pauseButton.gameObject.SetActive(false);
        _joysticField.SetActive(false);
        Time.timeScale = 0;
    }

    public void OnContinueButtonClick(CanvasGroup group)
    {
        group.alpha = 0;
        Time.timeScale = 1;
        _pauseButton.gameObject.SetActive(true);
        _joysticField.SetActive(true);
    }

    public void OnSettingsButton()
    {
        print("Найстройки");
    }

    public void OnRestartButtonClick()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void OnExitButtonClick()
    {
        Application.Quit();
        print("Выход");
    }
}
