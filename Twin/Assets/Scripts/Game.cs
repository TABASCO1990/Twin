using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Locations _location;
    [SerializeField] private Timer _timer;
    [SerializeField] private StageScreen _mainScreen;
    [SerializeField] private MobileInput _mobileInput;
    [SerializeField] private GameOverScreen _gameOverScreen;
    [SerializeField] private PauseScreen _pauseScreen;
    [SerializeField] private LevelComplete _levelCompleteScreen;
    //[SerializeField] private SettingScreen _settingScreen;
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
        //_settingScreen.SettingButtonClick += OnSettingButtonClick;
        _pauseScreen.ContinueButtonClick += OnContinueButtonClick;
        _player.GameOver += OnGameOver;   
        _player.LevelComplete += OnLevelComplete;     
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
        _player.LevelComplete -= OnLevelComplete;    
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

    /*public void OnSettingButtonClick()
    {
        _settingScreen.Open();
    }*/

    private void ResetAll()
    {
        _mobileInput.ResetJoystic();
        _stage.ResetPool();       
        _stage.GetComponent<PlayerColor>().ResetColors();
        _stage.GetComponent<ObstacleColor>().ResetColors();
        _timer.ResetTime();      
    }

    private void StartGame()
    {             
        Time.timeScale = 1;
        _stage.GetComponentInChildren<Plant>().ResetTile();
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
        ResetAll();   
        _levelCompleteScreen.Open();
        _activationStages.InitializeStage();     
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
