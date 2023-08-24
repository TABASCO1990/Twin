using System.Linq;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.Events;


/*[System.Serializable] public class PlayerInfo
{
    //—юда любые данные любых типов
    public int _sumScores;
    public int[] _scoreStages;
}*/

public class Progress : MonoBehaviour
{
    [DllImport("__Internal")] private static extern void SaveExtern(string date);
    [DllImport("__Internal")] private static extern void LoadExtern();

    [SerializeField] private Clock _clock;
    [SerializeField] private Locations _location;
    [SerializeField] private Player _player;
    [SerializeField] private TextMeshProUGUI _playerInfoText;

    //private PlayerInfo _playerInfo;

    public int _sumScores;
    public int[] _scoreStages;

    /*private void Awake()
    {
#if UNITY_WEBGL
        LoadExtern();
#endif
    }*/

    public event UnityAction<int,int,int> CalculateScore;
    //public PlayerInfo PlayerInfo;  

    private void Start()
    {
        //_playerInfo._scoreStages = new int[_location.CountStage];
        _scoreStages = new int[_location.CountStage];
    }

    public void CountScore()
    {
        //_playerInfo._scoreStages[_location._numberLevel] = _clock.RemainingTime + _player.Score;
        _scoreStages[_location._numberLevel] = _clock.RemainingTime + _player.Score;
        SetSumScores();

#if UNITY_WEBGL
        //Save();
#endif

        //CalculateScore?.Invoke(_playerInfo._scoreStages[_location._numberLevel],_location._numberLevel, _playerInfo._sumScores);
        CalculateScore?.Invoke(_scoreStages[_location._numberLevel],_location._numberLevel, _sumScores);
    }

    private void SetSumScores()
    {
        _sumScores = _scoreStages.Sum();
        //_playerInfo._sumScores = _playerInfo._scoreStages.Sum();
    }

    /*public void Save()
    {
        string jsonString = JsonUtility.ToJson(PlayerInfo);
        SaveExtern(jsonString);
    }

    public void SetPlayerInfo(string value)
    {
        PlayerInfo = JsonUtility.FromJson<PlayerInfo>(value);
        _playerInfoText.text = PlayerInfo._sumScores + " " + string.Join(", ", PlayerInfo._scoreStages);
    }*/
}
