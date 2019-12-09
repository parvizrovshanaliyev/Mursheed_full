using System;
using System.Collections.Generic;
using System.Text;

namespace ERP.Mursheed.Entities.Shared
{
    public class Guide
    {
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
