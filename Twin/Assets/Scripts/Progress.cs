using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class PlayerInfo
{
    public int[] _scores;
    public int _countActiveStages;
    public bool _isMusic;
    public bool _isEffects = true;
}

public class Progress : MonoBehaviour
{
    [DllImport("__Internal")] private static extern void SaveExtern(string date);
    [DllImport("__Internal")] private static extern void LoadExtern();
    [DllImport("__Internal")] private static extern void SetToLeaderboard(int value);

    [SerializeField] private Clock _clock;
    [SerializeField] private Locations _location;
    [SerializeField] private Player _player;
    [SerializeField] private ActivationStages _activationStages;
    [SerializeField] private PlayerRank _playerRank;

    private int[] _scoreStages;
    private int _sumScores; 
    
    public event UnityAction<int, int, int> CalculateScore;
    public PlayerInfo PlayerInfo;
    public static Progress Instance;

    private void Awake()
    {
        Instance = this;
        _scoreStages = new int[_location.CountStage];
        Instance.PlayerInfo._isEffects = true;
#if !UNITY_EDITOR && UNITY_WEBGL
        LoadExtern();
#endif
    }

    private void Start()
    {
        PlayerInfo._scores = new int[_location.CountStage];
    }

    public void CountScore()
    {
        SetStageScores();
        SetTotalScores();
        CalculateScore?.Invoke(_scoreStages[_location._numberLevel], _location._numberLevel, _sumScores);
    }

    private void SetStageScores() {
        _scoreStages[_location._numberLevel] = _clock.RemainingTime + _player.Score;
        _scoreStages.CopyTo(PlayerInfo._scores, 0);        
#if !UNITY_EDITOR && UNITY_WEBGL
        Save();
#endif
    }

    private void SetTotalScores()
    {
        int sum = 0;

        foreach (var item in PlayerInfo._scores)
        {
            sum += item;
        }
        
        _sumScores = sum;
        _playerRank.ShowInfo();
#if !UNITY_EDITOR && UNITY_WEBGL
        SetToLeaderboard(_sumScores);
#endif
    }

    public void Save()
    {
        string jsonString = JsonUtility.ToJson(PlayerInfo);
        SaveExtern(jsonString);
    }

    public void SetPlayerInfo(string value)
    {
        PlayerInfo = JsonUtility.FromJson<PlayerInfo>(value);
        PlayerInfo._scores.CopyTo(_scoreStages, 0);
        SetTotalScores();

        for (int i = 0; i < PlayerInfo._scores.Length; i++)
        {
            CalculateScore?.Invoke(PlayerInfo._scores[i], i, _sumScores);
        }

        for (int i = 0; i <= PlayerInfo._countActiveStages; i++)
        {
            _activationStages.SetActivatedStages(i);
        }
    }
}
