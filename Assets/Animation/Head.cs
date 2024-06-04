using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways, RequireComponent(typeof(Animator), typeof(Animation))]
public class Head : MonoBehaviour
{
    //����� ������ȣ��
    public string[] IpaArray;
    //���� ��� �ð�
    public float Duration = 1f;

    //ĳ�̵� ������Ʈ
    SkinnedMeshRenderer headRenderer;
    Animator animator;
    Animation anim;
    [SerializeField]
    Transform crossSection;
    //������ �ִϸ��̼� Ŭ���� ���� �ð�
    [SerializeField]
    float blendingDuration = 0.1f;

    void Start()
    {
        //������Ʈ ĳ��
        headRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
        animator = GetComponent<Animator>();
        anim = GetComponent<Animation>();
        //for (int i = 0; i < IpaArray.Length; i++)
        //{
        //    if (anim.GetClip(IpaArray[i]) == null) Debug.Log(IpaArray[i] + "is null");
        //    else Debug.Log(IpaArray[i] + "/" + anim.GetClip(IpaArray[i]));
        //}
    }

    void Update()
    {
        //TODO [�׽�Ʈ��] �ִϸ��̼� ���
        if (Input.GetKeyDown("space"))
        {
            PlayAnimations();
        }
    }

    private void LateUpdate()
    {
        //��� ���͸��� ���ܸ� ���� ����
        Vector3 normal = crossSection.right;
        for (int i = 0; i < headRenderer.sharedMaterials.Length; i++)
        {
            headRenderer.sharedMaterials[i].SetVector("_Normal", normal);
            headRenderer.sharedMaterials[i].SetFloat("_Distance", -Vector3.Dot(normal, crossSection.position));
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
            Debug.Log(IpaArray[i] + "/" + anim.GetClip(IpaArray[i]));
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