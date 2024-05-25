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
    public TextChanger total;

    public void CancelPopup()
    {
        SetResultPop(false);
    }
    public void SetResult(int c,int t)
    {
        SetResultPop(true);
        correct.SetText("" + c);
        total.SetText("" + t);
        Debug.Log((float)c / (float)t);
        StartCoroutine(chargeCircle((float)c/(float)t));
    }
    IEnumerator chargeCircle(float total)
    {
        while (circleFillers.GetCircle() < total)
        {
            yield return new WaitForSeconds(0.01f);
            circleFillers.SetCircle(fv);
        }
    }
    void SetResultPop(bool isTrue)
    {
        resultPopup.SetActive(isTrue);
        quizPopup.SetActive(!isTrue);
    }
}
