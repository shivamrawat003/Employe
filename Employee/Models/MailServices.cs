using System.IO;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;

public class EmailService
{
    private readonly string _smtpServer;
    private readonly int _port;
    private readonly string _username;
    private readonly string _password;

    public EmailService(string smtpServer, int port, string username, string password)
    {
        _smtpServer = smtpServer;
        _port = port;
        _username = username;
        _password = password;
    }

    public async Task SendEmailAsync(string to, string from, string subject, string body, HttpPostedFileBase attachment)
    {
        using (var client = new SmtpClient(_smtpServer, _port))
        {
            client.Credentials = new NetworkCredential(_username, _password);
            client.EnableSsl = true; // Use SSL if your SMTP server requires it

            var mailMessage = new MailMessage
            {
                From = new MailAddress(_username),
                Subject = subject,
                Body = body,
                IsBodyHtml = true // Set to true if the body is HTML
            };

            mailMessage.To.Add(to);
            if (attachment != null && attachment.ContentLength > 0)
            {
                var mailAttachment = new Attachment(attachment.InputStream, attachment.FileName);
                mailMessage.Attachments.Add(mailAttachment);
            }
            await client.SendMailAsync(mailMessage);
        }
    }
}
