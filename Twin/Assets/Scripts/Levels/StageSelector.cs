using System;
using UnityEngine;
using UnityEngine.Events;

namespace Levels
{
    public class StageSelector : MonoBehaviour
    {
        [SerializeField] private Launcher[] _launchers;
        [SerializeField] private Locations _locations;
        [SerializeField] private Sprite _spriteActive;

        private int _currentStage;

        public event UnityAction<int> StageChanged;

        private void Start()
        {
            _launchers[_currentStage].enabled = true;
            _currentStage = Progress.Instance.PlayerInfo._countActiveStages;
        }

        public void SetActivatedStages(int count)
        {
            _launchers[count].enabled = true;
            _launchers[count].SetButtonSprite(_spriteActive);
        }

        public void InitializeStage()
        {
            if (_locations.NumberLevel == _currentStage)
            {
                _currentStage++;

                if (_currentStage < _launchers.Length)
                {
                    CountStageActive();
                    _launchers[_currentStage].enabled = true;
                    _launchers[_currentStage].SetButtonSprite(_spriteActive);
                }
                else
                {
                    Debug.Log("�����������! �� ������ ��� ����.");
                }
            }
            else
            {
                Debug.Log("��� ������ �������.");
            }

            StageChanged?.Invoke(_locations.NumberLevel + 1);
        }

        private void CountStageActive()
        {
            Progress.Instance.PlayerInfo._countActiveStages = Math.Max(Progress.Instance.PlayerInfo._countActiveStages, _currentStage);

#if !UNITY_EDITOR && UNITY_WEBGL
        Progress.Instance.Save();
#endif
        }
    }
}