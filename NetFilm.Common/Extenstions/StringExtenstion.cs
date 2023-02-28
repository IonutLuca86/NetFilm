
namespace NetFilm.Common.Extenstions
{
    public static class StringExtenstion
    {
        public static string Truncate(this string input, int n)
        { 
        if(string.IsNullOrEmpty(input)) return string.Empty;
        else if (input.Length <= n)
                return input;
        else return $"{input.Substring(0, n)} ...";
        }

    }
}
