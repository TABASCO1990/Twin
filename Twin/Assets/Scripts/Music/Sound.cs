using UnityEngine.UI;
using UnityEngine;

public class Sound : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Sprite enableSprite;
    [SerializeField] private Sprite disableSprite;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private Image image;

    private bool audioEnabled;

    public bool AudioEnabled
    {
        get
        {
            return audioEnabled;
        }
        set
        {
            SetAudio(value);
        }
    }

    private void Start()
    {
        SetAudio(AudioEnabled);
    }

    public void SetAudio(bool enabled)
    {
        if (enabled)
        {           
            _audioSource.enabled = true;
            image.GetComponent<Image>().sprite = enableSprite;
            print("Enable Sound");
        }
        else
        {
            _audioSource.enabled = false;
            image.GetComponent<Image>().sprite = disableSprite;
            print("Disable Sound");
        }

        audioEnabled = enabled;
        Progress.Inststance.PlayerInfo._isSound = audioEnabled;
#if !UNITY_EDITOR && UNITY_WEBGL
        Progress.Inststance.Save();
#endif
    }

    public void SwitchAudio()
    {
        AudioEnabled = !AudioEnabled;
    }
}

