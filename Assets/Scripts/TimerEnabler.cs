using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerEnabler : MonoBehaviour
{
    public float timer;
    public GameObject[] disableBtn;
    public GameObject[] enableBtn;

     void Start()
    {
        Invoke("MakeIt", timer);
        
    }
    void MakeIt()
    {
        foreach (GameObject btn in disableBtn)
            btn.SetActive(false);

        foreach (GameObject btn in enableBtn)
            btn.SetActive(true);
    }



}
