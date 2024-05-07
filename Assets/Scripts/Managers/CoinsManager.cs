using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinsManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int coins;
    public bool unlimitedCoins = false;
    public TMP_Text coinsUI;


    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        coinsUI.text = coins.ToString();
    }

    public void UpdateCoinsUI()
    {
        coinsUI.text = coins.ToString();
    }

    public void AddCoins(int amount)
    {
        coins += amount;
    }

    public void SubstractCoins(int amount)
    {
        if(coins-amount>=0)
        {
            coins -= amount;
        }


    }
}
