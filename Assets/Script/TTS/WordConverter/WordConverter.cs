using System.Collections.Generic;
using UnityEngine;
using Unity.Sentis;
using System.IO;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class WordConverter : MonoBehaviour
{
    bool hasPhenomeDictionary = true;
    WordCompiler wordCompiler = new WordCompiler();
    readonly string[] phonemes = new string[] {
        "<blank>", "<unk>", "AH0", "N", "T", "D", "S", "R", "L", "DH", "K", "Z", "IH1",
        "IH0", "M", "EH1", "W", "P", "AE1", "AH1", "V", "ER0", "F", ",", "AA1", "B",
        "HH", "IY1", "UW1", "IY0", "AO1", "EY1", "AY1", ".", "OW1", "SH", "NG", "G",
        "ER1", "CH", "JH", "Y", "AW1", "TH", "UH1", "EH2", "OW0", "EY2", "AO0", "IH2",
        "AE2", "AY2", "AA2", "UW0", "EH0", "OY1", "EY0", "AO2", "ZH", "OW2", "AE0", "UW2",
        "AH2", "AY0", "IY2", "AW2", "AA0", "\"", "ER2", "UH2", "?", "OY2", "!", "AW0",
        "UH0", "OY0", "..", "<sos/eos>" };

    readonly string[] alphabet = "AE1 B K D EH1 F G HH IH1 JH K L M N AA1 P K R S T AH1 V W K Y Z".Split(' ');

    //Can change pitch and speed with this for a slightly different voice:
    const int samplerate = 22050;

    Dictionary<string, string> dict = new();

    IWorker engine;


    void Start()
    {
        ReadDictionary();
    }
    void ReadDictionary()
    {
        if (!hasPhenomeDictionary) return;

        var handle = Addressables.LoadAssetAsync<TextAsset>("Assets/Data/phoneme_dict.txt");
        handle.WaitForCompletion();
        if (handle.Status != AsyncOperationStatus.Succeeded)
        {
            Debug.LogError("Cannot open phoneme_dict.txt");
            return;
        }
        string[] words = handle.Result.text.Split("\n");
        for (int i = 0; i < words.Length - 1; i++)
        {
            string s = words[i];
            string[] parts = s.Split();
            if (parts[0] != ";;;") //ignore comments in file
            {
                string key = parts[0];
                dict.Add(key, s.Substring(key.Length + 2));
            }
        }
        // Add codes for punctuation to the dictionary
        dict.Add(",", ",");
        dict.Add(".", ".");
        dict.Add("!", "!");
        dict.Add("?", "?");
        dict.Add("\"", "\"");
        // You could add extra word pronounciations here e.g.
        //dict.Add("somenewword","[phonemes]");
    }
    public string ExpandNumbers(string text)
    {
        return text
            .Replace("0", " ZERO ")
            .Replace("1", " ONE ")
            .Replace("2", " TWO ")
            .Replace("3", " THREE ")
            .Replace("4", " FOUR ")
            .Replace("5", " FIVE ")
            .Replace("6", " SIX ")
            .Replace("7", " SEVEN ")
            .Replace("8", " EIGHT ")
            .Replace("9", " NINE ");
    }

    public string[] TextToPhonemes(string text)
    {
        text = ExpandNumbers(text).ToUpper();

        string[] words = text.Split();
        string tmp = "";
        for (int i = 0; i < words.Length; i++)
        {
            tmp += DecodeWord(words[i]);
        }
        string[] r = tmp.Split(" ");
        string[] output = new string[r.Length - 1];
        for (int i = 0; i < r.Length - 1; i++)
        {
            output[i] = r[i];
        }
        return wordCompiler.ConvertWord(output);
    }
    public string DecodeWord(string word)
    {
        string output = "";
        int start = 0;
        for (int end = word.Length; end >= 0 && start < word.Length; end--)
        {
            if (end <= start) //no matches
            {
                start++;
                end = word.Length + 1;
                continue;
            }
            string subword = word.Substring(start, end - start);
            if (dict.TryGetValue(subword, out string value))
            {
                output += value + " ";
                start = end;
                end = word.Length + 1;
            }
        }
        return output;
    }
    private void OnDestroy()
    {
        engine?.Dispose();
    }
}