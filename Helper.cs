using System.Text.Json;
using System.Text;
using System.Globalization;

namespace HIS.Client
{
    public static class Helper
    {
        public static string TrimEnd(this string source, string value) => source.EndsWith(value) ? source.Remove(source.LastIndexOf(value, StringComparison.Ordinal)) : source;

        public static string ToOracleDate(this string? date) => string.IsNullOrEmpty(date) ? string.Empty : DateTime.ParseExact(date, "dd/MM/yyyy", null).ToString("dd-MMM-yyyy", CultureInfo.InvariantCulture);

        public static StringContent PostData<T>(T t) where T : class => new(JsonSerializer.Serialize(t), Encoding.UTF8, "application/json");

        public static T ReadResponseMessage<T>(HttpResponseMessage message) => JsonSerializer.Deserialize<T>(message.Content.ReadAsStringAsync().Result);

        public static string ReadStringResponse(HttpResponseMessage message) => message.Content.ReadAsStringAsync().Result;
        public static string GetArabicDate(string engDate)
        {
            var arabicDate = "";
            try
            {
                DateTime date = DateTime.ParseExact(engDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                UmAlQuraCalendar cal = new UmAlQuraCalendar();
                int year = cal.GetYear(date);
                int month = cal.GetMonth(date);
                int day = cal.GetDayOfMonth(date);
                arabicDate = $"{day}/{month}/{year}";
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message.ToString());
            }
            return arabicDate;

        }
        public static string EnglishNumberDateToArabic(string date)
        {
            string output = string.Empty;
            List<char> result = date.ToCharArray().ToList();
            foreach (var r in result)
            {
                switch (r.ToString())
                {
                    case "/":
                        output += "/";
                        break;
                    case @"\":
                        output += @"\";
                        break;
                    case ".":
                        output += ".";
                        break;
                    case "-":
                        output += "-";
                        break;
                    case "0":
                        output += "٠";
                        break;
                    case "1":
                        output += "١";
                        break;
                    case "2":
                        output += "٢";
                        break;
                    case "3":
                        output += "٣";
                        break;
                    case "4":
                        output += "٤";
                        break;
                    case "5":
                        output += "٥";
                        break;
                    case "6":
                        output += "٦";
                        break;
                    case "7":
                        output += "٧";
                        break;
                    case "8":
                        output += "٨";
                        break;
                    case "9":
                        output += "٩";
                        break;
                }
            }
            return output;
        }

    }
}