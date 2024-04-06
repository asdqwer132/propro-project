using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class IPA
{
    public List<string> IPAList;
}
public class JsonManager
{
    JsonParser jsonParser = new JsonParser();
    
    public IPA Convert(string fileName)
    {
        IPA ipa = jsonParser.LoadJson<IPA>("C:/Users/LG/unity/propro-project/Assets/Data/" + fileName + ".Json");
        return ipa;
    }
}
