using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ContactoCallCenter
    {
        public int Id { get; set; }
        public int EstudianteId { get; set; }
        public DateTime FechaContacto {  get; set; }
        public string Estado { get; set; } = string.Empty;
    }
}
