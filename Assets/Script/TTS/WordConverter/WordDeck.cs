using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class WordDeck
{
    public List<string> wordList;
    RandomManager random = new RandomManager();
    public WordDeck(List<string> newWordList)
    {
        wordList = newWordList;
    }
    public string GetRandomWord()
    {
        string word = "";
        int index = random.GetRandomInt(0, wordList.Count);
        word = wordList[index];
        wordList.RemoveAt(index);
        return word;
    }
}
