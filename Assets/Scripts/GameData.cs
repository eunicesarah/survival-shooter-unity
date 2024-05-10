using UnityEngine;
using System.Collections.Generic;
using System;

namespace Nightmare
{
    
    [System.Serializable]
    public class GameData 
    { 
        public string Name;
        public string ArenaName;
        public int health;

        public int coins;

        public DateTime currentTime;

        public string playerName;

        public bool isMushroom;

        public bool isCactus;
        public GameData()
        {
            
        }

    }
}