using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    int indexer;


    void checkIndex()
    {
        indexer = PlayerPrefs.GetInt("dataIndex");
        print(indexer);

        if (PlayerPrefs.GetString("my_feeling_"+indexer) != null &&
            PlayerPrefs.GetString("my_joint_" + indexer) != null &&
            PlayerPrefs.GetString("my_morning_" + indexer) != null &&
            PlayerPrefs.GetString("my_fatigue_" + indexer) != null &&
            PlayerPrefs.GetString("my_myday_" + indexer) != null
            )
        {
            PlayerPrefs.SetInt("dataIndex", (indexer + 1));
        }
    }
    void Start()
    {

        checkIndex();
        print(DateTime.Now);
    }


    public void getGeneralFeeling(string userInput)
    {
        checkIndex();
        PlayerPrefs.SetString("my_feeling" + indexer, userInput);
    }

    public void getMyJoint(string userInput)
    {
        checkIndex();
    }

    public void getMyMorning(string userInput)
    {
        checkIndex();
    }
    public void getMyFatigue(string userInput)
    {
        checkIndex();
    }
    public void getMyDay(string userInput)
    {
        checkIndex();
    }
    public void getMyMedication(string userInput)
    {
        checkIndex();
    }
    public void getMyLabs(string userInput)
    {
        checkIndex();
    }
    public void getMyCalculator(string userInput)
    {
        checkIndex();
    }
}
