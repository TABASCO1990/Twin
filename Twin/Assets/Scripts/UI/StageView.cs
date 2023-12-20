using UnityEngine;
using UnityEngine.Events;

namespace UI
{
    public class StageView : ScreenBase
    {
        public event UnityAction SelectStageClick;

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
            SelectStageClick?.Invoke();
        }
    }
}
