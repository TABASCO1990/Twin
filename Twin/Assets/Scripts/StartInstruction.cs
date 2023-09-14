using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;

public class StartInstruction : MonoBehaviour
{
    [DllImport("__Internal")] private static extern void DeviceInfo();

    [SerializeField] private GameObject _navigation;
    [SerializeField] private GameObject _hintTimer;
    [SerializeField] private GameObject _keyboard;
    [SerializeField] private GameObject _joystick;

    public static StartInstruction Instance;

    private void Start()
    {
        Instance = this;
        DeviceInfo();
    }

    public void ShowInfo()
    {
        StartCoroutine(SetManual());
    }

    public void SetKeyboard()
    {
        _keyboard.SetActive(true);
    }

    public void SetJoystick()
    {
        _joystick.SetActive(true);
    }

    IEnumerator SetManual()
    {       
        _navigation.SetActive(true);
        _hintTimer.SetActive(true);
        yield return new WaitForSeconds(3f); 
        _navigation.SetActive(false);
        _hintTimer.SetActive(false);
    }
}
