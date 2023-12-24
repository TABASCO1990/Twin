using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Shared
{
    public class Progress : MonoBehaviour
    {
        public static Progress Instance;

        [SerializeField] private Timer.Clock _clock;
        [SerializeField] private Levels.Locations _location;
        [SerializeField] private Player.Player _player;
        [SerializeField] private Levels.StageSelector _activationStages;
        [SerializeField] private Player.PlayerRank _playerRank;

        private int[] _scoreStages;
        private int _sumScores;

        public Player.PlayerInfo PlayerInfo;

        public event Action<int, int, int> CalculateScore;

        private void Awake()
        {
            Instance = this;
            _scoreStages = new int[_location.CountStage];
            Instance.PlayerInfo.IsEffects = true;
#if !UNITY_EDITOR && UNITY_WEBGL
        LoadExtern();
#endif
        }

        private void Start()
        {
            PlayerInfo.Scores = new int[_location.CountStage];
        }

        [DllImport("__Internal")] private static extern void SaveExtern(string date);

        [DllImport("__Internal")] private static extern void LoadExtern();

        [DllImport("__Internal")] private static extern void SetToLeaderboard(int value);

        public void CountScore()
        {
            SetStageScores();
            SetTotalScores();
            CalculateScore?.Invoke(_scoreStages[_location.NumberLevel], _location.NumberLevel, _sumScores);
        }

        public void Save()
        {
            string jsonString = JsonUtility.ToJson(PlayerInfo);
            SaveExtern(jsonString);
        }

        public void SetPlayerInfo(string value)
        {
            PlayerInfo = JsonUtility.FromJson<Player.PlayerInfo>(value);
            PlayerInfo.Scores.CopyTo(_scoreStages, 0);
            SetTotalScores();

            for (int i = 0; i < PlayerInfo.Scores.Length; i++)
            {
                CalculateScore?.Invoke(PlayerInfo.Scores[i], i, _sumScores);
            }

            for (int i = 0; i <= PlayerInfo.CountActiveStages; i++)
            {
                _activationStages.SetActivatedStages(i);
            }
        }

        private void SetStageScores()
        {
            _scoreStages[_location.NumberLevel] = _clock.RemainingTime + _player.Score;
            _scoreStages.CopyTo(PlayerInfo.Scores, 0);
#if !UNITY_EDITOR && UNITY_WEBGL
        Save();
#endif
        }

        private void SetTotalScores()
        {
            int sum = 0;

            foreach (var item in PlayerInfo.Scores)
            {
                sum += item;
            }

            _sumScores = sum;
            _playerRank.ShowInfo();
#if !UNITY_EDITOR && UNITY_WEBGL
        SetToLeaderboard(_sumScores);
#endif
        }
    }
}