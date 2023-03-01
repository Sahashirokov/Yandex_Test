using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void AddCoinExtern(int value);
    public int NumberOfCoins;
    
    [SerializeField] TextMeshProUGUI _text;
    [SerializeField]  GameObject _advbutton;
    private void Start()
    {
        NumberOfCoins = Progress.Instance.PlayerInfo.Coins;
        _text.text = NumberOfCoins.ToString();
        transform.parent = null;
    }
    public void AddOne()
    {
        NumberOfCoins += 1;
        _text.text = NumberOfCoins.ToString();

    }
    public void SaveToProgress()
    {
        Progress.Instance.PlayerInfo.Coins = NumberOfCoins;
    }

    public void SpendMoney(int value)
    {
        NumberOfCoins -= value;
        _text.text = NumberOfCoins.ToString();
    }

    public void ShowAdvButton()
    {
        AddCoinExtern(100);
        _advbutton.SetActive(false);
    }

    public void AddCoins(int value)
    {
        NumberOfCoins += value;
        _text.text = NumberOfCoins.ToString();
        SaveToProgress();
    }
}
