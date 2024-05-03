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
        //public int coins;
        public TMP_Text coinsUI;
        public ShopItemSo[] shopItemSO;
        public GameObject[] shopPanelsGO;
        public ShopTemplate[] shopPanels;
        public Button[] myPurchaseButton;

        CoinsManager coinsManager;
        //public bool unlimitedCoins = false;
        // Start is called before the first frame update
        void Start()
        {
            coinsManager = FindObjectOfType<CoinsManager>();
            for (int i = 0;i < shopItemSO.Length; i++)
            {
                shopPanelsGO[i].SetActive(true);
            }
            coinsUI.text = "Coins : " + coinsManager.coins.ToString();
            LoadPanels();
            CheckPurchaseable();
        }

        // Update is called once per frame
        void Update()
        {
            coinsUI.text = "Coins : " + coinsManager.coins.ToString();
        }

        public void CheckPurchaseable()
        {
            for (int i = 0; i < shopItemSO.Length; i++)
            {
                if (coinsManager.coins >= shopItemSO[i].price)
                {
                    myPurchaseButton[i].interactable = true;
                }
                else
                    myPurchaseButton[i].interactable = false;
            }
        }

        public void PurchaseItem(int buttonNo)
        {
            if (coinsManager.coins >= shopItemSO[buttonNo].price)
            {
                coinsManager.coins -= shopItemSO[buttonNo].price;
                coinsUI.text = "Coins : " + coinsManager.coins.ToString();
                CheckPurchaseable();

            }
        }

        public void LoadPanels()
        {
            for (int i = 0; i < shopItemSO.Length; i++)
            {
                shopPanels[i].titleText.text = shopItemSO[i].title;
                shopPanels[i].descriptionText.text = shopItemSO[i].description;
                shopPanels[i].priceText.text = "$ " + shopItemSO[i].price.ToString();
            }
        }
    }
}
