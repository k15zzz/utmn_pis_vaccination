using PIS_Vaccination_PI_21_03.Source.Models.DTOModels;
using PIS_Vaccination_PI_21_03.Source.Models.ViewModels;
using PIS_Vaccination_PI_21_03.Source.Repository;

namespace PIS_Vaccination_PI_21_03.Source.Services.Statistic;

public class StatisticService
{
    public static List<ReportViewModel> MakeReport(DateTime dateStart, DateTime dateFinish, List<int> town)
    {
        var data = StatisticRepository.GetDateStatistic(
            DateTime.SpecifyKind(dateStart, DateTimeKind.Utc), 
            DateTime.SpecifyKind(dateFinish, DateTimeKind.Utc),
            town);

        var report = CreateReport(data);

        return report;
    }
    
    public static List<ReportViewModel> CreateReport(List<VaccinationDTO> report)
    {
        var dataGroupByTown = GroupingByTown(report);

        var rep = new ReportMaker();

        foreach (var town in dataGroupByTown)
        {
            var nameTown = town.Value[0].TownName;
            var countTown = CalculateCount(town.Value);
            var costTown = CalculateCost(town.Value);

            rep.AddTown(nameTown, countTown, costTown, town.Key);
        }

        return rep.ListReportViewModels();
    }

    private static int CalculateCount(List<VaccinationDTO> items)
    {
        return items.Count;
    }

    private static double CalculateCost(List<VaccinationDTO> items )
    {
        var cost = 0;

        foreach (var item in items) cost += item.Price;

        return cost;
    }

    private static Dictionary<int, List<VaccinationDTO>> GroupingByTown(List<VaccinationDTO> data)
    {
        var result = new Dictionary<int, List<VaccinationDTO>>{};
        
        foreach (var value in data)
        {
            if (!result.ContainsKey(value.FKTown)) result.Add(value.FKTown, new List<VaccinationDTO>());
            result[value.FKTown].Add(value);
        }

        return result;
    }
    
}