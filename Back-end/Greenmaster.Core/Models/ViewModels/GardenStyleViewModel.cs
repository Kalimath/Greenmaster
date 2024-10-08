﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using StaticData.Coloring;
using StaticData.Measuring;
using StaticData.Taxonomy;

namespace Greenmaster.Core.Models.ViewModels;

public class GardenStyleViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    [DataType(DataType.MultilineText)]
    public string Description { get; set; }
    public string[] Concepts { get; set; }
    public string[] Shapes { get; set; }
    public Color[] Colors { get; set; }
    
    
    [DisplayName(displayName: "Large garden only")]
    public bool RequiresLargeGarden { get; set; }
    [DisplayName(displayName: "All season interest")]
    public bool AllSeasonInterest { get; set; }
    
    [DisplayName(displayName: "Divide garden into rooms")]
    public bool DivideIntoRooms { get; set; }
    
    public Size PathSize { get; set; }

    [DisplayName(displayName: "Material types")]
    public int[] MaterialTypeIds { get; set; }
    public MaterialType[]? Materials { get; set; }
    [DisplayName(displayName: "Suitable plant genera (species groups)")]
    public PlantGenus[]? SuitablePlantGenera { get; set; }

    //TODO: add media 
}