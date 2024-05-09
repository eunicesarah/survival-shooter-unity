using Nightmare;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{

    GameObject player;
    PauseManager pauseManager;

    public GameObject SaveSpot;
    public GameObject SaveText;
    public GameObject SaveUI;
    public GameObject HudUI;
    public GameObject pauseGO;

    [SerializeField]
    private bool saveOpen = false;


    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }


    void Update()
    {

        if (Vector3.Distance(player.transform.position, SaveSpot.transform.position) < 4f)
        {
            SaveText.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                saveOpen = !saveOpen;
                SaveUI.SetActive(saveOpen);
                HudUI.SetActive(!saveOpen);
                pauseManager.Pause();
            }
        }
        else
        {
            SaveText.SetActive(false);
        }

    }
}
