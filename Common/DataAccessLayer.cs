using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.Common
{
    public class DataAccessLayer
    {
        public string ConnectionString { get; set; }
        public DataAccessLayer()
        {

        } 

        public DataTable ExecuteSP(string ProcedureName)
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(Connection.ConnectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(ProcedureName, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.Add(new SqlParameter("@userId", '"+txtId.Text+"'));
           //cmd.Parameters.Add(parameters);
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = cmd;
            sda.Fill(dt);
            return dt;
        }
        public DataTable ExecuteSPWithParams(string ProcedureName, string[] parameterValue, params object[] paramters)
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(Connection.ConnectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(ProcedureName, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            int count = 0;
            foreach (var item in parameterValue)
            {
                cmd.Parameters.Add(new SqlParameter("@" + item, paramters[count]));
                count++;
            }
            //cmd.Parameters.Add(new SqlParameter("@userId", '"+txtId.Text+"'));
            //cmd.Parameters.Add(parameters);
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = cmd;
            sda.Fill(dt);
            return dt;
        }
    }
}
