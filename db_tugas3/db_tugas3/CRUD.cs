using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;
using System.Web;
//Add mySQL Reference
using MySql;
using MySql.Data;
using MySql.Web;
using MySql.Data.MySqlClient;


namespace db_tugas3
{
    public class CRUD
    {

        public IDbConnection connString;
        public CRUD()
        {
            connString = new MySqlConnection("Server=127.0.0.1;" +
           "Port=3306;" +
           "Database=db_tugas2;" +
           "User ID=root;" +
           "Password=;" +
           "Pooling=true;Connection Lifetime=0");
        }


        public void TestConnection()
        {
            try
            {
                connString.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            if (connString.State.ToString() != "Open")
            {
                Console.WriteLine("Koneksi ke database Gagal!", "Warning!");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Koneksi ke database Berhasil!");
                Console.ReadLine();
            }
        }
    }
}
