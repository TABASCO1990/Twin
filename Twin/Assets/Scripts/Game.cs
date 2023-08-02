using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Location _location;
    //[SerializeField] private Plant _plant;
    //[SerializeField] private PlayerColor _playerColor;
    //[SerializeField] private ObstacleColor _obstacleColor;
    [SerializeField] private Timer _timer;
    [SerializeField] private MainScreen _mainScreen;
    [SerializeField] private MobileInput _mobileInput;
    [SerializeField] private GameOverScreen _gameOverScreen;
    [SerializeField] private PauseScreen _pauseScreen;
    [SerializeField] private LevelComplete _levelCompleteScreen;

    private void OnEnable()
    {
        _mainScreen.PlayButtonClick += OnPlayButtonClick;
        _gameOverScreen.RestartButtonClock += OnRestartButtonClick;
        _pauseScreen.ContinueButtonClick += OnContinueButtonClick;
        _player.GameOver += OnGameOver;
        _location.LevelComplete += OnLevelComplete;
    }

    private void OnDisable()
    {
        _mainScreen.PlayButtonClick -= OnPlayButtonClick;
        _gameOverScreen.RestartButtonClock -= OnRestartButtonClick;
        _pauseScreen.ContinueButtonClick -= OnContinueButtonClick;
        _player.GameOver -= OnGameOver;
        _location.LevelComplete -= OnLevelComplete;
    }

    private void Start()
    {
        Time.timeScale = 0;
        _mainScreen.Open();
    }

    private void OnPlayButtonClick()
    {
        _mainScreen.Close();
        StartGame();
    }

    public void OnRestartButtonClick()
    {
        _location.ResetPool();
        _location.GetComponentInChildren<Plant>().ResetTile();
        _location.GetComponent<PlayerColor>().ResetColors();
        _location.GetComponent<ObstacleColor>().ResetColors();
        _timer.ResetTime();
        _mobileInput.ResetJoystic();
        _gameOverScreen.Close();
        StartGame();
    }

    private void StartGame()
    {
        Time.timeScale = 1;
        _player.ResetPlayer();
    }

    private void OnGameOver()
    {
        Time.timeScale = 0;
        _gameOverScreen.Open();
    }

    private void OnLevelComplete()
    {
        Time.timeScale = 0;
        _levelCompleteScreen.Open();
    }

    private void OnContinueButtonClick()
    {
        Time.timeScale = 1;
        _pauseScreen.Close();
    }

    public void ExitPlay()
    {
        print("Выход");
        Application.Quit();
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
