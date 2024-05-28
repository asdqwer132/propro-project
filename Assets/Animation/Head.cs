using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animation))]
public class Head : MonoBehaviour
{
    //����� ������ȣ��
    public string[] IpaArray;
    //���� ��� �ð�
    public float Duration = 1f;

    //ĳ�̵� �ִϸ��̼� ������Ʈ
    Animation anim;
    //������ �ִϸ��̼� Ŭ���� ���� �ð�
    [SerializeField]
    float blendingDuration = 0.1f;

    void Start()
    {
        //������Ʈ ĳ��
        anim = GetComponent<Animation>();
    }

    void Update()
    {
        //TODO [�׽�Ʈ��] �ִϸ��̼� ���
        if (Input.GetKeyDown("space"))
        {
            PlayAnimations();
        }
    }

    //������ȣ �迭�� �ش��ϴ� �ִϸ��̼��� ���������� ���
    public void PlayAnimations()
    {
        //������ ������ȣ�� ������ ����
        if (IpaArray.Length == 0)
        {
            return;
        }

        //1. ��ü �ִϸ��̼� Ŭ�� ��� �ð� ���
        float totalDuration = 0f;
        for (int i = 0; i < IpaArray.Length; i++)
        {
            totalDuration += anim.GetClip(IpaArray[i]).length;
        }
        //�ִϸ��̼� ���� ���� �ð� ����
        totalDuration -= (IpaArray.Length - 1) * blendingDuration;

        //2. ���� ��� �ð��� �°� Ÿ�ӽ����� ����
        Time.timeScale = totalDuration / Duration;

        //3. �ִϸ��̼� ���
        //ù ������ȣ ��� ����, ����Ǵ� ��� �ִϸ��̼��� ����
        anim.Play(IpaArray[0]);
        for (int i = 1; i < IpaArray.Length; i++)
        {
            //���� ������ȣ ���ʹ� ť�� ����, ���� �ִϸ��̼ǰ� 0.1�� ����
            anim.CrossFadeQueued(IpaArray[i], 0.1f);
        }
    }
}
