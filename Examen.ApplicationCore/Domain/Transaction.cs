using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Domain
{
    public class Transaction
    {
        public DateTime Date { get; set; }
        public Double Montant { get; set; }
        [ForeignKey("Compte")]
        public string NumeroCompteFk { get; set; }
        public Compte Compte { get; set; }
        [ForeignKey("DAB")]
        public string DABFk { get; set; }
        public DAB DAB { get; set; }
    }
}
