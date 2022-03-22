﻿namespace Pezza.Core.Email
{
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using HtmlAgilityPack;
    using Pezza.Common.DTO;
    using Pezza.Common.Models;
    using SendGrid;
    using SendGrid.Helpers.Mail;

    public class EmailService
    {
        public string HtmlContent { get; set; }

        public CustomerDTO Customer { get; set; }

        public async Task<Result> SendEmail()
        {
            try
            {
                var doc = new HtmlDocument();
                doc.LoadHtml(this.HtmlContent);
                var plainText = doc.DocumentNode.SelectSingleNode("//body").InnerText;
                plainText = Regex.Replace(plainText, @"\s+", " ").Trim();

                var apiKey = "SENDGRIDKEY";
                var client = new SendGridClient(apiKey);
                var from = new EmailAddress("notify@pezza.com", "Pezza");
                var subject = $"Collect your order it while it's hot";
                var to = new EmailAddress(this.Customer?.Email, this.Customer?.Name);
                var plainTextContent = plainText;
                var htmlContent = this.HtmlContent;
                var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
                var response = await client.SendEmailAsync(msg);

                return response.StatusCode != System.Net.HttpStatusCode.OK ? Result.Failure("Email could not send") : Result.Success();
            }
            catch (System.Exception e)
            {
                Common.Logging.Logging.LogException(e);
                return Result.Success();
            }
        }
    }
}