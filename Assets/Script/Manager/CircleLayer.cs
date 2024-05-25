using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CircleLayer : MonoBehaviour
{
    public float radius = 2.0f;

    void Start()
    {
        s();
    }
    public void s()
    {
        int numOfChild = transform.childCount;

        for (int i = 0; i < numOfChild; i++)
        {
            float angle = Mathf.PI * 0.5f - i * (Mathf.PI * 2.0f) / numOfChild;

            GameObject child = transform.GetChild(i).gameObject;

            child.transform.position
                = transform.position + (new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0)) * radius;
        }
    }
}
