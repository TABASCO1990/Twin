using UnityEngine;
using UnityEngine.Events;

public class LevelComplete : ScreenBase
{
    public event UnityAction ContinueButtonClock;

    public override void Close()
    {
        CanvasGroup.alpha = 0;
        CanvasGroup.blocksRaycasts = false;
        DisableObjects(true);
    }

    public override void Open()
    {
        CanvasGroup.alpha = 1;
        CanvasGroup.blocksRaycasts = true;
        DisableObjects(false);
    }

    protected override void OnButtonClick()
    {
        ContinueButtonClock?.Invoke();
    }
}
