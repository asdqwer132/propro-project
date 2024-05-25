using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordCompiler
{
    Dictionary<string, string> dict = new Dictionary<string, string>()
    {
        { "AA0", "ɑ"},
        { "AA1", "ˈɑː"},
        { "AA2", "ˌɑ"},
        { "AE0", "æ"},
        { "AE1", "ˈæ"},
        { "AE2", "ˌæ"},
        { "AH0", "ə"},
        { "AH1", "ˈʌ"},
        { "AH2", "ˌʌ"},
        { "AO0", "ɔ"},
        { "AO1", "ˈɔː"},
        { "AO2", "ˌɔ"},
        { "AW0", "ʊ"},
        { "AW1", "ˈʊ"},
        { "AW2", "ˌʊ"},
        { "AY0", "ɪ"},
        { "AY1", "ˈɪ"},
        { "AY2", "ˌɪ"},
        { "B", "b"},
        { "CH", "tʃ"},
        { "D", "d"},
        { "DH", "ð"},
        { "EH0", "ɛ"},
        { "EH1", "ˈɛ"},
        { "EH2", "ˌɛ"},
        { "ER0", "ɚ"},
        { "ER1", "ˈɚ"},
        { "ER2", "ˌɚ"},
        { "EY0", "eɪ"},
        { "EY1", "ˈeɪ"},
        { "EY2", "ˌeɪ"},
        { "F", "f"},
        { "G", "g"},
        { "HH", "h"},
        { "IH0", "ɪ"},
        { "IH1", "ˈɪ"},
        { "IH2", "ˌɪ"},
        { "IY0", "i"},
        { "IY1", "ˈiː"},
        { "IY2", "ˌi"},
        { "JH", "dʒ"},
        { "K", "k"},
        { "L", "l"},
        { "M", "m"},
        { "N", "n"},
        { "NG", "ŋ"},
        { "OW0", "oʊ"},
        { "OW1", "ˈoʊ"},
        { "OW2", "ˌoʊ"},
        { "OY0", "ɔɪ"},
        { "OY1", "ˈɔɪ"},
        { "OY2", "ˌɔɪ"},
        { "P", "p"},
        { "R", "ɹ"},
        { "S", "s"},
        { "SH", "ʃ"},
        { "T", "t"},
        { "TH", "θ"},
        { "UH0", "ʊ"},
        { "UH1", "ˈʊ"},
        { "UH2", "ˌʊ"},
        { "UW", "uː"},
        { "UW0", "u"},
        { "UW1", "ˈuː"},
        { "UW2", "ˌu"},
        { "V", "v"},
        { "W", "w"},
        { "Y", "j"},
        { "Z", "z"},
        { "ZH", "ʒ"}
    };
    public List<string> GetAllIPA()
    {
        List<string> newList = new List<string>();
        foreach (KeyValuePair<string,string> entry in dict){
            newList.Add(entry.Value);
        }
        return newList;
    }
    //public string GetRandomIPA()
    //{
    //    RandomManager random = new RandomManager();
    //    int index = random.GetRandomInt(0, dict.Count);
    //    int i = 0;
    //    return null;
    //}
    public string[] ConvertWord(string[] value)
    {
        string[] output = new string[value.Length];
        for(int i = 0; i < value.Length; i++)
        {
            output[i] = ConvertPhonemes(value[i]);
        }
        return output;

    }
    string ConvertPhonemes(string value)
    {
        if (!dict.ContainsKey(value)) return "none";
        return dict[value];
    }
}
