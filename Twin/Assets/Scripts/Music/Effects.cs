using UnityEngine;
using UnityEngine.UI;

namespace Music
{
    public class Effects : MonoBehaviour
    {
        [SerializeField] private Sprite _enableSprite;
        [SerializeField] private Sprite _disableSprite;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private Image _image;

        private bool AudioEnabled
        {
            get => Progress.Instance.PlayerInfo._isEffects;
            set => SetAudio(value);
        }

        private void Start()
        {
            SetAudio(AudioEnabled);
        }

        public void SwitchAudio()
        {
            AudioEnabled = !AudioEnabled;
        }

        private void SetAudio(bool enabled)
        {
            _audioSource.enabled = enabled;
            _image.GetComponent<Image>().sprite = enabled ? _enableSprite : _disableSprite;

            Progress.Instance.PlayerInfo._isEffects = enabled;

#if !UNITY_EDITOR && UNITY_WEBGL
    Progress.Instance.Save();
#endif
        }
    }
}