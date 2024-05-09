using UnityEngine;


namespace Nightmare
{
    
    [System.Serializable]
    public class GameData 
    { 
        public string Name;
        public string ArenaName;
        public int health;

        public int coins;

        public string getName()
        {
            return Name;
        }
        public string getArenaName()
        {
            return ArenaName;
        }
        public void setName(string name)
        {
            Name = name;
        }

        public void setArenaName(string arenaName)
        {
            ArenaName = arenaName;
        }
        public int getHealth()
        {
            return health;
        }
        public void setHealth(int health)
        {
            this.health = health;

        }
    }
}