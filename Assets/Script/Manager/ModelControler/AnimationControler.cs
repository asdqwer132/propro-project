using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControler : MonoBehaviour
{
    //�ִϸ��̼� ��Ʈ�� �����̴�
    public SliderControler slider;
    //���� ��� �ð�
    public float Duration = 1f;
    Animation anim;
    bool isAnimating = false;
    //������ �ִϸ��̼� Ŭ���� ���� �ð�
    [SerializeField]
    float blendingDuration = 0.1f;
    void Start()
    {
        anim = GetComponent<Animation>();
    }
    //������ȣ �迭�� �ش��ϴ� �ִϸ��̼��� ���������� ���
    public void PlayAnimations(string[] IpaArray)
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
        slider.Slide(totalDuration);
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
