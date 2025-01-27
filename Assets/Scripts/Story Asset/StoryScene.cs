using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newScene", menuName = "Data/New Story Scene")]
[System.Serializable]
public class StoryScene : ScriptableObject
{
    public List<Sentence> sentences;
    public Sprite background;
    public StoryScene nextScene;
    public string SceneName;

    [System.Serializable]
    public struct Sentence
    {
        public string text;
        public Person speaker;
    }
}
