using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Net;

namespace ClientRest_050_Adelina_Yoga_Eka_Safira
{
    class Program
    {
        static void Main(string[] args)
        {
            ClassData cl = new ClassData();
            cl.getData();
            Program app = new Program();
            app.BuatMahasiswa();
            Console.ReadLine();
        }

        string baseUrl = "http://localhost:1918/";

        void BuatMahasiswa()
        {
            Mahasiswa mhs = new Mahasiswa();
            Console.Write("Masukan Nama: ");
            mhs.nama = Console.ReadLine();
            Console.Write("Masukan NIM: ");
            mhs.nim = Console.ReadLine();
            Console.Write("Masukan Prodi: ");
            mhs.prodi = Console.ReadLine();
            Console.Write("Masukan Angkatan: ");
            mhs.angkatan = Console.ReadLine();

            var data = JsonConvert.SerializeObject(mhs);
            var postdata = new WebClient();
            postdata.Headers.Add(HttpRequestHeader.ContentType, "application/json");
            string response = postdata.UploadString(baseUrl + "Mahasiswa", data);
            Console.WriteLine(response);
        }
    }

    [DataContract]
        public class Mahasiswa
        {
            private string _nama, _nim, _prodi, _angkatan;
            [DataMember(Order = 1)]
            public string nama
            {
                get { return _nama; }
                set { _nama = value; }
            }
            [DataMember(Order = 2)]
            public string nim
            {
                get { return _nim; }
                set { _nim = value; }
            }
            [DataMember(Order = 3)]
            public string prodi
            {
                get { return _prodi; }
                set { _prodi = value; }
            }
            [DataMember(Order = 4)]
            public string angkatan
            {
                get { return _angkatan; }
                set { _angkatan = value; }
            }
        }
    
}
