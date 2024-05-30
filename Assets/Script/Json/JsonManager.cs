using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class IPA
{
    public List<string> IPAList;
}
[System.Serializable]
public class Explain
{
    public List<IPAEx> IPAEx;
}
[System.Serializable]
public class IPAEx
{
    public string ipa;
    public List<string> explain;
}
public class JsonManager
{
    JsonParser jsonParser = new JsonParser();
    
    public T Convert<T>(string fileName)
    {
        //Debug.Log(Application.persistentDataPath + "../data" + fileName + ".Json");
        T ipa = jsonParser.LoadJson<T>("data/" + fileName);
        return ipa;
    }
}
