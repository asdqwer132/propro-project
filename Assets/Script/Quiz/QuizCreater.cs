using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizCreater
{
    WordCompiler wordCompiler = new WordCompiler();
    RandomManager random = new RandomManager();
    public QuizInfo GetNewRandomQuiz()
    {

        quizType quizType = random.GetRandomQuizType();
        WordDeck wordDeck = new WordDeck(wordCompiler.GetAllIPA());
        string[] answerList = new string[4];
        for(int i = 0; i < answerList.Length; i++)
        {
            answerList[i] = wordDeck.GetRandomWord();
        }
        int answerIndex = random.GetRandomInt(0, answerList.Length);
        QuizInfo newQuiz = new QuizInfo(quizType, answerList[answerIndex], answerList);
        Debug.Log(newQuiz.quizType + "/" + answerIndex+"/" + newQuiz.answerList[0] + "." + newQuiz.answerList[1] + "." + newQuiz.answerList[2] + "." + newQuiz.answerList[3]);
        return newQuiz;
    }
}
