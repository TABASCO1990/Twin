using UnityEngine;
using UnityEngine.UI;

public class Effects : MonoBehaviour
{
    [SerializeField] private Sprite _enableSprite;
    [SerializeField] private Sprite _disableSprite;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private Image _image;

    public bool AudioEnabled
    {
        get
        {
            return Progress.Instance.PlayerInfo._isEffects;
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

        Progress.Instance.PlayerInfo._isEffects = enabled;
#if !UNITY_EDITOR && UNITY_WEBGL
        Progress.Instance.Save();
#endif
    }

    public void SwitchAudio()
    {
        AudioEnabled = !AudioEnabled;
    }
}

