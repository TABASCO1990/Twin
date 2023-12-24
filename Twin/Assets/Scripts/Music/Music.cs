using UnityEngine;
using UnityEngine.UI;

namespace Music
{
    public class Music : MonoBehaviour
    {
        [SerializeField] private Sprite _enableSprite;
        [SerializeField] private Sprite _disableSprite;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private Image _image;

        private bool AudioEnabled
        {
            get => Shared.Progress.Instance.PlayerInfo.IsMusic;
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

            Shared.Progress.Instance.PlayerInfo.IsMusic = enabled;

#if !UNITY_EDITOR && UNITY_WEBGL
    Progress.Instance.Save();
#endif
        }
    }
}