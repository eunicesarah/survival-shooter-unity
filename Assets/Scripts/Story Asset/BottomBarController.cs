using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Nightmare
{
public class BottomBarController : MonoBehaviour
{
    public TextMeshProUGUI barText;
    public TextMeshProUGUI name;

    private int sentenceIndex = -1;
    public StoryScene currentScene;
    public bool forceComplete = false;
    private State state = State.COMPLETED;

    private enum State
    {
        PLAYING, COMPLETED
    }

    public void PlayScene(StoryScene scene)
    {
        currentScene = scene;
        sentenceIndex = -1;
        PlayNextSentence();
    }

    public void PlayNextSentence()
    {
        StartCoroutine(TypeText(currentScene.sentences[++sentenceIndex].text));

        name.text = currentScene.sentences[sentenceIndex].speaker?.speakerName ?? "";
        // Debug.Log(name.text);
        Debug.Log(MainManager.Instance.playerName + " nama player");
        {
        if (name.text == "LoneWolf")
            name.text = MainManager.Instance.playerName;
        } 
        name.color = currentScene.sentences[sentenceIndex].speaker?.textColor ?? Color.white;

    }

    public bool IsCompleted()
    {
        return state == State.COMPLETED;
    }

    public bool IsLastSentence()
    {
        return sentenceIndex + 1 == currentScene.sentences.Count;
    }

    private IEnumerator TypeText(string text)
    {
        barText.text = "";
        state = State.PLAYING;
        int wordIndex = 0;

        while (state != State.COMPLETED)
        {
            barText.text += text[wordIndex];
            yield return new WaitForSeconds(0.05f);
            if (forceComplete)
            {
                wordIndex = text.Length;
                forceComplete = false;
                barText.text = text;
            }
            else
            {
                
                wordIndex++;
            }

            if (wordIndex >= text.Length)
            {
                state = State.COMPLETED;
                break;
            }
        }
    }

    public void ForceComplete()
    {
        forceComplete = true;
    }
}

}