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

        if (PlayerPrefs.GetString("my_feeling_" + indexer).Length != 0 &&
            /*PlayerPrefs.GetString("my_joint_" + indexer).Length != 0 &&*/
            PlayerPrefs.GetString("my_morning_" + indexer).Length != 0 &&
            PlayerPrefs.GetString("my_fatigue_" + indexer).Length != 0 &&
            PlayerPrefs.GetString("my_myday_" + indexer).Length != 0
            )
        {
            PlayerPrefs.SetInt("dataIndex", (indexer + 1));
            // save to excel:


            // send to email
        }
    }
    void Start()
    {

        checkIndex();
    }


    public void getGeneralFeeling(string userInput)
    {
        checkIndex();
        PlayerPrefs.SetString("my_feeling_" + indexer, userInput);
        PlayerPrefs.SetString("my_feeling_time", DateTime.Now.ToString());
    }

    public void getMyJoint(string userInput)
    {
        checkIndex();
    }

    public void getMyMorning(string userInput)
    {
        checkIndex();
        PlayerPrefs.SetString("my_morning_" + indexer, userInput);
        PlayerPrefs.SetString("my_morning_time", DateTime.Now.ToString());

    }
    public void getMyFatigue(string userInput)
    {
        checkIndex();
        PlayerPrefs.SetString("my_fatigue_" + indexer, userInput);
        PlayerPrefs.SetString("my_fatigue_time", DateTime.Now.ToString());

    }
    public void getMyDay(string userInput)
    {
        checkIndex();
        PlayerPrefs.SetString("my_myday_" + indexer, userInput);
        PlayerPrefs.SetString("my_myday_time", DateTime.Now.ToString());

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
