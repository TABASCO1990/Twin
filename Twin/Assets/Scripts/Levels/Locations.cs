using System;
using UnityEngine;

namespace Levels
{
    public class Locations : MonoBehaviour
    {
        [SerializeField] private Stage[] _stages;

        private int _numberLevel;

        public event Action<int> StageInitialised;

        public int NumberLevel => _numberLevel;

        public int CountStage => _stages.Length;

        private void Start()
        {
            _stages[_numberLevel].gameObject.SetActive(true);
        }

        public Stage GetStage()
        {
            _stages[_numberLevel].gameObject.SetActive(true);
            Stage level = _stages[_numberLevel];
            return level;
        }

        public void SetNumberStage(int number)
        {
            _numberLevel = number;
            StageInitialised(_numberLevel);
        }

        public void ResetStages()
        {
            foreach (var stage in _stages)
            {
                stage.gameObject.SetActive(false);
            }
        }
    }
}