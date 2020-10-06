using PracticaMapeo_4.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PracticaMapeo_4.MPP
{
    public class MapeoGenerico : IMapeo
    {
        public T Mapeo<T>(DataRow dataRow) where T : class, new()
        {
            object resultado = new T();
            var propieties = resultado.GetType().GetProperties();

            foreach (var prop in propieties)
            {
                object c = GetRowValues(dataRow, prop);
                prop.SetValue(resultado,c);
            }
            return (T)resultado;
        }

        private object GetRowValues(DataRow dataRow, PropertyInfo prop)
        {
            object resu = dataRow[prop.Name];
            return resu;
        }
    }
}
