using Levels;
using System;
using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Shared
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private Player.Player _player;
        [SerializeField] private Player.PlayerMover _playerMover;
        [SerializeField] private Locations _location;
        [SerializeField] private Timer.Clock _clock;
        [SerializeField] private UI.StageView _mainScreen;
        [SerializeField] private Controller.MobileInput _mobileInput;
        [SerializeField] private UI.GameOverScreen _gameOverScreen;
        [SerializeField] private UI.PauseScreen _pauseScreen;
        [SerializeField] private UI.LevelComplete _levelCompleteScreen;
        [SerializeField] private StageSelector _activationStages;

        [Header("Stages")]
        [SerializeField] private Launcher _launcherStage_1;
        [SerializeField] private Launcher _launcherStage_2;
        [SerializeField] private Launcher _launcherStage_3;
        [SerializeField] private Launcher _launcherStage_4;
        [SerializeField] private Launcher _launcherStage_5;
        [SerializeField] private Launcher _launcherStage_6;
        [SerializeField] private Launcher _launcherStage_7;
        [SerializeField] private Launcher _launcherStage_8;
        [SerializeField] private Launcher _launcherStage_9;
        [SerializeField] private Launcher _launcherStage_10;

        [Header("Current stage")]
        [SerializeField] private Stage _stage;

        public event Action ColorReseted;

        private void OnEnable()
        {
            _launcherStage_1.InitializeStage += OnPlayButtonClickFirst;
            _launcherStage_2.InitializeStage += OnPlayButtonClick;
            _launcherStage_3.InitializeStage += OnPlayButtonClick;
            _launcherStage_4.InitializeStage += OnPlayButtonClick;
            _launcherStage_5.InitializeStage += OnPlayButtonClick;
            _launcherStage_6.InitializeStage += OnPlayButtonClick;
            _launcherStage_7.InitializeStage += OnPlayButtonClick;
            _launcherStage_8.InitializeStage += OnPlayButtonClick;
            _launcherStage_9.InitializeStage += OnPlayButtonClick;
            _launcherStage_10.InitializeStage += OnPlayButtonClick;
            _gameOverScreen.RestartButtonClock += OnRestartButtonClick;
            _pauseScreen.ContinueButtonClick += OnContinueButtonClick;
            _player.GameOver += OnGameOver;
            _player.LevelCompleted += OnLevelCompleted;
        }

        private void OnDisable()
        {
            _launcherStage_1.InitializeStage -= OnPlayButtonClickFirst;
            _launcherStage_2.InitializeStage -= OnPlayButtonClick;
            _launcherStage_3.InitializeStage -= OnPlayButtonClick;
            _launcherStage_4.InitializeStage -= OnPlayButtonClick;
            _launcherStage_5.InitializeStage -= OnPlayButtonClick;
            _launcherStage_6.InitializeStage -= OnPlayButtonClick;
            _launcherStage_7.InitializeStage -= OnPlayButtonClick;
            _launcherStage_8.InitializeStage -= OnPlayButtonClick;
            _launcherStage_9.InitializeStage -= OnPlayButtonClick;
            _launcherStage_10.InitializeStage -= OnPlayButtonClick;
            _gameOverScreen.RestartButtonClock -= OnRestartButtonClick;
            _pauseScreen.ContinueButtonClick -= OnContinueButtonClick;
            _player.GameOver -= OnGameOver;
            _player.LevelCompleted -= OnLevelCompleted;
        }

        private void Start()
        {
            Time.timeScale = 0;
            _mainScreen.Open();
        }

        public void OnRestartButtonClick()
        {
            ResetAll();
            _gameOverScreen.Close();
            StartGame();
        }

        public void ExitPlay()
        {
            ExitGame();
        }

        public void ReloadScene()
        {
            SceneManager.LoadScene(0);
        }

        private void OnPlayButtonClickFirst(Stage stage)
        {
            _location.ResetStages();
            _stage = stage;
            Time.timeScale = 1;
            ResetTile();
            _player.ResetPlayer();
            StartInstruction.Instance.ShowInfo();
            StartCoroutine(DeleyStartTimer());
        }

        private void OnPlayButtonClick(Stage stage)
        {
            _location.ResetStages();
            _stage = stage;
            StartGame();
        }

        private void ResetAll()
        {
            _mobileInput.ResetJoystic();
            _stage.ResetPool();
            ColorReseted?.Invoke();
            _clock.ResetTime();
        }

        private void StartGame()
        {
            Time.timeScale = 1;
            ResetTile();
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

        private IEnumerator DelayShowScreen()
        {
            _playerMover.enabled = false;
            _activationStages.InitializeStage();
            yield return new WaitForSeconds(2.0f);
            _playerMover.enabled = true;
            Time.timeScale = 0;
            ResetAll();
            _levelCompleteScreen.Open();
        }

        private IEnumerator DeleyStartTimer()
        {
            _playerMover.enabled = false;
            yield return new WaitForSeconds(3);
            _clock.ResetTime();
            _playerMover.enabled = true;
        }

        private void OnContinueButtonClick()
        {
            Time.timeScale = 1;
            _pauseScreen.Close();
        }

        private void ResetTile()
        {
            _stage.GetComponentInChildren<Plant>().ResetTile();
        }

        [DllImport("__Internal")] private static extern void ExitGame();
    }
}