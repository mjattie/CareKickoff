using System.Diagnostics;

namespace ClientDataViewer.Data.Client;

public record Client(string FirstName, string LastName, DateTime BirthDate, string Gender, string NativeId)
{
    public string FullName => $"{FirstName} {LastName}";
    public string Initial => FirstName.First().ToString();
    public string BirthDateFormatted => BirthDate.ToShortDateString();

    public GenderEnum GenderEnum => Gender switch
    {
        "male" => GenderEnum.Male,
        "female" => GenderEnum.Female,
        _ => GenderEnum.Other
    };
}

public enum GenderEnum
{
    Male,
    Female,
    Other
}