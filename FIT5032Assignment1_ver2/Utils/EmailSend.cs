using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace FIT5032Assignment1_ver2.Utils
{
    public class EmailSend
    {
        private const String API_KEY = "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";

        public void SendSingle(String toEmail, String subject, String contents)
        {
            var client = new SendGridClient(API_KEY);
            var from = new EmailAddress("zionqian741@gmail.com", "FIT5032 Example Email User");
            var to = new EmailAddress(toEmail, "");
            var plainTextContent = contents;
            var htmlContent = "<p>" + contents + "</p>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = client.SendEmailAsync(msg);
        }

        public void SendAttach(String toEmail, String subject, String contents)
        {
            var client = new SendGridClient(API_KEY);
            var from = new EmailAddress("zionqian741@gmail.com", "FIT5032 Example Email User");
            var to = new EmailAddress(toEmail, "");
            var plainTextContent = contents;
            var htmlContent = "<p>" + contents + "</p >";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var bytes = File.ReadAllBytes("C:\\Users\\crono\\Documents\\AttachEmailTest.txt");
            var file = Convert.ToBase64String(bytes);
            msg.AddAttachment("AttatchEmailTest", file);
            var response = client.SendEmailAsync(msg);
        }

        public void SendBulkAttachEmial(List<String> toEmail, String subject, String contents)
        {
            var client = new SendGridClient(API_KEY);
            var from = new EmailAddress("zionqian741@gmail.com", "FIT5032 Example Email User");
            List<EmailAddress> to = new List<EmailAddress>();
            foreach (String email in toEmail)
            {
                to.Add(new EmailAddress(email, ""));
            }
            var plainTextContent = contents;
            var htmlContent = "<p>" + contents + "</p >";
            var msg = MailHelper.CreateSingleEmailToMultipleRecipients(from, to, subject, plainTextContent, htmlContent);
            var bytes = File.ReadAllBytes("C:\\Users\\crono\\Documents\\AttatchEmailTest.txt");
            var file = Convert.ToBase64String(bytes);
            msg.AddAttachment("AttatchEmailTest", file);
            var response = client.SendEmailAsync(msg);
        }
    }
}