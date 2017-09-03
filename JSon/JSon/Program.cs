using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Net;

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

            var fileName = Path.Combine(directory.FullName, "players.json");
            var file = new FileInfo(fileName);

            //var fileContents = ReadFootballResults(fileName);
            var fileContents = DeserializedPlayer(fileName);

            // string[] filelines = fileContents.Split(new char[] { '\r', '\n' });

            //foreach (var xx in fileContents)
            //    Console.WriteLine(xx.TeamName);

            var ABC = GetNewsFromPlayer("Galih Pratama");
            foreach (var xxx in ABC)
            {
                Console.WriteLine("Tanggal : {0}\n", xxx.datePublished);
                Console.WriteLine("Judul : {0}\n", xxx.name);
                Console.WriteLine(" \n {0} \n\n", xxx.description);
            }
                

            //Console.WriteLine(GetNewsFromPlayer("Galih Pratama"));


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

        public static List<GameResult> ReadFootballResults(string fileName)
        {
            var SoccerResults = new List<GameResult>();
            using (var reader = new StreamReader(fileName))
            {
                var line = "";
                while ((line = reader.ReadLine()) != null)
                {
                    string[] values = line.Split(',');
                    GameResult GR = new GameResult();
                    DateTime GDate;
                    HomeOrAway Homer;
                    int parseInt;
                    Double PossessionPercent;

                    if (DateTime.TryParse(values[0], out GDate))
                        GR.GameDate = GDate;

                    GR.TeamName = values[1];

                    if (Enum.TryParse(values[2], out Homer))
                        GR.HomeOrAway = Homer;

                   

                    if (int.TryParse(values[3], out parseInt))
                    
                        GR.Goals = parseInt;
                    
                    if (int.TryParse(values[4], out parseInt))
                    
                       GR.GoalAttempts = parseInt;
                    
                    if (int.TryParse(values[5], out parseInt))
                    
                        GR.ShotsOnGoal = parseInt;
                    
                    if (int.TryParse(values[6], out parseInt))
                    
                        GR.ShotsOffGoal = parseInt;

                    
                    if (Double.TryParse(values[6], out PossessionPercent))
                    {
                        GR.PossessionPercent = PossessionPercent;
                    }

                    SoccerResults.Add(GR);
                }
            }
            return SoccerResults;



        }

        public static List<Player> DeserializedPlayer(string fileName)
        {
            var players = new List<Player>();
            var serializer = new JsonSerializer();
            using (var reader = new StreamReader(fileName))
            using (var JsonReader = new JsonTextReader(reader))
            {
                players = serializer.Deserialize<List<Player>>(JsonReader);

            }

            return players;
        }

        public static string GetGoogleHomepage()
        {
            var webClient = new WebClient();
            byte[] googlehome = webClient.DownloadData("https://makersinstitute.id");

            using (var stream = new MemoryStream(googlehome))
            using (var reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();        
            }

            
        }

        public static List<NewsResult> GetNewsFromPlayer(string PlayerName)
        {
            var webClient = new WebClient();
            webClient.Headers.Add("Ocp-Apim-Subscription-Key", "00c599495da24655b850423762172e18");
            byte[] PlayerNews = webClient.DownloadData(String.Format("https://api.cognitive.microsoft.com/bing/v5.0/news/search?q={0}&mkt=en-us", PlayerName));
            var Results = new List<NewsResult>();
            var Serializer = new JsonSerializer();

            using (var stream = new MemoryStream(PlayerNews))
            using (var reader = new StreamReader(stream))
            using (var JsonReader = new JsonTextReader(reader))
            {
                Results = Serializer.Deserialize<NewsSearch>(JsonReader).NewsResults;
            }   

            return Results;
        }   
    }
}
