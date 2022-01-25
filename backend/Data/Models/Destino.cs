﻿using System.ComponentModel.DataAnnotations;
using BoleteriaOnline.Web.Attributes;
using Humanizer;
using Microsoft.EntityFrameworkCore;

namespace BoleteriaOnline.Web.Data.Models;
[Index(nameof(Nombre), IsUnique = true)]
[HumanDescription("destino", GrammaticalGender.Masculine)]
public class Destino : Auditory
{
    public int Id { get; set; }
    [StringLength(100)]
    public string Nombre { get; set; }
}
