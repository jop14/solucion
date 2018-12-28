using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Data.Odbc;

namespace MODERN_GUI_2
{
    class conexion{

        public string cadena = @"Driver={SQL Server};Server=LAPTOP-N9A3KFG7\OMAR;UID=sa;PWD=adminATIO;Database=solucion; ";
        public OdbcConnection cn;
        public OdbcCommandBuilder cmb;
        public DataSet ds = new DataSet();
        public OdbcDataAdapter da;

        private void conectar()
        {
            cn = new OdbcConnection(cadena);
        }
        public conexion()
        {
            conectar();
        }
        public DataTable select(string tabla)
        {
            string sql = "select  * from " + tabla;
            da = new OdbcDataAdapter(sql, cn);
            DataSet dts = new DataSet();
            da.Fill(dts, tabla);

            DataTable dt = new DataTable();
            dt = dts.Tables[tabla];
            return dt;
        }
        public DataTable select_condicion(string tabla, string condicion)
        {
            string sql = "select  * from " + tabla + "where" + condicion;
            da = new OdbcDataAdapter(sql, cn);
            DataSet dts = new DataSet();
            da.Fill(dts, tabla);
            DataTable dt = new DataTable();
            dt = dts.Tables[tabla];
            return dt;
        }
        public void consulta(string sql, string tabla)
        {
            ds.Tables.Clear();
            da = new OdbcDataAdapter(sql, cn);
            cmb = new OdbcCommandBuilder(da);
            da.Fill(ds, tabla);
        }
    }
}
