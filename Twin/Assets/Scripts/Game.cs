using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Location _location;
    [SerializeField] private Plant _plant;
    [SerializeField] private PlayerColor _playerColor;
    [SerializeField] private ObstacleColor _obstacleColor;
    [SerializeField] private Timer _timer;
    [SerializeField] private MainScreen _mainScreen;
    [SerializeField] private MobileInput _mobileInput;
    [SerializeField] private GameOverScreen _gameOverScreen;
    [SerializeField] private PauseScreen _pauseScreen;

    private void OnEnable()
    {
        _mainScreen.PlayButtonClick += OnPlayButtonClick;
        _gameOverScreen.RestartButtonClock += OnRestartButtonClick;
        _pauseScreen.ContinueButtonClick += OnContinueButtonClick;
        _player.GameOver += OnGameOver;
        _pauseScreen.ContinueButtonClick += OnContinueButtonClick;
    }

    private void OnDisable()
    {
        _mainScreen.PlayButtonClick -= OnPlayButtonClick;
        _gameOverScreen.RestartButtonClock -= OnRestartButtonClick;
        _player.GameOver -= OnGameOver;
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
        _plant.ResetTile();
        _playerColor.ResetColors();
        _obstacleColor.ResetColors();
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
