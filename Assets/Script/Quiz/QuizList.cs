using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizList : MonoBehaviour
{
    public QuizInfo[] quizInfos;
    RandomManager random = new RandomManager();

    public QuizInfo[] GetQuizsWithType(quizType quizType)
    {
        int cnt = 0;
        for (int i = 0; i < quizInfos.Length; i++)
        {
            if (quizInfos[i].quizType == quizType) cnt++;
        }
        QuizInfo[] newQuizs = new QuizInfo[cnt];
        int index = 0;
        for (int i = 0; i < quizInfos.Length; i++)
        {
            if (quizInfos[i].quizType == quizType) newQuizs[index++] = quizInfos[i];
        }
        return newQuizs;
    }
    public QuizInfo GetRandomQuiz()
    {
        return quizInfos[random.GetRandomInt(0, quizInfos.Length)];
    }
}
