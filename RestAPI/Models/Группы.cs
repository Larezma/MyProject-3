using System;
using System.Collections.Generic;

namespace RestAPI.Models;

public partial class Группы
{
    public string НомерГруппы { get; set; } = null!;

    public string? СтаростаГруппы { get; set; }

    public string? Специальность { get; set; }

    public int? КоличествоСтудентов { get; set; }

    public string? Факультет { get; set; }

    public int? НомерКафедры { get; set; }

    public virtual ICollection<Расписание> Расписаниеs { get; set; } = new List<Расписание>();
}
