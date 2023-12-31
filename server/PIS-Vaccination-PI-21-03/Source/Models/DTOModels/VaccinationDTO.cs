namespace PIS_Vaccination_PI_21_03.Source.Models.DTOModels;

public class VaccinationDTO
{
    public int Id { get; set; }
    public string Type { get; set; }
    public DateTime Date { get; set; }
    public string NumOfSeries { get; set; }
    public DateTime DateOfExpire { get; set; }
    public string PositionOfDoc { get; set; }
    public string TownName { get; set; }
    public int Price { get; set; }
    public int FKTown { get; set; } = 0;
}