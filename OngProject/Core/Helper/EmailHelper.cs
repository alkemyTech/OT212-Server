using System;
using System.IO;

namespace OngProject.Core.Helper
{
    public static class EmailHelper
    {
        public static string GetWelcomeEmail()
        {
            return GetEmailForTemplate("Bienvenido a Somos Mas", 
                "Su usuario ha sido creado con éxito", "somosmas@email.com");
        }

        public static string GetEmailForTemplate(string title, string message, string contact)
        {
            try
            {
                var filePath = Path.Combine(Environment.CurrentDirectory, "Templates/WelcomeEmail.html");
                var file = File.OpenText(filePath);

                var content = File.ReadAllText(filePath);

                content = content.Replace("T&iacute;tulo", title);
                content = content.Replace("Texto del email", message);
                content = content.Replace("Datos de contacto de ONG", contact);

                return content;
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
