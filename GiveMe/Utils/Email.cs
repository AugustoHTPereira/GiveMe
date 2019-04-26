using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace GiveMe.Utils
{
    public static class Email
    {
        public static void Send(string To, string Message, string Subject)
        {
            //MailMessage Email = new MailMessage();
            //SmtpClient SMTP = new SmtpClient();
            //var credential = new NetworkCredential
            //{
            //    UserName = "empresteinoreply@gmail.com",
            //    Password = "emprestei2019"
            //};

            //try
            //{
            //    Email.From = new MailAddress("empresteinoreply@gmail.com", "EMPRESTEI");
            //    Email.To.Clear();
            //    Email.To.Add(Para);
            //    Email.Subject = Assunto;
            //    Email.IsBodyHtml = true;
            //    Email.Body = Mensagem;
            //    SMTP.Host = "smtp.gmail.com";
            //    SMTP.Credentials = credential;
            //    SMTP.EnableSsl = true;
            //    SMTP.Send(Email);
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception( ex.Message + "Algum erro ocorreu e não foi possível encaminhar o e-mail de confirmação. Contate o suporte.");
            //}

            //Email = null;
            //SMTP = null;

            try
            {
                MailMessage mail = new MailMessage();

                mail.From = new MailAddress("empresteinoreply@gmail.com", "Emprestei - NO-REPLY");
                mail.To.Add(To); // para
                mail.Subject = Subject; // assunto
                mail.Body = Message; // mensagem

                // em caso de anexos
                //mail.Attachments.Add(new Attachment(@"C:\teste.txt"));

                using (var smtp = new SmtpClient("smtp.gmail.com"))
                {
                    smtp.EnableSsl = true; // GMail requer SSL
                    smtp.Port = 587;       // porta para SSL
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network; // modo de envio
                    smtp.UseDefaultCredentials = false;

                    // seu usuário e senha para autenticação
                    smtp.Credentials = new NetworkCredential("empresteinoreply@gmail.com", "emprestei2019");

                    // envia o e-mail
                    smtp.Send(mail);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Seu usuário foi registrado mas ocorreu algum erro ao enviar seu e-mail de confirmação. Contate o TGS (Suporte Técnico). Detalhes: " + ex.Message);
            }
        }
    }
}
