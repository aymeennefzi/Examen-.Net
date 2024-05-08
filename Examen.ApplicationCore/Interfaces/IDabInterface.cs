using AM.ApplicationCore.Interfaces;
using Examen.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Interfaces
{
    public interface IDabInterface : IService<DAB>
    {
        public int TotalTransaction(DAB dAB);
        public int AllTransaction(Compte compte);
       

    }
}
