using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private Image _fill;
    [SerializeField] private TMP_Text _time;
    [SerializeField] private int _duration;
    [SerializeField] private float _remainingDuration;

    private void Awake()
    {
        BeginTime(_duration);
    }

    private void Update()
    {
        UpdateTimer();
    }


    private void UpdateTimer()
    {
        if (_remainingDuration >= 0)
        {
            _remainingDuration -= Time.deltaTime;
            _time.text = Mathf.Round(_remainingDuration).ToString();
            _fill.fillAmount = Mathf.InverseLerp(0, _duration, _remainingDuration);
        }
        else
        {
            EndTime();
        }     
    }

    private void BeginTime(int second)
    {
        _remainingDuration = second;
    }

    private void EndTime()
    {
        print("Конец");
    }
}
