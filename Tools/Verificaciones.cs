namespace WSSistemaUniversitario.Tools
{
    public class Verificaciones
    {
        public bool EsNumero(string valor)
        {
            // el _ sirve para ignorar lo que devuelve ya que no lo necesito.
            return int.TryParse(valor, out _);
        }
    }
}
