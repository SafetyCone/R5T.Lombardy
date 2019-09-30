using System;


namespace R5T.Lombardy
{
    public class DirectorySeparatorOperator : IDirectorySeparatorOperator
    {
        public char WindowsDirectorySeparatorChar => DirectorySeparator.WindowsChar;
        public string WindowsDirectorySeparator => DirectorySeparator.Windows;
        public char NonWindowsDirectorySeparatorChar => DirectorySeparator.NonWindowsChar;
        public string NonWindowsDirectorySeparator => DirectorySeparator.NonWindows;
        public char PlatformDefaultDirectorySeparatorChar => DirectorySeparator.StringToCharUnchecked(DirectorySeparator.PlatformDefault);
        public string PlatformDefaultDirectorySeparator => DirectorySeparator.PlatformDefault;
        public char DefaultDirectorySeparatorChar => DirectorySeparator.StringToCharUnchecked(DirectorySeparator.Default);
        public string DefaultDirectorySeparator => DirectorySeparator.Default;



        public char GetDirectorySeparatorStringToCharUnchecked(string directorySeparator)
        {
            var output = DirectorySeparator.StringToCharUnchecked(directorySeparator);
            return output;
        }

        public string GetDirectorySeparatorCharToStringUnchecked(char directorySeparatorChar)
        {
            var output = DirectorySeparator.CharToStringUnchecked(directorySeparatorChar);
            return output;
        }

        public bool IsDirectorySeparator(string possibleDirectorySeparator)
        {
            var output = possibleDirectorySeparator == DirectorySeparator.Windows
                || possibleDirectorySeparator == DirectorySeparator.NonWindows;

            return output;
        }

        public void ValidateDirectorySeparatorArgument(string possibleDirectorySeparator, string parameterName)
        {
            if (!DirectorySeparator.IsDirectorySeparator(possibleDirectorySeparator))
            {
                throw DirectorySeparator.GetInvalidDirectorySeparatorArgumentException(possibleDirectorySeparator, parameterName);
            }
        }


        public string GetInvalidDirectorySeparatorExceptionMessage(string invalidDirectorySeparator)
        {
            var message = DirectorySeparator.GetInvalidDirectorySeparatorExceptionMessage(invalidDirectorySeparator);
            return message;
        }

        public Exception GetInvalidDirectorySeparatorException(string invalidDirectorySeparator)
        {
            var exception = DirectorySeparator.GetInvalidDirectorySeparatorException(invalidDirectorySeparator);
            return exception;
        }

        public ArgumentException GetInvalidDirectorySeparatorArgumentException(string invalidDirectorySeparator, string parameterName)
        {
            var exception = DirectorySeparator.GetInvalidDirectorySeparatorArgumentException(invalidDirectorySeparator, parameterName);
            return exception;
        }
    }
}
