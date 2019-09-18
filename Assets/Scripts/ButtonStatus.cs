using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonStatus : MonoBehaviour
{
    public GameObject[] disableBtn;
    public GameObject[] enableBtn;

    public void ButtonEnabler()
    {
        foreach (GameObject btn in disableBtn)
            btn.SetActive(false);

        foreach (GameObject btn in enableBtn)
            btn.SetActive(true);

    }
}
