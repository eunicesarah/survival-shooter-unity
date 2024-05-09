using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Nightmare
{
    public class DataManager {
    string dataPath;
    string fileExtension;

    public DataManager() {
        this.dataPath = Application.persistentDataPath;
        this.fileExtension = "json";
    }

    string GetPathToFile(string fileName) {
        return Path.Combine(dataPath, string.Concat(fileName, ".", fileExtension));
    }
    
    public void Save(GameData data, bool overwrite = true) {
        string fileLocation = GetPathToFile(data.Name);

        if (!overwrite && File.Exists(fileLocation)) {
            throw new IOException("The file already exists and cannot be overwritten.");
        }

        File.WriteAllText(fileLocation, Serialize(data));
    }

    public GameData Load(string name) {
        string fileLocation = GetPathToFile(name);

        if (!File.Exists(fileLocation)) {
            throw new ArgumentException($"No file : '{name}'");
        }

        return Deserialize<GameData>(File.ReadAllText(fileLocation));
    }

    public void Delete(string name) {
        string fileLocation = GetPathToFile(name);

        if (File.Exists(fileLocation)) {
            File.Delete(fileLocation);
        }
    }

    public IEnumerable<string> ListSaves() {
        foreach (string path in Directory.EnumerateFiles(dataPath)) {
            if (Path.GetExtension(path) == fileExtension) {
                yield return Path.GetFileNameWithoutExtension(path);
            }
        }
    }

    public string Serialize<T>(T obj) {
            return JsonUtility.ToJson(obj, true);
        }

    public T Deserialize<T>(string json) {
            return JsonUtility.FromJson<T>(json);
        }
    }
}
