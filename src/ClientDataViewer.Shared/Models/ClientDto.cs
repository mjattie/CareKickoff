namespace ClientDataViewer.Shared.Models;

public record ClientDto(string FirstName, string LastName, DateTime BirthDate, Gender Gender, string NativeId)
{
    public string FullName => $"{FirstName} {LastName}";
    public string Initial => FirstName.First().ToString();
    public string BirthDateFormatted => BirthDate.ToShortDateString();
}