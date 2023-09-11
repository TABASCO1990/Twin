using UnityEngine;
using System.Runtime.InteropServices;

public class Marketing : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private PauseScreen _pauseScreen;
    [SerializeField] private int _seconds;
    [SerializeField] private AudioSource _audioSource;

    [DllImport("__Internal")] private static extern void ShowFullScreenAdv();

    [DllImport("__Internal")] private static extern void AddTimeForAdv(int value); 

    public void ShowFullScreenAdvertisement()
    {
#if !UNITY_EDITOR && UNITY_WEBGL
    ShowFullScreenAdv();
#endif
    }

    private void Awake()
    {
#if !UNITY_EDITOR && UNITY_WEBGL
    ShowFullScreenAdv();
#endif
    }

    public void ContinuePlaySound()
    {
        _audioSource.Play();
    }

    public void ShowAdvReward()
    {
        AddTimeForAdv(_seconds);
    }

    public void AddTime(int value)
    {       
        _player.IncreaseTime(value);
    }

    public void PauseGame()
    {
        _pauseScreen.Open();
    }
}
