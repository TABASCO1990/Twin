using System;
using UnityEngine;
using UnityEngine.UI;

namespace Levels
{
    public class Launcher : MonoBehaviour
    {
        [SerializeField] protected GameObject[] ObjectsDisabled;
        [SerializeField] protected GameObject _joystick;
        [SerializeField] private Stage _stage;
        [SerializeField] private Locations _location;
        [SerializeField] private int _numberStage;
        [SerializeField] private GameObject _buttonStart;

        public event Action<Stage> InitializeStage;

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

        private void Start()
        {
            _buttonStart.GetComponent<Button>().enabled = true;
        }

        public void SetButtonSprite(Sprite sprite)
        {
            _buttonStart.GetComponent<Image>().sprite = sprite;
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
            _joystick.GetComponent<Controller.MobileInput>().enabled = isActive;

            foreach (var screenObject in ObjectsDisabled)
            {
                screenObject.gameObject.SetActive(isActive);
            }
        }
    }
}