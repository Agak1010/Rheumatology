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


        SmtpClient SmtpServer = new SmtpClient("smtp.com");


        MailMessage mail = new MailMessage();

         mail.To.Add(emailInput.text);
 

        string surveyStatus = ""; // (SaveToDB.skippedQuestions < 22) ? "\n\n PLEASE NOTE THAT THIS SURVEY WAS COMPLETED SUCCESSFULLY" : "\n\n PLEASE NOTE THAT THIS SURVEY WAS INCOMPLETED";

        mail.Subject = "Jordan Society of Rhematology report of " + (System.DateTime.Now.Day).ToString() + "-" +
            System.DateTime.Now.Month + "-" +
            System.DateTime.Now.Year;
        mail.Body = "Hey "+ nameInput.text+ " , \nWe are currently working on something awesome.  Stay tuned!" +
            
            surveyStatus +
            ". \n\nThanks,\n Rhematology Support";
        SmtpServer.Port = 587; //  
         SmtpServer.EnableSsl = true;

        // mail.Attachments.Add(new Attachment(ruta));
        ServicePointManager.ServerCertificateValidationCallback =
            delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) {
                return true;
            };
        SmtpServer.Send(mail);
        Debug.Log("mail Sent...");

        


    }
}
