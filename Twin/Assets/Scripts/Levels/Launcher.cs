using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Launcher : MonoBehaviour
{
    [SerializeField] private Stage _stage; //������������ ��� �����
    [SerializeField] private Locations _location; //������� ����� ������ ����
    [SerializeField] private int _numberStage; //����� ������
    [SerializeField] private Button _buttonStart;
    [SerializeField] protected GameObject[] ObjectsDisabled;
    [SerializeField] protected GameObject _joystick;

    public event UnityAction<Stage> InitializeStage;

    public int NumberStage => _numberStage;

    private void Start()
    {
        _buttonStart.enabled = true;
    }

    private void OnEnable()
    {
        _buttonStart.onClick.AddListener(ActivateStage);
        _buttonStart.onClick.AddListener(SetStage);
    
    }

    private void OnDisable()
    {
        _buttonStart.onClick.RemoveListener(ActivateStage);
        _buttonStart.onClick.RemoveListener(SetStage);

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
}
