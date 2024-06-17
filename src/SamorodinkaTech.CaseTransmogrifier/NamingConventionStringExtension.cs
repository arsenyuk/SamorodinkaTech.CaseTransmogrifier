namespace SamorodinkaTech.CaseTransmogrifier
{
    /// <summary>
    /// Extension methods for implement naming convention
    /// </summary>
    public static class NamingConventionStringExtension
    {
        /// <summary>
        /// Camel Case (camelCase)
        /// </summary>
        /// <remarks>
        /// for later implementation
        /// https://stackoverflow.com/questions/15526107/acronyms-in-camelcase
        /// </remarks>
        public static string CamelCase(this string val)
        {
            if (string.IsNullOrEmpty(val))
                return string.Empty;

            return val.ParseCase().CamelCase();
        }

        /// <summary>
        /// Camel Case (camelCase)
        /// </summary>
        public static string CamelCase(this string[] val)
        {
            if (val == null)
                return string.Empty;

            if (val.Length == 0)
                return string.Empty;

            return val.ApplyCamelCase().JoinToFontCase();
        }

        /// <summary>
        /// Pascal Case (PascalCase)
        /// </summary>
        public static string PascalCase(this string val)
        {
            if (string.IsNullOrEmpty(val))
                return string.Empty;

            return val.ParseCase().PascalCase();
        }

        /// <summary>
        /// Pascal Case (PascalCase)
        /// </summary>
        public static string PascalCase(this string[] val)
        {
            if (val == null)
                return string.Empty;

            if (val.Length == 0)
                return string.Empty;

            return val.ApplyTitleCase().JoinToFontCase();
        }

        /// <summary>
        /// Snake Case (snake_case)
        /// </summary>
        public static string SnakeCase(this string val)
        {
            if (string.IsNullOrEmpty(val))
                return string.Empty;

            return val.ParseCase().SnakeCase();
        }

        /// <summary>
        /// Snake Case (snake_case)
        /// </summary>
        public static string SnakeCase(this string[] val)
        {
            if (val == null)
                return string.Empty;

            if (val.Length == 0)
                return string.Empty;

            return val.ApplyLowerCase().JoinToSnake();
        }

        /// <summary>
        /// Kebab Case (kebab-case)
        /// </summary>
        public static string KebabCase(this string val)
        {
            if (string.IsNullOrEmpty(val))
                return string.Empty;

            return val.ParseCase().KebabCase();
        }

        /// <summary>
        /// Kebab Case (kebab-case)
        /// </summary>
        public static string KebabCase(this string[] val)
        {
            if (val == null)
                return string.Empty;

            if (val.Length == 0)
                return string.Empty;

            return val.ApplyLowerCase().JoinToKebab();
        }
    }
}