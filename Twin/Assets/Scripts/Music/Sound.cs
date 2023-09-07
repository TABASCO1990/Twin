using UnityEngine.UI;
using UnityEngine;

public class Sound : MonoBehaviour
{
    [SerializeField] private Sprite _enableSprite;
    [SerializeField] private Sprite _disableSprite;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private Image _image;

    public bool AudioEnabled
    {
        get
        {
            return Progress.Instance.PlayerInfo._isSound;
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
            _image.GetComponent<Image>().sprite = _enableSprite;
        }
        else
        {
            _audioSource.enabled = false;
            _image.GetComponent<Image>().sprite = _disableSprite;
        }

        Progress.Instance.PlayerInfo._isSound = enabled;
#if !UNITY_EDITOR && UNITY_WEBGL
        Progress.Instance.Save();
#endif
    }

    public void SwitchAudio()
    {
        AudioEnabled = !AudioEnabled;
    }
}