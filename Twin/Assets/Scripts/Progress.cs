using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.Events;


[System.Serializable]
public class PlayerInfo
{
    //—юда любые данные любых типов
    public int _sumScores;
    public int[] _scoreStages;
}

public class Progress : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void SaveExtern(string date);
    [DllImport("__Internal")]
    private static extern void LoadExtern();

    [SerializeField] private Clock _clock;
    [SerializeField] private Locations _location;
    [SerializeField] private Player _player;
    [SerializeField] private TextMeshProUGUI _playerInfoText;

    public PlayerInfo PlayerInfo;

    public event UnityAction<int, int, int> CalculateScore;

    private void Awake()
    {
        PlayerInfo._scoreStages = new int[_location.CountStage];
        LoadExtern();
    }

    public void CountScore()
    {
        PlayerInfo._scoreStages[_location._numberLevel] = _clock.RemainingTime + _player.Score;
        SetSumScores();
        CalculateScore?.Invoke(PlayerInfo._scoreStages[_location._numberLevel], _location._numberLevel, PlayerInfo._sumScores);
        Save();
    }

    private void SetSumScores()
    {
        int sum = 0;

        foreach (var item in PlayerInfo._scoreStages)
        {
            sum += item;
        }

        PlayerInfo._sumScores = sum;
    }

    public void Save()
    {
        string jsonString = JsonUtility.ToJson(PlayerInfo);
        SaveExtern(jsonString);
    }

    public void SetPlayerInfo(string value)
    {
        PlayerInfo = JsonUtility.FromJson<PlayerInfo>(value);
        _playerInfoText.text = PlayerInfo._sumScores.ToString();
    }
}
