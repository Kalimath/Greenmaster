﻿using System.ComponentModel.DataAnnotations.Schema;

namespace eu.greenmaster.Models;

public class Point
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public double X { get; set; }
    public double Y { get; set; }
    public double Z { get; set; }
}