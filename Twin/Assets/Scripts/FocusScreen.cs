using UnityEngine;

public class FocusScreen : MonoBehaviour
{
    [SerializeField] private PauseScreen _pauseScreen;
    [SerializeField] private MobileInput _mobileInput;

    private void OnApplicationFocus()
    {
        if (_mobileInput.enabled == true)
        {
            _pauseScreen.Open();
        }
    }
}
