using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            

            logger.LogInfo("Log initialized");

            var lines = File.ReadAllLines(csvPath);

            logger.LogInfo($"Lines: {lines[0]}");

            if(lines.Length == 0)
            {
                logger.LogError("Oh no we don't have any lines");
            }
            else if(lines.Length == 1)
            {
                logger.LogWarning("We only have 1 line where is the other one!? How could this happen!?");
            }
            else
            {
                logger.LogInfo("Everything is normaL");
            }


         
            var parser = new TacoParser();

            
            var locations = lines.Select(parser.Parse).ToArray();

          
            ITrackable bell1 = null;
            ITrackable bell2 = null;
            double distance = 0;
            
           
               


            for( int i = 0; i < locations.Length; i++ )
            {
                var locA = locations[i];


                var corA = new GeoCoordinate();
                corA.Latitude = locA.Location.Latitude;
                corA.Longitude = locA.Location.Longitude;

                for(int x = 0; x < locations.Length; x++ )
                {
                    var locB = locations[x];

                    var corB = new GeoCoordinate();
                    corB.Latitude = locB.Location.Latitude;
                    corB.Longitude = locB.Location.Longitude;


                    if(corA.GetDistanceTo(corB) > distance)
                    {
                        distance = corA.GetDistanceTo(corB);
                        bell1 = locA;
                        bell2 = locB;
                    }
                }

                
            }



            Console.WriteLine($"These tacobells are the futhest apart {bell1.Name} {bell2.Name}");

        }
    }
}
