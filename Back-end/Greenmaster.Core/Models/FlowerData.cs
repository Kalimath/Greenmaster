﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace Greenmaster.Core.Models;

public class FlowerData
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int FlowerDataId { get; set; }
    public Color Color { get; set; } = Color.Green;
    public string FlowerPeriod { get; set; }
    public bool IsFragrant { get; set; } = false;
    public bool AttractsPollinators { get; set; } = false;
}