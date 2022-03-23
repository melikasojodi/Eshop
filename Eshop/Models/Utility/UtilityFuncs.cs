using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;



public class UtilityFuncs
{
    public DateTime ToShamsi(DateTime dt)
    {
        PersianCalendar pcDate = new PersianCalendar();
        int Year = pcDate.GetYear(dt);
        int Month = pcDate.GetMonth(dt);
        int Day = pcDate.GetDayOfMonth(dt);

        return new DateTime(Year, Month, Day);

    }

    public string TimeMozayedeh(string dt1, DateTime dt2)
    {
        DateTime DateEnd = Convert.ToDateTime(dt1);
        var t = DateEnd - dt2;


        return t.Days + "روز و" + t.Hours + "ساعت و" + t.Minutes + "دقیقه و" + t.Seconds + "ثانیه";

    }









    /// <summary>
    /// 
    /// </summary>
    /// <param name="Smtp">پروتوکل ارسال ایمیل</param>
    /// <param name="FromEmail">UserName</param>
    /// <param name="Password">کلمه ی عبور</param>
    /// <param name="To">ایمیل گیرنده</param>
    /// <param name="Subject">عنوان ایمیل</param>
    /// <param name="Message">متن ایمیل</param>



    public void SendEmail(string Smtp, string FromEmail, string Password, string To, string Subject, string Message)
    {
        MailMessage MyMessage = new MailMessage();
        MyMessage.From = new MailAddress(FromEmail);
        MyMessage.To.Add(To);
        //MyMessage.To.Add(To);
        MyMessage.Subject = Subject;
        MyMessage.Body = Message;
        MyMessage.IsBodyHtml = true;
        MyMessage.Priority = MailPriority.High;

        //if (Attach != null)
        //{
        //    string filename = Attach.FileName;
        //    string filepath = "D:\\" + filename;
        //    Attach.SaveAs(filepath);
        //    Attachment attach = new Attachment(filepath);
        //    attach.TransferEncoding = System.Net.Mime.TransferEncoding.Base64;
        //    MyMessage.Attachments.Add(attach);
        //}

        SmtpClient mysmtp = new SmtpClient(Smtp,587);
        mysmtp.UseDefaultCredentials = false;
        mysmtp.EnableSsl = true;
        mysmtp.Credentials = new NetworkCredential(FromEmail, Password);
        //mysmtp.Port = 25;
        mysmtp.Send(MyMessage);
    }





    public bool SendSms(string MobileNumber, string Message, string UserName, string Password, string Sender)
    {
        try
        {
            EShop.EshopSendSms.SendReceive ws = new EShop.EshopSendSms.SendReceive();

            string err = string.Empty;
            long[] mobileNos = new long[1];
            string[] messages = new string[1];

            mobileNos[0] = long.Parse(MobileNumber);
            messages[0] = Message;
            long[] result = ws.SendMessageWithLineNumber(UserName, Password, mobileNos, messages, Sender, System.DateTime.Now, ref err);
            if (err == "" || err == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch
        {

            return false;

        }
    }
}


