using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Security.Cryptography.X509Certificates;


namespace Nightmare
{
    public class ShopManager : MonoBehaviour
    {
        public int coins;
        public TMP_Text coinsUI;
        public ShopItemSo[] shopItemSO;
        public GameObject[] shopPanelsGO;
        public ShopTemplate[] shopPanels;
        public Button[] myPurchaseButton;
        // Start is called before the first frame update
        void Start()
        {
            for (int i = 0;i < shopItemSO.Length; i++)
            {
                shopPanelsGO[i].SetActive(true);
            }
            Debug.Log("testteste");


            coinsUI.text = "Coins : " +coins.ToString();
            LoadPanels();
            CheckPurchaseable();
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public void AddCoins()
        {
            coins+= 40;
            coinsUI.text = "Coins : "+ coins.ToString();
            CheckPurchaseable();
        }

        public void CheckPurchaseable()
        {
            Debug.Log(coins);
            for (int i = 0; i < shopItemSO.Length; i++)
            {
                if (coins >= shopItemSO[i].price)
                {
                    Debug.Log("Masuk sini button");
                    myPurchaseButton[i].interactable = true;
                }
                else
                    myPurchaseButton[i].interactable = false;
            }
        }

        public void PurchaseItem(int buttonNo)
        {
            if (coins >= shopItemSO[buttonNo].price)
            {
                coins-= shopItemSO[buttonNo].price;
                coinsUI.text = "Coins : " + coins.ToString();
                CheckPurchaseable();

            }
        }

        public void LoadPanels()
        {
            for (int i = 0; i < shopItemSO.Length; i++)
            {
                shopPanels[i].titleText.text = shopItemSO[i].title;
                shopPanels[i].descriptionText.text = shopItemSO[i].description;
                shopPanels[i].priceText.text = "$" + shopItemSO[i].price.ToString();
            }
        }
    }
}
