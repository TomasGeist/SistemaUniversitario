using WSSistemaUniversitario.DTOs;

namespace WSSistemaUniversitario.Services
{
    public interface IEmailService
    {
        public void EnviarEmail(EmailDTO correo, MemoryStream pdf);

    }
}
