using UnityEngine;
using UnityEngine.UI;

public class Sound : MonoBehaviour
{
    [SerializeField] private Button _musicButton;
    [SerializeField] private AudioSource _audioEffects;
    [SerializeField] private Image _musicImage;
    [SerializeField] private Sprite onMusic;
    [SerializeField] private Sprite offMusic;

    private void OnEnable()
    {
        _musicButton.onClick.AddListener(OnEffectsPlay);
    }

    private void OnDisable()
    {
        _musicButton.onClick.RemoveListener(OnEffectsPlay);
    }

    private void OnEffectsPlay()
    {      
        OffSound();
    }

    public void OffSound()
    {
        if (Progress.Inststance.PlayerInfo.isOnMusic)
        {          
            Progress.Inststance.PlayerInfo.isOnMusic = false;
            _audioEffects.enabled = false;
            _musicImage.GetComponent<Image>().sprite = offMusic;
        }
        else
        {
            Progress.Inststance.PlayerInfo.isOnMusic = true;
            _audioEffects.enabled = true;
            _musicImage.GetComponent<Image>().sprite = onMusic;
        }
#if !UNITY_EDITOR && UNITY_WEBGL
        Progress.Inststance.Save();
#endif
    }
}
