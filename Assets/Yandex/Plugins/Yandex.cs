using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Yandex : MonoBehaviour
   
{
    [DllImport("__Internal")]
    private static extern void Hello();


    [DllImport("__Internal")]
    private static extern void GiveMePlayerData();


    [DllImport("__Internal")]
    private static extern void Rategame();

    [SerializeField] TextMeshProUGUI _nameText;
    [SerializeField] RawImage _photo;
    [SerializeField] GameObject _Objphoto;
   

    public void RateGameButton()
    {
        Rategame();
    }



    public void HelloButtin()
    {
        GiveMePlayerData();
    }

    public void SetName(string name)
    {
        _nameText.text = name;
    }

    
    public void SetPhoto(string url)
    {
        _Objphoto.SetActive(true);
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
