namespace WSSistemaUniversitario.Models.Response
{
    public class Respuesta
    {
        public int codigo { get; set; }
        public string? descripcion { get; set; }
        public object? data {  get; set; }

        public Respuesta()
        {
            codigo = 0;
            descripcion = null;
            data = null;
        }
    }
}
