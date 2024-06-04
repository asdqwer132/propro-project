using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DanielLochner.Assets.SimpleScrollSnap;
using System;
public class SettingPopup : Popup
{
    public GameObject main;
    public TextChangerList textChangerList;
    public Head head;
    public Animator animator;
    public SimpleScrollSnap scrollSnapAge;
    public SimpleScrollSnap scrollSnapGender;
    public float age = 0;
    public float gender = 0;
    private void Start()
    {
        Cancel();
        string[] ageValues = new string[41];
        for (int i = 0; i < ageValues.Length; i++)
        {
            ageValues[i] = "" + (i + 10);
        }
        textChangerList.SetTextArray(ageValues);
    }
    private void Update()
    {
        if (age != scrollSnapAge.SelectedPanel)
        {
            age = scrollSnapAge.SelectedPanel;
            float normalizedAge = (age / 40) * 2 - 1;
            Debug.Log("age" + normalizedAge);
            animator.SetFloat("Age", normalizedAge);
            PlayerPrefs.SetFloat("Age", normalizedAge);
        }
        if (gender != scrollSnapGender.SelectedPanel)
        {
            gender = scrollSnapGender.SelectedPanel;
            float normalizedGender = gender * 2 - 1;
            Debug.Log("gen" + normalizedGender);
            animator.SetFloat("Gender", normalizedGender);
            PlayerPrefs.SetFloat("Age", normalizedGender);
        }
    }
    public void OpenSet()
    {
        Open();
        main.SetActive(false);
    }
    public void CloseSet()
    {
        Cancel();
        main.SetActive(true);
    }
}
