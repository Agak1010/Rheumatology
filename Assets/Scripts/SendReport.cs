using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Text;

using UnityEngine;
using SimpleJSON;
using System;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

public class SendReport : MonoBehaviour
{

   // string GetAllServey = "http://imscorgau.ipage.com/agakProject/survey/getallsurvays.php";

    public InputField emailInput, nameInput;
    // Use this for initialization
    public void sendReport()
    {

        StartCoroutine(CombineReport());
    }

    IEnumerator CombineReport()
    {

        yield return new WaitForSeconds(.1f);

        System.DateTime dt = (System.DateTime.Today);
        string fileName = dt.DayOfWeek + dt.ToString("dd-MMMM");
        //StartCoroutine (tryExcel(fileName));

        StartCoroutine(SendDailyReportRounds(fileName));
    }

    IEnumerator SendDailyReportRounds(string filename)
    {

        yield return new WaitForSeconds(0.1f);


        SmtpClient SmtpServer = new SmtpClient("smtp.ipage.com");


        MailMessage mail = new MailMessage();

        mail.From = new MailAddress("noreply@onthelinesoftworks.com");
        mail.To.Add(emailInput.text);
 

        string surveyStatus = ""; // (SaveToDB.skippedQuestions < 22) ? "\n\n PLEASE NOTE THAT THIS SURVEY WAS COMPLETED SUCCESSFULLY" : "\n\n PLEASE NOTE THAT THIS SURVEY WAS INCOMPLETED";

        mail.Subject = "Jordan Society of Rhematology report of " + (System.DateTime.Now.Day).ToString() + "-" +
            System.DateTime.Now.Month + "-" +
            System.DateTime.Now.Year;
        mail.Body = "Hey "+ nameInput.text+ " , \nWe are currently working on something awesome.  Stay tuned!" +
            
            surveyStatus +
            ". \n\nThanks,\n Rhematology Support";
        SmtpServer.Port = 587; //  
        SmtpServer.Credentials = new System.Net.NetworkCredential("noreply@onthelinesoftworks.com", "OnTheLine@2018") as ICredentialsByHost;
        SmtpServer.EnableSsl = true;

        // mail.Attachments.Add(new Attachment(ruta));
        ServicePointManager.ServerCertificateValidationCallback =
            delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) {
                return true;
            };
        SmtpServer.Send(mail);
        Debug.Log("mail Sent...");

        /*string desktopPath = Application.persistentDataPath;//.GetFolderPath (System.Environment.SpecialFolder.DesktopDirectory);

        string ruta = desktopPath + "/" + filename + " Survey.csv";

        //El archivo existe? lo BORRAMOS
        if (File.Exists(ruta))
        {
            //File.Delete(ruta);
        }

        //Crear el archivo
        //var sr = File.Create(ruta,1024,FileOptions.None);//,1024, FileOptions.DeleteOnClose);//,1000,FileOptions.DeleteOnClose);

        //File.SetAttributes (ruta, FileAttributes.ReadOnly);

        string datosCSV = "Survey Report" + System.Environment.NewLine;
        datosCSV += " IMEI " + PlayerPrefs.GetString("IMEI") + System.Environment.NewLine + (System.DateTime.Now.Day).ToString() + "."
            + (System.DateTime.Now.Month).ToString() + "."
            + (System.DateTime.Now.Year).ToString() +
            System.Environment.NewLine + System.Environment.NewLine;
        datosCSV += "Total Surveys, IMEI, Avatar, Date, Time, Durdation, " +
            "q1,q2,q3,q4,q5,q6,q7,q8,q9,q10,q11,q12,q13,q14,q15,q16,q17,q18,q19,q20,q21,q22,q23,q24,q25,q26,q27,q28,q29,q30" + System.Environment.NewLine;

        WWWForm form = new WWWForm();
        form.AddField("imei", PlayerPrefs.GetString("IMEI"));

        WWW entereddata = new WWW(GetAllServey, form);

        yield return entereddata;

        var json = JSON.Parse(entereddata.text);

        int dataSize = json[0].Count;

        for (int ii = 0; ii < dataSize; ii++)
        {
            int nodeSize = json[0][ii].Count;

            for (int k = 0; k < nodeSize; k++)
            {
                datosCSV += json[0][ii][k].Value.ToString() + ",";

            }
            datosCSV += System.Environment.NewLine;
        }

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
        mail.To.Add("unfpa@onthelinesoftworks.com");
        mail.CC.Add("hasan.gharaibeh@onthelinesoftworks.com");
        mail.CC.Add("canadian.agak@gmail.com");


        string surveyStatus = ""; // (SaveToDB.skippedQuestions < 22) ? "\n\n PLEASE NOTE THAT THIS SURVEY WAS COMPLETED SUCCESSFULLY" : "\n\n PLEASE NOTE THAT THIS SURVEY WAS INCOMPLETED";

        mail.Subject = "Survey report of " + (System.DateTime.Now.Day).ToString() + "-" +
            System.DateTime.Now.Month + "-" +
            System.DateTime.Now.Year;
        mail.Body = "Hi Dear, \nKindly note the attached survey report for tablet IMEI: " +
            PlayerPrefs.GetString("IMEI") +
            surveyStatus +
            ". \n\nThanks,\nOnTheLineSoftworks Team";
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


        if (SaveToDB.skippedQuestions < 22)
            Application.LoadLevel("Spinning");
        else
            Application.LoadLevel("0");*/


    }
}
