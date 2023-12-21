using TMPro;
using UnityEngine;

namespace UI
{
    [RequireComponent(typeof(Timer.TimerBonus))]
    public class Bonus : MonoBehaviour
    {
        [SerializeField] private TMP_Text _value;

        private Timer.TimerBonus _timerBonus;

        private void Start()
        {
            _timerBonus = GetComponent<Timer.TimerBonus>();
            _value.text = "+" + _timerBonus.Value;
        }
    }
}