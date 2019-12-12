using System.Collections.Generic;

namespace Entities.Shared
{
    public class Language
    {
        public Language()
        {
            DriverLanguages = new HashSet<DriverLanguage>();
            GuideLanguages = new HashSet<GuideLanguage>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<DriverLanguage> DriverLanguages { get; set; }
        public virtual ICollection<GuideLanguage> GuideLanguages { get; set; }
    }

    public class DriverLanguage
    {
        public int Id { get; set; }

        public int DriverId { get; set; }

        public int LanguageId { get; set; }

        public virtual Driver Driver { get; set; }

        public virtual Language Language { get; set; }
    }
    public class GuideLanguage
    {
        public int Id { get; set; }

        public int GuideId { get; set; }

        public int LanguageId { get; set; }

        public virtual Guide Guide { get; set; }

        public virtual Language Language { get; set; }
    }

}
