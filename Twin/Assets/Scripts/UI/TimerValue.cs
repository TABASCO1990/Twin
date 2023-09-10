using TMPro;
using UnityEngine;

[RequireComponent(typeof(TimerBonus))]
public class Bonus : MonoBehaviour
{
    [SerializeField] private TMP_Text _value;

    private TimerBonus _timerBonus;
    
    void Start()
    {
        _timerBonus = GetComponent<TimerBonus>();
        _value.text = "+" + _timerBonus.Value;
    }
}
