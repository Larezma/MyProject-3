using System;
using System.Collections.Generic;

namespace RestAPI.Models;

public partial class Расписание
{
    public int КодДисциплины { get; set; }

    public int КодЭкзаменатора { get; set; }

    public string НомерГруппы { get; set; } = null!;

    public string НомерАудитории { get; set; } = null!;

    public virtual ГрафикРаботы ГрафикРаботы { get; set; } = null!;

    public virtual Аудитории НомерАудиторииNavigation { get; set; } = null!;

    public virtual Группы НомерГруппыNavigation { get; set; } = null!;
}
