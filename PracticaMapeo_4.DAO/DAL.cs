using PracticaMapeo_4.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaMapeo_4.DAO
{
    public class DAL
    {
        private readonly IMapeo mapeo;
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["MapeoDB"].ConnectionString;

        public DAL(IMapeo mapeo)
        {
            this.mapeo = mapeo;
        }

        public IList<T> Listar<T>() where T : class,new()
        {
            using (SqlConnection sqlConnection = CrearConexion())
            {
                string query = "Select * from " + TraerTabla<T>();
                DataSet dataSet = new DataSet();
                SqlCommand sqlCommand = new SqlCommand(query,sqlConnection);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(dataSet);

                return dataSet.Tables[0].Rows.Cast<DataRow>().Select(mapeo.Mapeo<T>).ToList();
            }
        }

        private string TraerTabla<T>()
        {
            return typeof(T).Name;
        }

        private SqlConnection CrearConexion()
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            return sqlConnection;
        }
    }
}
