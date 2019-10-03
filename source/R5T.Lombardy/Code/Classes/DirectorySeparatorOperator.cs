using System;

using R5T.Rugia;


namespace R5T.Lombardy
{
    public class DirectorySeparatorOperator : IDirectorySeparatorOperator
    {
        public char InvalidDirectorySeparatorChar => DirectorySeparator.InvalidChar;
        public char WindowsDirectorySeparatorChar => DirectorySeparator.WindowsChar;
        public char NonWindowsDirectorySeparatorChar => DirectorySeparator.NonWindowsChar;
        public char ExecutingMachineDefaultDirectorySeparatorChar => DirectorySeparator.ExecutingMachineDefaultChar;
        public char PlatformDefaultDirectorySeparatorChar => DirectorySeparator.PlatformDefaultChar;
        public char DefaultDirectorySeparatorChar
        {
            get
            {
                return DirectorySeparator.DefaultChar;
            }
            set
            {
                DirectorySeparator.DefaultChar = value;
            }
        }
        public char[] ValidDirectorySeparatorChars => DirectorySeparator.ValidDirectorySeparatorChars;

        public string InvalidDirectorySeparator => DirectorySeparator.Invalid;
        public string WindowsDirectorySeparator => DirectorySeparator.Windows;
        public string NonWindowsDirectorySeparator => DirectorySeparator.NonWindows;
        public string ExecutingMachineDefaultDirectorySeparator => DirectorySeparator.ExecutingMachineDefault;
        public string PlatformDefaultDirectorySeparator => DirectorySeparator.PlatformDefault;
        public string DefaultDirectorySeparator
        {
            get
            {
                return DirectorySeparator.Default;
            }
            set
            {
                DirectorySeparator.Default = value;
            }
        }
        public string[] ValidDirectorySeparators => DirectorySeparator.ValidDirectorySeparators;


        public void ResetDefaultDirectorySeparator()
        {
            DirectorySeparator.ResetDefault();
        }

        public char GetDirectorySeparatorCharForPlatform(Platform platform)
        {
            var output = DirectorySeparator.GetDirectorySeparatorCharForPlatform(platform);
            return output;
        }

        public string GetDirectorySeparatorForPlatform(Platform platform)
        {
            var output = DirectorySeparator.GetDirectorySeparatorForPlatform(platform);
            return output;
        }

        public Platform GetPlatformForDirectorySeparator(char directorySeparator)
        {
            var output = DirectorySeparator.GetPlatformForDirectorySeparator(directorySeparator);
            return output;
        }

        public Platform GetPlatformForDirectorySeparator(string directorySeparator)
        {
            var output = DirectorySeparator.GetPlatformForDirectorySeparator(directorySeparator);
            return output;
        }

        public char GetDirectorySeparatorStringToCharUnchecked(string directorySeparator)
        {
            var output = DirectorySeparator.StringToCharUnchecked(directorySeparator);
            return output;
        }

        public char GetDirectorySeparatorStringToChar(string directorySeparator)
        {
            var output = DirectorySeparator.StringToChar(directorySeparator);
            return output;
        }

        public string GetDirectorySeparatorCharToStringUnchecked(char directorySeparatorChar)
        {
            var output = DirectorySeparator.CharToStringUnchecked(directorySeparatorChar);
            return output;
        }

        public string GetDirectorySeparatorCharToString(char directorySeparatorChar)
        {
            var output = DirectorySeparator.CharToString(directorySeparatorChar);
            return output;
        }

        public bool IsInvalid(char directorySeparator)
        {
            var output = DirectorySeparator.IsInvalid(directorySeparator);
            return output;
        }

        public bool IsValid(char directorySeparator)
        {
            var output = DirectorySeparator.IsValid(directorySeparator);
            return output;
        }

        public void Validate(char directorySeparator)
        {
            DirectorySeparator.Validate(directorySeparator);
        }

        public void Validate(char directorySeparator, string argumentName)
        {
            DirectorySeparator.Validate(directorySeparator, argumentName);
        }

        public void ValidateWindows(char directorySeparator)
        {
            DirectorySeparator.ValidateWindows(directorySeparator);
        }

