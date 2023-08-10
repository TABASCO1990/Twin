using UnityEngine;

public class SettingScreen : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroup;

    public void Close()
    {
        _canvasGroup.alpha = 0;
        _canvasGroup.blocksRaycasts = false;
    }

    public void Open()
    {
        _canvasGroup.alpha = 1;
        _canvasGroup.blocksRaycasts = true;
    }
}

