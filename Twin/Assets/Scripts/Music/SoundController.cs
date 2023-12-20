using UnityEngine;

namespace Music
{
    public class SoundController : MonoBehaviour
    {
        private void OnApplicationFocus(bool hasFocus)
        {
            Silence(!hasFocus);
        }

        private void OnApplicationPause(bool isPaused)
        {
            Silence(isPaused);
        }

        private void Silence(bool silence)
        {
            AudioListener.pause = silence;
            AudioListener.volume = silence ? 0 : 1;
        }
    }
}