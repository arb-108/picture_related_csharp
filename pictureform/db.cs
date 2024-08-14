using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pictureform
{
    internal class db
    {
        string constr = ConfigurationManager.ConnectionStrings["pictureform.Properties.Settings.pictureConnectionString"].ConnectionString;
        
        public void insertpic(student stu)
        {
            SqlConnection conn = new SqlConnection(constr);
            using(conn)
            {
                SqlCommand cmd = new SqlCommand("usp_insertpic", conn);
                cmd.CommandType=System.Data.CommandType.StoredProcedure;
                conn.Open();
                cmd.Parameters.AddWithValue("@name", stu.name);
                cmd.Parameters.AddWithValue("@picture", stu.photo);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Inserted Successfully", "Record Added", MessageBoxButtons.OK);
            }
        }
        public DataTable GetData()
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(constr);
            using (conn)
            {
                SqlCommand cmd = new SqlCommand("usp_datagrid", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();
                SqlDataReader dr= cmd.ExecuteReader();
                dt.Load(dr);
            }
            return dt;
        }

    
    }
}
