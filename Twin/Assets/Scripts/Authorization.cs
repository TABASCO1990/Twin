using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class Authorization : MonoBehaviour
{
    [DllImport("__Internal")] public static extern void ShowWindowAuthorization();

    [DllImport("__Internal")] private static extern void InitAuthorization();

    [SerializeField] private Button _login;
    [SerializeField] private GameObject AreaLogin;

    private void Start()
    {
        ShowWindowAuthorization();
    }

    private void OnEnable()
    {
        _login.onClick.AddListener(Login);
    }

    private void OnDisable()
    {
        _login.onClick.RemoveListener(Login);
    } 

    public void ShowScreen()
    {
        AreaLogin.SetActive(true);       
    }

    public void CloseScreen()
    {
        AreaLogin.SetActive(false);
    }

    public void Login()
    {
        InitAuthorization();
    }
}
