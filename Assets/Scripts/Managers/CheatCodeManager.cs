using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Nightmare
{
    public class CheatCodeManager : MonoBehaviour
    {
        float maxTimeForCheat= 15f;
        float timeBeforeCheatsEnds;
        bool cheatStarted, cPressed, hPressed, tPressed, cheatActivated;
        PlayerHealth playerHealth;
        PlayerMovement playerMovement;
        PlayerShooting playerShooting;
        Animator anim;
        private List<string> cheatCodeList = new List<string>();

        [SerializeField]
        private bool playerTyping = false;
        [SerializeField]
        private string currentString = "";

        private bool enterPressed = false;


        void Awake()
        {
            playerHealth = FindObjectOfType<PlayerHealth>();
            playerMovement = FindObjectOfType<PlayerMovement>();
            playerShooting = FindObjectOfType<PlayerShooting>();
            anim = GameObject.Find("HUDCanvas").GetComponent<Animator>();
        }

        void Update()
        {
            
            if (Input.GetKeyDown(KeyCode.Return))
            {
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
            //foreach (string code in cheatCodeList)
            //{
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
            //}
            return false;
        }
    }

}
