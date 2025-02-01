using System.Globalization;

namespace ClientDataViewer.Data.Entities;

public record Client(string FirstName, string LastName, DateTime BirthDate, string Gender, string NativeId)
{
    public string FullName => $"{FirstName} {LastName}";
    public string Initial => FirstName.First().ToString();
    public string BirthDateFormatted => BirthDate.ToShortDateString();
}
