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
        public static void MailDocument(string _to, string _pieceJointe)
        {
            //Paramètre depuis les settings
            string server = Properties.Settings.Default.MailServer;
            bool isSSL = Properties.Settings.Default.MailEnableSSL;
            int port = Properties.Settings.Default.MailPort;
            string email = Properties.Settings.Default.MailAddress;
            string password = Properties.Settings.Default.MailPassword;
            string displayName = Properties.Settings.Default.MailDisplayName; ; //Le nom à afficher comme expéditeur du mail

            //Paramètre passés à la méthode
            string to = _to;

            //Cération du message 


            //SmtpClient client = new SmtpClient(server);
            // Credentials are necessary if the server requires the client 
            // to authenticate before it will send email on the client's behalf.
            //client.UseDefaultCredentials = true;
            SmtpClient client = new SmtpClient(server);

            //Si on veut en SSL, on disable UseDefaultCredentials
            if (isSSL == true)
            {
                client.UseDefaultCredentials = false;
            }

            //Création du client
            client.Port = port;
            client.Credentials =
            new System.Net.NetworkCredential(email, password);
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


            //Création du message 
            MailMessage message = new MailMessage(email, to);
            message.IsBodyHtml = true;
            message.Subject = "Votre document n°"+data.Name;
            //Expéditeur du message
            MailAddress expediteur = new MailAddress(email, displayName);
            message.From = expediteur;

            //Body du message
            message.Body =
            @"<h1>Votre document</h1><br>" 
            + "<p>Bonjour,</p>" 
            + "<p>Votre document est joint au mail : " + data.Name +"</p>" 
            + "<br /><br /><br />"
            + "<p>Cordialement,</p>"
            + "<p>L'équipe Microwest + ShopyPhone Sàrl</p>"
            ;

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

    }
}
