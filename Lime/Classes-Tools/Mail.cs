using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail; //Permet l'utilisation des mails
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace Lime
{
    class Mail
    {
        public static void CreateTestMessage2(string _server, string  _to, string _from, string _pieceJointe)
        {
            string to = _to;
            string from = _from;
            MailMessage message = new MailMessage(from, to);
            message.Subject = "Test Lime";
            message.Body = @"Envoi de mail test";
            message.IsBodyHtml = true;

            //SmtpClient client = new SmtpClient(server);
            // Credentials are necessary if the server requires the client 
            // to authenticate before it will send email on the client's behalf.
            //client.UseDefaultCredentials = true;


            SmtpClient client = new SmtpClient("smtp.gmail.com");
            client.UseDefaultCredentials = false;
            client.Port = 587;
            client.Credentials =
            new System.Net.NetworkCredential("Dwennx@gmail.com", "Idclip00?");
            client.EnableSsl = true;

            #region Piece Jointe
            // Specify the file to be attached and sent.
            string file = _pieceJointe;
            // Create  the file attachment for this email message.
            Attachment data = new Attachment(file, System.Net.Mime.MediaTypeNames.Application.Octet);
            // Add time stamp information for the file.
            ContentDisposition disposition = data.ContentDisposition;
            disposition.CreationDate = System.IO.File.GetCreationTime(file);
            disposition.ModificationDate = System.IO.File.GetLastWriteTime(file);
            disposition.ReadDate = System.IO.File.GetLastAccessTime(file);
            // Add the file attachment to this email message.
            message.Attachments.Add(data);
            #endregion


            try
            {
                client.Send(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in CreateTestMessage2(): {0}",
                    ex.ToString());
            }
        }

        //Exemple d'envoi de Mail
        //public void Send (System.Net.Mail.MailMessage message);
        // OU ALORS
        //public void Send(string from, string to, string subject, string body);
    }
}
