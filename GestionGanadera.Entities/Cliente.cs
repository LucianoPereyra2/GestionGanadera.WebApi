namespace GestionGanadera.Entities
{
    public class Cliente
    {
        public int Id { get; set; }
        public string RazonSocial { get; set; } = null!;
        public string CUIT { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public bool Activo { get; set; } = true;
    }
}
