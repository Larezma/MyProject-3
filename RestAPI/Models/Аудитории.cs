using System;
using System.Collections.Generic;

namespace RestAPI.Models;

public partial class Аудитории
{
    public string НомерАудитории { get; set; } = null!;

    public string? ТипАудитории { get; set; }

    public int? КоличествоПосадочныхМест { get; set; }

    public virtual ICollection<Расписание> Расписаниеs { get; set; } = new List<Расписание>();
}
