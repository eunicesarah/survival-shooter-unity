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
        public GameObject pauseGO;
        public PauseManager pauseManager;

        [SerializeField]
        private bool shopOpen = false;

        void Awake()
        {
            shopUI = GameObject.Find("ShopCanvas").transform.GetChild(0).gameObject;
            HUDUI = GameObject.Find("HUDCanvas");
            interactText = HUDUI.transform.GetChild(8).gameObject;
            player = GameObject.FindGameObjectWithTag("Player");
            shopKeeper = GameObject.FindGameObjectWithTag("ShopKeeper");
            pauseGO = GameObject.Find("PauseCanvas");
            pauseManager = FindObjectOfType<PauseManager>();
        }


        void Update()
        {
            if(shopKeeper!=null)
            {
                if(Vector3.Distance(player.transform.position, shopKeeper.transform.position) < 5f)
                {
                    interactText.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        shopOpen = !shopOpen;
                        shopUI.SetActive(shopOpen);
                        HUDUI.SetActive(!shopOpen);
                        pauseManager.Pause();

                    }
                    // shopOpen = false;
                    // shopUI.SetActive(shopOpen);
                    // HUDUI.SetActive(!shopOpen);
                }else{
                    interactText.SetActive(false);
                }
            }

        }
    }

}
