namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();
        
        public ITrackable Parse(string line)
        {
            logger.LogInfo("Begin parsing");

        
            var cells = line.Split(',');

       
            if (cells.Length < 3)
            {
               
                logger.LogWarning("Array is less than 3 something is wrong");


              
                return null; 
            }



            var latitiude = double.Parse(cells[0]);
            var longitiude = double.Parse(cells[1]);
            string name = cells[2];



     
            
            var point = new Point();
            point.Latitude = latitiude;
            point.Longitude = longitiude;

            var tacoBell = new TacoBell();
            tacoBell.Name = name;
            tacoBell.Location = point;

            


            return tacoBell;
        }
    }
}