using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class PlayerRank : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void GetPlayerRank();

    [SerializeField] private TMP_Text _rank;

    public event UnityAction<int> RatingChanged;

    public void ShowInfo()
    {
#if !UNITY_EDITOR && UNITY_WEBGL
        GetPlayerRank();
#endif
    }

    public void SetInfo(int rating)
    {
        _rank.text = rating.ToString();
        RatingChanged?.Invoke(rating);
    }
}
