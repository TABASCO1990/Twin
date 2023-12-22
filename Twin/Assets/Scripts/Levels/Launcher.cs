using System;
using UnityEngine;
using UnityEngine.UI;

namespace Levels
{
    public class Launcher : MonoBehaviour
    {
        [SerializeField] private GameObject[] ObjectsDisabled;
        [SerializeField] private Stage _stage;
        [SerializeField] private Locations _location;
        [SerializeField] private int _numberStage;
        [SerializeField] private Button _stageStart;

        public event Action<Stage> InitializeStage;

        private void OnEnable()
        {
            _stageStart.onClick.AddListener(ActivateStage);
        }

        private void OnDisable()
        {
            _stageStart.onClick.RemoveListener(ActivateStage);
        }

        private void Start()
        {
            _stageStart.enabled = true;
        }

        public void SetButtonSprite(Sprite sprite)
        {
            _stageStart.GetComponent<Image>().sprite = sprite;
        }

        private void ActivateStage()
        {
            _stage.gameObject.SetActive(true);
            _location.SetNumberStage(_numberStage);
            SetObjects(true);
            InitializeStage?.Invoke(_stage);
        }

        private void SetObjects(bool isActive)
        {
            foreach (var screenObject in ObjectsDisabled)
            {
                screenObject.gameObject.SetActive(isActive);
            }
        }
    }
}