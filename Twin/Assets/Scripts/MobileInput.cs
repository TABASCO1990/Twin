using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.OnScreen;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class MobileInput : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [SerializeField] private RectTransform _stickTransform;

    private RectTransform _canvasRectTransform;
    private Vector2 _startPosition;
    private Image _image;
    private OnScreenStick _stick;

    void Start()
    {
        _image = GetComponent<Image>();
        _canvasRectTransform = GetComponentInParent<Canvas>().GetComponent<RectTransform>();
        _stick = _stickTransform.GetComponent<OnScreenStick>();
        _startPosition = _stickTransform.anchoredPosition;
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
            _stickTransform.anchoredPosition = localPoint;
            _image.enabled = false;
            _stick.OnPointerDown(eventData);
            _stick.GetComponent<Image>().enabled = true;
        }    
    }

    public void OnPointerUp(PointerEventData eventData)
    {   
        _stick.OnPointerUp(eventData);
        _image.enabled = true;
        _stickTransform.anchoredPosition = _startPosition;
        _stick.GetComponent<Image>().enabled = false;
    }
}
