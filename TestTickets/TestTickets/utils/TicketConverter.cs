using System.Globalization;

public class TicketConverter {
    public static DateTime getDate(string[] ticket)
    {
        HashSet<char> validChars = new HashSet<char>(
            new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'});
        var dateString = new string((from c in ticket[2]
                                       where validChars.Contains(c)
                                       select c).ToArray());
        string dateFormat = "ddMMyyyy";
        DateTime date = new DateTime(0001, 01, 01);
        if (DateTime.TryParseExact(dateString, dateFormat, null, DateTimeStyles.NoCurrentDateDefault, out date)) {
            return date;
        } else
        {
            return date;
        }
    }

    public static string getStation(string[] ticket)
    {
        string[] stationString = ticket[3].Split("  ");
        return stationString[1];
    }
}