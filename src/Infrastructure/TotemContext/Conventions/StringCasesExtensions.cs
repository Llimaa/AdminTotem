namespace Infrastructure.Conventions
{
    public static class StringCasesExtensions
    {
        public static string CamelToSnakeCase(this string value)
        {
            return string.Concat(
                value.Select((x, i) => i > 0 && char.IsUpper(x) ? "_" + x.ToString().ToLower() : x.ToString().ToLower())
            );
        }
    }
}