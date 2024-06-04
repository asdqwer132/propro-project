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
            Debug.Log("age" + ((age / 40) * 2 - 1));
            animator.SetFloat("Age", (age / 40) * 2 - 1);
        }
        if (gender != scrollSnapGender.SelectedPanel)
        {
            gender = scrollSnapGender.SelectedPanel;
            Debug.Log("gen" + (gender * 2 - 1));
            animator.SetFloat("Gender", gender * 2 - 1);
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
