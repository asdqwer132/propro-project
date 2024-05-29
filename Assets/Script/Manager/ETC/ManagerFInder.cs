using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerFInder
{
   
    public T GetComponetWithTag<T>(string tag)
    {
        T compo = default(T);
        GameObject[] managers = GameObject.FindGameObjectsWithTag(tag);
        for(int i = 0; i < managers.Length; i++)
        {
            compo = managers[i].GetComponent<T>();
            if (compo != null) return compo;
        }
        return compo;
    }
}
