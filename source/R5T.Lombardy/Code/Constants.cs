using System;


namespace R5T.Lombardy
{
    public static class Constants
    {
        /// <summary>
        /// Begins with either:
        /// * The Windows directory separator.
        /// * The non-Windows directory separator.
        /// * A volume name, the volume separator, and the Windows directory separator (because only Windows paths use the volume).
        /// </summary>
        public static readonly string RootIndicatedPathRegexPattern = $@"^\{DirectorySeparator.Windows}|^{DirectorySeparator.NonWindows}|^.*{VolumeSeparator.Default}\{DirectorySeparator.Windows}";

    }
}
