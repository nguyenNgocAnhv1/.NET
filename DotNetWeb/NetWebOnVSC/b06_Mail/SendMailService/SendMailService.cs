using Microsoft.Extensions.Options;
using MimeKit;

public class SendMailService
{
    MailSetting _mailSetting { get; set; }
    public SendMailService(IOptions<MailSetting> mailSetting)
    {
        _mailSetting = mailSetting.Value;
        System.Console.WriteLine("===== " + mailSetting.Value.DisplayName);
        System.Console.WriteLine("===");
    }
    public async Task<string> SendMail(MailContent mailContent)
    {
        var email = new MimeMessage();
        email.Sender = new MailboxAddress(_mailSetting.DisplayName, _mailSetting.Mail);
        email.From.Add(new MailboxAddress(_mailSetting.DisplayName, _mailSetting.Mail));
        email.To.Add(new MailboxAddress(mailContent.to, mailContent.to));
        email.Subject = mailContent.subject;
        var builder = new BodyBuilder();
        builder.HtmlBody = mailContent.body;
        // builder
        email.Body = builder.ToMessageBody();
        using var smtp = new MailKit.Net.Smtp.SmtpClient();

        try
        {
            await smtp.ConnectAsync(_mailSetting.Host, _mailSetting.Port, MailKit.Security.SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync(_mailSetting.Mail, _mailSetting.Password);
            await smtp.SendAsync(email);
        }
        catch(Exception e)
        {
            System.Console.WriteLine(e.Message);
            return "loi";
        }
        smtp.Disconnect(true);
        return "gui thanh cong";
    }
}
public class MailContent
{
    public string to { get; set; }
    public string subject { get; set; }
    public string body { get; set; }

}