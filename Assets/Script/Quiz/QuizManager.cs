using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizManager : MonoBehaviour
{
    public QuizResultManager resultManager;
    public AnswerManager answerManager;
    public TextLegucyChanger quizTitle;
    public int initialQuizCount = 3;
    int currentCount;
    int quizCount;
    QuizCreater quizCreater = new QuizCreater();
    List<QuizInfo> currentQuizList = new List<QuizInfo>();
    List<QuizInfo> wrongQuizList = new List<QuizInfo>();
    bool isWait = false;
    bool isRetry = false;
    private void Start()
    {

        resultManager.SetResult(1, 3);
        //InitQuiz();
    }
    public void SetWrongQuiz()
    {
        if(wrongQuizList.Count == 0)
        {
            Debug.Log("틀린게 없심");
            return;
        }
        isRetry = true;
        currentCount = 0;
        quizCount = wrongQuizList.Count;
        currentQuizList = wrongQuizList;
        wrongQuizList = new List<QuizInfo>();
        resultManager.CancelPopup();
        SetQuiz();
    }
    public void InitQuiz()
    {
        isRetry = false;
        currentCount = 0;
        quizCount = initialQuizCount;
        currentQuizList = new List<QuizInfo>();
        wrongQuizList = new List<QuizInfo>();
        resultManager.CancelPopup();
        SetQuiz();
    }
    public void ResetQuiz()
    {
        currentQuizList = new List<QuizInfo>();
    }
    void SetQuiz()
    {
        QuizInfo newQuiz;
        if (!isRetry)
        {
            newQuiz = quizCreater.GetNewRandomQuiz();//새 퀴즈
            currentQuizList.Add(newQuiz);
        }
        else newQuiz = currentQuizList[currentCount];
        quizTitle.SetText(newQuiz.GetFixedQuizTitle());
        answerManager.SetAnswer(newQuiz.answerList);
    }
    void EndQuiz()
    {
        int total = currentQuizList.Count;
        int correct = total - wrongQuizList.Count;
        resultManager.SetResult(correct, total);
    }
    public void CheckAnswer(int index)
    {
        if (!isWait)
        {
            QuizInfo currentQuiz = currentQuizList[currentQuizList.Count - 1];
            currentCount++;
            if(!answerManager.CheckAnswer(index,currentQuiz.GetAnswerIndex()))
            {
                wrongQuizList.Add(currentQuiz);
            }
            StartCoroutine(GetNextQuiz());
        }
    }
    IEnumerator GetNextQuiz()
    {
        isWait = true;
        yield return new WaitForSeconds(1f);
        if (currentCount == quizCount) EndQuiz();//퀴즈 종료
        else SetQuiz();
        isWait = false;
    }
}
