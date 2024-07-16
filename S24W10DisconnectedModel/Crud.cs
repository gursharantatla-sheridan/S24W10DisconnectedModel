using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace S24W10DisconnectedModel
{
    public class Crud
    {
        private SqlConnection conn;
        private SqlDataAdapter adp;
        private SqlCommandBuilder cmdBuilder;
        private DataSet ds;
        private DataTable tbl;

        public Crud()
        {
            string query = "select ProductID, ProductName, UnitPrice, UnitsInStock from Products";

            conn = new SqlConnection(Data.ConnectionString);
            adp = new SqlDataAdapter(query, conn);
            cmdBuilder = new SqlCommandBuilder(adp);
        }

        private void FillDataSet()
        {
            ds = new DataSet();
            adp.Fill(ds);

            tbl = ds.Tables[0];
        }

        public DataTable GetAllProducts()
        {
            FillDataSet();
            return tbl;
        }
    }
}
