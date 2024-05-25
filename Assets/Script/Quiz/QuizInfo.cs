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
                return "�� ���� ���� ���� ������ȣ�� ���ÿ�.";
            case quizType.sound:
                return "���� �Ҹ��� ��� �ش��ϴ�\n������ȣ�� ���ÿ�.";
            default:
                return "none of Ttype";
        }
    }
}
