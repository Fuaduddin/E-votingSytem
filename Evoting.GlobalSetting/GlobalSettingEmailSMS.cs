using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services.Description;
using System.Web;
using System.Net;
using System.Collections.Specialized;
using System.Runtime.Remoting.Messaging;
using Vonage;
using Vonage.Request;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;
using Vonage.Common;
using Vonage.Messaging;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace Evoting.GlobalSetting
{
    public interface IEmailSMSGlobalSettings
    {
        bool SendingMail(string Emailbody, string CustomerEmail, string Subject);
        bool SentSMS(int OTPCode, string ReciverNumber, string apikey);
        bool ProfileActivationConfirmationEmailBody(string CustomerName, string ElectionDetails, string CustomerEmail);
        bool AppointmentConfirmationEmailBody(string CustomerName, string AppointmentSubject,
            string AppoinmentWIth, string AppointmentDate, string CustomerEmail);
        bool VoteConfirmationEmailBody(string CustomerName, string ElectionDetails, string CustomerEmail);
    }
    public class GlobalSettingEmailSMS: IEmailSMSGlobalSettings
    {
        // Email Settings
        public const string System_Official_Mail = "fuaduddinador@gmail.com";
        public const string System_Official_ContactNumber = "01644443221";
        public const string Email_From_CompanyName = "E-voting System";
        public const string Host = "smtp.gmail.com";
        public const int Port = 587;
        public const string SendingVotingConfirmationSUbject = "Voting has been confirmed";
        public const string SendingAppointmentConfirmationSubject = "Appointment has been confirmed";
        public const string SendingUserAccountActivationConfirmationSubject = "Your Account Have Been Activated";

        public bool SendingMail(string Emailbody, string CustomerEmail,string Subject)
        {
            bool isSent = true;
            try
            {
                //Send Email
                MailMessage Msg = new MailMessage();
              // Msg.From = new MailAddress(System_Official_Mail, Email_From_CompanyName);// replace with valid value
                Msg.Subject = Subject;
                Msg.To.Add(CustomerEmail); //replace with correct values
                Msg.Body = Emailbody;
                Msg.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = Host;
                smtp.Port = Port;
                smtp.Credentials = new System.Net.NetworkCredential(System_Official_Mail, System_Official_ContactNumber);// replace with valid value
                smtp.EnableSsl = true;
                smtp.Timeout = 20000;
                smtp.Send(Msg);
            }
            catch
            {
                isSent = false;
            }
            return isSent;
        }

        // Email Sending Body
        public bool AppointmentConfirmationEmailBody(string CustomerName, string AppointmentSubject,
            string AppoinmentWIth, string AppointmentDate, string CustomerEmail)
        {
            bool IsSent = true;
            string Emailbody = "";
             Emailbody = "Hi Mr/Mrs" + CustomerName + "Your Appointment Subject:" + AppointmentSubject +
                "has been confirmed with" + AppoinmentWIth + "on" + AppointmentDate;
            try
            {
                SendingMail(Emailbody, CustomerEmail, SendingAppointmentConfirmationSubject);
            }
            catch (Exception ex)
            {
                IsSent = false;
                throw new Exception (ex.ToString());
            }
            return IsSent;
        }
        public bool VoteConfirmationEmailBody(string CustomerName, string ElectionDetails, string CustomerEmail)
        {
            bool IsSent = true;
            string Emailbody = 
                "Hi Mr/Mrs" + CustomerName + "Your Vote of" + ElectionDetails + 
                "has been submitted.The final result will be published soon.";
            try
            {
                SendingMail(Emailbody, CustomerEmail, SendingVotingConfirmationSUbject);
            }
            catch(Exception ex)
            {
                IsSent=false;
                throw new Exception(ex.ToString());
            }
            return IsSent;
        }
        public bool ProfileActivationConfirmationEmailBody(string CustomerName, string ElectionDetails, string CustomerEmail)
        {
            bool IsSent = true;
            string Emailbody =
                "Hi Mr/Mrs" + CustomerName + "Your Vote of" + ElectionDetails +
                "has been submitted.The final result will be published soon.";
            try
            {
                SendingMail(Emailbody, CustomerEmail, SendingUserAccountActivationConfirmationSubject);
            }
            catch (Exception ex)
            {
                IsSent = false;
                throw new Exception(ex.ToString());
            }
            return IsSent;
        }
        public bool SentSMS(int OTPCode,string ReciverNumber,string apikey)
        {
            bool isSent = true;
            try
            {
                using(var clientserver = new HttpClient())
                {
                    string APIURLSMS= "https://api.sms.net.bd/sendsms";
                    string Message = "Your OTP is " + OTPCode + "(Send by E-Voting)";
                    clientserver.BaseAddress = new Uri(APIURLSMS);
                    clientserver.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var responseMSG = clientserver.GetAsync("?api_key=" + apikey + "&msg=" + Message + "&to=" + ReciverNumber).Result;
                }
            }
            catch(Exception ex)
            {
                isSent = false;
                throw new Exception(ex.ToString() );
            }
            return isSent;
        }
    }
}
