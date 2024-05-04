using UnityEngine;

[CreateAssetMenu(fileName = "newPerson", menuName = "Data/New Person")]
[System.Serializable]
public class Person : ScriptableObject
{
    public string speakerName;
    public Color textColor;
}
