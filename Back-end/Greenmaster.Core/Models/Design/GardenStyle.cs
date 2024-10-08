﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using StaticData.Coloring;
using StaticData.Measuring;
using StaticData.Taxonomy;

namespace Greenmaster.Core.Models.Design;

public class GardenStyle
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string[] Concepts { get; set; }
    public string[] Shapes { get; set; }
    public Color[] Colors { get; set; }
    
    [DisplayName(displayName: "Large garden only")]
    public bool RequiresLargeGarden { get; set; }
    
    [DisplayName(displayName: "All seasons interest")]
    public bool AllSeasonInterest { get; set; }
    
    [DisplayName(displayName: "Divides garden into rooms")]
    public bool DivideIntoRooms { get; set; }
    
    public Size PathSize { get; set; }
    
    public virtual ICollection<MaterialType>? Materials { get; set; } = new HashSet<MaterialType>();
    public PlantGenus[] SuitablePlantGenera { get; set; } = Array.Empty<PlantGenus>();
    
    //TODO: add climateType
    //TODO: add budgetType,
    //TODO: add Purpose
    
    //public string ImageBase64 { get; set; } TODO: add visualisation image
}