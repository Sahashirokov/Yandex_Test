using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;

public class YandexAutch : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void AutchPlayer();

    [SerializeField]  GameObject Actbutton;
    [SerializeField]  TextMeshProUGUI authtext;
    [SerializeField]  string oktext;
    
    
    
    public void Authbutton()
    {
        AutchPlayer();
    }

    public void SetButton(string obj)
    {
        if (authtext.text == "Log in"||authtext.text=="successfully")
        {
            oktext = oktext;
        }
        else
        {
            oktext = "Успех";
        }
        
        
        if (obj == "lite")
        {
           // Actbutton.SetActive(true);
           authtext.text = authtext.text;
        }
        else
        {
            authtext.text = oktext;
            // Actbutton.SetActive(false);
        }
    }
}
