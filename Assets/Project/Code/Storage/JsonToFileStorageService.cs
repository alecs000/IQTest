using Newtonsoft.Json;
using System;
using System.IO;
using UnityEngine;
using Path = System.IO.Path;

public class JsonToFileStorageService : IStorageServic
{
    public void Loud<T>(string key, Action<T> callback)
    {
        string path = BuildPath(key);
        if (!File.Exists(path))
        {
            return;
        }
        using (var fileStream = new StreamReader(path))
        {
            string json = fileStream.ReadToEnd();
            var data = JsonConvert.DeserializeObject<T>(json);

            callback?.Invoke(data);
        }
    }

    public void Save(string key, object data, Action<bool> callback = null)
    {
        string path = BuildPath(key);
        string json = JsonConvert.SerializeObject(data);
        using (var fileStream = new StreamWriter(path))
        {
            fileStream.Write(json);
        }
        callback?.Invoke(true);
    }
    private string BuildPath(string path)
    {
        return Path.Combine(Application.persistentDataPath, path);
    }
}
