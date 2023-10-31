using System.Text.RegularExpressions;

namespace WebsiteGeneratorApi.WebApi.Helpers
{
    public static class KeyValidatorHelper
    {
        public static bool IsValid(string websiteBlocksKey)
        {
            var pattern = @"^\S*$";
            return !string.IsNullOrEmpty(websiteBlocksKey) && Regex.IsMatch(websiteBlocksKey, pattern, RegexOptions.IgnoreCase);
        }
    }
}
