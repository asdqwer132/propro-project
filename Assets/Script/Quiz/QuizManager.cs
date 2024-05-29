using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizManager : MonoBehaviour
{
    public int initialQuizCount = 5;
    public QuizResultManager resultManager;
    public AnswerManager answerManager;
    public TextLegucyChanger quizTitle;
    public TextChanger fakeTextForPlayTTSorAnimation;
    public GameObject quizSelect;
    public GameObject quizMain;
    public GameObject soundQuiz;
    public GameObject animationsQuiz;
    TTSManager tts;
    ModelAnimationControler animationControler;
    QuizCreater quizCreater = new QuizCreater();
    List<QuizInfo> currentQuizList = new List<QuizInfo>();
    List<QuizInfo> wrongQuizList = new List<QuizInfo>();
    QuizInfo currentQuiz;
    quizType quizType = quizType.animation;
    int currentCount;
    int quizCount;
    bool isWait = false;
    bool isRetry = false;
    private void Start()
    {
        ManagerFInder fInder = new ManagerFInder();
        tts = fInder.GetComponetWithTag<TTSManager>("manager");
        animationControler = fInder.GetComponetWithTag<ModelAnimationControler>("manager");
        if (tts == null) Debug.Log("tts");
        if (animationControler == null) Debug.Log("ani");
        //resultManager.SetResult(2, 5);
        RestartQuiz();
    }
    public void SetWrongQuiz(int index)
    {
        if (wrongQuizList.Count == 0)
        {
            Debug.Log("틀린게 없심");
            return;
        }
        isRetry = true;
        //currentCount = 0;
        //quizCount = wrongQuizList.Count;
        //currentQuizList = wrongQuizList;
        //wrongQuizList = new List<QuizInfo>();
        resultManager.CancelPopup();
        currentQuiz = currentQuizList[index];
        SetQuiz(currentQuiz);
    }
    public void RestartQuiz()
    {
        quizSelect.SetActive(true);
        quizMain.SetActive(false);
        resultManager.OffPop();
    }
    public void SetQuizType(int index)
    {
        if (index == 0)
        {
            quizType = quizType.animation;
            soundQuiz.SetActive(false);
            animationsQuiz.SetActive(true);
        }
        if (index == 1)
        {
            quizType = quizType.sound;
            soundQuiz.SetActive(true);
            animationsQuiz.SetActive(false);
        }
        quizSelect.SetActive(false);
        quizMain.SetActive(true);
        InitQuiz();
    }
    void InitQuiz()
    {
        isRetry = false;
        currentCount = 0;
        quizCount = initialQuizCount;
        currentQuizList = new List<QuizInfo>();
        wrongQuizList = new List<QuizInfo>();
        currentQuiz = null;
        SetQuiz();
    }
    void PlaySorA(string anwser)
    {
        fakeTextForPlayTTSorAnimation.SetText(anwser);
        if (quizType == quizType.animation) animationControler.PlayIPAAnimation();
        if (quizType == quizType.sound) tts.SpeakIPA();
    }
    void SetQuiz(QuizInfo newQuiz)
    {
        if (isRetry)
        {
            quizTitle.SetText(newQuiz.GetFixedQuizTitle());
            answerManager.SetAnswer(newQuiz.answerList);
            PlaySorA(newQuiz.answer);
        }
    }
    void SetQuiz()
    {
        QuizInfo newQuiz;
        if (!isRetry)
        {
            newQuiz = quizCreater.GetNewRandomQuiz(quizType);//새 퀴즈
            currentQuizList.Add(newQuiz);
            quizTitle.SetText(newQuiz.GetFixedQuizTitle());
            answerManager.SetAnswer(newQuiz.answerList);
            PlaySorA(newQuiz.answer);
        }
    }
    void EndQuiz()
    {
        int total = currentQuizList.Count;
        int correct = total - wrongQuizList.Count;
        bool[] answerList = new bool[quizCount];
        int wrongCnt = 0;
        for (int i = 0; i < quizCount; i++)
        {
            if (wrongQuizList.Count != 0 && wrongQuizList.Count > wrongCnt)
            {
                if (currentQuizList[i] == wrongQuizList[wrongCnt])
                {
                    answerList[i] = false;
                    wrongCnt++;
                }
                else answerList[i] = true;
            }
            else
            {
                answerList[i] = true;
            }
        }
        resultManager.SetResult(correct, total, answerList);
    }
    public void CheckAnswer(int index)
    {
        if (!isWait)
        {
            if (!isRetry)
            {
                currentQuiz = currentQuizList[currentQuizList.Count - 1];
                currentCount++;
                if (!answerManager.CheckAnswer(index, currentQuiz.GetAnswerIndex()))
                {
                    wrongQuizList.Add(currentQuiz);
                }
            }
            else
            {
                if (answerManager.CheckAnswer(index, currentQuiz.GetAnswerIndex()))
                {
                    int wqi = wrongQuizList.FindIndex(x => x == currentQuiz);
                    wrongQuizList.RemoveAt(wqi);
                }
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
