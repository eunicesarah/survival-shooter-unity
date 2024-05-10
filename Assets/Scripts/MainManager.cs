using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Nightmare
{
    
    public class MainManager : MonoBehaviour
    {

        private static MainManager instance;
        [SerializeField] public GameData gameData;

        public static MainManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject obj = new GameObject("MainManager");
                instance = obj.AddComponent<MainManager>();
                DontDestroyOnLoad(obj);
            }
            return instance;
        }
    }


        DataManager dataService;
        PlayerHealth playerhealth;

        CameraFollow camera;

        public int playerHealth = 100;
        public int coin = 100;

        public float totalDistanceTraveled = 0f;
        public DateTime startTime;
        public DateTime endTime;
        public TimeSpan playTime; 

        public int totalbullets = 0;
        public int bulletsHit = 0;
        public int deathCount = 0;
        public int questCompleted = 0;
        public int enemyKilled = 0;
        public DateTime startTimeScene;
        public float distanceTraveledScene = 0f;
        public int totalbulletsScene = 0;
        public int bulletsHitScene = 0;
        public int enemyKilledScene = 0;

        public string saveName;

        public string playerName;

        public int difficulty = 1;

        private bool loads = false;
        [SerializeField] private bool save = false;
        [SerializeField] private bool load = false;

        [SerializeField] private bool test = false;

        [SerializeField] private bool increase = false;

        private void OnValidate()
        {
        
            if (save)
            {
                save = false;
                // playerhealth = FindObjectOfType<PlayerHealth>();
                // gameData.ArenaName = SceneManager.GetActiveScene().name;
                // gameData.health = playerhealth.currentHealth;
                // gameData.coins = this.coin;
                // gameData.Name = "Save1";
                SaveGame("Save1", "1");
                
            }

            if (load)
            {
                load = false;
                LoadGame(saveName);
            }

            if (test){
                test = false;
                // float totalDistanceTraveledKm = totalDistanceTraveled / 1000f;
                // Debug.Log(totalDistanceTraveledKm + " km");
                Debug.Log("masuk");
                IEnumerable<string> saves = ListSaves();
                foreach (string save in saves)
                {
                    Debug.Log(save);
                }
            }

            if (increase)
            {
                increase = false;
                this.coin += 10;
            }
        }
     

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
        
        void Start() {
            SceneManager.sceneLoaded += OnSceneLoaded;
            startTime = DateTime.Now;
            dataService = new DataManager();
            gameData = new GameData();
        }

        void Update(){
            if (Input.GetKeyDown(KeyCode.Escape))
            {
            endTime = DateTime.Now;
            playTime = endTime - startTime;
            string playTimeFormatted = $"{playTime.Hours:00}:{playTime.Minutes:00}:{playTime.Seconds:00}";
            Debug.Log("Playtime: " + playTimeFormatted);

            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                float accuracy = (float)bulletsHit / totalbullets * 100;
                Debug.Log(accuracy + "% accuracy");
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Story progress: " + (float) (questCompleted / 4 * 100) + "%");
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Enemies killed: " + enemyKilled);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Deaths: " + deathCount);
            }





        }

        void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
            if (!loads) return;

            if (scene.name == "Help"){
                this.playerHealth = 100;
                this.coin = 100;
                return;
            }
            
            PlayerHealth playerhealth = FindObjectOfType<PlayerHealth>();

            // GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

            //         if(enemies!=null)
            //         {
            //             foreach (GameObject enemy in enemies)
            //             {
            //                 Destroy(enemy);
            //             }
            //         }
            QuestComplete questComplete = FindObjectOfType<QuestComplete>();
            questComplete.isFromLoad = true;
            
            if (playerhealth != null)
            {
                
                playerhealth.currentHealth = gameData.health;
                playerhealth.healthSlider.value = playerhealth.currentHealth;
                this.playerName = gameData.playerName;
                this.playerHealth = gameData.health;
                this.coin = gameData.coins;
            }

            else
            {
                Debug.LogWarning("PlayerHealth component not found in the loaded scene.");
            }


        }
        
        public void SaveGame(string gameName, string index) { 
            IEnumerable<string> saves = ListSaves();
            foreach (string save in saves)
            {
                if (save[0].ToString() == index)
                {
                    DeleteGame(save);
                }
            }
            playerhealth = FindObjectOfType<PlayerHealth>();
            gameData.playerName = this.playerName;
            gameData.ArenaName = SceneManager.GetActiveScene().name;
            gameData.health = playerhealth.currentHealth;
            gameData.coins = this.coin;
            gameData.Name = index + "_" +  gameName + "_" + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
            gameData.currentTime = DateTime.Now;
            dataService.Save(gameData);
            
            }

        public void LoadGame(string gameName) {
            gameData = dataService.Load(gameName);
            SceneManager.LoadScene(gameData.ArenaName);
            loads = true;
        }
        public void DeleteGame(string gameName) { 
            dataService.Delete(gameName);
        }
        
        public IEnumerable<string> ListSaves() {
            return dataService.ListSaves();
        }
    }
}