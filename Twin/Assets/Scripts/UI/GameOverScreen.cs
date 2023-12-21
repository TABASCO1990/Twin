using System;

namespace UI
{
    public class GameOverScreen : ScreenBase
    {
        public event Action RestartButtonClock;

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
            RestartButtonClock?.Invoke();
        }
    }
}