        public void ValidateWindows(char directorySeparator, string argumentName)
        {
            DirectorySeparator.ValidateWindows(directorySeparator, argumentName);
        }

        public void ValidateNonWindows(char directorySeparator)
        {
            DirectorySeparator.ValidateNonWindows(directorySeparator);
        }

        public void ValidateNonWindows(char directorySeparator, string argumentName)
        {
            DirectorySeparator.ValidateNonWindows(directorySeparator, argumentName);
        }

        public bool IsDirectorySeparator(char possibleDirectorySeparator)
        {
            var output = DirectorySeparator.IsDirectorySeparator(possibleDirectorySeparator);
            return output;
        }

        public bool IsDirectorySeparator(char value, char possibleDirectorySeparator)
        {
            var output = DirectorySeparator.IsDirectorySeparator(value, possibleDirectorySeparator);
            return output;
        }

        public bool IsWindowsDirectorySeparator(char directorySeparator)
        {
            var output = DirectorySeparator.IsWindowsDirectorySeparator(directorySeparator);
            return output;
        }

        public bool IsNonWindowsDirectorySeparator(char directorySeparator)
        {
            var output = DirectorySeparator.IsNonWindowsDirectorySeparator(directorySeparator);
            return output;
        }



        public bool IsInvalid(string directorySeparator)
        {
            var output = DirectorySeparator.IsInvalid(directorySeparator);
            return output;
        }

        public bool IsValid(string directorySeparator)
        {
            var output = DirectorySeparator.IsValid(directorySeparator);
            return output;
        }

        public void Validate(string directorySeparator)
        {
            DirectorySeparator.Validate(directorySeparator);
        }

        public void Validate(string directorySeparator, string argumentName)
        {
            DirectorySeparator.Validate(directorySeparator, argumentName);
        }

        public void ValidateWindows(string directorySeparator)
        {
            DirectorySeparator.ValidateWindows(directorySeparator);
        }

        public void ValidateWindows(string directorySeparator, string argumentName)
        {
            DirectorySeparator.ValidateWindows(directorySeparator, argumentName);
        }

        public void ValidateNonWindows(string directorySeparator)
        {
            DirectorySeparator.ValidateNonWindows(directorySeparator);
        }

        public void ValidateNonWindows(string directorySeparator, string argumentName)
        {
            DirectorySeparator.ValidateNonWindows(directorySeparator, argumentName);
        }

        public bool IsDirectorySeparator(string possibleDirectorySeparator)
        {
            var output = DirectorySeparator.IsDirectorySeparator(possibleDirectorySeparator);
            return output;
        }

        public bool IsDirectorySeparator(string value, string possibleDirectorySeparator)
        {
            var output = DirectorySeparator.IsDirectorySeparator(value, possibleDirectorySeparator);
            return output;
        }

        public bool IsWindowsDirectorySeparator(string directorySeparator)
        {
            var output = DirectorySeparator.IsWindowsDirectorySeparator(directorySeparator);
            return output;
        }

        public bool IsNonWindowsDirectorySeparator(string directorySeparator)
        {
            var output = DirectorySeparator.IsNonWindowsDirectorySeparator(directorySeparator);
            return output;
        }

        public char GetAlternateDirectorySeparatorUnchecked(char directorySeparator)
        {
            var output = DirectorySeparator.GetAlternateDirectorySeparatorUnchecked(directorySeparator);
            return output;
        }

        public char GetAlternateDirectorySeparator(char directorySeparator)
        {
            var output = DirectorySeparator.GetAlternateDirectorySeparator(directorySeparator);
            return output;
        }

        public string GetAlternateDirectorySeparatorUnchecked(string directorySeparator)
        {
            var output = DirectorySeparator.GetAlternateDirectorySeparatorUnchecked(directorySeparator);
            return output;
        }

        public string GetAlternateDirectorySeparator(string directorySeparator)
        {
            var output = DirectorySeparator.GetAlternateDirectorySeparator(directorySeparator);
            return output;
        }

        public bool TryDetectDirectorySeparator(string pathSegment, out string directorySeparator, string defaultDirectorySeparator)
        {
            var output = DirectorySeparator.TryDetectDirectorySeparator(pathSegment, out directorySeparator, defaultDirectorySeparator);
            return output;
        }

