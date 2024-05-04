using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControlleropening : MonoBehaviour
{
    public StoryScene currentScene;
    public BottomBarController bottomBar;
    public BackgroundController backgroundController;
    public Canvas currentCanvas; 
    public Canvas nextCanvas; 

    void Start()
    {
        bottomBar.PlayScene(currentScene);
        backgroundController.SetImage(currentScene.background);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (bottomBar.IsCompleted())
            {
                if (bottomBar.IsLastSentence())
                {
                    currentCanvas.gameObject.SetActive(false);
                    nextCanvas.gameObject.SetActive(true);
                }
                else
                {
                    bottomBar.PlayNextSentence();
                }
            }
            else
            {
                bottomBar.ForceComplete();
            }
        }
    }
}
