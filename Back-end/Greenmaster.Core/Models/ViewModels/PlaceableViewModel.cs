using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Greenmaster.Core.Helpers.Attributes;
using Greenmaster.Core.Models.Measurements;

namespace Greenmaster.Core.Models.ViewModels;

public class PlaceableViewModel
{
    //Identity
    [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
    public Guid Id { get; set; }
    
    //Auditable
    [DataType(DataType.Date)]
    public DateTime? Created { get; set; }
    [DataType(DataType.Date)]
    public DateTime? Modified { get; set; }
    
    //Main
    public string Name { get; set; }
    [AtLeastOneRequired(new[] { $"{nameof(LocationId)}", $"{nameof(Location)}" },
        ErrorMessage = $"At least one of {nameof(LocationId)} or {nameof(Location)} is required.")]
    public int LocationId { get; set; }
    
    [AtLeastOneRequired(new[] { $"{nameof(LocationId)}", $"{nameof(Location)}" },
        ErrorMessage = $"At least one of {nameof(LocationId)} or {nameof(Location)} is required.")]
    public Point? Location { get; set; }
    
    [AtLeastOneRequired(new[] { $"{nameof(DimensionsId)}", $"{nameof(Dimensions)}" },
        ErrorMessage = $"At least one of {nameof(DimensionsId)} or {nameof(Dimensions)} is required.")]
    public int DimensionsId { get; set; }
    [AtLeastOneRequired(new[] { $"{nameof(DimensionsId)}", $"{nameof(Dimensions)}" },
        ErrorMessage = $"At least one of {nameof(DimensionsId)} or {nameof(Dimensions)} is required.")]
    public Dimensions? Dimensions { get; set; }
    
    [AtLeastOneRequired(new[] { $"{nameof(TypeId)}", $"{nameof(Type)}" },
        ErrorMessage = $"At least one of {nameof(TypeId)} or {nameof(Type)} is required.")]
    public int? TypeId { get; set; }
    
    [AtLeastOneRequired(new[] { $"{nameof(TypeId)}", $"{nameof(Type)}" },
        ErrorMessage = $"At least one of {nameof(TypeId)} or {nameof(Type)} is required.")]
    public ObjectType? Type { get; set; }
    
    [AtLeastOneRequired(new[] { $"{nameof(RenderingId)}", $"{nameof(Rendering)}" },
        ErrorMessage = $"At least one of {nameof(RenderingId)} or {nameof(Rendering)} is required.")]
    public int? RenderingId { get; set; }
    
    [AtLeastOneRequired(new[] { $"{nameof(RenderingId)}", $"{nameof(Rendering)}" },
        ErrorMessage = $"At least one of {nameof(RenderingId)} or {nameof(Rendering)} is required.")]
    public RenderingViewModel? Rendering { get; set; }
    
    //Plant-specific properties
    public Specie? Specie { get; set; }
}