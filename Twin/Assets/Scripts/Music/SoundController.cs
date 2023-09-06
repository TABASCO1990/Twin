using UnityEngine;

public class SoundController : MonoBehaviour
{
    void OnApplicationFocus(bool hasFocus)
    {
        Silence(!hasFocus);
    }

    void OnApplicationPause(bool isPaused)
    {
        Silence(isPaused);
    }

    private void Silence(bool silence)
    {
        AudioListener.pause = silence;
        AudioListener.volume = silence ? 0 : 1;
    }

}
