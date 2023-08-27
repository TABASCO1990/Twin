using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class PlayerInfo
{
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
    [SerializeField] private TMP_Text _text;

    public PlayerInfo PlayerInfo;
    public event UnityAction<int, int, int> CalculateScore;
    private int _sumScores;

    private void Awake()
    {
        PlayerInfo._scoreStages = new int[_location.CountStage];
        LoadExtern();
    }

    public void CountScore()
    {
        SetScoreStage();
        SetTotalScores();
        CalculateScore?.Invoke(PlayerInfo._scoreStages[_location._numberLevel], _location._numberLevel, _sumScores);
        Save();
    }

    private void SetScoreStage()
    {
        PlayerInfo._scoreStages[_location._numberLevel] = _clock.RemainingTime + _player.Score;        
    }

    private void SetTotalScores()
    {
        int sum = 0;

        foreach (var item in PlayerInfo._scoreStages)
        {
            sum += item;
        }

        _sumScores = sum;
    }

    public void Save()
    {
        string jsonString = JsonUtility.ToJson(PlayerInfo);
        SaveExtern(jsonString);
    }

    public void SetPlayerInfo(string value)
    {
        PlayerInfo = JsonUtility.FromJson<PlayerInfo>(value);
        SetTotalScores();

        _text.text = "Total score: " + _sumScores + "\n"
    
           + "[0]: " + PlayerInfo._scoreStages[0] + "\n"
           + "[1]: " + PlayerInfo._scoreStages[1] + "\n"
           + "[2]: " + PlayerInfo._scoreStages[2] + "\n"
           + "[3]: " + PlayerInfo._scoreStages[3] + "\n"
           + "[4]: " + PlayerInfo._scoreStages[4] + "\n"
           + "[5]: " + PlayerInfo._scoreStages[5] + "\n"
           + "[6]: " + PlayerInfo._scoreStages[6] + "\n"
           + "[7]: " + PlayerInfo._scoreStages[7] + "\n";

        for (int i = 0; i < PlayerInfo._scoreStages.Length; i++)
        {
            CalculateScore?.Invoke(PlayerInfo._scoreStages[i], i, _sumScores);
        }
    }
}
