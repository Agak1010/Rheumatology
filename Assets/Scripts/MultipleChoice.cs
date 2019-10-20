using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultipleChoice : MonoBehaviour
{
    public string question;
    public GameObject[] disableBtn;
    public SaveData _data;
    public bool isGeneral, isJoint, isMorning, isFatigue, isDay;
     public void ButtonEnabler(GameObject answerName)
    {
        print(answerName.name);
        foreach (GameObject btn in disableBtn)
            btn.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);


        answerName.GetComponent<Image>().color = new Color(0.4f, 0.4f, 0.4f, 0.4f);

        if (isGeneral)
            _data.getGeneralFeeling(answerName.name);

        if (isJoint)
            _data.getMyJoint(answerName.name);

        if (isMorning)
            _data.getMyMorning(answerName.name);

        if (isFatigue)
            _data.getMyFatigue(answerName.name);

        if (isDay)
            _data.getMyDay(answerName.name);
    }
}
