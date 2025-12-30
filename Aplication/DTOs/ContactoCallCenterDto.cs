using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.DTOs
{
    public class ContactoCallCenterDto
    {
        public int EstudianteId { get; set; }
        public DateTime FechaContacto { get; set; }
        public string Estado { get; set; } = string.Empty;
    }
}
