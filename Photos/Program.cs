using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;

namespace Photos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var startDateTime = GetDateTime();
            //var endDateTime = GetDateTime();

            var startDateTime = GetDateTime("09052024","2031");
            var endDateTime = GetDateTime("09052024","2039");

            //var totalNumberOfPhotos = GetPhotosNumber("10");
            var totalNumberOfPhotos = GetPhotosNumber("10");

            //var imageNames = GetPhotosNames();
            var imageNames = GetPhotosNames("IMG_09052024_200512_010.CR2\n\r" +
                                            "IMG_09052024_201015_002.CR2\n\r" +
                                            "DSC_09-05-2024_20-10-01-021.DNG\n\r" +
                                            "DSC_09-05-2024_20-10-07-092.DNG\n\r" +
                                            "DJI_2024-05-09-20-05-55.JPG\n\r" +
                                            "DJI_2024-05-09-20-10-33.JPG\n\r" +
                                            "IMG_09052024_204505_003.CR2\n\r" +
                                            "DSC_09-05-2024_20-45-12-003.DNG\n\r" +
                                            "DJI_2024-05-09-20-45-13.JPG\n\r" +
                                            "IMG_09052024_205055_004.CR2\n\r" +
                                            "IMG_09052024_203151_001.CR2\n\r" +
                                            "IMG_09052024_203900_002.CR2\n\r" +
                                            "DJI_2024-05-09-20-35-00.JPG\n\r" +
                                            "DSC_09-05-2024_20-36-00-065.DNG\n\r"
            );

            ShowNecessaryPhotos(startDateTime, endDateTime, totalNumberOfPhotos, imageNames);
        }


        public static string[] GetPhotosNames(string? sourceArray = null)
        {
            var sb = new StringBuilder();

            if (sourceArray == null)
            {
                Console.WriteLine("To exit type 'q'");

                char currentChar = '\0';
                do
                {
                    currentChar = Convert.ToChar(Console.Read());
                    sb.Append(currentChar);
                }
                while (currentChar != 'q');

                return sb.ToString().Split("\n\r");
            }
            else
            {
                return sourceArray.Split("\n\r");
            }
        }
        public static DateTime GetDateTime(string date = "", string time = "")
        {
            if (date == string.Empty)
            {
                date = Console.ReadLine();
            }
            
            if(time == string.Empty)
            {
                time = Console.ReadLine();
            }

            return DateTime.ParseExact(date + " " + time, "ddMMyyyy HHmm", CultureInfo.InvariantCulture);

        }
        public static int GetPhotosNumber(string number = "")
        {
            if(number == string.Empty)
            {
                return int.Parse(Console.ReadLine());
            }
            else
            {
                return int.Parse(number);
            }
        }
        public static void ShowNecessaryPhotos(DateTime startDataTime, DateTime endDataTime, int totalNumberOfPhotos, string[] imageNames)
        {
            Dictionary<DateTime, string> targeDictionary = new();

            if (endDataTime < startDataTime)
            {
                Console.WriteLine("End dataTime is lower then start dataTime");
                return;
            }
            var currentNumberOfPhotos = 0;
            for (int i = 0; i < imageNames.Length; i++)
            {
                if(currentNumberOfPhotos < totalNumberOfPhotos && imageNames[i].Length > 3)
                {
                    switch (imageNames[i][..3])
                    {
                        case "IMG":
                            {
                                var temp = imageNames[i][(imageNames[i].IndexOf('_') + 1)..imageNames[i].LastIndexOf('_')];
                                var tempDateTime = DateTime.ParseExact(temp, "ddMMyyyy_HHmmss",CultureInfo.InvariantCulture);

                                currentNumberOfPhotos += CheckConditionAndAdd(targeDictionary, imageNames[i],tempDateTime,startDataTime,endDataTime);                         
                            }
                            break;
                        case "DSC":
                            {
                                var temp = imageNames[i][(imageNames[i].IndexOf('_') + 1)..imageNames[i].LastIndexOf('-')];
                                var tempDateTime = DateTime.ParseExact(temp, "dd-MM-yyyy_HH-mm-ss", CultureInfo.InvariantCulture);

                                currentNumberOfPhotos += CheckConditionAndAdd(targeDictionary, imageNames[i], tempDateTime, startDataTime, endDataTime);
                            }
                            break ;
                        case "DJI":
                            {
                                var temp = imageNames[i][(imageNames[i].IndexOf('_') + 1)..imageNames[i].IndexOf('.')];
                                var tempDateTime = DateTime.ParseExact(temp, "yyyy-MM-dd-HH-mm-ss", CultureInfo.InvariantCulture);

                                currentNumberOfPhotos += CheckConditionAndAdd(targeDictionary, imageNames[i], tempDateTime, startDataTime, endDataTime);
                            }
                            break ;
                        default:
                            break;
                    }
                }                
            }

            targeDictionary = targeDictionary.OrderBy(x => x.Key).ToDictionary();

            foreach (var key in targeDictionary.Keys)
            {
                if (key >= startDataTime && key <= endDataTime)
                {
                    Console.WriteLine(targeDictionary[key]);
                }
            }
        }
        public static int CheckConditionAndAdd(Dictionary<DateTime, string> sourceDictionary, string imageName,DateTime current, DateTime start, DateTime end)
        {
            if (current >= start && current <= end)
            {
                sourceDictionary.Add(current, imageName);
                return 1;
            }
            return 0;
        }
    }
}
