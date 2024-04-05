using NUnit.Framework;
using TestTickets.utils;

[TestFixture]
public class TicketsTest
{
    private static string DIR = AppDomain.CurrentDomain.BaseDirectory + "resources/tickets";
    private static string STATIONS = "Екатеринбург-Пассажирский, Нижний Тагил, Московский вокзал, Пл. 75 км";

    [Test]
    public void CheckTicketsData()
    {
        List<string> filenames = FileReader.getFolderFilenames(DIR);
        foreach (string filename in filenames)
        {
            string[] ticketData = FileReader.readFile(DIR, filename).Split('\n');
            Boolean dateOk = checkDate(ticketData);
            Boolean stationOk = checkStation(ticketData);
            Assertions.True(dateOk && stationOk, "Билет: '" + filename + "' is not OK", "Билет: '" + filename + "' is OK");
        }
    }

    public static Boolean checkDate(string[] ticket)
    {
        DateTime ticketDate = TicketConverter.getDate(ticket);
        if (DateTime.Compare(ticketDate, new DateTime(0001, 01, 01)) > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static Boolean checkStation(string[] ticket)
    {
        string ticketStation = TicketConverter.getStation(ticket).ToLower();
        if (STATIONS.ToLower().Contains(ticketStation))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
