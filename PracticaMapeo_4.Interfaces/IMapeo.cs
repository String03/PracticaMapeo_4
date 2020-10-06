using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaMapeo_4.Interfaces
{
    public interface IMapeo
    {
        T Mapeo<T>(DataRow dataRow) where T: class,new();
    }
}
