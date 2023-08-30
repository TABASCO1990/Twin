using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;


public class Yandex : MonoBehaviour
{
    [DllImport("__Internal")] 
    private static extern void GiveMePlayerData();

    /*[DllImport("__Internal")] 
    private static extern void GiveLeaderRank();*/

    [SerializeField] private TMP_Text _nameText;
    /*[SerializeField] private TMP_Text _rankText;*/
    [SerializeField] private RawImage _photo;

  /*  public void HelloButton()
    {
        GiveLeaderRank();
    }

    public void GetRank(int rating)
    {     
        _rankText.text = rating.ToString();
    }*/

    public void SetName(string name)
    {
        _nameText.text = name;
    }

    public void SetPhoto(string url)
    {
        StartCoroutine(DownloadImage(url));
    }

    IEnumerator DownloadImage(string mediaUrl)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(mediaUrl);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            Debug.Log(request.error);
        else
            _photo.texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
    }
}
