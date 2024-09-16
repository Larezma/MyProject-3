using System;
using System.Collections.Generic;

namespace RestAPI.Models;

public partial class Экзаменаторы
{
    public int КодЭкзаменатора { get; set; }

    public string? Фамилия { get; set; }

    public string? Имя { get; set; }

    public string? Отчество { get; set; }

    public int? НомерКафедры { get; set; }

    public string? Должность { get; set; }

    public virtual ICollection<ГрафикРаботы> ГрафикРаботыs { get; set; } = new List<ГрафикРаботы>();
}
