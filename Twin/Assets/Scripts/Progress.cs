using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class PlayerInfo
{
    public int[] _scores; // ����������� ������ ����������� ������
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

    private int[] _scoreStages;
    private int _sumScores;   
    public event UnityAction<int, int, int> CalculateScore;
    public PlayerInfo PlayerInfo;

    private void Awake()
    {       
#if !UNITY_EDITOR && UNITY_WEBGL
        LoadExtern();
#endif
    }

    private void Start()
    {
        _scoreStages = new int[_location.CountStage];
    }

    public void CountScore()
    {
        SetStageScores();
        CountTotalScores();
        CalculateScore?.Invoke(_scoreStages[_location._numberLevel], _location._numberLevel, _sumScores);
    }

    private void SetStageScores() {
        _scoreStages[_location._numberLevel] = _clock.RemainingTime + _player.Score;
        // ���������� ������
#if !UNITY_EDITOR && UNITY_WEBGL
        Save();
#endif
    }

    private void CountTotalScores()
    {
        int sum = 0;

        foreach (var item in _scoreStages)
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

        _text.text = PlayerInfo._scores[0] + "\n"+
            PlayerInfo._scores[1] + "\n" +
            PlayerInfo._scores[2] + "\n" +
            PlayerInfo._scores[3] + "\n" +
            PlayerInfo._scores[4] + "\n" +
            PlayerInfo._scores[5] + "\n" +
            PlayerInfo._scores[6] + "\n" +
            PlayerInfo._scores[7] + "\n";

       /* for (int i = 0; i < _scoreStages.Length; i++)
        {
            CalculateScore?.Invoke(_scoreStages[i], i, _sumScores);
        }*/
    }
}
