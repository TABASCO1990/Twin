using UnityEngine;
using UnityEngine.UI;

public abstract class ScreenBase : MonoBehaviour
{
    [SerializeField] protected CanvasGroup CanvasGroup;
    [SerializeField] protected Button Button;
    [SerializeField] protected GameObject[] ObjectsDisabled;
    [SerializeField] protected GameObject Joystick;

    private void OnEnable()
    {
        Button.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        Button.onClick.RemoveListener(OnButtonClick);    
    }

    protected abstract void OnButtonClick();

    public abstract void Open();

    public abstract void Close();

    protected void DisableObjects(bool isActive)
    {
        Joystick.GetComponent<Image>().enabled = isActive;
        Joystick.GetComponent<MobileInput>().enabled = isActive;

        foreach (var item in ObjectsDisabled)
        {
            item.gameObject.SetActive(isActive);
        }
    }
}
