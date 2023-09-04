using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Locations _location;
    [SerializeField] private Clock _clock;
    [SerializeField] private StageScreen _mainScreen;
    [SerializeField] private MobileInput _mobileInput;
    [SerializeField] private GameOverScreen _gameOverScreen;
    [SerializeField] private PauseScreen _pauseScreen;
    [SerializeField] private LevelComplete _levelCompleteScreen;
    [SerializeField] private ActivationStages _activationStages;

    [Header("Stages")]
    [SerializeField] private Launcher _launcherStage_1;
    [SerializeField] private Launcher _launcherStage_2;
    [SerializeField] private Launcher _launcherStage_3;
    [SerializeField] private Launcher _launcherStage_4;
    [SerializeField] private Launcher _launcherStage_5;
    [SerializeField] private Launcher _launcherStage_6;
    [SerializeField] private Launcher _launcherStage_7;

    [Header("Current stage")]
    [SerializeField] private Stage _stage;

    [DllImport("__Internal")]
    private static extern void ExitGame();

    private void OnEnable()
    {      
        _launcherStage_1.InitializeStage += OnPlayButtonClick;
        _launcherStage_2.InitializeStage += OnPlayButtonClick;
        _launcherStage_3.InitializeStage += OnPlayButtonClick;
        _launcherStage_4.InitializeStage += OnPlayButtonClick;
        _launcherStage_5.InitializeStage += OnPlayButtonClick;
        _launcherStage_6.InitializeStage += OnPlayButtonClick;
        _launcherStage_7.InitializeStage += OnPlayButtonClick;
        _gameOverScreen.RestartButtonClock += OnRestartButtonClick;
        _pauseScreen.ContinueButtonClick += OnContinueButtonClick;
        _player.GameOver += OnGameOver;   
        _player.LevelCompleted += OnLevelCompleted;     
    }

    private void OnDisable()
    {
        _launcherStage_1.InitializeStage -= OnPlayButtonClick;
        _launcherStage_2.InitializeStage -= OnPlayButtonClick;
        _launcherStage_3.InitializeStage -= OnPlayButtonClick;
        _launcherStage_4.InitializeStage -= OnPlayButtonClick;
        _launcherStage_5.InitializeStage -= OnPlayButtonClick;
        _launcherStage_6.InitializeStage -= OnPlayButtonClick;
        _launcherStage_7.InitializeStage -= OnPlayButtonClick;
        _gameOverScreen.RestartButtonClock -= OnRestartButtonClick;
        //_settingScreen.SettingButtonClick -= OnSettingButtonClick;
        _pauseScreen.ContinueButtonClick -= OnContinueButtonClick;
        _player.GameOver -= OnGameOver;
        _player.LevelCompleted -= OnLevelCompleted;    
    }

    private void Start()
    {
        Time.timeScale = 0;
        _mainScreen.Open();
    }

    private void OnPlayButtonClick(Stage stage)
    {
        _location.ResetStages();
        _stage = stage;
        StartGame();   
    }

    public void OnRestartButtonClick()
    {
        ResetAll();
        _gameOverScreen.Close();
        StartGame();
    }

    private void ResetAll()
    {
        _mobileInput.ResetJoystic();
        _stage.ResetPool();       
        _stage.GetComponent<PlayerColor>().ResetColors();
        _stage.GetComponent<ObstacleColor>().ResetColors();
        _clock.ResetTime();
    }

    private void StartGame()
    {             
        Time.timeScale = 1;
        _stage.GetComponentInChildren<Plant>().ResetTile();
        _player.ResetPlayer();
        _clock.ResetTime();
    }

    private void OnGameOver()
    {
        Time.timeScale = 0;
        _gameOverScreen.Open();
    }

    private void OnLevelCompleted()
    {
        StartCoroutine(DelayShowScreen());
    }

    IEnumerator DelayShowScreen()
    {
        _player.GetComponent<PlayerMover>().enabled = false;
        _activationStages.InitializeStage();
        yield return new WaitForSeconds(2.0f);
        Time.timeScale = 0;
        ResetAll();      
        _levelCompleteScreen.Open();
        _player.GetComponent<PlayerMover>().enabled = true;
    }

    private void OnContinueButtonClick()
    {
        Time.timeScale = 1;
        _pauseScreen.Close();
    }

    public void ExitPlay()
    {
        ExitGame();
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
