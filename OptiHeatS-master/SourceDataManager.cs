using System.Globalization;

namespace OptiHeatPro
{
    public class DataEntry
    {
        public DateTime TimeFrom { get; set; }
        public DateTime TimeTo { get; set; }
        public double HeatDemand { get; set; }
        public decimal ElectricityPrice { get; set; }
    }

    public class HeatingData
    {
        public List<DataEntry>? WinterData { get; private set; }
        public List<DataEntry>? SummerData { get; private set; }

        public void Read()
        {
            WinterData = new List<DataEntry>();
            SummerData = new List<DataEntry>();

            using (var reader = new StreamReader(@"Data/SourceManagerData.csv"))
            {
                reader.ReadLine(); // Skip header
                reader.ReadLine(); // Skip sub-header

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');

                    StoreData(values);
                }
            }
        }

        private void StoreData(string[] values)
        {
            var format = "dd/MM/yyyy HH.mm";
        
            var winterEntry = new DataEntry
            {
                TimeFrom = DateTime.ParseExact(values[0], format, CultureInfo.InvariantCulture),
                TimeTo = DateTime.ParseExact(values[1], format, CultureInfo.InvariantCulture),
                HeatDemand = double.Parse(values[2].Replace(',', '.'), CultureInfo.InvariantCulture),
                ElectricityPrice = decimal.Parse(values[3].Replace(',', '.'), CultureInfo.InvariantCulture)
            };
            WinterData.Add(winterEntry);
        
            var summerEntry = new DataEntry
            {
                TimeFrom = DateTime.ParseExact(values[5], format, CultureInfo.InvariantCulture),
                TimeTo = DateTime.ParseExact(values[6], format, CultureInfo.InvariantCulture),
                HeatDemand = double.Parse(values[7].Replace(',', '.'), CultureInfo.InvariantCulture),
                ElectricityPrice = decimal.Parse(values[8].Replace(',', '.'), CultureInfo.InvariantCulture)
            };
            SummerData.Add(summerEntry);
        }
    }
}