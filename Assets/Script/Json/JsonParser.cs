
using System.IO;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
public class JsonParser
{
    public void SaveJson<T>(T saveData, string path)
    {
        string jsonData = ObjectToJson(saveData);

        File.WriteAllText(path, jsonData);
    }
    public T LoadJson<T>(string path)
    {
        var handle = Addressables.LoadAssetAsync<TextAsset>(path);
        handle.WaitForCompletion();
        if (handle.Status != AsyncOperationStatus.Succeeded)
        {
            Debug.LogError("Cannot open path");
        }
        T data = JsonToOject<T>(handle.Result.text);
        return data;

    }
    public string ObjectToJson(object obj) { return JsonConvert.SerializeObject(obj, Formatting.Indented); }
    public T JsonToOject<T>(string jsonData) { return JsonConvert.DeserializeObject<T>(jsonData); }
}
