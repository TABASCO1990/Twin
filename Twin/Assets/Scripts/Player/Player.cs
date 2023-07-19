using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _bonus;

    private int _score;
    private bool isLive;

    public event UnityAction<int> ScoreChanged;

    public void IncreaseScore()
    {
        _score += _bonus;
        ScoreChanged?.Invoke(_score);
    }

    private void TakeDamage()
    {

    }
}