        public bool TryDetectDirectorySeparatorOrInvalid(string pathSegment, out string directorySeparator)
        {
            var output = DirectorySeparator.TryDetectDirectorySeparatorOrInvalid(pathSegment, out directorySeparator);
            return output;
        }

        public bool TryDetectDirectorySeparatorOrDefault(string pathSegment, out string directorySeparator)
        {
            var output = DirectorySeparator.TryDetectDirectorySeparatorOrDefault(pathSegment, out directorySeparator);
            return output;
        }

        public bool TryDetectDirectorySeparator(string pathSegment, out string directorySeparator)
        {
            var output = DirectorySeparator.TryDetectDirectorySeparator(pathSegment, out directorySeparator);
            return output;
        }

        public string DetectDirectorySeparator(string pathSegment)
        {
            var output = DirectorySeparator.DetectDirectorySeparator(pathSegment);
            return output;
        }

        public string DetectDirectorySeparatorOrDefault(string pathSegment)
        {
            var output = DirectorySeparator.DetectDirectorySeparatorOrDefault(pathSegment);
            return output;
        }

        public string DetectDirectorySeparatorOrDefault(string pathSegment, string defaultDirectorySeparator)
        {
            var output = DirectorySeparator.DetectDirectorySeparatorOrDefault(pathSegment, defaultDirectorySeparator);
            return output;
        }

        public string DetectDirectorySeparatorOrWindows(string pathSegment)
        {
            var output = DirectorySeparator.DetectDirectorySeparatorOrWindows(pathSegment);
            return output;
        }

        public string DetectDirectorySeparatorOrNonWindows(string pathSegment)
        {
            var output = DirectorySeparator.DetectDirectorySeparatorOrNonWindows(pathSegment);
            return output;
        }

        public string DetectDirectorySeparatorOrInvalid(string pathSegment)
        {
            var output = DirectorySeparator.DetectDirectorySeparatorOrInvalid(pathSegment);
            return output;
        }

        public bool IsDirectorySeparatorDetected(string pathSegment)
        {
            var output = DirectorySeparator.IsDirectorySeparatorDetected(pathSegment);
            return output;
        }

        public bool IsDirectorySeparatorDetectedUnchecked(string pathSegment, string directorySeparator)
        {
            var output = DirectorySeparator.IsDirectorySeparatorDetectedUnchecked(pathSegment, directorySeparator);
            return output;
        }

        public bool IsDirectorySeparatorDetected(string pathSegment, string directorySeparator)
        {
            var output = DirectorySeparator.IsDirectorySeparatorDetected(pathSegment, directorySeparator);
            return output;
        }

        public bool IsWindowsDirectorySeparatorDetected(string pathSegment)
        {
            var output = DirectorySeparator.IsWindowsDirectorySeparatorDetected(pathSegment);
            return output;
        }

        public bool IsWindowsDirectorySeparatorDetectedAssumeWindows(string pathSegment)
        {
            var output = DirectorySeparator.IsWindowsDirectorySeparatorDetectedAssumeWindows(pathSegment);
            return output;
        }

        public bool IsNonWindowsDirectorySeparatorDetected(string pathSegment)
        {
            var output = DirectorySeparator.IsNonWindowsDirectorySeparatorDetected(pathSegment);
            return output;
        }

        public bool IsNonWindowsDirectorySeparatorDetectedAssumeNonWindows(string pathSegment)
        {
            var output = DirectorySeparator.IsNonWindowsDirectorySeparatorDetectedAssumeNonWindows(pathSegment);
            return output;
        }

        public bool IsMixedDirectorySeparatorsDetected(string pathSegment)
        {
            var output = DirectorySeparator.IsMixedDirectorySeparatorsDetected(pathSegment);
            return output;
        }

        public bool ContainsDirectorySeparator(string pathSegment)
        {
            var output = DirectorySeparator.ContainsDirectorySeparator(pathSegment);
            return output;
        }

        public bool ContainsDirectorySeparatorUnchecked(string pathSegment, string directorySeparator)
        {
            var output = DirectorySeparator.ContainsDirectorySeparatorUnchecked(pathSegment, directorySeparator);
            return output;
        }

