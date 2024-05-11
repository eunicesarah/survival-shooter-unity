using Nightmare;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    SceneNav sceneNav;
    public StoryScene currentScene;
    public BottomBarController bottomBar;
    public BackgroundController backgroundController;

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
                    if (!currentScene.nextScene)
                    {
                        if (currentScene.SceneName == "Ending3"){
                            Invoke("LoadSceneDelayed", 4f);
                        } else {
                        sceneNav = FindObjectOfType<SceneNav>();
                        sceneNav.PlayGame();

                        }
                    } 
                    else
                    {
                        currentScene = currentScene.nextScene;
                        bottomBar.PlayScene(currentScene);
                        backgroundController.SwitchImage(currentScene.background);
                    }
                    
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

    void LoadSceneDelayed()
        {
            SceneManager.LoadScene(0);
        }

}
