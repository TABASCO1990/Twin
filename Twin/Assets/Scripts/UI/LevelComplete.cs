using UnityEngine;
using UnityEngine.Events;


public class LevelComplete : ScreenBase
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioWin;

    public event UnityAction ContinueButtonClock;

    public override void Close()
    {
        CanvasGroup.alpha = 0;
        CanvasGroup.blocksRaycasts = false;
        Button.interactable = false;
        DisableObjects(true);
        
    }

    public override void Open()
    {
        CanvasGroup.alpha = 1;
        CanvasGroup.blocksRaycasts = true;
        Button.interactable = true;
        DisableObjects(false);
        _audioSource.PlayOneShot(_audioWin);
    }

    protected override void OnButtonClick()
    {
        ContinueButtonClock?.Invoke();
    }
}
