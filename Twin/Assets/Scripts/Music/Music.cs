using UnityEngine.UI;
using UnityEngine;

public class Music : MonoBehaviour
{
    [SerializeField] private Sprite _enableSprite;
    [SerializeField] private Sprite _disableSprite;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private Image _image;

    private bool AudioEnabled
    {
        get => Progress.Instance.PlayerInfo._isMusic;
        set => SetAudio(value);
    }

    private void Start()
    {
        SetAudio(AudioEnabled);
    }

    private void SetAudio(bool enabled)
    {
        _audioSource.enabled = enabled;
        _image.GetComponent<Image>().sprite = enabled ? _enableSprite : _disableSprite;

        Progress.Instance.PlayerInfo._isMusic = enabled;

#if !UNITY_EDITOR && UNITY_WEBGL
    Progress.Instance.Save();
#endif
    }

    public void SwitchAudio()
    {
        AudioEnabled = !AudioEnabled;
    }
}