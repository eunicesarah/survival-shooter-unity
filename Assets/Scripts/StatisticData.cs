using UnityEngine;
using System.Collections.Generic;
using System;

namespace Nightmare
{
    
    [System.Serializable]
    public class StatisticData 
    { 
        public string playTime; 

        public int totalbullets;
        public int bulletsHit;
        public int deathCount;
        public int questCompleted;
        public int enemyKilled;
        public float totalDistanceTraveled;

        public StatisticData(string playtime)
        {
            this.playTime = playtime;
        }

        public StatisticData()
        {
            
        }
    

    }
}