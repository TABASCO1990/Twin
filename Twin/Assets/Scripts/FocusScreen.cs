using UnityEngine;

namespace Controller
{
    public class FocusScreen : MonoBehaviour
    {
        [SerializeField] private UI.PauseScreen _pauseScreen;
        [SerializeField] private MobileInput _mobileInput;

        private void OnApplicationFocus()
        {
            if (_mobileInput.enabled == true)
            {
                _pauseScreen.Open();
            }
        }
    }
}
