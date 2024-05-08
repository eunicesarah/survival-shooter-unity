using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Nightmare
{
    public class CheatCodeManager : MonoBehaviour
    {

        PlayerHealth playerHealth;
        PlayerMovement playerMovement;
        PlayerShooting playerShooting;
        Animator anim;
        GameObject enterMark;
        ShopManager shopManager;
        CoinsManager coinsManager;

        GameObject player;

        SpawnOrbs orbsManager;

        PetManager petManager;

        Transform mushroom;
        Transform cactus;
        MushroomHealth mushroomHealth;
        CactusHealth cactusHealth;


        [SerializeField]
        private bool playerTyping = false;
        [SerializeField]
        private string currentString = "";


        void Awake()
        {
            playerHealth = FindObjectOfType<PlayerHealth>();
            playerMovement = FindObjectOfType<PlayerMovement>();
            playerShooting = FindObjectOfType<PlayerShooting>();
            orbsManager = FindObjectOfType<SpawnOrbs>();
            anim = GameObject.Find("HUDCanvas").GetComponent<Animator>();
            enterMark = GameObject.Find("HUDCanvas").transform.GetChild(6).gameObject;
            coinsManager = FindObjectOfType<CoinsManager>();
            player = GameObject.FindGameObjectWithTag("Player");
            petManager = FindObjectOfType<PetManager>();
        }

        void Update()
        {
            mushroom = GameObject.Find("MushroomSmilePA(Clone)")?.transform;
            cactus = GameObject.Find("CactusPA(Clone)")?.transform;
            if (mushroom != null)
                mushroomHealth = mushroom.GetComponent<MushroomHealth>();

            if (cactus != null)
                cactusHealth = cactus.GetComponent<CactusHealth>();
            
            if (Input.GetKeyDown(KeyCode.Return))
            {
                enterMark.SetActive(!enterMark.activeSelf);
                if (playerTyping)
                {
                    CheckCheat(currentString);
                }
                playerTyping = !playerTyping;
            }


            if (playerTyping)
            {
                foreach (char c in Input.inputString)
                {
                    if (c == '\b')
                    {
                        if (currentString.Length > 0)
                        {
                            currentString = currentString.Substring(0,currentString.Length - 1);
                        }
                    }
                    else if (c == '\n' || c == '\r')
                    {
                        currentString = "";
                    }
                    else
                    {
                        currentString += c;
                    }
                }
            }

        }
        private bool CheckCheat(string _input)
        {
            if (_input == "god")
            {
                Debug.Log("Cheat Activate " + _input);
                playerHealth.godMode = true;
                anim.SetTrigger("Cheat");
                return true;
            }
            else if (_input == "fast")
            {
                Debug.Log("Cheat Activate " + _input);
                playerMovement.speed = 12f;
                anim.SetTrigger("Cheat");
                return true;

            }
            else if (_input == "kill")
            {
                Debug.Log("Cheat Activate " + _input);
                playerShooting.damagePerShot = 1000000;
                anim.SetTrigger("Cheat");
                return true;

            }
            else if (_input == "rich")
            {
                Debug.Log("Cheat Activate " + _input);
                coinsManager.unlimitedCoins = true;
                coinsManager.coins = 9999999;
                coinsManager.UpdateCoinsUI();
                anim.SetTrigger("Cheat");
                return true;
            }
            else if(_input=="orbs")
            {
                Debug.Log("Cheat Activate " + _input);
                orbsManager.SpawnAllOrbs(player.transform);
                anim.SetTrigger("Cheat");
                return true;
            }
            else if(_input=="opet") //heal pet
            {
                Debug.Log("Cheat Activate " + _input);
                if(mushroom!=null)
                {
                    Debug.Log("Mushroom Health: " + mushroomHealth.currentHealth);
                    if (petManager.isMushroom)
                    {

                        mushroomHealth.currentHealth = 40;
                        Debug.Log("Mushroom Health: " + mushroomHealth.currentHealth);
                    }
                }else if (cactus != null)
                {

                    Debug.Log("Cactus Health: " + cactusHealth.currentHealth);
                    if (petManager.isCactus)
                    {
                        cactusHealth.currentHealth = 40;
                        Debug.Log("Cactus Health: " + cactusHealth.currentHealth);
                    }
                }
                anim.SetTrigger("Cheat");
                return true;
            }
            else if(_input=="xpet")// kill pet
            {
                Debug.Log("Cheat Activate " + _input);
                if(cactus!=null)
                {
                    // Debug.Log("Mushroom Health: " + mushroomHealth.currentHealth);
                    if (petManager.isCactus)
                    {
                        cactusHealth.currentHealth = 0;
                        petManager.isCactus = false;
                    }

                }else if ( mushroom!= null)
                {
                    if (petManager.isMushroom)
                    {
                        mushroomHealth.currentHealth = 0;
                        petManager.isMushroom = false;
                    }
                }
                anim.SetTrigger("Cheat");
                return true;
            }
            else
            {
                Debug.Log("Cheat not found");
                return false;
            }
            return false;
        }
    }

}
