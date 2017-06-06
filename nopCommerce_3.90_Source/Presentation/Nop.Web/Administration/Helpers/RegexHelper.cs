using System;
using System.Linq;
using System.Collections.Generic;

namespace Nop.Admin.Helpers
{
    public static class RegexHelper
    {
        public enum TRegex
        {
            Email = 1,
            Telephone,
            Currency,
            Number,
            OnlyLetter,
            Other
        }

        public static Dictionary<string, string> RegexList;

        public static Dictionary<string, string> GetRegexList()
        {
            return new Dictionary<string, string>() {     { "Mail", "blah" }
                                                        , { "Telephone","blah1.5" }
                                                        , { "Currency","blah2" }
                                                        , { "Number","blah3" }
                                                        , { "OnlyLetter","blah4" }
                                                        , { "Other","blah4" }
                                                    };
        }
    }
}