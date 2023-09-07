using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class PlayerInfo
{
    public int[] _scores;
    public int _countActiveStages;
    public bool _isSound;
    public bool isEffects;
}

public class Progress : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void SaveExtern(string date);
    [DllImport("__Internal")]
    private static extern void LoadExtern();
    [DllImport("__Internal")]
    private static extern void SetToLeaderboard(int value);

    [SerializeField] private Clock _clock;
    [SerializeField] private Locations _location;
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private ActivationStages _activationStages;
    [SerializeField] private PlayerRank _playerRank;
    [SerializeField] private Sound _sound;
    [SerializeField] private Effects _effects;

    private int[] _scoreStages;
    private int _sumScores;   
    public event UnityAction<int, int, int> CalculateScore;
    public PlayerInfo PlayerInfo;
    public static Progress Inststance;

    private void Awake()
    {
        Inststance = this;
        _scoreStages = new int[_location.CountStage];
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

        _text.text = PlayerInfo._scores[0].ToString() + "\n" +
            PlayerInfo._scores[1].ToString() + "\n" +
            PlayerInfo._scores[2].ToString() + "\n" +
            PlayerInfo._scores[3].ToString() + "\n" +
            PlayerInfo._scores[4].ToString() + "\n" +
            PlayerInfo._scores[5].ToString() + "\n" +
            PlayerInfo._scores[6].ToString() + "\n" +
            PlayerInfo._scores[7].ToString() + "\n\n" +
            "Count Stage:" + PlayerInfo._countActiveStages + "\n\n" +
            "Progress: " + Inststance.PlayerInfo._isSound;

        for (int i = 0; i < PlayerInfo._scores.Length; i++)
        {
            CalculateScore?.Invoke(PlayerInfo._scores[i], i, _sumScores);
        }

        for (int i = 0; i <= PlayerInfo._countActiveStages; i++)
        {
            _activationStages.SetActivatedStages(i);
        }

        _sound.AudioEnabled = Inststance.PlayerInfo._isSound;
    }
}
