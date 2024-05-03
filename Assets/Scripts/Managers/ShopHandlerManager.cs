using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Nightmare
{
    public class ShopHandlerManager : MonoBehaviour
    {

        public GameObject shopUI;
        public GameObject HUDUI;
        [SerializeField]
        private bool shopOpen = false;

        void Awake()
        {
            shopUI = GameObject.Find("ShopCanvas").transform.GetChild(0).gameObject;
            HUDUI = GameObject.Find("HUDCanvas");
        }


        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                shopOpen = !shopOpen;
                shopUI.SetActive(shopOpen);
                HUDUI.SetActive(!shopOpen);

            }
        }
    }

}
