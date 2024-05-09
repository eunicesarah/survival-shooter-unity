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
        void Awake()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        public void SpawnPet(Vector3 position)
        {
            if (isCactus)
            {
                Instantiate(cactus, position, Quaternion.identity);
            }
            else if (isMushroom)
            {
                Instantiate(mushroom, position, Quaternion.identity);
            }
        }
    }

}
