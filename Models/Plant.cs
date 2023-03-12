using System.ComponentModel.DataAnnotations.Schema;
using Greenmaster_ASP.Models.Static.Object.Organic;

namespace Greenmaster_ASP.Models;

[Table("Plant")]
public class Plant : Placeable
{
    public int SpecieId { get; set; }
    public virtual Specie Specie { get; set; }
}