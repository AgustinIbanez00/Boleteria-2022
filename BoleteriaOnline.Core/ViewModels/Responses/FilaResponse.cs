﻿using BoleteriaOnline.Core.Data.Enums;

namespace BoleteriaOnline.Web.ViewModels.Responses;
public class FilaResponse
{
    public int Id { get; set; }
    public List<CeldaResponse> Cells { get; set; }
    public Planta Planta { get; set; }

}
