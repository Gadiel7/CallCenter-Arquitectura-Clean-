namespace Aplication.DTOs
{
    public class DashboardMetricasDto
    {
        public int TotalContactos { get; set; }
        public int Contactados { get; set; }
        public int NoContactados { get; set; }

        // 👇 ESTO FALTABA
        public List<ContactoDashboardDto> Contactos { get; set; } = new();
    }

    public class ContactoDashboardDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Celular { get; set; } = string.Empty;
        public bool Contactado { get; set; }
    }
}
