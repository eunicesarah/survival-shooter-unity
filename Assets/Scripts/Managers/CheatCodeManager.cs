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
            cheatCodeList.Add("god");
            cheatCodeList.Add("infiniteammo");
            cheatCodeList.Add("infinitehealth");
        }


        void Update()
        {
            //if (timeBeforeCheatsEnds <= 0)
            //{
            //    cheatStarted = false;
            //    cPressed = false;
            //    hPressed = false;
            //    tPressed = false;
            //}

            //if (cheatStarted)
            //{
            //    timeBeforeCheatsEnds -= Time.deltaTime;

            //}

            //if (Input.GetKeyDown(KeyCode.C))
            //{
            //    timeBeforeCheatsEnds = maxTimeForCheat;
            //    cheatStarted = true;
            //    cPressed = true;
            //}
            //if (Input.GetKeyDown(KeyCode.H) && cPressed)
            //{
            //    timeBeforeCheatsEnds = maxTimeForCheat;
            //    hPressed = true;
            //}
            //if (Input.GetKeyDown(KeyCode.T) && hPressed)
            //{
            //    timeBeforeCheatsEnds = maxTimeForCheat;
            //    cheatActivated = true;
            //    tPressed = true;
            //}
            //if (cheatActivated)
            //{
            //    Debug.Log("cheat activated");
            //    playerHealth.godMode = true;
            //    cheatStarted = false;
            //    cPressed = false;
            //    hPressed = false;
            //    tPressed = false;
            //    cheatActivated = false;
            //}
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
                return true;
            }
            else if (_input == "fast")
            {
                Debug.Log("Cheat Activate " + _input);
                playerMovement.speed = 12f;
                return true;

            }
            else if (_input == "kill")
            {
                Debug.Log("Cheat Activate " + _input);
                playerShooting.damagePerShot = 1000000;
                return true;

            }
            //}
            return false;
        }
    }

}
