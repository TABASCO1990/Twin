using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Locations _location;
    [SerializeField] private Timer _timer;
    [SerializeField] private MainScreen _mainScreen;
    [SerializeField] private StageScreen _stageScreen;
    [SerializeField] private MobileInput _mobileInput;
    [SerializeField] private GameOverScreen _gameOverScreen;
    [SerializeField] private PauseScreen _pauseScreen;
    [SerializeField] private LevelComplete _levelCompleteScreen;

    [SerializeField] private Stage _stage;

    private void Awake()
    {
        _stage = _location.GetStage();
    }

    private void OnEnable()
    {
        _stageScreen.StageButtonClick += OnPlayButtonClick;
        _gameOverScreen.RestartButtonClock += OnRestartButtonClick;
        _pauseScreen.ContinueButtonClick += OnContinueButtonClick;
        _player.GameOver += OnGameOver;
        _stage.LevelComplete += OnLevelComplete;
    }

    private void OnDisable()
    {
        _stageScreen.StageButtonClick -= OnPlayButtonClick;
        _gameOverScreen.RestartButtonClock -= OnRestartButtonClick;
        _pauseScreen.ContinueButtonClick -= OnContinueButtonClick;
        _player.GameOver -= OnGameOver;
        _stage.LevelComplete -= OnLevelComplete;
    }

    private void Start()
    {
        Time.timeScale = 0;
        _mainScreen.Open();
    }

    private void OnPlayButtonClick()
    {
        _stageScreen.Close();
        StartGame();
    }

    public void OnRestartButtonClick()
    {
        _stage.ResetPool();
        _stage.GetComponentInChildren<Plant>().ResetTile();
        _stage.GetComponent<PlayerColor>().ResetColors();
        _stage.GetComponent<ObstacleColor>().ResetColors();
        _timer.ResetTime();
        _mobileInput.ResetJoystic();
        _gameOverScreen.Close();
        StartGame();
    }

    private void StartGame()
    {
        Time.timeScale = 1;
        _player.ResetPlayer();
        _stage = _location.GetStage();
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
