using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Nightmare {
public class CoinsManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int coins;
    public bool unlimitedCoins = false;
    public TMP_Text coinsUI;


    void Awake()
    {
        coins = MainManager.Instance.coin;
    }

    // Update is called once per frame
    void Update()
    {
        coinsUI.text = MainManager.Instance.coin.ToString();
    }

    public void UpdateCoinsUI()
    {
        coinsUI.text = MainManager.Instance.coin.ToString();
    }

    public void AddCoins(int amount)
    {
        MainManager.Instance.coin += amount;
    }

    public void SubstractCoins(int amount)
    {
        if(MainManager.Instance.coin-amount>=0)
        {
            MainManager.Instance.coin -= amount;
        }


    }
}
}
