using UnityEngine;
using UnityEngine.UI;

public abstract class Music : MonoBehaviour
{
    [SerializeField] protected Sprite EnableSprite;
    [SerializeField] protected Sprite DisableSprite;
    [SerializeField] protected AudioSource AudioSource;
    [SerializeField] protected Image Image;

    public virtual bool AudioEnabled
    {
        get
        {
            return AudioEnabled;
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

    protected abstract void SetAudio(bool enabled);

    public void SwitchAudio()
    {
        AudioEnabled = !AudioEnabled;
    }
}
