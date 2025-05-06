using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indica.System.Domain.Entities
{
    public class Electrician : Employer
    {
        public int IdSupervisor { get; set; }
        public string[] Habilities { get; set; }
    }
}
