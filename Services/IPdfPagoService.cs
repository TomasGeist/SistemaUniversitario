namespace WSSistemaUniversitario.Services
{
    public interface IPdfPagoService
    {
        public MemoryStream generarPdf(int id);

    }
}
