using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraffLifeWeb.Helpers
{
    public static class Helpers
    {
        public static bool IsAlphaNumeric(string str) // allows UTF characters
        {
            return str.All(char.IsLetterOrDigit);
        }

        public static bool IsValidId(string str)
        {
            return str.All((c) => IsAlphaNumeric(c.ToString()) || c == '-');
        }

        public static string GetRank(int level)
        {
            string rank = "Nobody";
            /// Allow custom rank at 158?
            ///
            if (level >= 152)
            {
                rank = "OG Graff God";
            }
            if (level >= 146)
            {
                rank = "Graff God";
            }
            else if (level >= 130)
            {
                rank = "Legendary Graff King";
            }
            else if (level >= 124)
            {
                rank = "Graff King";
            }
            else if (level >= 112)
            {
                rank = "Graff Legend";
            }
            else if (level >= 100)
            {
                rank = "All City";
            }
            else if (level >= 69)
            {
                rank = "Famous";
            }
            else if (level >= 55)
            {
                rank = "Well Known";
            }
            else if (level >= 45)
            {
                rank = "Known";
            }
            else if (level >= 30)
            {
                rank = "Getting Up";
            }
            else if (level >= 16)
            {
                rank = "Graff Writer";
            }
            else if (level >= 8)
            {
                rank = "Graff Disciple";
            }
            else if (level >= 3)
            {
                rank = "Somebody";
            }
            else if (level >= 0)
            {
                rank = "Toy";
            }
            else if (level < 0)
            {
                rank = "Toy";///////////////THAT DOESN'T MAKE SENSE... level can't be <0, but we should take into account fame here?...negative fame doesn't make sense either... so unless we implement respect, then it won't work
            }
            return rank;
        }

    }


}
