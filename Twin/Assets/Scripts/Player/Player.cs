using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerMover))]
public class Player : MonoBehaviour
{
    private PlayerMover _mover;
    private int _score;

    public event UnityAction<int> ScoreChanged;
    public event UnityAction<float> TimeChanged;
    public event UnityAction GameOver;

    private void Start()
    {
        _mover = GetComponent<PlayerMover>();
    }

    public void IncreaseScore(int score)
    {
        _score += score;
        ScoreChanged?.Invoke(_score);
    }

    public void IncreaseTime(float time)
    {
        TimeChanged?.Invoke(time);
    }

    public void ResetPlayer()
    {
        _score = 0;
        ScoreChanged?.Invoke(_score);
        _mover.ResetPlayer();
    }

    public void Die()
    {
        GameOver?.Invoke();
    }
}