        public bool ContainsDirectorySeparator(string pathSegment, string directorySeparator)
        {
            var output = DirectorySeparator.ContainsDirectorySeparator(pathSegment, directorySeparator);
            return output;
        }

        public bool ContainsWindowsDirectorySeparator(string pathSegment)
        {
            var output = DirectorySeparator.ContainsWindowsDirectorySeparator(pathSegment);
            return output;
        }

        public bool ContainsNonWindowsDirectorySeparator(string pathSegment)
        {
            var output = DirectorySeparator.ContainsNonWindowsDirectorySeparator(pathSegment);
            return output;
        }

        public bool ContainsMixedDirectorySeparator(string pathSegment)
        {
            var output = DirectorySeparator.ContainsMixedDirectorySeparator(pathSegment);
            return output;
        }

        public bool TryGetDominantDirectorySeparator(string pathSegment, out string dominantDirectorySeparator)
        {
            var output = DirectorySeparator.TryGetDominantDirectorySeparator(pathSegment, out dominantDirectorySeparator);
            return output;
        }

        public string GetDominantDirectorySeparator(string pathSegment)
        {
            var output = DirectorySeparator.GetDominantDirectorySeparator(pathSegment);
            return output;
        }

        public bool TryGetDominantDirectorySeparatorPlatform(string pathSegment, out Platform platform)
        {
            var output = DirectorySeparator.TryGetDominantDirectorySeparatorPlatform(pathSegment, out platform);
            return output;
        }

        public Platform GetDominantDirectorySeparatorPlatform(string pathSegment)
        {
            var output = DirectorySeparator.GetDominantDirectorySeparatorPlatform(pathSegment);
            return output;
        }


        #region Exceptions

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

        public string GetWindowsDirectorySeparatorExpectedExceptionMessage(string notWindowsDirectorySeparator)
        {
            var message = DirectorySeparator.GetWindowsDirectorySeparatorExpectedExceptionMessage(notWindowsDirectorySeparator);
            return message;
        }

        public Exception GetWindowsDirectorySeparatorExpectedException(string notWindowsDirectorySeparator)
        {
            var exception = DirectorySeparator.GetWindowsDirectorySeparatorExpectedException(notWindowsDirectorySeparator);
            return exception;
        }

        public ArgumentException GetWindowsDirectorySeparatorExpectedArgumentException(string found, string parameterName)
        {
            var exception = DirectorySeparator.GetWindowsDirectorySeparatorExpectedArgumentException(found, parameterName);
            return exception;
        }

        public string GetNonWindowsDirectorySeparatorExpectedExceptionMessage(string notNonWindowsDirectorySeparator)
        {
            var message = DirectorySeparator.GetNonWindowsDirectorySeparatorExpectedExceptionMessage(notNonWindowsDirectorySeparator);
            return message;
        }

        public Exception GetNonWindowsDirectorySeparatorExpectedException(string notNonWindowsDirectorySeparator)
        {
            var exception = DirectorySeparator.GetNonWindowsDirectorySeparatorExpectedException(notNonWindowsDirectorySeparator);
            return exception;
        }

        public ArgumentException GetNonWindowsDirectorySeparatorExpectedArgumentException(string found, string parameterName)
        {
            var exception = DirectorySeparator.GetNonWindowsDirectorySeparatorExpectedArgumentException(found, parameterName);
            return exception;
        }

        public string GetUnableToDetectDirectorySeparatorExceptionMessage(string pathSegment)
        {
            var message = DirectorySeparator.GetUnableToDetectDirectorySeparatorExceptionMessage(pathSegment);
            return message;
        }

        public Exception GetUnableToDetectDirectorySeparatorException(string pathSegment)
        {
            var exception = DirectorySeparator.GetUnableToDetectDirectorySeparatorException(pathSegment);
            return exception;
        }

        public ArgumentException GetUnableToDetectDirectorySeparatorArgumentException(string pathSegment, string parameterName)
        {
            var exception = DirectorySeparator.GetUnableToDetectDirectorySeparatorArgumentException(pathSegment, parameterName);
            return exception;
        }


        #endregion
    }
}
