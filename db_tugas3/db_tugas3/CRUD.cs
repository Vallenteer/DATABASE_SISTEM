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
        public MySqlConnection connString= new MySqlConnection("Server=127.0.0.1;" +
           "Port=3306;" +
           "Database=db_tugas2;" +
           "User ID=root;" +
           "Password=;" +
           "Pooling=true;Connection Lifetime=0");
        public CRUD()
        {
           
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
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Koneksi ke database Berhasil!");
                Console.WriteLine("Tekan enter untuk melanjutkan.....");
                Console.ReadLine();
                connString.Close();
            }
        }
        public void tambahmahasiswa()
        {
            Console.Clear();
            string nama;
            char jenisK= ' ';
            Console.Write("Masukan Nama Mahasiswa   : ");
            nama=Console.ReadLine();
            do
            {
                Console.Write("Masukan Jenis Kelamin (F/M) : ");
                jenisK = Console.ReadKey().KeyChar;
                jenisK = char.ToUpper(jenisK);
                Console.WriteLine();
                switch (jenisK)
                {
                    case 'F':
                        continue;

                    case 'M':
                        continue;

                    default:
                        jenisK = ' ';
                        break;
                }
            } while (jenisK == ' ');

                //string query = "insert into Mahasiswa (Nama_Mahasiswa,JenisKelamin) value(@name,@jenisK)";
                //open connection
                connString.Open();
            MySqlCommand sqlcomm;
            sqlcomm = connString.CreateCommand();
            sqlcomm.CommandText = "INSERT into mahasiswa (Nama_Mahasiswa,JenisKelamin) value(@name,@jenisK)";
            sqlcomm.Parameters.AddWithValue("@name", nama.Trim());
            sqlcomm.Parameters.AddWithValue("@jenisK", jenisK);
            try
            {
                sqlcomm.ExecuteNonQuery();
                Console.WriteLine("Berhasil Memasukan data Mahasiswa!"); 
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            connString.Close();
            Console.WriteLine("Tekan sembarang untuk kembali ke menu...");
            Console.ReadKey();
            Program.Tmahasiswa();
        }
        public void readmahasiswa()
        {
            Console.Clear();
            Console.WriteLine("NIM\tNama Mahasiswa\t\t\t\t\tJenis Kelamin");
            connString.Open();
            MySqlCommand sqlcomm;
            sqlcomm = connString.CreateCommand();
            sqlcomm.CommandText = "SELECT * FROM mahasiswa";
            MySqlDataReader sqlDr = sqlcomm.ExecuteReader();
            while (sqlDr.Read())
            {
                string nim = Convert.ToString(sqlDr["NIM"]);
                string nama = (string)sqlDr["Nama_Mahasiswa"];
                string jenisK = (string)sqlDr["jenisKelamin"];

                // Print the data.
                //Console.WriteLine(nim + "\t\t" + nama + "\t\t" + jenisK);
                if (nama.Length < 8)
                {
                    Console.WriteLine("{0}\t{1}\t\t\t\t\t\t{2}", nim, nama, jenisK);
                }
                else if (nama.Length < 16)
                {
                    Console.WriteLine("{0}\t{1}\t\t\t\t\t{2}", nim, nama, jenisK);
                }
                else if (nama.Length < 24)
                {
                    Console.WriteLine("{0}\t{1}\t\t\t\t{2}", nim, nama, jenisK);

                }
                else if (nama.Length < 31)
                {
                    Console.WriteLine("{0}\t{1}\t\t\t{2}", nim, nama, jenisK);

                }
                else if (nama.Length < 39)
                {
                    Console.WriteLine("{0}\t{1}\t\t{2}", nim, nama, jenisK);

                }
                else
                {
                    Console.WriteLine("{0}\t{1}\t{2}", nim, nama, jenisK);
                }
               
            }
            connString.Close();
            Console.WriteLine("Tekan sembarang untuk kembali ke menu...");
            Console.ReadKey();
            Program.Tmahasiswa();
        }

        public void updatemahasiswa()
        {
            Console.Clear();
            string nama1;
            char jenisK;
            string Nim;
            Console.Write("Masukan NIM yang mau dirubah : ");
            Nim=Console.ReadLine();
            Console.Write("Masukan Nama Mahasiswa yang mau dirubah  :");
            nama1 = Console.ReadLine();
            do
            {
                Console.Write("Masukan Jenis Kelamin (F/M) : ");
                jenisK = Console.ReadKey().KeyChar;
                jenisK = char.ToUpper(jenisK);
                Console.WriteLine();
                switch (jenisK)
                {
                    case 'F':
                        continue;

                    case 'M':
                        continue;

                    default:
                        jenisK = ' ';
                        break;
                }
            } while (jenisK == ' ');
            
            connString.Open();
            MySqlCommand sqlcomm;
            sqlcomm = connString.CreateCommand();
            sqlcomm.CommandText = "UPDATE mahasiswa SET Nama_Mahasiswa = @Name, JenisKelamin = @jenisK WHERE NIM = @NIM";
            sqlcomm.Parameters.AddWithValue("@NIM", Nim.Trim());
            sqlcomm.Parameters.AddWithValue("@name", nama1.Trim());
            sqlcomm.Parameters.AddWithValue("@jenisK", jenisK);
            try
            {
                sqlcomm.ExecuteNonQuery();
                Console.WriteLine("Berhasil Merubah data Mahasiswa dengan NIM : {0}!!",Nim);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            connString.Close();
            Console.WriteLine("Tekan sembarang untuk kembali ke menu...");
            Console.ReadKey();
            Program.Tmahasiswa();
        }
       
        public void deletemahasiswa()
        {
            Console.Clear();
            string Nim;
            Console.Write("Masukan NIM yang ada di hapus datanya : ");
            Nim=Console.ReadLine();
            connString.Open();
            MySqlCommand sqlcomm;
            sqlcomm = connString.CreateCommand();
            sqlcomm.CommandText = "Delete from mahasiswa where NIM=@NIM";
            sqlcomm.Parameters.AddWithValue("@NIM", Nim.Trim());
            try
            {
                sqlcomm.ExecuteNonQuery();
                Console.WriteLine("Berhasil menghapus data mahasiswa dengan NIM : {0}!",Nim);
            }
            catch (Exception e)
            {

                Console.WriteLine("Gagal menghapus data mahasiswa dengan NIM : {0}!", Nim);
                Console.WriteLine(e);
            }
            connString.Close();
            Console.WriteLine("Tekan sembarang untuk kembali ke menu...");
            Console.ReadKey();
            Program.Tmahasiswa();
        }
        /// <summary>
        /// ////////////////////////////////////////////////////////////// matakuliah
        /// </summary>
        public void tambahmatakuliah()
        {
            Console.Clear();
            string KodeMK;
            string MatKul;
            int SKS,Sem;
            Console.Write("Masukan KodeMK   : ");
            KodeMK = Console.ReadLine();
            Console.Write("Masukan Nama MK   : ");
            MatKul = Console.ReadLine();
            Console.Write("Masukan SKS   : ");
            SKS = int.Parse(Console.ReadLine());
            Console.Write("Masukan Semester   : ");
            Sem = int.Parse(Console.ReadLine());
            connString.Open();
            MySqlCommand sqlcomm;
            sqlcomm = connString.CreateCommand();
            sqlcomm.CommandText = "INSERT INTO `db_tugas2`.`matakuliah` (`KodeMK`, `NamaMK`, `SKS`, `semester`) VALUES(@KodeMK,@MatKul,@SKS,@Sem)";
            sqlcomm.Parameters.AddWithValue("@KodeMK", KodeMK.Trim());
            sqlcomm.Parameters.AddWithValue("@MatKul", MatKul.Trim());
            sqlcomm.Parameters.AddWithValue("@SKS", SKS);
            sqlcomm.Parameters.AddWithValue("@Sem", Sem);
            try
            {
                sqlcomm.ExecuteNonQuery();
                Console.WriteLine("Berhasil Memasukan data MataKuliah!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            connString.Close();
            Console.WriteLine("Tekan sembarang untuk kembali ke menu...");
            Console.ReadKey();
            Program.TMK();
        }
        
         public void readmatakuliah()
        {
            Console.Clear();
            Console.WriteLine("KodeMK\tNama MataKuliah\t\t\t\t\tSKS\tSemester ");
            connString.Open();
            MySqlCommand sqlcomm;
            sqlcomm = connString.CreateCommand();
            sqlcomm.CommandText = "SELECT * FROM matakuliah";
            MySqlDataReader sqlDr = sqlcomm.ExecuteReader();
            while (sqlDr.Read())
            {
                string KodeMK = (string)sqlDr["KodeMK"];
                string nama = (string)sqlDr["NamaMK"];
                string SKS = Convert.ToString(sqlDr["SKS"]);
                string Sem = Convert.ToString(sqlDr["Semester"]);

                // Print the data.
                //Console.WriteLine(nim + "\t\t" + nama + "\t\t" + jenisK);
                if (nama.Length < 8)
                {
                    Console.WriteLine("{0}\t{1}\t\t\t\t\t\t{2}\t{3}", KodeMK, nama, SKS,Sem);
                }
                else if (nama.Length < 16)
                {
                    Console.WriteLine("{0}\t{1}\t\t\t\t\t{2}\t{3}", KodeMK, nama, SKS,Sem);
                }
                else if (nama.Length < 24)
                {
                    Console.WriteLine("{0}\t{1}\t\t\t\t{2}\t{3}", KodeMK, nama, SKS,Sem);

                }
                else if (nama.Length < 31)
                {
                    Console.WriteLine("{0}\t{1}\t\t\t{2}\t{3}", KodeMK, nama, SKS,Sem);

                }
                else if (nama.Length < 39)
                {
                    Console.WriteLine("{0}\t{1}\t\t{2}\t{3}", KodeMK, nama, SKS,Sem);

                }
                else
                {
                    Console.WriteLine("{0}\t{1}\t{2}\t{3}", KodeMK, nama, SKS,Sem);
                }

            }
            connString.Close();
            Console.WriteLine("Tekan sembarang untuk kembali ke menu...");
            Console.ReadKey();
            Program.TMK();
         }

        public void updatematakuliah()
        {
            Console.Clear();
            string KodeMK;
            string MatKul;
            int SKS,Sem;
            Console.Write("Masukan KodeMK yang ingin dirubah  : ");
            KodeMK = Console.ReadLine();
            Console.Write("Masukan Nama MK baru  : ");
            MatKul = Console.ReadLine();
            Console.Write("Masukan SKS  baru : ");
            SKS = int.Parse(Console.ReadLine());
            Console.Write("Masukan Semester baru  : ");
            Sem = int.Parse(Console.ReadLine());
            connString.Open();
            MySqlCommand sqlcomm;
            sqlcomm = connString.CreateCommand();
            sqlcomm.CommandText = "UPDATE matakuliah set NamaMK=@namamk,SKS=@sks,Semester=@sem WHERE KodeMK = @kodeMK";
            sqlcomm.Parameters.AddWithValue("@kodeMK", KodeMK.Trim());
            sqlcomm.Parameters.AddWithValue("@namamk", MatKul.Trim());
            sqlcomm.Parameters.AddWithValue("@sks", SKS);
            sqlcomm.Parameters.AddWithValue("@sem",Sem);
            try
            {
                sqlcomm.ExecuteNonQuery();
                Console.WriteLine("Berhasil Merubah data MataKuliah dengan KodeMK : {0}!!",KodeMK);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            connString.Close();
            Console.WriteLine("Tekan sembarang untuk kembali ke menu...");
            Console.ReadKey();
            Program.TMK();
        }
      
        public void deletematakuliah()
        {
            Console.Clear();
            string KodeMK;
            Console.Write("Masukan Kode yang akan di hapus datanya : ");
            KodeMK=Console.ReadLine();
            connString.Open();
            MySqlCommand sqlcomm;
            sqlcomm = connString.CreateCommand();
            sqlcomm.CommandText = "Delete from matakuliah where KodeMK=@KodeMK";
            sqlcomm.Parameters.AddWithValue("@KodeMK", KodeMK.Trim());
            try
            {
                sqlcomm.ExecuteNonQuery();
                Console.WriteLine("Berhasil menghapus data matakuliah dengan KodeMK : {0}!",KodeMK);
            }
            catch (Exception e)
            {

                Console.WriteLine("Gagal menghapus data mahasiswa dengan KodeMK : {0}!",KodeMK);
                Console.WriteLine(e);
            }
            connString.Close();
            Console.WriteLine("Tekan sembarang untuk kembali ke menu...");
            Console.ReadKey();
            Program.TMK();
        }

        /// <summary>
        /// ////////////////////////////////////////////////////////////// tablekuliah
        /// </summary>
        public void tambahkuliah()
        {
            Console.Clear();
            int NIM;
            string KodeMK;
            float nilai;
            Console.Write("Masukan NIM   : ");
            NIM = int.Parse(Console.ReadLine());           
            Console.Write("Masukan KodeMK   : ");
            KodeMK = Console.ReadLine();
            Console.Write("Masukan Nilai   : ");
            nilai = float.Parse(Console.ReadLine());
            
            connString.Open();
            MySqlCommand sqlcomm;
            sqlcomm = connString.CreateCommand();
            sqlcomm.CommandText = "INSERT INTO `db_tugas2`.`tablekuliah` (`Nilai_Angka`, `NIM`, `KodeMK`) VALUES(@nilai,@nim,@KodeMK)";
            sqlcomm.Parameters.AddWithValue("@KodeMK", KodeMK.Trim());
            sqlcomm.Parameters.AddWithValue("@nilai", nilai);
            sqlcomm.Parameters.AddWithValue("@nim", NIM);
            try
            {
                sqlcomm.ExecuteNonQuery();
                Console.WriteLine("Berhasil Memasukan data MataKuliah!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            connString.Close();
            ubahnilai();
            Console.WriteLine("Tekan sembarang untuk kembali ke menu...");
            Console.ReadKey();
            Program.TKuliah();
        }
        public void ubahnilai()
        {
            connString.Open();
            MySqlCommand sqlcomm;
            sqlcomm = connString.CreateCommand();
            sqlcomm.CommandText = "Update tablekuliah set Nilai_Huruf='A' where Nilai_Angka>='86'; Update tablekuliah set Nilai_Huruf='B' where Nilai_Angka>='71'&& Nilai_Angka<'86'; Update tablekuliah set Nilai_Huruf='C' where Nilai_Angka>='60'&& Nilai_Angka<'71'; Update tablekuliah set Nilai_Huruf='D' where Nilai_Angka<'60'; Update tablekuliah set nilaiIP='4' where Nilai_Huruf='A'; Update tablekuliah set nilaiIP='3' where Nilai_Huruf='B'; Update tablekuliah set nilaiIP='2' where Nilai_Huruf='C'; Update tablekuliah set nilaiIP='1' where Nilai_Huruf='D';";
            try
            {
                sqlcomm.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            connString.Close();
        }

        public void readkuliah()
        {
            Console.Clear();
            //No, NIM, Semester, KodeMK, Nilai_Huruf, Nilai_Angka, nilaiIP, totalnilaiip
            Console.WriteLine("No\tNIM\tSemester\tKodeMK\tNilai_Huruf\tNilai_Angka\tNilaiIP\ttotalnilaiIP ");
            connString.Open();
            MySqlCommand sqlcomm;
            sqlcomm = connString.CreateCommand();
            sqlcomm.CommandText = "SELECT * FROM tablekuliah";
            MySqlDataReader sqlDr = sqlcomm.ExecuteReader();
            while (sqlDr.Read())
            {
                string no = Convert.ToString(sqlDr["No"]);
                string NIM = Convert.ToString(sqlDr["NIM"]);
                string Sem = Convert.ToString(sqlDr["Semester"]);
                string  KodeMK= (string)sqlDr["KodeMK"];
                string nilaih = (string)sqlDr["Nilai_Huruf"];
                string nilaia = Convert.ToString(sqlDr["Nilai_Angka"]);
                string IP = Convert.ToString(sqlDr["NilaiIP"]);
                string totip = Convert.ToString(sqlDr["totalnilaiip"]);

                // Print the data.
                //Console.WriteLine("No\tNIM\tSemester\tKodeMK\tNilai_Huruf\tNilai_Angka\tNilaiIP\ttotalnilaiIP ");

                    Console.WriteLine("{0}\t{1}\t{2}\t\t{3}\t{4}\t\t{5}\t\t{6}\t{4}", no, NIM,Sem,KodeMK,nilaih,nilaia,IP,totip);
                

            }
            connString.Close();
            Console.WriteLine("Tekan sembarang untuk kembali ke menu...");
            Console.ReadKey();
            Program.TKuliah();
        }
        public void updatekuliah()
        {
            Console.Clear();
            int ID;
            float nilai;
            Console.Write("Masukan ID nilai yang ingin dirubah  : ");
            ID = int.Parse(Console.ReadLine());
            Console.Write("Masukan Nilai baru  : ");
            nilai = float.Parse(Console.ReadLine());
            connString.Open();
            MySqlCommand sqlcomm;
            sqlcomm = connString.CreateCommand();
            sqlcomm.CommandText = "UPDATE tablekuliah set Nilai_Angka=@nilai WHERE  no= @id";
            sqlcomm.Parameters.AddWithValue("@id", ID);
            sqlcomm.Parameters.AddWithValue("@nilai", nilai);
            try
            {
                sqlcomm.ExecuteNonQuery();
                Console.WriteLine("Berhasil Merubah data nilai di nomor : {0}!!", ID);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            connString.Close();
            ubahnilai();
            Console.WriteLine("Tekan sembarang untuk kembali ke menu...");
            Console.ReadKey();
            Program.TKuliah();
        }
        public void deletekuliah()
        {
            Console.Clear();
            int ID;
            Console.Write("Masukan id yang akan di hapus datanya : ");
            ID = int.Parse(Console.ReadLine());
            connString.Open();
            MySqlCommand sqlcomm;
            sqlcomm = connString.CreateCommand();
            sqlcomm.CommandText = "Delete from tablekuliah where no=@ID";
            sqlcomm.Parameters.AddWithValue("@ID", ID);
            try
            {
                sqlcomm.ExecuteNonQuery();
                Console.WriteLine("Berhasil menghapus data nilai nomor ke : {0}!", ID);
            }
            catch (Exception e)
            {

                Console.WriteLine("Gagal menghapus data nilai nomor ke : {0}!", ID);
                Console.WriteLine(e);
            }
            connString.Close();

            Console.WriteLine("Tekan sembarang untuk kembali ke menu...");
            Console.ReadKey();
            Program.TKuliah();
        }

        

      }
}
