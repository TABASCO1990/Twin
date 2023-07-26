using UnityEngine;
using UnityEngine.Events;

public class MainScreen : ScreenBase
{
    public event UnityAction PlayButtonClick;

    public override void Close()
    {
        CanvasGroup.alpha = 0;
        Button.interactable = false;
        CanvasGroup.blocksRaycasts = false;
        DisableObjects(true);
    }

    public override void Open()
    {
        CanvasGroup.alpha = 1;
        Button.interactable = true;
        CanvasGroup.blocksRaycasts = true;
        DisableObjects(false);
    }

    protected override void OnButtonClick()
    {
        PlayButtonClick?.Invoke();
    }
}
