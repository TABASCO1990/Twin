using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.OnScreen;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class MobileInput : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [SerializeField] private RectTransform _knobJoystick;
    [SerializeField] private RectTransform _stickJoystic;

    private RectTransform _canvasRectTransform;
    private Vector2 _startPosition;
    private Image _image;
    private OnScreenStick _stick;

    void Start()
    {
        _image = GetComponent<Image>();
        _canvasRectTransform = GetComponentInParent<Canvas>().GetComponent<RectTransform>();
        _stick = _knobJoystick.GetComponent<OnScreenStick>();
        _startPosition = _knobJoystick.anchoredPosition;
    }

    public void ResetJoystic()
    {
        _startPosition = _knobJoystick.anchoredPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        _stick.OnDrag(eventData);
    }

    public void OnPointerDown(PointerEventData eventData)
    {     
        Vector2 localPoint;
        
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(_canvasRectTransform, eventData.position,eventData.pressEventCamera,out localPoint))
        {
            _knobJoystick.anchoredPosition = localPoint;
            _stickJoystic.anchoredPosition = localPoint;
            _image.enabled = false;
            _stickJoystic.GetComponent<Image>().enabled = true;
            _stick.OnPointerDown(eventData);
            _stick.GetComponent<Image>().enabled = true;
        }    
    }

    public void OnPointerUp(PointerEventData eventData)
    {   
        _stick.OnPointerUp(eventData);
        _image.enabled = true;
        _knobJoystick.anchoredPosition = _startPosition;
        _stickJoystic.anchoredPosition = _startPosition;
        _stickJoystic.GetComponent<Image>().enabled = false;
        _stick.GetComponent<Image>().enabled = false;
    }
}
