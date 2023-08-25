using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.Events;


[System.Serializable]
public class PlayerInfo
{
    //—юда любые данные любых типов
    //public int _sumScores;
    
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
    [SerializeField] private TMP_Text _playerInfoText;

    private int _sumScores;

    public PlayerInfo PlayerInfo;

    public event UnityAction<int, int, int> CalculateScore;

    public static Progress Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            transform.parent = null;
            DontDestroyOnLoad(gameObject);
            Instance = this;
            PlayerInfo._scoreStages = new int[_location.CountStage];
#if !UNITY_EDITOR && UNITY_WEBGL
        LoadExtern();
#endif
        }
        else
        {
            Destroy(gameObject);
        }
    }



    public void CountScore()
    {
        SetScoreStage();
        SetTotalScores();
        //CalculateScore?.Invoke(PlayerInfo._scoreStages[_location._numberLevel], _location._numberLevel, PlayerInfo._sumScores);
        CalculateScore?.Invoke(PlayerInfo._scoreStages[_location._numberLevel], _location._numberLevel, _sumScores);

    }

    private void SetScoreStage()
    {
        PlayerInfo._scoreStages[_location._numberLevel] = _clock.RemainingTime + _player.Score;
#if !UNITY_EDITOR && UNITY_WEBGL
        Save();
#endif
    }

    private void SetTotalScores()
    {
        int sum = 0;

        foreach (var item in PlayerInfo._scoreStages)
        {
            sum += item;
        }

        //PlayerInfo._sumScores = sum;
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
        //_playerInfoText.text = PlayerInfo._sumScores.ToString() + "\n" + PlayerInfo._scoreStages[0];
        _playerInfoText.text = _sumScores.ToString() + "\n" + PlayerInfo._scoreStages[0];
    }
}
