using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    public class PlayerRank : MonoBehaviour
    {
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

        [DllImport("__Internal")] private static extern void GetPlayerRank();
    }
}
