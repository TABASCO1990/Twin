using UnityEngine;
using System.Runtime.InteropServices;

public class Marketing : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private int _seconds;

    [DllImport("__Internal")]
    private static extern void ShowFullScreenAdv();

    [DllImport("__Internal")]
    private static extern void AddTimeForAdv(int value); 

    public void ShowFullScreenAdvertisement()
    {
        ShowFullScreenAdv();
    }

    public void ShowAdvReward()
    {
        AddTimeForAdv(_seconds);
    }

    public void AddTime(int value)
    {
        _player.IncreaseTime(value);
    }
}
