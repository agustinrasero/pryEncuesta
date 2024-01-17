using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;

namespace pryEncuesta
{
    internal class TABLA
    {
        public DataTable GetData(string sql)
        {
            OleDbDataAdapter adap = new OleDbDataAdapter(sql, Properties.Settings.Default.CADENA);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            return dt;
        }
    }
}
