using UnityEngine;
using System.Runtime.InteropServices;

public class Marketing : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void ShowFullScreenAdv();

    public void ShowFullScreenAdvertisement()
    {
        ShowFullScreenAdv();
    }
}
