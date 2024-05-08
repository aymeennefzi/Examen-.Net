using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Domain
{
    public class Banque
    {
        [Key]
        public int Code { get; set; }
        [EmailAddress(ErrorMessage = "L'email n'est pas dans un format valide.")]
        public string Email { get; set; }
        public string Nom { get; set; }
        public string Rue { get; set; }
        public string Ville { get; set; }
        public IEnumerable<Compte> Comptes { get; set; }
    }
}
