using System.ComponentModel.DataAnnotations.Schema;

namespace PIS_Vaccination_PI_21_03.Source.Models;

[Table("permission")]
public class PermissionEntitiesModel
{
    [Column("id")]
    public int Id { get; set; }
    [Column("name")]
    public string Name { get; set; }
    public List<PermissionRoleEntitiesModel> PermissionRoles { get; set; }
}