using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Nightmare
{
    public class ShopHandlerManager : MonoBehaviour
    {

        public GameObject shopUI;
        public GameObject HUDUI;

        public GameObject player;
        public GameObject shopKeeper;

        public GameObject interactText;
        public GameObject noShopText;
        public GameObject pauseGO;
        public PauseManager pauseManager;

        public QuestComplete questComplete;
        Animator anim;

        [SerializeField]
        private bool shopOpen = false;

        public GameObject shopManagerGO;
        ShopManager shopManager;
        public GameObject backButton;

        void Awake()
        {
            // shopUI = GameObject.Find("ShopCanvas").transform.GetChild(0).gameObject;
            // HUDUI = GameObject.Find("HUDCanvas");
            // interactText = HUDUI.transform.GetChild(8).gameObject;
            player = GameObject.FindGameObjectWithTag("Player");
            anim = GameObject.Find("HUDCanvas").GetComponent<Animator>();
            // shopKeeper = GameObject.FindGameObjectWithTag("ShopKeeper");
            // pauseGO = GameObject.Find("PauseCanvas");
            pauseManager = FindObjectOfType<PauseManager>();
            questComplete = FindObjectOfType<QuestComplete>();
            shopManager = shopManagerGO.GetComponent<ShopManager>();
            backButton = shopUI.transform.GetChild(6).gameObject;
        }


        void Update()
        {
            if(shopKeeper!=null && !MainManager.Instance.isFromLoad)
            {
                if(Vector3.Distance(player.transform.position, shopKeeper.transform.position) < 5f && questComplete.isQuestCompleted)
                {
                    interactText.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        shopOpen = !shopOpen;
                        shopUI.SetActive(shopOpen);
                        HUDUI.SetActive(!shopOpen);
                        shopManager.CheckPurchaseable();
                        // pauseManager.Pause();

                    }
                    // shopOpen = false;
                    // shopUI.SetActive(shopOpen);
                    // HUDUI.SetActive(!shopOpen);
                }else{
                    interactText.SetActive(false);
                }
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                anim.SetTrigger("NoShop");
            }

        }

        public void CloseShop()
        {
            shopOpen = false;
            shopUI.SetActive(shopOpen);
            HUDUI.SetActive(!shopOpen);
            // backButton.SetActive(false);
        }
    }

}
