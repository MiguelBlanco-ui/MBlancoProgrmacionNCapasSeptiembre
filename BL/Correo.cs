using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace BL
{
    public class Correo
    {
        public static bool ConfirmacionCorreo(ML.Usuario usuario) { 

        bool confirmacion = false;

            //configurar el cliente smtp

            var smtpClient = new SmtpClient("smtp.gmail.com") {
                Port = 587,
                Credentials =  new NetworkCredential("tapiablanco9@gmail.com", "raxyhzrgslxancle"), 
                EnableSsl = true
            };


            //Crear el mensaje del correo

            var mailMessage = new MailMessage { 
            From = new MailAddress("tapiablanco9@gmail.com"),
            Subject = "Confirmación",
            Body ="Se Agregaron correctamento los datos.",
            IsBodyHtml = true,
            };

            if (usuario.Email != null)
            {
                mailMessage.To.Add(usuario.Email);

                //Enviar correo
                smtpClient.Send(mailMessage);

                confirmacion = true;

            }

            return confirmacion;
        }
    }
}
