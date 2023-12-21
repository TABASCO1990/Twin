using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class Authorization : MonoBehaviour
    {
        [SerializeField] private Button _login;
        [SerializeField] private GameObject AreaLogin;

        private void OnEnable()
        {
            _login.onClick.AddListener(Login);
        }

        private void OnDisable()
        {
            _login.onClick.RemoveListener(Login);
        }

        private void Start()
        {
#if !UNITY_EDITOR && UNITY_WEBGL
            ShowWindowAuthorization();
#endif
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

        [DllImport("__Internal")] public static extern void ShowWindowAuthorization();

        [DllImport("__Internal")] private static extern void InitAuthorization();
    }
}