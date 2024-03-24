using System;
using System.IO;
using System.Text;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using UnityEngine;

public class WordConverter : MonoBehaviour
{

    private Dictionary<string, string> dictionary;
    
    void Start()
    {
        SetDic("/Data/EnIPA.txt");
    }
    void SetDic(string path)
    {
        this.dictionary = new Dictionary<string, string>();
        var assembly = typeof(WordConverter).Assembly;
        var resource = Application.dataPath + path;
        using (var reader = new StreamReader(resource))
        {
            string line = null;
            while ((line = reader.ReadLine()) != null)
            {
                var parts = line.Split(',', 2);
                if (parts.Length == 2)
                    dictionary[parts[0].Trim()] = parts[1].Trim();
            }
        }
    }
    public string WordToIPA(string text)
    {
        var builder = new StringBuilder();
        string[] words = Regex.Split(text, @"([\s\p{P}])"); // Split on spaces or punctuation

        foreach (var match in words)
        {
            var lower = match.ToLower();
            if (dictionary.ContainsKey(lower))
            {
                builder.Append(dictionary[lower]);
            }
            else
            {
                builder.Append(lower);
            }
        }
        return builder.ToString();
    }

}
