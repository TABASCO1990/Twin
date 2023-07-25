using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class PauseScreen : MonoBehaviour
{
    [SerializeField] private Button _settingsButton;
    [SerializeField] private Button _continueButton;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private Button _pauseButton;
    [SerializeField] private GameObject _joysticField;

    private CanvasGroup _group;

    private void OnEnable()
    {
        _settingsButton.onClick.AddListener(OnSettingsButton);
        _continueButton.onClick.AddListener(OnContinueButtonClick);
        _restartButton.onClick.AddListener(OnRestartButtonClick);
        _exitButton.onClick.AddListener(OnExitButtonClick);
    }

    private void OnDisable()
    {
        _settingsButton.onClick.RemoveListener(OnSettingsButton);
        _continueButton.onClick.RemoveListener(OnContinueButtonClick);
        _restartButton.onClick.RemoveListener(OnRestartButtonClick);
        _exitButton.onClick.RemoveListener(OnExitButtonClick);
    }

    private void Start()
    {
        _group = GetComponent<CanvasGroup>();
        _group.alpha = 0;
    }

    private void OnSettingsButton()
    {
        print("Найстройки");
    }

    private void OnContinueButtonClick()
    {
        _group.alpha = 0;
        Time.timeScale = 1;
        _pauseButton.gameObject.SetActive(true);
        _joysticField.SetActive(true);
    }

    private void OnRestartButtonClick()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    private void OnExitButtonClick()
    {
        Application.Quit();
    }
}
