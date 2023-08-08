using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(PlayerCollisionHandler))]
public class Player : MonoBehaviour
{
    private const int MaxCountScore = 17;

    private PlayerMover _mover;
    private PlayerCollisionHandler _collisionHandler;
    private int _score;
    private int _countEventsScore;

    public event UnityAction<int> ScoreChanged;
    public event UnityAction<float> TimeChanged;
    public event UnityAction LevelComplete;
    public event UnityAction GameOver;   

    public int CountEventsScore => _countEventsScore;

    private void Start()
    {
        _mover = GetComponent<PlayerMover>();
        _collisionHandler = GetComponent<PlayerCollisionHandler>();
    }

    public void IncreaseScore(int score)
    {
        _score += score;
        _countEventsScore++;
        ScoreChanged?.Invoke(_score);
    }

    public void IncreaseTime(float time)
    {
        TimeChanged?.Invoke(time);
    }

    public void ResetPlayer()
    {
        _score = 0;
        _countEventsScore = 0;
        ScoreChanged?.Invoke(_score);
        _mover.ResetPlayer();
        _collisionHandler.ResetCollisoin();
    }

    public void Die()
    {
        GameOver?.Invoke();
    }

    public void CheckLevelCompletion()
    {
        if (CountEventsScore == MaxCountScore)
        {
            LevelComplete?.Invoke();
        }
    }
}
