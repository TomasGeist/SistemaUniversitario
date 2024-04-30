using MailKit.Security;
using MimeKit.Text;
using MimeKit;
using MailKit.Net.Smtp;
using WSSistemaUniversitario.DTOs;
using MimeKit.Cryptography;
using WSSistemaUniversitario.Models;

namespace WSSistemaUniversitario.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;
        private readonly DbSistemauniversitarioContext _db;

        public EmailService(IConfiguration config, DbSistemauniversitarioContext db)
        {
            _config = config;
            _db = db;
        }
        public void EnviarEmail(EmailDTO correo, MemoryStream pdf)
        {
            var emailAlumno = _db.Alumno.FirstOrDefault(a => a.IdAlumno == correo.IdAlumno);

            if (emailAlumno !=  null)
            {
                correo.Asunto = "Pago de cuota";
                correo.Contenido = "El pago de la cuota fue procesado con éxito, se adjunta comprobante";
                correo.Para = emailAlumno.Correo;

                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse(_config.GetSection("Email:Username").Value));
                email.To.Add(MailboxAddress.Parse(correo.Para));
                email.Subject = correo.Asunto;
                var builder = new BodyBuilder
                {
                    HtmlBody = correo.Contenido
                };

                builder.Attachments.Add("ComprobanteCuota.pdf", pdf.ToArray());

                email.Body = builder.ToMessageBody();


                using (var smtp = new SmtpClient())
                {
                    smtp.Connect(
                        _config.GetSection("Email:Host").Value,
                        Convert.ToInt32(_config.GetSection("Email:Port").Value),
                        SecureSocketOptions.StartTls);

                    smtp.Authenticate(_config.GetSection("Email:UserName").Value,
                        _config.GetSection("Email:Pass").Value
                        );

                    smtp.Send(email);
                    smtp.Disconnect(true);

                }
            }
            else
            {
                throw new Exception("Hubo un error en la solicitud");
            }
        }
    }
}
