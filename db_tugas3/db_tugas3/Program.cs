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
    class Program
    {
        static void Main()
        {
            CRUD app=new CRUD();
            app.TestConnection();


        }
    }
}
