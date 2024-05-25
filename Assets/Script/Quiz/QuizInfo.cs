using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum quizType { animation, sound }
public class QuizInfo
{
    public quizType quizType;
    public string answer;
    public string[] answerList = { "Null", "Null", "Null", "Null" };

    public QuizInfo(quizType quizType, string answer, string[] answerList)
    {
        this.quizType = quizType;
        this.answer = answer;
        this.answerList = answerList;
    }
    public int GetAnswerIndex()
    {
        for (int i = 0; i < answerList.Length; i++)
            if (answer == answerList[i]) return i;
        return 0;
    }
    public string GetFixedQuizTitle()
    {
        switch (quizType)
        {
            case quizType.animation:
                return "위 모델이 발음 중인 발음기호를 고르시오.";
            case quizType.sound:
                return "다음 소리를 듣고 해당하는\n발음기호를 고르시오.";
            default:
                return "none of Ttype";
        }
    }
}
