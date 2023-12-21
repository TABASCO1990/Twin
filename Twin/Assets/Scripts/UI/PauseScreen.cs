using System;
using UnityEngine;

namespace UI
{
    public class PauseScreen : ScreenBase
    {
        public event Action ContinueButtonClick;

        public override void Close()
        {
            CanvasGroup.alpha = 0;
            Button.interactable = false;
            CanvasGroup.blocksRaycasts = false;
            DisableObjects(true);
        }

        public override void Open()
        {
            Time.timeScale = 0;
            CanvasGroup.alpha = 1;
            Button.interactable = true;
            CanvasGroup.blocksRaycasts = true;
            DisableObjects(false);
        }

        protected override void OnButtonClick()
        {
            ContinueButtonClick?.Invoke();
        }
    }
}
