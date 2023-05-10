
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using Org.BouncyCastle.Asn1.Ocsp;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;
using System.Net;
//using System.Net.Mail;
using static Org.BouncyCastle.Math.EC.ECCurve;

internal class  Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
         sendEmailWithSendGrid().Wait();


    }
    static async Task sendEmailWithSendGrid()
    {
        //string SENDGRID_API_KEY = "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";
        string SENDGRID_API_KEY = "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";
        var client = new SendGridClient(SENDGRID_API_KEY);
        var from = new EmailAddress("alihamza.bcss19@iba-suk.edu.pk", "Ali Hamza");
        //var to = new EmailAddress("alihamza.bcss19@iba-suk.edu.pk", "Ali Hamza");
        var to = new EmailAddress("alihamzaansari.dev@gmail.com", "Ali Hamza Ansari");
        var subject = "I am from SendGrid";
        var plainTextContent = "Email from console";
        var htmlContent = "<strong>with simple click</strong>";


        var msg = MailHelper.CreateSingleEmail(
                from,
                to,
                subject,
                plainTextContent,
                htmlContent
            );

        var response = await client.SendEmailAsync(msg);
        await Console.Out.WriteLineAsync("Email sent");
    }
    private void sendEmailWithSMTP()
    {
        try
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("eriberto.orn79@ethereal.email"));

            email.To.Add(MailboxAddress.Parse("eriberto.orn79@ethereal.email"));
            //email.To.Add(MailboxAddress.Parse("alihamzaansari.dev@gmail.com"));
            //email.To.Add(MailboxAddress.Parse("alihamza.bcss19@iba-suk.edu.pk"));
            email.Subject = "Hello123";
            email.Body = new TextPart(TextFormat.Html) { Text = "The new email arrives. email body" };

            using var smtp = new SmtpClient();
            smtp.Connect("smtp.ethereal.email", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("eriberto.orn79@ethereal.email", "sbejw6UBR3WHvSm2ut");
            //smtp.Authenticate("alihamza.bcss19@iba-suk.edu.pk", "&hz1K7R6");
            smtp.Send(email);
            smtp.Disconnect(true);
            Console.WriteLine("Email sent");

            //using var smtp = new SmtpClient("smtp.ethereal.email", 587);
            //smtp.EnableSsl = true;
            //smtp.UseDefaultCredentials = false;
            ////smtp.Connect("smtp.ethereal.email", 587, SecureSocketOptions.StartTls);
            //smtp.Credentials = new NetworkCredential("eriberto.orn79@ethereal.email", "sbejw6UBR3WHvSm2ut");
            //smtp.Send(email);
            //smtp.Disconnect(true);


            /////////////////////////////////////////////////////

            //MailMessage message = new MailMessage();

            //message.From = new MailAddress("eriberto.orn79@ethereal.email");
            //message.To.Add("alihamzaansari.dev@gmail.com");
            //message.Subject = "New email";
            //message.Body = "Hi there, this email sent by Console app";
            ////message.IsBodyHtml = true;

            //SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            //smtpClient.EnableSsl = true;
            //smtpClient.UseDefaultCredentials = false;

            //smtpClient.Credentials = new NetworkCredential("riberto.orn79@ethereal.email", "sbejw6UBR3WHvSm2ut");
            //smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;

            //smtpClient.Send(message);

            ////////////////////////////////////////////

            //        Console.WriteLine("email sent");
            //using (MailMessage message = new MailMessage())
            //{
            //    message.From = new MailAddress("alihamza.bcss19@iba-suk.edu.pk");
            //    message.To.Add("alihamzaansari.dev@gmail.com");
            //    message.Subject = "New email";
            //    message.Body = "<h2>Hi there, this email sent by Console app</h2>";
            //    message.IsBodyHtml = true;

            //    using(SmtpClient smtpClient = new SmtpClient("smtp.gmail.com",587))
            //    {
            //        smtpClient.EnableSsl = true;
            //        smtpClient.UseDefaultCredentials = false;

            //        smtpClient.Credentials = new NetworkCredential("", "");
            //        smtpClient.DeliveryMethod =  SmtpDeliveryMethod.Network;

            //        smtpClient.Send(message);
            //        Console.WriteLine("email sent");
            //    }
            //}
        }
        catch (Exception ex)
        { Console.WriteLine(ex.ToString()); }
    }
}   
