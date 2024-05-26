using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizResultManager : MonoBehaviour
{
    public float fv = 0.005f;
    public CircleFiller circleFillers;
    public GameObject quizPopup;
    public GameObject resultPopup;
    public TextChanger correct;
    public ImageChanger[] results;
    public void OffPop()
    {
        resultPopup.SetActive(false);
    }
    public void CancelPopup()
    {
        SetResultPop(false);
    }
    public void SetResult(int c,int t,bool[] anwerList)
    {
        SetResultPop(true);
        circleFillers.InitCircle(0);
        correct.SetText("0");
        for (int i = 0; i < anwerList.Length; i++)
        {
            if (anwerList[i]) results[i].ChangeColor(Color.green);
            else results[i].ChangeColor(Color.red);
        }
        StartCoroutine(chargeCircle((float)c/(float)t));
    }
    IEnumerator chargeCircle(float total)
    {
        while (circleFillers.GetCircle() < total)
        {
            yield return new WaitForSeconds(0.01f);
            circleFillers.SetCircle(fv);
            correct.SetText("" + (int)(circleFillers.GetCircle() * 100));
        }
    }
    void SetResultPop(bool isTrue)
    {
        resultPopup.SetActive(isTrue);
        quizPopup.SetActive(!isTrue);
    }
}
