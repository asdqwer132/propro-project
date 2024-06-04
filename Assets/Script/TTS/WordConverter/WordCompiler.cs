using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordCompiler
{
    Dictionary<string, string> dictionary = new Dictionary<string, string>()
    {
#region 원본 발음
        //{ "AA0", "ɑ"},
        //{ "AA1", "ˈɑː"},
        //{ "AA2", "ˌɑ"},
        //{ "AE0", "æ"},
        //{ "AE1", "ˈæ"},
        //{ "AE2", "ˌæ"},
        //{ "AH0", "ə"},
        //{ "AH1", "ˈʌ"},
        //{ "AH2", "ˌʌ"},
        //{ "AO0", "ɔ"},
        //{ "AO1", "ˈɔː"},
        //{ "AO2", "ˌɔ"},
        //{ "AW0", "ʊ"},
        //{ "AW1", "ˈʊ"},
        //{ "AW2", "ˌʊ"},
        //{ "AY0", "ɪ"},
        //{ "AY1", "ˈɪ"},
        //{ "AY2", "ˌɪ"},
        //{ "B", "b"},
        //{ "CH", "tʃ"},
        //{ "D", "d"},
        //{ "DH", "ð"},
        //{ "EH0", "ɛ"},
        //{ "EH1", "ˈɛ"},
        //{ "EH2", "ˌɛ"},
        //{ "ER0", "ɚ"},
        //{ "ER1", "ˈɚ"},
        //{ "ER2", "ˌɚ"},
        //{ "EY0", "eɪ"},
        //{ "EY1", "ˈeɪ"},
        //{ "EY2", "ˌeɪ"},
        //{ "F", "f"},
        //{ "G", "g"},
        //{ "HH", "h"},
        //{ "IH0", "ɪ"},
        //{ "IH1", "ˈɪ"},
        //{ "IH2", "ˌɪ"},
        //{ "IY0", "i"},
        //{ "IY1", "ˈiː"},
        //{ "IY2", "ˌi"},
        //{ "JH", "dʒ"},
        //{ "K", "k"},
        //{ "L", "l"},
        //{ "M", "m"},
        //{ "N", "n"},
        //{ "NG", "ŋ"},
        //{ "OW0", "oʊ"},
        //{ "OW1", "ˈoʊ"},
        //{ "OW2", "ˌoʊ"},
        //{ "OY0", "ɔɪ"},
        //{ "OY1", "ˈɔɪ"},
        //{ "OY2", "ˌɔɪ"},
        //{ "P", "p"},
        //{ "R", "ɹ"},
        //{ "S", "s"},
        //{ "SH", "ʃ"},
        //{ "T", "t"},
        //{ "TH", "θ"},
        //{ "UH0", "ʊ"},
        //{ "UH1", "ˈʊ"},
        //{ "UH2", "ˌʊ"},
        //{ "UW", "uː"},
        //{ "UW0", "u"},
        //{ "UW1", "ˈuː"},
        //{ "UW2", "ˌu"},
        //{ "V", "v"},
        //{ "W", "w"},
        //{ "Y", "j"},
        //{ "Z", "z"},
        //{ "ZH", "ʒ"}
#endregion
        { "AA0", "ɑ"},
        { "AA1", "ɑː"},
        { "AA2", "ɑ"},
        { "AE0", "æ"},
        { "AE1", "æ"},
        { "AE2", "æ"},
        { "AH0", "ə"},
        { "AH1", "ʌ"},
        { "AH2", "ʌ"},
        { "AO0", "ɔ"},
        { "AO1", "ɔː"},
        { "AO2", "ɔ"},
        { "AW0", "u"},
        { "AW1", "u"},
        { "AW2", "u"},
        { "AY0", "iː"},
        { "AY1", "iː"},
        { "AY2", "iː"},
        { "B", "b"},
        { "CH", "tʃ"},
        { "D", "d"},
        { "DH", "ð"},
        { "EH0", "ɛ"},
        { "EH1", "ɛ"},
        { "EH2", "ɛ"},
        { "ER0", "ə"},
        { "ER1", "ə"},
        { "ER2", "ə"},
        { "EY0", "e"},
        { "EY1", "e"},
        { "EY2", "e"},
        { "F", "f"},
        { "G", "g"},
        { "HH", "h"},
        { "IH0", "iː"},
        { "IH1", "iː"},
        { "IH2", "iː"},
        { "IY0", "i"},
        { "IY1", "iː"},
        { "IY2", "i"},
        { "JH", "dʒ"},
        { "K", "k"},
        { "M", "m"},
        { "N", "n"},
        { "NG", "ŋ"},
        { "OW0", "ou"},
        { "OW1", "ou"},
        { "OW2", "ou"},
        { "OY0", "ɔi"},
        { "OY1", "ɔi"},
        { "OY2", "ɔi"},
        { "P", "p"},
        { "R", "ɹ"},
        { "S", "s"},
        { "SH", "ʃ"},
        { "T", "t"},
        { "TH", "θ"},
        { "UH0", "u"},
        { "UH1", "u"},
        { "UH2", "u"},
        { "UW", "uː"},
        { "UW0", "u"},
        { "UW1", "uː"},
        { "UW2", "u"},
        { "V", "v"},
        { "W", "w"},
        { "Y", "j"},
        { "Z", "z"},
        { "ZH", "ʒ"},
        { "L", "l" }
    };
    public List<string> GetAllIPA()
    {
        List<string> newList = new List<string>();
        foreach (KeyValuePair<string, string> entry in dictionary)
        {
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
       // Test();
        List<string> allIpa = new List<string>();
        for (int i = 0; i < value.Length; i++)
        {
            string trimValue = value[i].Trim();
            allIpa.Add(ConvertPhonemes(trimValue));
        }
        string[] output = new string[allIpa.Count];
        for (int i = 0; i < allIpa.Count; i++)
        {
            output[i] = allIpa[i];
        }
        return output;

    }
    string ConvertPhonemes(string value)
    {
        if (!dictionary.ContainsKey(value)) return "none";
        return dictionary[value];
    }
}