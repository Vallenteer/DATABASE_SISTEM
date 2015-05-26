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
            Console.Clear();
            CRUD app = new CRUD();
            app.TestConnection();
            int pilihMenu = 0;
            bool kondisi;
            string pilih;

            do
            {
                menuUtama();
                Console.Write("Masukan pilihan anda : ");
                //pilihBukuMenu = Convert.ToInt16(Console.ReadLine());
                pilih = Console.ReadLine();
                kondisi = int.TryParse(pilih, out pilihMenu);
                if (kondisi==true && pilihMenu > 0 && pilihMenu < 7)
                {
                    continue;
                }
                Console.WriteLine("Pilihan yang anda masukan salah!");
                Console.WriteLine("Tekan sembarang untuk memilih kembali...");
                Console.ReadLine();
            } while (pilihMenu < 1 || pilihMenu > 6);

            switch (pilihMenu)
            {
                case 1:
                    Tmahasiswa();
                    break;
                case 2:
                    TMK();
                    break;
                case 3:
                    TKuliah();
                    break;
                case 4:
                    ListQuery();
                    break;
                case 5:
                     Environment.Exit(0);
                    break;
            }

            Console.ReadKey();

        }
        public static void menuUtama()
        {
            Console.Clear();
            Console.WriteLine("\t\t\t\tDatabase db_tugas2");
            Console.WriteLine("\t\t\t\t===================\n");
            Console.WriteLine("1. Table Mahasiswa\n");
            Console.WriteLine("2. Table Mata Kuliah\n");
            Console.WriteLine("3. Table Kuliah\n");
            Console.WriteLine("4. Query\n");
            Console.WriteLine("5. Exit \n");

        }

        public static void Tmahasiswa()
        {
            CRUD app=new CRUD();
            int pilihMenu = 0;
            bool kondisi;
            string pilih;

            do
            {
                Console.Clear();
                Console.WriteLine("\t\t\t\tTable Mahasiswa");
                Console.WriteLine("\t\t\t\t===============\n");
                Console.WriteLine("1. Create Data\n");
                Console.WriteLine("2. Update Data\n");
                Console.WriteLine("3. Read Data\n");
                Console.WriteLine("4. Delete Data\n");
                Console.WriteLine("5. Main Menu \n");
                Console.Write("Masukan pilihan anda : ");
                //pilihBukuMenu = Convert.ToInt16(Console.ReadLine());
                pilih = Console.ReadLine();
                kondisi = int.TryParse(pilih, out pilihMenu);
                if (kondisi==true && pilihMenu > 0 && pilihMenu < 7)
                {
                    continue;
                }
                Console.WriteLine("Pilihan yang anda masukan salah!");
                Console.WriteLine("Tekan sembarang untuk memilih kembali...");
                Console.ReadLine();
            } while (pilihMenu < 1 || pilihMenu > 6);
            
            switch (pilihMenu)
            {
                case 1:
                    app.tambahmahasiswa();
                    break;
                case 2:
                    app.updatemahasiswa();
                    break;
                case 3:
                    app.readmahasiswa();
                    break;
                case 4:
                    app.deletemahasiswa();
                    break;
                case 5:
                    Main();
                    break;
            }
        }
        
        public static void TMK()
        {
             CRUD app=new CRUD();
            int pilihMenu = 0;
            bool kondisi;
            string pilih;

            do
            {
                Console.Clear();
                Console.WriteLine("\t\t\t\tTable Mata Kuliah");
                Console.WriteLine("\t\t\t\t=================\n");
                Console.WriteLine("1. Create Data\n");
                Console.WriteLine("2. Update Data\n");
                Console.WriteLine("3. Read Data\n");
                Console.WriteLine("4. Delete Data\n");
                Console.WriteLine("5. Main Menu \n");
                Console.Write("Masukan pilihan anda : ");
                //pilihBukuMenu = Convert.ToInt16(Console.ReadLine());
                pilih = Console.ReadLine();
                kondisi = int.TryParse(pilih, out pilihMenu);
                if (kondisi==true && pilihMenu > 0 && pilihMenu < 7)
                {
                    continue;
                }
                Console.WriteLine("Pilihan yang anda masukan salah!");
                Console.WriteLine("Tekan sembarang untuk memilih kembali...");
                Console.ReadLine();
            } while (pilihMenu < 1 || pilihMenu > 6);

            switch (pilihMenu)
            {
                case 1:
                    app.tambahmatakuliah();
                    break;
                case 2:
                    app.updatematakuliah();
                    break;
                case 3:
                    app.readmatakuliah();
                    break;
                case 4:
                    app.deletematakuliah();
                    break;
                case 5:
                    Main();
                    break;
            }
        }
        public static void  TKuliah()
        {
            CRUD app = new CRUD();
            int pilihMenu = 0;
            bool kondisi;
            string pilih;

            do
            {
                Console.Clear();
                Console.WriteLine("\t\t\t\tTable Kuliah");
                Console.WriteLine("\t\t\t\t=================\n");
                Console.WriteLine("1. Create Data\n");
                Console.WriteLine("2. Update Data\n");
                Console.WriteLine("3. Read Data\n");
                Console.WriteLine("4. Delete Data\n");
                Console.WriteLine("5. Main Menu \n");
                Console.Write("Masukan pilihan anda : ");
                //pilihBukuMenu = Convert.ToInt16(Console.ReadLine());
                pilih = Console.ReadLine();
                kondisi = int.TryParse(pilih, out pilihMenu);
                if (kondisi == true && pilihMenu > 0 && pilihMenu < 7)
                {
                    continue;
                }
                Console.WriteLine("Pilihan yang anda masukan salah!");
                Console.WriteLine("Tekan sembarang untuk memilih kembali...");
                Console.ReadLine();
            } while (pilihMenu < 1 || pilihMenu > 6);

            switch (pilihMenu)
            {
                case 1:
                    app.tambahkuliah();
                    break;
                case 2:
                    app.updatekuliah();
                    break;
                case 3:
                    app.readkuliah();
                    break;
                
                case 4:
                    app.deletekuliah();
                    break;
                case 5:
                    Main();
                    break;
            }
        }

        public static void  ListQuery()
        {
            CRUD app = new CRUD();
            int pilihMenu = 0;
            bool kondisi;
            string pilih;

            do
            {
                Console.Clear();
                Console.WriteLine("\t\t\t\tQuery");
                Console.WriteLine("\t\t\t\t=================\n");
                Console.WriteLine("1. IPK masing-masing mahasiswa\n");
                Console.WriteLine("2. Rata-rata IPK semua mahasiswa\n");
                Console.WriteLine("3. Rata-rata IPK mahasiswa\n");
                Console.WriteLine("4. Rata-rata IPK mahasiswi\n");
                Console.WriteLine("5. Rata-rata Nilai per MK \n");
                Console.WriteLine("6. 10 IPK tertinggi (data mahasiswa ditampilkan)\n");
                Console.WriteLine("7.10 IPK terendah (data mahasiswa ditampilkan)\n");
                Console.WriteLine("8. Daftar mahasiswa/i yang harus mengulang beserta nama MK\n");
                Console.WriteLine("9. Jumlah mahasiswa yang mendapat masing-masing grade (A,B,C atau D) per MK\n");
                Console.WriteLine("10. Konversi nilai IPK dari skala 4 ke skala 5 untuk semua data IPK mahasiswa \n");
                Console.Write("Masukan pilihan anda : ");
                //pilihBukuMenu = Convert.ToInt16(Console.ReadLine());
                pilih = Console.ReadLine();
                kondisi = int.TryParse(pilih, out pilihMenu);
                if (kondisi == true && pilihMenu > 0 && pilihMenu < 11)
                {
                    continue;
                }
                Console.WriteLine("Pilihan yang anda masukan salah!");
                Console.WriteLine("Tekan sembarang untuk memilih kembali...");
                Console.ReadLine();
            } while (pilihMenu < 1 || pilihMenu > 11);

            switch (pilihMenu)
            {
                case 1:
                    app.q1();
                    break;
                case 2:
                    app.q2();
                    break;
                case 3:
                    
                    break;

                case 4:
                    
                    break;
                case 5:
                    
                    break;
                case 6:

                    break;
                case 7:

                    break;
                case 8:

                    break;

                case 9:

                    break;
                case 10:

                    break;
            }
        }
    }
}
