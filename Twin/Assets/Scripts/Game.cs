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
    [SerializeField] private GameOverScreen _gameOverScreen;

    private void OnEnable()
    {
        _mainScreen.PlayButtonClick += OnPlayButtonClick;
        _gameOverScreen.RestartButtonClock += OnRestartButtonClick;
        _player.GameOver += OnGameOver;
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

    private void OnRestartButtonClick()
    {
        _location.ResetPool();
        _plant.ResetTile();
        _playerColor.ResetColors();
        _obstacleColor.ResetColors();
        _timer.ResetTime();
        _gameOverScreen.Close();
        StartGame();
    }

    private void StartGame()
    {
        Time.timeScale = 1;
        _player.ResetPlayer();
    }

    public void OnGameOver()
    {
        Time.timeScale = 0;
        _gameOverScreen.Open();
    }
}
