using System;
using System.Collections.Generic;

namespace RestAPI.Models;

public partial class Экзамены
{
    public int КодДисциплины { get; set; }

    public string? НазваниеДисциплины { get; set; }

    public DateOnly? ДатаИВремяПроведения { get; set; }

    public virtual ICollection<ГрафикРаботы> ГрафикРаботыs { get; set; } = new List<ГрафикРаботы>();
}
