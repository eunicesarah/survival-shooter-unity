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

        public int score;

        public float totalDistanceTraveled = 0f;
        public DateTime startTime;
        public DateTime endTime;
        public TimeSpan playTime; 

        public int totalbullets = 0;
        public int bulletsHit = 0;
        public int deathCount = 0;
        public int questCompleted = 0;
        public int enemyKilled = 0;

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
                playerhealth = FindObjectOfType<PlayerHealth>();
                gameData.ArenaName = SceneManager.GetActiveScene().name;
                gameData.health = playerhealth.currentHealth;
                gameData.Name = "Save1";
                SaveGame();
                
            }

            if (load)
            {
                load = false;
                LoadGame("Save1");
            }

            if (test){
                test = false;
                float totalDistanceTraveledKm = totalDistanceTraveled / 1000f;
                Debug.Log(totalDistanceTraveledKm + " km");
            }

            if (increase)
            {
                increase = false;
                score += 10;
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
            if (scene.name == "Menu" || !loads) return;
            
            PlayerHealth playerhealth = FindObjectOfType<PlayerHealth>();
            if (playerhealth != null)
        {
            
            playerhealth.currentHealth = gameData.health;
            playerhealth.healthSlider.value = playerhealth.currentHealth;
        }

        else
        {
            Debug.LogWarning("PlayerHealth component not found in the loaded scene.");
        }


        }
        
        public void SaveGame() { 
            dataService.Save(gameData);
            
            }

        public void LoadGame(string gameName) {
            gameData = dataService.Load(gameName);


            if (String.IsNullOrWhiteSpace(gameData.ArenaName)) {
                gameData.ArenaName = "Testing";
            }

            SceneManager.LoadScene(gameData.ArenaName);
            loads = true;
            

        }
        public void DeleteGame(string gameName) { 
            dataService.Delete(gameName);
            }
    }
}