using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;
using System.IO;
using System.Text;

using System;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

public class SaveData : MonoBehaviour
{
    int indexer;


    void checkIndex()
    {
        indexer = PlayerPrefs.GetInt("dataIndex");

        if (PlayerPrefs.GetString("my_feeling_" + indexer).Length != 0 &&
            /*PlayerPrefs.GetString("my_joint_" + indexer).Length != 0 &&*/
            PlayerPrefs.GetString("my_morning_" + indexer).Length != 0 &&
            PlayerPrefs.GetString("my_fatigue_" + indexer).Length != 0 &&
            PlayerPrefs.GetString("my_myday_" + indexer).Length != 0
            )
        {
            indexer++;
            PlayerPrefs.SetInt("dataIndex", (indexer));

        }
        print(indexer);

    }
    void Start()
    {
        //PlayerPrefs.DeleteAll();
        checkIndex();
    }


    public void getGeneralFeeling(string userInput)
    {
        checkIndex();
        PlayerPrefs.SetString("my_feeling_" + indexer, userInput);
        PlayerPrefs.SetString("my_feeling_time_" + indexer, DateTime.Now.ToString());
    }

    public void getMyJoint(string userInput)
    {
        checkIndex();
    }

    public void getMyMorning(string userInput)
    {
        checkIndex();
        PlayerPrefs.SetString("my_morning_" + indexer, userInput);
        PlayerPrefs.SetString("my_morning_time_" + indexer, DateTime.Now.ToString());

    }
    public void getMyFatigue(string userInput)
    {
        checkIndex();
        PlayerPrefs.SetString("my_fatigue_" + indexer, userInput);
        PlayerPrefs.SetString("my_fatigue_time_" + indexer, DateTime.Now.ToString());

    }
    public void getMyDay(string userInput)
    {
        checkIndex();
        PlayerPrefs.SetString("my_myday_" + indexer, userInput);
        PlayerPrefs.SetString("my_myday_time_" + indexer, DateTime.Now.ToString());

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


    public void sendEmail()
    {
        StartCoroutine(SendDailyReportRounds());
    }

     

    IEnumerator SendDailyReportRounds()
    {
        sendingReport.SetActive(true);

        string desktopPath = Application.persistentDataPath;//.GetFolderPath (System.Environment.SpecialFolder.DesktopDirectory);

        string ruta = desktopPath + "/"  + " Rheumatoid Arthritis Report.csv";

        //El archivo existe? lo BORRAMOS
        if (File.Exists(ruta))
        {
            //File.Delete(ruta);
        }

        //Crear el archivo
        //var sr = File.Create(ruta,1024,FileOptions.None);//,1024, FileOptions.DeleteOnClose);//,1000,FileOptions.DeleteOnClose);

        //File.SetAttributes (ruta, FileAttributes.ReadOnly);

        string datosCSV = "Rheumatoid Arthritis Report" + System.Environment.NewLine;
        datosCSV += System.Environment.NewLine + (System.DateTime.Now.Day).ToString() + "."
            + (System.DateTime.Now.Month).ToString() + "."
            + (System.DateTime.Now.Year).ToString() +
            System.Environment.NewLine + System.Environment.NewLine;
        datosCSV += "All records, Gender,"+
            "General feeling question, general feeling answer, time," +
            "Morning feeling question, morning feeling answer, time," +
            "Fatigue question, Fatigue answer, time,"+
            "MyDay question, MyDay answer, time,"+System.Environment.NewLine;

        for (int i = 0; i <= indexer; i++)
        {
            string _feeling = PlayerPrefs.GetString("my_feeling_" + i);
            string _feeling_time = PlayerPrefs.GetString("my_feeling_time_" + i);

            string _morning = PlayerPrefs.GetString("my_morning_" + i);
            string _morning_time = PlayerPrefs.GetString("my_morning_time_" + i);


            string _fatigue = PlayerPrefs.GetString("my_fatigue_" + i);
            string _fatigue_time = PlayerPrefs.GetString("my_fatigue_time_" + i);


            string _myDay = PlayerPrefs.GetString("my_myday_" + i);
            string _myDay_time = PlayerPrefs.GetString("my_myday_time_" + i);


            datosCSV += i + ",";
            datosCSV += PlayerPrefs.GetString("Gender") + ",";
            datosCSV += "How are feeling in general?" + ",";
            datosCSV += _feeling + ",";
            datosCSV += _feeling_time + ",";

            datosCSV += "Do you suffer from morning stiffness?" + ",";
            datosCSV += _morning + ",";
            datosCSV += _morning_time + ",";

            datosCSV += "How fatigued are you today?" + ",";
            datosCSV += _fatigue + ",";
            datosCSV += _fatigue_time + ",";

            datosCSV += "How active were you today?" + ",";
            datosCSV += _myDay + ",";
            datosCSV += _myDay_time + ",";
             

            datosCSV += System.Environment.NewLine;

        }
        datosCSV += System.Environment.NewLine;


       

        //sr.Write(datosCSV);
        if (File.Exists(ruta))
        {
            File.Delete(ruta);
        }
        StreamWriter outStream = System.IO.File.CreateText(ruta);
        outStream.WriteLine(datosCSV);
        outStream.Close();

        //FileInfo fInfo = new FileInfo(ruta);
        //fInfo.IsReadOnly = false;

        //sr.Close();            

        yield return new WaitForSeconds(0.1f);

        //Application.OpenURL(ruta);



        SmtpClient SmtpServer = new SmtpClient("smtp.ipage.com");


        MailMessage mail = new MailMessage();

        mail.From = new MailAddress("noreply@onthelinesoftworks.com");
       // mail.To.Add("unfpa@onthelinesoftworks.com");
       /* mail.CC.Add("hasan.gharaibeh@onthelinesoftworks.com");*/
        mail.CC.Add("canadian.agak@gmail.com");
        mail.To.Add("swehu1988@gmail.com");

         

        mail.Subject = "Rheumatoid Arthritis patient report of " + (System.DateTime.Now.Day).ToString() + "-" +
            System.DateTime.Now.Month + "-" +
            System.DateTime.Now.Year;
        mail.Body = "Hi Dear, \nKindly note the attached Rheumatoid Arthritis patient report." +
                        "\n\nThanks,\nOnTheLineSoftworks Team";
        SmtpServer.Port = 587; //  
        SmtpServer.Credentials = new System.Net.NetworkCredential("noreply@onthelinesoftworks.com", "OnTheLine@2018") as ICredentialsByHost;
        SmtpServer.EnableSsl = true;

        mail.Attachments.Add(new Attachment(ruta));
        ServicePointManager.ServerCertificateValidationCallback =
            delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) {
                return true;
            };
        SmtpServer.Send(mail);
        Debug.Log("mail Sent...");

        sendingReport.SetActive(false);
         
    }


    public void setGender(string gender)
    {

        PlayerPrefs.SetString("Gender", gender);
    }


    public GameObject sendingReport;

}
