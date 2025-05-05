using System;
using System.Collections.Generic;

namespace CuratorJournal.DataAccess.Models;

public partial class Translation
{
    public string LanguageCode { get; set; } = null!;

    public string KeyName { get; set; } = null!;

    public string Translation1 { get; set; } = null!;

    public virtual TranslationKey KeyNameNavigation { get; set; } = null!;

    public virtual Language LanguageCodeNavigation { get; set; } = null!;
}
