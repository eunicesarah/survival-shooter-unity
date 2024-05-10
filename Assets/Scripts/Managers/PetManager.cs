using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Nightmare
{
    public class PetManager : MonoBehaviour
    {
        public bool isCactus = false;
        public bool isMushroom = false;

        public GameObject cactus;
        public GameObject mushroom;
        GameObject player;
        void Awake()
        {
            player = GameObject.FindGameObjectWithTag("Player");
            Debug.Log("Mushroom " + MainManager.Instance.isMushroom);
            Debug.Log("Cactus " + MainManager.Instance.isCactus);
            if (MainManager.Instance.isMushroom)
            {
                // petManager.isMushroom = true;
                this.SpawnPet(player.transform.position, "Mushroom");

            }

            if (MainManager.Instance.isCactus)
            {
                this.SpawnPet(player.transform.position, "Cactus");
                // petManager.isCactus = true;

            }
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        // public void SpawnPet(Vector3 position)
        // {
        //     if (isCactus)
        //     {
        //         Instantiate(cactus, position, Quaternion.identity);
        //     }
        //     else if (isMushroom)
        //     {
        //         Instantiate(mushroom, position, Quaternion.identity);
        //     }
        // }
        public void SpawnPet(Vector3 position, string petType)
        {
            if (petType == "Cactus")
            {
                Instantiate(cactus, position, Quaternion.identity);
            }
            else if (petType == "Mushroom")
            {
                Instantiate(mushroom, position, Quaternion.identity);
            }
        }

    }

}
