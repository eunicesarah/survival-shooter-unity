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
        public GameObject[] myImage;

        PetManager petManager;
        GameObject player;

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
            coinsUI.text = coinsManager.coins.ToString();
            petManager = FindObjectOfType<PetManager>();
            player = GameObject.FindGameObjectWithTag("Player");
            LoadPanels();
            CheckPurchaseable();
        }

        // Update is called once per frame
        void Update()
        {
            coinsUI.text = coinsManager.coins.ToString();
        }

        public void CheckPurchaseable()
        {
            for (int i = 0; i < shopItemSO.Length; i++)
            {
                Debug.Log("Checking purchaseable "+ petManager.isCactus + " " + petManager.isMushroom );

                // if(petManager.isCactus || petManager.isMushroom)
                // {
                //     myPurchaseButton[i].interactable = false;
                //     myImage[i].SetActive(true);
                // }
                // else
                // {
                //     if (coinsManager.coins >= shopItemSO[i].price)
                //     {
                //         myPurchaseButton[i].interactable = true;
                //         myImage[i].SetActive(false);
                //     }
                //     else
                //     {
                //         myPurchaseButton[i].interactable = false;
                //     }

                // }
                if (coinsManager.coins >= shopItemSO[i].price)
                {
                    if(i == 0 && petManager.isMushroom)
                    {
                        myPurchaseButton[i].interactable = false;
                        myImage[i].SetActive(true);
                    }
                    else if(i == 1 && petManager.isCactus)
                    {
                        myPurchaseButton[i].interactable = false;
                        myImage[i].SetActive(true);
                    }
                    else
                    {
                        myPurchaseButton[i].interactable = true;
                        myImage[i].SetActive(false);
                    }
                }
                else
                {
                    myPurchaseButton[i].interactable = false;
                    myImage[i].SetActive(true);
                }



            }
        }

        public void PurchaseItem(int buttonNo)
        {
            if (coinsManager.coins >= shopItemSO[buttonNo].price)
            {
                coinsManager.coins -= shopItemSO[buttonNo].price;
                coinsUI.text = "Coins : " + coinsManager.coins.ToString();
                if(buttonNo == 0)
                {
                    petManager.isMushroom = true;
                    petManager.SpawnPet(player.transform.position, "Mushroom");
                }
                else if(buttonNo == 1)
                {
                    petManager.isCactus = true;
                    petManager.SpawnPet(player.transform.position, "Cactus");
                }
                // petManager.SpawnPet(player.transform.position);
                CheckPurchaseable();

            }
        }

        public void LoadPanels()
        {
            for (int i = 0; i < shopItemSO.Length; i++)
            {
                shopPanels[i].titleText.text = shopItemSO[i].title;
                shopPanels[i].descriptionText.text = shopItemSO[i].description;
                shopPanels[i].priceText.text = shopItemSO[i].price.ToString();
            }
        }
    }
}
