﻿namespace EbaNews.Core.Filters
{
    public class GetNewsFilter
    {
        public int Page { get; set; }

        public int PageSize { get; set; }

        public int? LanguageId { get; set; }

        public string SearchPhrase { get; set; }
    }
}