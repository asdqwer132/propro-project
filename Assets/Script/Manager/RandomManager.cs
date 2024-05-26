using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomManager
{
    public int GetRandomInt(int start, int end)
    {
        return Random.Range(start,end);
    }
    public quizType GetRandomQuizType()
    {
        return Random.Range(0, 2) == 1 ? quizType.animation : quizType.sound;
    }
}
