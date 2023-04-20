namespace ML
{
    public class Persona
    {
        public int? IdPersona { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public int Edad { get; set; }
        public string Correo { get; set; }
        public string Habilidades { get; set; }
        public string HabilidadPrincipal { get; set; }
        public string HabilidadSecundaria { get; set; }
        public int IdTipo { get; set; }
        public List<object> Personas { get; set; }

    }
}