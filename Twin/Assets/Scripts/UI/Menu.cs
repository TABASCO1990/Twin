using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private Button _pauseButton;
    [SerializeField] private GameObject _joysticField;

    public void ActivtePausePanel(CanvasGroup panel)
    {
        panel.alpha = 1;
        _pauseButton.gameObject.SetActive(false);
        _joysticField.gameObject.SetActive(false);
        Time.timeScale = 0;
    }


}
