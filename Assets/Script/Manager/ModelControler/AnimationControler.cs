using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControler : MonoBehaviour
{
    //애니메이션 컨트롤 슬라이더
    public SliderControler slider;
    //음성 재생 시간
    public float Duration = 1f;
    Animation anim;
    bool isAnimating = false;
    //인접한 애니메이션 클립간 블렌딩 시간
    [SerializeField]
    float blendingDuration = 0.1f;
    void Start()
    {
        anim = GetComponent<Animation>();
    }
    //발음기호 배열에 해당하는 애니메이션을 순차적으로 재생
    public void PlayAnimations(string[] IpaArray)
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
        slider.Slide(totalDuration);
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
