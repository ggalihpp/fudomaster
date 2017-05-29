using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace JSon
{
    class Program
    {
        static void Main(string[] args)
        {
            //Get the path of directory
            string currentDirectory = Directory.GetCurrentDirectory();
            DirectoryInfo directory = new DirectoryInfo(currentDirectory);

            //get the files

            var fileName = Path.Combine(directory.FullName, "SoccerGameResults.csv");
            var file = new FileInfo(fileName);

            var fileContents = ReadFootballResults(fileName);

            // string[] filelines = fileContents.Split(new char[] { '\r', '\n' });

            foreach (var xx in fileContents)
                Console.WriteLine(xx[1]);



            //if (file.Exists)
            //{
            //    using (var reader = new StreamReader(file.FullName))
            //    {
            //        Console.SetIn(reader);
            //        Console.WriteLine(Console.ReadLine());
            //        reader.Close(); //harus ditutup agar dia tidak read terus
            //    }
            //}




        }

        //public static string Readfile(string fileName)
        //{
        //    using (var reader = new StreamReader(fileName))
        //    {
        //        return reader.ReadToEnd();
        //    }
        //}

        public static List<string[]> ReadFootballResults(string fileName)
        {
            var SoccerResults = new List<string[]>();
            using (var reader = new StreamReader(fileName))
            {
                var line = "";
                while ((line = reader.ReadLine()) != null)
                {
                    string[] values = line.Split(',');
                    SoccerResults.Add(values);
                }
            }
            return SoccerResults;
        }
    }
}
