using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] CoinManager _coinManager;

    Playermodifer _playermodifer;

    [DllImport("__Internal")]
    private static extern void SetToLeaderboard(int value);



    private void Start()
    {
        _playermodifer = FindObjectOfType<Playermodifer>();
    }
    public void BuyWidth()
    {
        if(_coinManager.NumberOfCoins >= 100)
        {
            _coinManager.SpendMoney(100);
            Progress.Instance.PlayerInfo.Coins = _coinManager.NumberOfCoins;
            Progress.Instance.PlayerInfo.Width += 25;
            _playermodifer.SetWidtch(Progress.Instance.PlayerInfo.Width);
        }

    }
    public void BuyHeight()
    {
        if (_coinManager.NumberOfCoins >= 100)
        {
            _coinManager.SpendMoney(100);
            Progress.Instance.PlayerInfo.Coins = _coinManager.NumberOfCoins;
            Progress.Instance.PlayerInfo.Height += 25;

            SetToLeaderboard(Progress.Instance.PlayerInfo.Height);

            _playermodifer.SetHeight(Progress.Instance.PlayerInfo.Height);
        }
    }
}
