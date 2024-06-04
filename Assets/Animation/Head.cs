using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways, RequireComponent(typeof(Animator), typeof(Animation))]
public class Head : MonoBehaviour
{
    //재생할 발음기호들
    public string[] IpaArray;
    //음성 재생 시간
    public float Duration = 1f;

    //캐싱된 컴포넌트
    SkinnedMeshRenderer headRenderer;
    Animator animator;
    Animation anim;
    [SerializeField]
    Transform crossSection;
    //인접한 애니메이션 클립간 블렌딩 시간
    [SerializeField]
    float blendingDuration = 0.1f;

    void Start()
    {
        //컴포넌트 캐싱
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
        //TODO [테스트용] 애니메이션 재생
        if (Input.GetKeyDown("space"))
        {
            PlayAnimations();
        }
    }

    private void LateUpdate()
    {
        //모든 머터리얼에 절단면 상태 전달
        Vector3 normal = crossSection.right;
        for (int i = 0; i < headRenderer.sharedMaterials.Length; i++)
        {
            headRenderer.sharedMaterials[i].SetVector("_Normal", normal);
            headRenderer.sharedMaterials[i].SetFloat("_Distance", -Vector3.Dot(normal, crossSection.position));
        }
    }

    //발음기호 배열에 해당하는 애니메이션을 순차적으로 재생
    public void PlayAnimations()
    {
        //실행할 발음기호가 없으면 종료
        if (IpaArray.Length == 0)
        {
            return;
        }

        //1. 전체 애니메이션 클립 재생 시간 계산
        float totalDuration = 0f;
        for (int i = 0; i < IpaArray.Length; i++)
        {
            Debug.Log(IpaArray[i] + "/" + anim.GetClip(IpaArray[i]));
            totalDuration += anim.GetClip(IpaArray[i]).length;
        }
        //애니메이션 간의 블렌딩 시간 빼기
        totalDuration -= (IpaArray.Length - 1) * blendingDuration;

        //2. 음성 재생 시간에 맞게 타임스케일 조정
        Time.timeScale = totalDuration / Duration;

        //3. 애니메이션 재생
        //첫 발음기호 재생 시작, 실행되는 모든 애니메이션을 정지
        anim.Play(IpaArray[0]);
        for (int i = 1; i < IpaArray.Length; i++)
        {
            //다음 발음기호 부터는 큐에 예약, 이전 애니메이션과 0.1초 블렌딩
            anim.CrossFadeQueued(IpaArray[i], 0.1f);
        }
    }
}