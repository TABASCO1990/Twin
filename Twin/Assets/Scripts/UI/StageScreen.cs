using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class StageScreen : ScreenBase
{
    public event UnityAction StageButtonClick;

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

    public void SetButtonStage(Button playButton)
    {
        Button = playButton;
    }

    protected override void OnButtonClick()
    {
        StageButtonClick?.Invoke();
    }
}
