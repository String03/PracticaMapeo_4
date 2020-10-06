using PracticaMapeo_4.DAO;
using PracticaMapeo_4.EE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaMapeo_4.BLL
{
    public class GeneroBLL
    {
        private readonly DAL dAL;

        public GeneroBLL(DAL dAL)
        {
            this.dAL = dAL;
        }

        public IEnumerable<Genero> ListarGeneros()
        {
            return dAL.Listar<Genero>();
        }
    }
}
