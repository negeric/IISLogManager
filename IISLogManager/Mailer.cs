using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace IISLogManager
{
    class Mailer
    {
        public static int SendMail(string subject, string message)
        {
            string to = Settings.GetAppSetting("SMTPToAddress");
            string from = Settings.GetAppSetting("SMTPFromAddress");
            string server = Settings.GetAppSetting("SMTPServer");
            bool auth = (Settings.GetAppSetting("SMTPUseAuth") == "true") ? true : false;
            //Do validation
            from = (from == "error") ? "IISLogManager@localhost" : from;
            if (to == "error")
                return -1;
            else
            {
                try
                {
                    //Start mail
                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress(from);
                    //Add multiple to address if present
                    if (to.Contains(";"))
                    {
                        List<string> addrs = to.Split(';').ToList<string>();
                        foreach (string addr in addrs)
                        {
                            try
                            {
                                mail.To.Add(addr);
                            }
                            catch
                            {
                                ErrorHandler.logError("SMTP Error in TO Address", "Error adding the TO address " + addr + " to the mail message.  Please check the format", "mail");
                            }
                        }
                    } else
                    {
                        mail.To.Add(to);
                    }
                    mail.Subject = subject;
                    mail.Body = message;
                    SmtpClient smtp = new SmtpClient(server);
                    if (auth)
                    {                        
                        string user = Settings.GetAppSetting("SMTPUser");
                        string password = Settings.GetAppSetting("SMTPPass");
                        System.Net.NetworkCredential cred = new System.Net.NetworkCredential(user, password);
                        smtp.Credentials = cred;
                    }
                    smtp.Send(mail);
                    return 1;
                }
                catch (Exception ex)
                {
                    ErrorHandler.logError("SMTP Error Sending Email", "There was an erorr sending an email.  See exception for details", "mail", true, ex);
                    return -2;
                }
            }
        }    
    }
}
