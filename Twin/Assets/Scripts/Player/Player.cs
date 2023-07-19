using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    private int _score;
    private float _bonusTime;
    private bool isLive;

    public event UnityAction<int> ScoreChanged;
    public event UnityAction<float> TimeChanged;

    public void IncreaseScore(int score)
    {
        _score += score;
        ScoreChanged?.Invoke(_score);
    }

    public void IncreaseTime(float time)
    {
        TimeChanged?.Invoke(time);
    }

    private void TakeDamage()
    {

    }
}
