using PracticaMapeo_4.BLL;
using PracticaMapeo_4.DAO;
using PracticaMapeo_4.MPP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaMapeo_4.Factory
{
    public static class GeneroFactory
    {
        public static GeneroBLL CrearInstancia()
        {
            return new GeneroBLL(new DAL(new MapeoGenerico()));
        }
    }
}
