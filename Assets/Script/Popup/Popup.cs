using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cancel();
    }
    public void Open() { gameObject.SetActive(true); }
    public void Cancel() { gameObject.SetActive(false); }
}
