using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Sentis;
using System.IO;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

//                      Jets Text-To-Speech Inference
//                      =============================
//
// This file implements the Jets Text-to-speech model in Unity Sentis
// The model uses phenomes instead of raw text so you have to convert it first.
// Place this file on the Main Camera
// Add an audio source
// Change the inputText
// When running you can press space bar to play it again

public class RunJets : MonoBehaviour
{
    [SerializeField]
    AssetReferenceT<ModelAsset> jetsModelFile;
    [SerializeField]
    AssetReferenceT<TextAsset> phenomeDictionaryFile;

    public string inputText = "Once upon a time, there lived a girl called Alice. She lived in a house in the woods.";
    //string inputText = "The quick brown fox jumped over the lazy dog";
    //string inputText = "There are many uses of the things she uses!";

    readonly Dictionary<string, string> ipaDic = new Dictionary<string, string>()
    {
        { "ɑ" , "AA0 AA0"},
        { "ɑː", "AA1 AA1"},
        //{ "ɑ" , "AA2 AA2"},
        { "æ" , "AE0 AE0"},
        //{ "æ" , "AE1 AE1"},
        //{ "æ" , "AE2 AE2"},
        { "ə" , "AH0 AH0"},
        { "ʌ" , "AH1 AH1"},
        //{ "ʌ" , "AH2 AH2"},
        //{ "ə" , "ER0 ER0"},
        //{ "ə" , "ER1 ER1"},
        //{ "ə" , "ER2 ER2"},
        { "ɔ" , "AO0 AO0"},
        { "ɔː", "AO1 AO1"},
        //{ "ɔ" , "AO2 AO2"},
        { "u" , "AW0 AW0"},
        //{ "u" , "AW1 AW1"},
        //{ "u" , "AW2 AW2"},
        //{ "u" , "UH0 UH0"},
        //{ "u" , "UH1 UH1"},
        //{ "u" , "UH2 UH2"},
        { "uː", "UW UW "},
        //{ "u" , "UW0 UW0"},
        //{ "uː", "UW1 UW1"},
        //{ "u" , "UW2 UW2"},
        { "iː", "AY0 AY0"},
        //{ "iː", "AY1 AY1"},
        //{ "iː", "AY2 AY2"},
        //{ "iː", "IH0 IH0"},
        //{ "iː", "IH1 IH1"},
        //{ "iː", "IH2 IH2"},
        { "i" , "IY0 IY0"},
        //{ "iː", "IY1 IY1"},
        //{ "i" , "IY2 IY2"},
        { "b" , "B B"},
        { "tʃ", "CH CH"},
        { "d" , "D D"},
        { "ð" , "DH DH"},
        { "ɛ" , "EH0 EH0"},
        //{ "ɛ" , "EH1 EH1"},
        //{ "ɛ" , "EH2 EH2"},
        { "e" , "EY0 EY0"},
        //{ "e" , "EY1 EY1"},
        //{ "e" , "EY2 EY2"},
        { "f" , "F F"},
        { "g" , "G G"},
        { "h" , "HH HH"},
        { "dʒ", "JH JH"},
        { "k" , "K K"},
        { "m" , "M M"},
        { "n" , "N N"},
        { "ŋ" , "NG NG"},
        { "ou", "OW0 OW0"},
        //{ "ou", "OW1 OW1"},
        //{ "ou", "OW2 OW2"},
        { "ɔi", "OY0 OY0"},
        //{ "ɔi", "OY1 OY1"},
        //{ "ɔi", "OY2 OY2"},
        { "p" , "P P"},
        { "ɹ" , "R R"},
        { "s" , "S S"},
        { "ʃ" , "SH SH"},
        { "t" , "T T"},
        { "θ" , "TH TH"},
        { "v" , "V V"},
        { "w" , "W W"},
        { "j" , "Y Y"},
        { "z" , "Z Z"},
        { "ʒ" , "ZH ZH"},
        { "l", "L L"},
    };

    //Set to true if we have put the phoneme_dict.txt in the Assets/StreamingAssets folder
    bool hasPhenomeDictionary = true;

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

    AudioClip clip;

    void Start()
    {
        LoadModel();
        ReadDictionary();
        //TextToSpeech();
    }

    void LoadModel()
    {
        var handle = jetsModelFile.LoadAssetAsync<ModelAsset>();
        handle.WaitForCompletion();
        if (handle.Status != AsyncOperationStatus.Succeeded)
        {
            Debug.LogError("Cannot open jetsModelFile");
            return;
        }
        var model = ModelLoader.Load(handle.Result);
        engine = WorkerFactory.CreateWorker(BackendType.GPUCompute, model);
    }

    public float[] TextToSpeech()
    {
        return DoInference(TextToPhonemes(inputText));
    }

    void ReadDictionary()
    {
        if (!hasPhenomeDictionary) return;

        var handle = phenomeDictionaryFile.LoadAssetAsync<TextAsset>();
        handle.WaitForCompletion();
        if(handle.Status != AsyncOperationStatus.Succeeded)
        {
            Debug.LogError("Cannot open phenomeDictionaryFile");
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

    public string TextToPhonemes(string text)
    {
        if(ipaDic.ContainsKey(text))
        {
            return ipaDic[text];
        }

        string output = "";
        text = ExpandNumbers(text).ToUpper();

        string[] words = text.Split();
        for (int i = 0; i < words.Length; i++)
        {
            output += DecodeWord(words[i]);
        }
        return output;
    }

    //Decode the word into phenomes by looking for the longest word in the dictionary that matches
    //the first part of the word and so on.
    //This works fairly well but could be improved. The original paper had a model that
    //dealt with guessing the phonemes of words
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

    int[] GetTokens(string ptext)
    {
        string[] p = ptext.Split();
        var tokens = new int[p.Length];
        for (int i = 0; i < tokens.Length; i++)
        {
            tokens[i] = Mathf.Max(0, System.Array.IndexOf(phonemes, p[i]));
        }
        return tokens;
    }

    public float[] DoInference(string ptext)
    {
        int[] tokens = GetTokens(ptext);

        using var input = new TensorInt(new TensorShape(tokens.Length), tokens);
        var result = engine.Execute(input);

        var output = result.PeekOutput("wav") as TensorFloat;
        output.MakeReadable();
        var samples = output.ToReadOnlyArray();

        Debug.Log($"Audio size = {samples.Length / samplerate} seconds");

        clip = AudioClip.Create("voice audio", samples.Length, 1, samplerate, false);
        clip.SetData(samples, 0);

        Speak();
        return samples;
    }
    private void Speak()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        if (audioSource != null)
        {
            audioSource.clip = clip;
            audioSource.Play();
        }
        else
        {
            Debug.Log("There is no audio source");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TextToSpeech();
        }
    }

    private void OnDestroy()
    {
        engine?.Dispose();
    }
}