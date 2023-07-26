using UnityEngine;
using UnityEngine.Events;

public class GameOverScreen : ScreenBase
{
    public event UnityAction RestartButtonClock;

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
        Button.interactable = true;
        CanvasGroup.blocksRaycasts = true;
        DisableObjects(false);
    }

    protected override void OnButtonClick()
    {
        RestartButtonClock?.Invoke();
    } 
}
