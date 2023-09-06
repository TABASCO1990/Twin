using UnityEngine;
using UnityEngine.UI;

public abstract class Music : MonoBehaviour
{
    [SerializeField] protected Button _button;
    [SerializeField] protected AudioSource _audioEffects;
    [SerializeField] protected Image _musicImage;
    [SerializeField] protected Sprite onMusic;
    [SerializeField] protected Sprite offMusic;

    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        SetStatus();
    }

    public abstract void SetStatus();
}
