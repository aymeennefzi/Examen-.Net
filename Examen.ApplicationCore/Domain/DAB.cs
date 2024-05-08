using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Domain
{
    public class DAB
    {
        public string DABId { get; set; }
        public string Loacalisation { get; set; }
        public IEnumerable<Transaction> Transactions  { get; set; }
    }
}
