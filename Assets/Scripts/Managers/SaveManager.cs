using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

namespace Nightmare {
    public class SaveManager : MonoBehaviour
    {

        GameObject player;

        public QuestComplete questComplete;        
        public PauseManager pauseManager;
        public GameObject SaveSpot;
        public GameObject SaveText;
        public GameObject SaveUI;
        public GameObject HudUI;
        public GameObject pauseGO;

        public TextMeshProUGUI saveName1;
        public TextMeshProUGUI saveName2;
        public TextMeshProUGUI saveName3;
        public TextMeshProUGUI saveNameDate1;
        public TextMeshProUGUI saveNameDate2;
        public TextMeshProUGUI saveNameDate3;

        public TMP_InputField editName1;
        public TMP_InputField editName2;
        public TMP_InputField editName3;

    [SerializeField]
    private bool saveOpen = false;
    private bool open = false;


        void Awake()
        {
            player = GameObject.FindGameObjectWithTag("Player");
            pauseManager = FindObjectOfType<PauseManager>();
            questComplete = FindObjectOfType<QuestComplete>();
        }


        void Update()
        {
            
            if (SaveSpot != null && !MainManager.Instance.isFromLoad)
            {
                if(Vector3.Distance(player.transform.position, SaveSpot.transform.position) < 4f && !open && questComplete.isQuestCompleted)
                {
                        SaveText.SetActive(true);
                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            open = true;
                            saveOpen = !saveOpen;
                            SaveUI.SetActive(saveOpen);
                            HudUI.SetActive(!saveOpen);
                            pauseManager.Pause();
                            Debug.Log("Pause");
                            IEnumerable<string> saves = MainManager.Instance.ListSaves();
                            foreach (string save in saves)
                            {
                                
                                if (save[0] == '1')
                                {
                                    string[] parts = save.Split('_');
                                    saveName1.text = parts[1];
                                    saveNameDate1.text = parts[2] + "\n" + parts[3].Replace("-", ":");
                                    editName1.text = parts[1];
                                }
                                else if (save[0] == '2')
                                {
                                    string[] parts = save.Split('_');
                                    saveName2.text = parts[1];
                                    saveNameDate2.text = parts[2] + "\n" + parts[3].Replace("-", ":");
                                    editName2.text = parts[1];
                                }
                                else if (save[0] == '3')
                                {
                                    string[] parts = save.Split('_');
                                    saveName3.text = parts[1];
                                    saveNameDate3.text = parts[2] + "\n" + parts[3].Replace("-", ":");
                                    editName3.text = parts[1];
                                }
                            }
                        }
                }
                else
                {
                      SaveText.SetActive(false);
                }
            }
        }
        public void SaveGame1(){
            MainManager.Instance.SaveGame(saveName1.text, "1");
        }
        public void SaveGame2(){
            MainManager.Instance.SaveGame(saveName2.text, "2");
        }
        public void SaveGame3(){
            MainManager.Instance.SaveGame(saveName3.text, "3");
        }


        public void Cancel()
        {
            open = false;
            saveOpen = !saveOpen;
            SaveUI.SetActive(saveOpen);
            HudUI.SetActive(!saveOpen);
            pauseManager.Pause();
            Debug.Log("Play");
        }

    }

    

}
