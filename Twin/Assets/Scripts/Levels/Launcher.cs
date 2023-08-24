using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Launcher : MonoBehaviour
{
    [SerializeField] private Stage _stage; //активировать его будем
    [SerializeField] private Locations _location; //передаём номер уровня сюда
    [SerializeField] private int _numberStage; //номер уровня
    [SerializeField] private GameObject _buttonStart;
    [SerializeField] protected GameObject[] ObjectsDisabled;
    [SerializeField] protected GameObject _joystick;

    public event UnityAction<Stage> InitializeStage;

    public int NumberStage => _numberStage;

    private void Start()
    {
        _buttonStart.GetComponent<Button>().enabled = true;
    }

    private void OnEnable()
    {
        _buttonStart.GetComponent<Button>().onClick.AddListener(ActivateStage);
        _buttonStart.GetComponent<Button>().onClick.AddListener(SetStage); 
    }

    private void OnDisable()
    {
        _buttonStart.GetComponent<Button>().onClick.RemoveListener(ActivateStage);
        _buttonStart.GetComponent<Button>().onClick.RemoveListener(SetStage);
    }

    private void ActivateStage()
    {
        _stage.gameObject.SetActive(true);
        _location.SetNumberStage(_numberStage);     
        SetObjects(true);
    }

    private void SetStage()
    {
        InitializeStage?.Invoke(_stage);
    }

    private void SetObjects(bool isActive)
    {
        _joystick.GetComponent<Image>().enabled = isActive;
        _joystick.GetComponent<MobileInput>().enabled = isActive;

        foreach (var screenObject in ObjectsDisabled)
        {
            screenObject.gameObject.SetActive(isActive);
        }
    }

    public void SetButtonSprite(Sprite sprite)
    {
        _buttonStart.GetComponent<Image>().sprite = sprite;
    }
}
