using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerMover))]
public class Player : MonoBehaviour
{
    [SerializeField] private Location _location;

    private PlayerMover _mover;
    private int _score;
    private int _countEventsScore;

    public event UnityAction<int> ScoreChanged;
    public event UnityAction<float> TimeChanged;
    public event UnityAction GameOver;
    public event UnityAction LevelComplete;

    private void Start()
    {
        _mover = GetComponent<PlayerMover>();
    }

    public void IncreaseScore(int score)
    {
        _score += score;
        _countEventsScore++;
        ScoreChanged?.Invoke(_score);
        CheckLevelCompletion();
    }

    public void CheckLevelCompletion()
    {
        if (_countEventsScore == _location.CountTarget) 
        {     
            LevelComplete?.Invoke();
        }
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
    }

    public void Die()
    {
        GameOver?.Invoke();
    }
}
