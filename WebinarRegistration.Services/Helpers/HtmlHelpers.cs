using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace WebinarRegistration.Services.Helpers
{
    public static class HtmlHelpers
    {
        public static string MaskPersonalData(string input)
        {
            var maskedData = new List<string>();
            var maskRegex = new Regex(@"\S+");
            foreach (var regexMatch in maskRegex.Matches(input))
            {
                var match = regexMatch.ToString();
                maskedData.Add(match.First() + new string('-', match.Length - 1));
            }
            return string.Join(" ", maskedData.ToArray());
        }
    }
}
