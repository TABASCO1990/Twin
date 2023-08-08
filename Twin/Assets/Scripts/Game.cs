using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Locations _location;
    [SerializeField] private Timer _timer;
    [SerializeField] private MainScreen _mainScreen;
    [SerializeField] private GameObject _stageScreen;
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
   
    private void OnEnable()
    {      
        _launcherStage_1.InitializeStage += OnPlayButtonClick;// заработало потомучто поставил ввер
        _launcherStage_2.InitializeStage += OnPlayButtonClick;// заработало потомучто поставил ввер
        _launcherStage_3.InitializeStage += OnPlayButtonClick;// заработало потомучто поставил ввер
        _launcherStage_4.InitializeStage += OnPlayButtonClick;// заработало потомучто поставил ввер
        _launcherStage_5.InitializeStage += OnPlayButtonClick;// заработало потомучто поставил ввер
        _launcherStage_6.InitializeStage += OnPlayButtonClick;// заработало потомучто поставил ввер
        _launcherStage_7.InitializeStage += OnPlayButtonClick;// заработало потомучто поставил ввер

        _gameOverScreen.RestartButtonClock += OnRestartButtonClick;
        _pauseScreen.ContinueButtonClick += OnContinueButtonClick;
        _player.GameOver += OnGameOver;
        
        _player.LevelComplete += OnLevelComplete;     
    }


    private void OnDisable()
    {
        _launcherStage_1.InitializeStage -= OnPlayButtonClick;
        _launcherStage_2.InitializeStage -= OnPlayButtonClick;// заработало потомучто поставил ввер
        _launcherStage_3.InitializeStage -= OnPlayButtonClick;// заработало потомучто поставил ввер
        _launcherStage_4.InitializeStage -= OnPlayButtonClick;// заработало потомучто поставил ввер
        _launcherStage_5.InitializeStage -= OnPlayButtonClick;// заработало потомучто поставил ввер
        _launcherStage_6.InitializeStage -= OnPlayButtonClick;// заработало потомучто поставил ввер
        _launcherStage_7.InitializeStage -= OnPlayButtonClick;
        _gameOverScreen.RestartButtonClock -= OnRestartButtonClick;
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
        _stage = stage;
        _stageScreen.SetActive(false);
        StartGame();   
    }

    public void OnRestartButtonClick()
    {
        ResetAll();
        _mobileInput.ResetJoystic();
        _gameOverScreen.Close();
        StartGame();
    }

    private void ResetAll()
    {
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
        _location.ResetStages();
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
