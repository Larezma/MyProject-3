using System;
using System.Collections.Generic;

namespace RestAPI.Models;

public partial class ГрафикРаботы
{
    public int КодДисциплины { get; set; }

    public int КодЭкзаменатора { get; set; }

    public virtual Экзамены КодДисциплиныNavigation { get; set; } = null!;

    public virtual Экзаменаторы КодЭкзаменатораNavigation { get; set; } = null!;

    public virtual ICollection<Расписание> Расписаниеs { get; set; } = new List<Расписание>();
}
