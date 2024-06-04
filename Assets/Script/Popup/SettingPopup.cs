using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DanielLochner.Assets.SimpleScrollSnap;
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
            Debug.Log("afe" + (0.02439f * age));
            animator.SetFloat("Age", (0.02439f * age));
        }
        if (gender != scrollSnapGender.SelectedPanel)
        {
            gender = scrollSnapGender.SelectedPanel;
            Debug.Log("gen" + (gender * 100));
            animator.SetFloat("Gender", (gender * 100) / 100.0f);
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
