using System;

using R5T.Magyar;
using R5T.Rugia;


namespace R5T.Lombardy
{
    public static class DirectorySeparator
    {
        public const char InvalidChar = '\0';
        public const char WindowsChar = '\\';
        public const char NonWindowsChar = '/';
        public static char ExecutingMachineDefaultChar
        {
            get
            {
                var executingMachinePlatform = PlatformOperator.ExecutingMachinePlatform;

                var output = DirectorySeparator.GetDirectorySeparatorCharForPlatform(executingMachinePlatform);
                return output;
            }
        }
        public static char PlatformDefaultChar
        {
            get
            {
                var platform = PlatformOperator.Platform;

                var output = DirectorySeparator.GetDirectorySeparatorCharForPlatform(platform);
                return output;
            }
        }
        public static char DefaultChar
        {
            get
            {
                var @default = DirectorySeparator.Default;

                var output = DirectorySeparator.StringToCharUnchecked(@default);
                return output;
            }
            set
            {
                if (DirectorySeparator.IsDirectorySeparator(value))
                {
                    var stringValue = DirectorySeparator.CharToStringUnchecked(value);
                    DirectorySeparator.zDefault = stringValue;
                }
                else
                {
                    var stringValue = DirectorySeparator.CharToStringUnchecked(value);
                    var exception = DirectorySeparator.GetInvalidDirectorySeparatorException(DirectorySeparator.CharToStringUnchecked(value));
                    throw exception;
                }
            }
        }

        public const string Invalid = null;
        public const string Windows = @"\";
        public const string NonWindows = "/";
        public static string ExecutingMachineDefault
        {
            get
            {
                var executingMachinePlatform = PlatformOperator.ExecutingMachinePlatform;

                var output = DirectorySeparator.GetDirectorySeparatorForPlatform(executingMachinePlatform);
                return output;
            }
        }
        /// <summary>
        /// Provides the default directory separator for the current <see cref="PlatformOperator.Platform"/>.
        /// </summary>
        public static string PlatformDefault
        {
            get
            {
                var platform = PlatformOperator.Platform;

                var output = DirectorySeparator.GetDirectorySeparatorForPlatform(platform);
                return output;
            }
        }
        /// <summary>
        /// Default value allows indirection from platform default value.
        /// Use the string value to keep track of the default.
        /// </summary>
        private static string zDefault;
        /// <summary>
        /// Allows getting/setting the default directory separator.
        /// Provdes the <see cref="DirectorySeparator.PlatformDefault"/> value, unless explicitly set otherwise.
        /// </summary>
        public static string Default
        {
            get
            {
                // If the default value is unset, return the platform default. Else return the explicitly set value.
                if(DirectorySeparator.IsInvalid(DirectorySeparator.zDefault))
                {
                    return DirectorySeparator.PlatformDefault;
                }
                else
                {
                    return DirectorySeparator.zDefault;
                }
            }
            set
            {
                if (DirectorySeparator.IsDirectorySeparator(value))
                {
                    DirectorySeparator.zDefault = value;
                }
                else
                {
                    var exception = DirectorySeparator.GetInvalidDirectorySeparatorException(value);
                    throw exception;
                }
            }
        }


        static DirectorySeparator()
        {
            DirectorySeparator.ResetDefault();
        }

        /// <summary>
        /// Resets the default value so that the platform default value is used.
        /// </summary>
        private static void ResetDefault()
        {
            DirectorySeparator.zDefault = DirectorySeparator.Invalid;
        }

        public static char GetDirectorySeparatorCharForPlatform(Platform platform)
        {
            switch (platform)
            {
                case Platform.NonWindows:
                    return DirectorySeparator.NonWindowsChar;

                case Platform.Windows:
                    return DirectorySeparator.WindowsChar;

                default:
                    var message = EnumHelper.UnexpectedEnumerationValueMessage(platform);
                    throw new Exception(message);
            }
        }

        public static string GetDirectorySeparatorForPlatform(Platform platform)
        {
            switch(platform)
            {
                case Platform.NonWindows:
                    return DirectorySeparator.NonWindows;

                case Platform.Windows:
                    return DirectorySeparator.Windows;

                default:
                    var message = EnumHelper.UnexpectedEnumerationValueMessage(platform);
                    throw new Exception(message);
            }
        }

        public static Platform GetPlatformForDirectorySeparator(char directorySeparator)
        {
            DirectorySeparator.Validate(directorySeparator);

            switch(directorySeparator)
            {
                case DirectorySeparator.NonWindowsChar:
                    return Platform.NonWindows;

                case DirectorySeparator.WindowsChar:
                    return Platform.Windows;

                default:
                    var @string = DirectorySeparator.CharToString(directorySeparator);

                    var exception = DirectorySeparator.GetInvalidDirectorySeparatorArgumentException(@string, nameof(directorySeparator));
                    throw exception;
            }
        }

        public static Platform GetPlatformForDirectorySeparator(string directorySeparator)
        {
            DirectorySeparator.Validate(directorySeparator);

            switch(directorySeparator)
            {
                case DirectorySeparator.NonWindows:
                    return Platform.NonWindows;

                case DirectorySeparator.Windows:
                    return Platform.Windows;

                default:
                    var exception = DirectorySeparator.GetInvalidDirectorySeparatorArgumentException(directorySeparator, nameof(directorySeparator));
                    throw exception;
            }
        }

        public static char StringToCharUnchecked(string directorySeparator)
        {
            var output = directorySeparator[0];
            return output;
        }

        public static char StringToChar(string directorySeparator)
        {
            DirectorySeparator.Validate(directorySeparator);

            var output = DirectorySeparator.StringToCharUnchecked(directorySeparator);
            return output;
        }

        public static string CharToStringUnchecked(char directorySeparatorChar)
        {
            var output = directorySeparatorChar.ToString();
            return output;
        }

        public static string CharToString(char directorySeparatorChar)
        {
            DirectorySeparator.Validate(directorySeparatorChar);

            var output = DirectorySeparator.CharToStringUnchecked(directorySeparatorChar);
            return output;
        }

        public static bool IsInvalid(char directorySeparator)
        {
            var output = directorySeparator == DirectorySeparator.InvalidChar;
            return output;
        }

        public static bool IsValid(char directorySeparator)
        {
            var output = !DirectorySeparator.IsInvalid(directorySeparator);
            return output;
        }

        /// <summary>
        /// Checks that the specified directory separator is actually a directory separator, and throws an exception if it is not.
        /// </summary>
        /// /// <exception cref="Exception">Thrown if the <paramref name="directorySeparator"/> is not a valid directory separator according to <see cref="DirectorySeparator.IsValid(char)"/>.</exception>
        public static void Validate(char directorySeparator)
        {
            var isValid = DirectorySeparator.IsValid(directorySeparator);
            if (!isValid)
            {
                var @string = DirectorySeparator.CharToStringUnchecked(directorySeparator);

                var exception = DirectorySeparator.GetInvalidDirectorySeparatorException(@string);
                throw exception;
            }
        }

        /// <summary>
        /// Checks that the specified directory separator argument is actually a directory separator, and throws an exception if it is not.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown if the <paramref name="directorySeparator"/> is not a valid directory separator according to <see cref="DirectorySeparator.IsValid(char)"/>.</exception>
        public static void Validate(char directorySeparator, string argumentName)
        {
            if (!DirectorySeparator.IsValid(directorySeparator))
            {
                var @string = DirectorySeparator.CharToStringUnchecked(directorySeparator);

                var exception = DirectorySeparator.GetInvalidDirectorySeparatorArgumentException(@string, argumentName);
                throw exception;
            }
        }

        public static void ValidateWindows(char windowsDirectorySeparator)
        {
            DirectorySeparator.Validate(windowsDirectorySeparator);

            var isWindows = DirectorySeparator.IsWindowsDirectorySeparator(windowsDirectorySeparator);
            if (!isWindows)
            {
                var @string = DirectorySeparator.CharToStringUnchecked(windowsDirectorySeparator);

                var exception = DirectorySeparator.GetWindowsDirectorySeparatorExpectedException(@string);
                throw exception;
            }
        }

        public static void ValidateWindows(char windowsDirectorySeparator, string argumentName)
        {
            DirectorySeparator.Validate(windowsDirectorySeparator);

            var isWindows = DirectorySeparator.IsWindowsDirectorySeparator(windowsDirectorySeparator);
            if (!isWindows)
            {
                var @string = DirectorySeparator.CharToStringUnchecked(windowsDirectorySeparator);

                var exception = DirectorySeparator.GetWindowsDirectorySeparatorExpectedArgumentException(@string, argumentName);
                throw exception;
            }
        }

        public static void ValidateNonWindows(char nonWindowsDirectorySeparator)
        {
            DirectorySeparator.Validate(nonWindowsDirectorySeparator);

            var isWindows = DirectorySeparator.IsNonWindowsDirectorySeparator(nonWindowsDirectorySeparator);
            if (!isWindows)
            {
                var @string = DirectorySeparator.CharToStringUnchecked(nonWindowsDirectorySeparator);

                var exception = DirectorySeparator.GetNonWindowsDirectorySeparatorExpectedException(@string);
                throw exception;
            }
        }

        public static void ValidateNonWindows(char nonWindowsDirectorySeparator, string argumentName)
        {
            DirectorySeparator.Validate(nonWindowsDirectorySeparator);

            var isWindows = DirectorySeparator.IsNonWindowsDirectorySeparator(nonWindowsDirectorySeparator);
            if (!isWindows)
            {
                var @string = DirectorySeparator.CharToStringUnchecked(nonWindowsDirectorySeparator);

                var exception = DirectorySeparator.GetNonWindowsDirectorySeparatorExpectedArgumentException(@string, argumentName);
                throw exception;
            }
        }



        public static bool IsDirectorySeparator(char possibleDirectorySeparator)
        {
            var isDirectorySeparator =
                   possibleDirectorySeparator == DirectorySeparator.WindowsChar ||
                   possibleDirectorySeparator == DirectorySeparator.NonWindowsChar;

            return isDirectorySeparator;
        }

        /// <summary>
        /// Determines if the specified value equals the specified directory-separator, and if the specified directory separator is actually a directory separator.
        /// </summary>
        public static bool IsDirectorySeparator(char value, char possibleDirectorySeparator)
        {
            var areEqual = value == possibleDirectorySeparator;
            if (!areEqual)
            {
                return false;
            }

            var isDirectorySeparator = DirectorySeparator.IsDirectorySeparator(possibleDirectorySeparator);
            if (!isDirectorySeparator)
            {
                return false;
            }

            return true;
        }

        public static bool IsWindowsDirectorySeparator(char directorySeparator)
        {
            var isWindows = DirectorySeparator.IsDirectorySeparator(directorySeparator, DirectorySeparator.WindowsChar);
            return isWindows;
        }

        public static bool IsNonWindowsDirectorySeparator(char directorySeparator)
        {
            var isWindows = DirectorySeparator.IsDirectorySeparator(directorySeparator, DirectorySeparator.NonWindowsChar);
            return isWindows;
        }

        /// <summary>
        /// Between the Windows ('\', back-slash) and the non-Windows ('/', slash) directory separators, given one, return the other.
        /// Unchecked - If the input directory separator is neither the Windows nor non-Windows separator, the Windows separator is returned.
        /// </summary>
        public static string GetAlternateDirectorySeparatorUnchecked(char directorySeparator)
        {
            var isWindows = DirectorySeparator.IsWindowsDirectorySeparator(directorySeparator);
            if (isWindows)
            {
                return DirectorySeparator.NonWindows;
            }
            else
            {
                return DirectorySeparator.Windows;
            }
        }

        /// <summary>
        /// Between the Windows ('\', back-slash) and the non-Windows ('/', slash) directory separator, given one, return the other.
        /// Checked - Validates the directory separator first.
        /// </summary>
        public static string GetAlternateDirectorySeparator(char directorySeparator)
        {
            DirectorySeparator.Validate(directorySeparator);

            var alternateDirectorySeparator = DirectorySeparator.GetAlternateDirectorySeparatorUnchecked(directorySeparator);
            return alternateDirectorySeparator;
        }



        public static bool IsInvalid(string directorySeparator)
        {
            var output = directorySeparator == DirectorySeparator.Invalid;
            return output;
        }

        public static bool IsValid(string directorySeparator)
        {
            var output = !DirectorySeparator.IsInvalid(directorySeparator);
            return output;
        }

        /// <summary>
        /// Checks that the specified directory separator is actually a directory separator, and throws an exception if it is not.
        /// </summary>
        /// <exception cref="Exception">Thrown if the <paramref name="directorySeparator"/> is not a valid directory separator according to <see cref="DirectorySeparator.IsValid(string)"/>.</exception>
        public static void Validate(string directorySeparator)
        {
            var isValid = DirectorySeparator.IsValid(directorySeparator);
            if (!isValid)
            {
                var exception = DirectorySeparator.GetInvalidDirectorySeparatorException(directorySeparator);
                throw exception;
            }
        }

        /// <summary>
        /// Checks that the specified directory separator argument is actually a directory separator, and throws an exception if it is not.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown if the <paramref name="directorySeparator"/> is not a valid directory separator according to <see cref="DirectorySeparator.IsValid(string)"/>.</exception>
        public static void Validate(string directorySeparator, string argumentName)
        {
            if (!DirectorySeparator.IsValid(directorySeparator))
            {
                var exception = DirectorySeparator.GetInvalidDirectorySeparatorArgumentException(directorySeparator, argumentName);
                throw exception;
            }
        }

        public static void ValidateWindows(string windowsDirectorySeparator)
        {
            DirectorySeparator.Validate(windowsDirectorySeparator);

            var isWindows = DirectorySeparator.IsWindowsDirectorySeparator(windowsDirectorySeparator);
            if (!isWindows)
            {
                var exception = DirectorySeparator.GetWindowsDirectorySeparatorExpectedException(windowsDirectorySeparator);
                throw exception;
            }
        }

        public static void ValidateWindows(string windowsDirectorySeparator, string argumentName)
        {
            DirectorySeparator.Validate(windowsDirectorySeparator);

            var isWindows = DirectorySeparator.IsWindowsDirectorySeparator(windowsDirectorySeparator);
            if (!isWindows)
            {
                var exception = DirectorySeparator.GetWindowsDirectorySeparatorExpectedArgumentException(windowsDirectorySeparator, argumentName);
                throw exception;
            }
        }

        public static void ValidateNonWindows(string nonWindowsDirectorySeparator)
        {
            DirectorySeparator.Validate(nonWindowsDirectorySeparator);

            var isWindows = DirectorySeparator.IsNonWindowsDirectorySeparator(nonWindowsDirectorySeparator);
            if (!isWindows)
            {
                var exception = DirectorySeparator.GetNonWindowsDirectorySeparatorExpectedException(nonWindowsDirectorySeparator);
                throw exception;
            }
        }

        public static void ValidateNonWindows(string nonWindowsDirectorySeparator, string argumentName)
        {
            DirectorySeparator.Validate(nonWindowsDirectorySeparator);

            var isWindows = DirectorySeparator.IsNonWindowsDirectorySeparator(nonWindowsDirectorySeparator);
            if (!isWindows)
            {
                var exception = DirectorySeparator.GetNonWindowsDirectorySeparatorExpectedArgumentException(nonWindowsDirectorySeparator, argumentName);
                throw exception;
            }
        }

        public static bool IsDirectorySeparator(string possibleDirectorySeparator)
        {
            var isDirectorySeparator =
                   possibleDirectorySeparator == DirectorySeparator.Windows ||
                   possibleDirectorySeparator == DirectorySeparator.NonWindows;

            return isDirectorySeparator;
        }

        /// <summary>
        /// Determines if the specified value equals the specified directory-separator, and if the specified directory separator is actually a directory separator.
        /// </summary>
        public static bool IsDirectorySeparator(string value, string possibleDirectorySeparator)
        {
            var areEqual = value == possibleDirectorySeparator;
            if (!areEqual)
            {
                return false;
            }

            var isDirectorySeparator = DirectorySeparator.IsDirectorySeparator(possibleDirectorySeparator);
            if (!isDirectorySeparator)
            {
                return false;
            }

            return true;
        }

        public static bool IsWindowsDirectorySeparator(string directorySeparator)
        {
            var isWindows = DirectorySeparator.IsDirectorySeparator(directorySeparator, DirectorySeparator.Windows);
            return isWindows;
        }

        public static bool IsNonWindowsDirectorySeparator(string directorySeparator)
        {
            var isWindows = DirectorySeparator.IsDirectorySeparator(directorySeparator, DirectorySeparator.NonWindows);
            return isWindows;
        }

        /// <summary>
        /// Between the Windows ('\', back-slash) and the non-Windows ('/', slash) directory separators, given one, return the other.
        /// Unchecked - If the input directory separator is neither the Windows nor non-Windows separator, the Windows separator is returned.
        /// </summary>
        public static string GetAlternateDirectorySeparatorUnchecked(string directorySeparator)
        {
            var isWindows = DirectorySeparator.IsWindowsDirectorySeparator(directorySeparator);
            if (isWindows)
            {
                return DirectorySeparator.NonWindows;
            }
            else
            {
                return DirectorySeparator.Windows;
            }
        }

        /// <summary>
        /// Between the Windows ('\', back-slash) and the non-Windows ('/', slash) directory separator, given one, return the other.
        /// Checked - Validates the directory separator first.
        /// </summary>
        public static string GetAlternateDirectorySeparator(string directorySeparator)
        {
            DirectorySeparator.Validate(directorySeparator);

            var alternateDirectorySeparator = DirectorySeparator.GetAlternateDirectorySeparatorUnchecked(directorySeparator);
            return alternateDirectorySeparator;
        }

        /// <summary>
        /// Attempts to detect the directory separator (Windows or non-Windows) used within a path segment.
        /// Returns true if the a directory separator can be detected, and sets the output <paramref name="directorySeparator"/> to the detected value.
        /// Returns false if a directory separator cannot be detected, and sets the output <paramref name="directorySeparator"/> to the provided <paramref name="defaultDirectorySeparator"/> value.
        /// Returns true if both (mixed) directory separators are detected, and sets the sets the output <paramref name="directorySeparator"/> to the detected value.
        /// A path segment might have both Windows and non-Windows directory separators. Whichever directory separator occurs first in the path segment (thus, closer to the root) is dominant, and is returned as the path segment's directory separator.
        /// </summary>
        public static bool TryDetectDirectorySeparator(string pathSegment, out string directorySeparator, string defaultDirectorySeparator)
        {
            var indexOfWindows = pathSegment.IndexOf(DirectorySeparator.Windows);
            var indexOfNonWindows = pathSegment.IndexOf(DirectorySeparator.NonWindows);

            var windowsFound = StringHelper.IsFound(indexOfWindows);
            var nonWindowsFound = StringHelper.IsFound(indexOfNonWindows);

            // Neither Windows nor non-Windows directory is found, 
            if (!windowsFound && !nonWindowsFound)
            {
                directorySeparator = defaultDirectorySeparator;
                return false;
            }

            // Mixed path, go with whichever separator was found first (whichever is closer to the root).
            if (windowsFound && nonWindowsFound)
            {
                var windowsBeforeNonWindows = indexOfWindows < indexOfNonWindows; // There will never be an equals case, since two different characters cannot have the same index in a string. At least until quantum computing arrives!
                if (windowsBeforeNonWindows)
                {
                    directorySeparator = DirectorySeparator.Windows;
                    return true;
                }
                else
                {
                    directorySeparator = DirectorySeparator.NonWindows;
                    return true;
                }
            }

            // At this point, either the Windows or non-Windows directory separator was found.
            if (windowsFound)
            {
                directorySeparator = DirectorySeparator.Windows;
                return true;
            }
            else
            {
                directorySeparator = DirectorySeparator.NonWindows;
                return true;
            }
        }

        /// <summary>
        /// Attempts to detect the directory separator (Windows or non-Windows) used within a path segment.
        /// Returns true if a directory separator can be detected, false otherwise.
        /// If no directory separator is detected, the output <paramref name="directorySeparator"/> is set to the <see cref="DirectorySeparator.Invalid"/> value.
        /// </summary>
        public static bool TryDetectDirectorySeparatorOrInvalid(string pathSegment, out string directorySeparator)
        {
            var output = DirectorySeparator.TryDetectDirectorySeparator(pathSegment, out directorySeparator, DirectorySeparator.Invalid);
            return output;
        }

        /// <summary>
        /// Attempts to detect the directory separator (Windows or non-Windows) used within a path segment.
        /// Returns true if a directory separator can be detected, false otherwise.
        /// If no default directory separator is detected, the output <paramref name="directorySeparator"/> is set to the <see cref="DirectorySeparator.Default"/> value.
        /// </summary>
        public static bool TryDetectDirectorySeparatorOrDefault(string pathSegment, out string directorySeparator)
        {
            var output = DirectorySeparator.TryDetectDirectorySeparator(pathSegment, out directorySeparator, DirectorySeparator.Default);
            return output;
        }

        /// <summary>
        /// Attempts to detect the directory separator (Windows or non-Windows) used within a path segment, setting the output <paramref name="directorySeparator"/> to the <see cref="DirectorySeparator.Default"/> if no directory separator can be detected.
        /// Returns true if a directory separator can be detected, false otherwise.
        /// </summary>
        public static bool TryDetectDirectorySeparator(string pathSegment, out string directorySeparator)
        {
            var output = DirectorySeparator.TryDetectDirectorySeparatorOrDefault(pathSegment, out directorySeparator);
            return output;
        }

        /// <summary>
        /// Detects the directory separator used in a path segment.
        /// If no directory separator can be detected, throws an exception.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when a path segment a directory separator cannot be detected (i.e. the input path segment contains no directory separators).</exception>
        public static string DetectDirectorySeparator(string pathSegment)
        {
            var detectionSuccess = DirectorySeparator.TryDetectDirectorySeparator(pathSegment, out var directorySeparator);
            if (!detectionSuccess)
            {
                var exception = DirectorySeparator.GetUnableToDetectDirectorySeparatorArgumentException(pathSegment, nameof(pathSegment));
                throw exception;
            }

            return directorySeparator;
        }

        /// <summary>
        /// Detects the directory separator used in a path segment.
        /// If no directory separator can be detected, returns the <see cref="DirectorySeparator.Default"/> value.
        /// </summary>
        public static string DetectDirectorySeparatorOrDefault(string pathSegment)
        {
            DirectorySeparator.TryDetectDirectorySeparatorOrDefault(pathSegment, out var directorySeparator);

            return directorySeparator;
        }

        /// <summary>
        /// Detects the directory separator used in a path segment.
        /// If a directory separator cannot be detected (for example, if the path segment is a file-name, or the non-directory indicated relative path between parent a child directory, which is just the directory name), return the specified default.
        /// </summary>
        public static string DetectDirectorySeparatorOrDefault(string pathSegment, string defaultDirectorySeparator)
        {
            DirectorySeparator.TryDetectDirectorySeparator(pathSegment, out var directorySeparator, defaultDirectorySeparator);

            return directorySeparator;
        }

        /// <summary>
        /// Detects the directory separator used in a path segment, or if no directory separator can be detected, returns to the Windows value.
        /// </summary>
        public static string DetectDirectorySeparatorOrDefaultWindows(string pathSegment)
        {
            var directorySeparator = DirectorySeparator.DetectDirectorySeparatorOrDefault(pathSegment, DirectorySeparator.Windows);
            return directorySeparator;
        }

        /// <summary>
        /// Detects the directory separator used in a path segment, or if no directory separator can be detected, defaults to the non-Windows value.
        /// </summary>
        public static string DetectDirectorySeparatorOrDefaultNonWindows(string pathSegment)
        {
            var directorySeparator = DirectorySeparator.DetectDirectorySeparatorOrDefault(pathSegment, DirectorySeparator.NonWindows);
            return directorySeparator;
        }

        /// <summary>
        /// Determines if any directory separator can be detected for a path segment.
        /// </summary>
        public static bool IsDirectorySeparatorDetected(string pathSegment)
        {
            var isAnySeparatorDetected = DirectorySeparator.TryDetectDirectorySeparatorOrInvalid(pathSegment, out var _); // Use the actual try-detect logic to keep logic consistent.
            return isAnySeparatorDetected;
        }

        /// <summary>
        /// Determines if the specified directory separator is detected for the path segment.
        /// Unchecked - No validation is performed on the input directory separator.
        /// </summary>
        public static bool IsDirectorySeparatorDetectedUnchecked(string pathSegment, string directorySeparator)
        {
            var isAnySeparatorDetected = DirectorySeparator.TryDetectDirectorySeparatorOrInvalid(pathSegment, out var outDirectorySeparator);
            if (isAnySeparatorDetected)
            {
                var isDetected = directorySeparator == outDirectorySeparator;
                return isDetected;
            }

            return false;
        }

        /// <summary>
        /// Determines if the specified directory separator is detected for the path segment.
        /// The input directory separator is validated.
        /// </summary>
        public static bool IsDirectorySeparatorDetected(string pathSegment, string directorySeparator)
        {
            DirectorySeparator.Validate(directorySeparator);

            var isDetected = DirectorySeparator.IsDirectorySeparatorDetectedUnchecked(pathSegment, directorySeparator);
            return isDetected;
        }

        /// <summary>
        /// Determine if the Windows directory separator is detected in a path segment.
        /// </summary>
        public static bool IsWindowsDirectorySeparatorDetected(string pathSegment)
        {
            var isWindows = DirectorySeparator.IsDirectorySeparatorDetectedUnchecked(pathSegment, DirectorySeparator.Windows);
            return isWindows;
        }

        /// <summary>
        /// Determine if the Windows directory separator is detected in a path segment, but if no directory separator is detected, assume the Windows directory separator was detected (return true).
        /// </summary>
        public static bool IsWindowsDirectorySeparatorDetectedAssumeWindows(string pathSegment)
        {
            var directorySeparator = DirectorySeparator.DetectDirectorySeparatorOrDefaultWindows(pathSegment);

            var isWindows = DirectorySeparator.IsWindowsDirectorySeparator(directorySeparator);
            return isWindows;
        }

        /// <summary>
        /// Determine if the non-Windows directory separator is detected in a path segment.
        /// </summary>
        public static bool IsNonWindowsDirectorySeparatorDetected(string pathSegment)
        {
            var isNonWindows = DirectorySeparator.IsDirectorySeparatorDetectedUnchecked(pathSegment, DirectorySeparator.NonWindows);
            return isNonWindows;
        }

        /// <summary>
        /// Determine if the non-Windows directory separator is detected in a path segment, but if no directory separator is detected, assume the non-Windows directory separator was detected (return true).
        /// </summary>
        public static bool IsNonWindowsDirectorySeparatorDetectedAssumeNonWindows(string pathSegment)
        {
            var directorySeparator = DirectorySeparator.DetectDirectorySeparatorOrDefaultNonWindows(pathSegment);

            var isNonWindows = DirectorySeparator.IsNonWindowsDirectorySeparator(directorySeparator);
            return isNonWindows;
        }

        public static bool IsMixedDirectorySeparatorsDetected(string pathSegment)
        {
            var hasWindows = DirectorySeparator.IsWindowsDirectorySeparatorDetected(pathSegment);
            var hasNonWindows = DirectorySeparator.IsNonWindowsDirectorySeparatorDetected(pathSegment);

            var hasMixed = hasWindows && hasNonWindows;
            return hasMixed;
        }

        /// <summary>
        /// Determine if a path-segment contains ANY directory separator.
        /// </summary>
        /// <remarks>Similar to <see cref="DirectorySeparator.IsDirectorySeparatorDetected(string)"/>, but uses an alternate, simpler, <see cref="String.Contains(string)"/> logic that should give the same answer, but just in case provides and alternate test.</remarks>
        public static bool ContainsDirectorySeparator(string pathSegment)
        {
            var output = pathSegment.Contains(DirectorySeparator.Windows)
                || pathSegment.Contains(DirectorySeparator.NonWindows);

            return output;
        }

        /// <summary>
        /// Determines if a path segment contains a specified directory separator.
        /// Detecting the use of a directory-separator by a path-segment requires an extra step beyond just determining if the path-segment contains the directory-separator.
        /// A path-segment can contain both Windows and non-Windows directory-separators, in which case the first directory-separator is the detected directory-separator because it is dominant.
        /// Unchecked - No validation is peformed on the specified directory separator. This is simply determining if one string (the directory separator) appears within another (the path-segment).
        /// </summary>
        /// <remarks>Similar to <see cref="DirectorySeparator.IsDirectorySeparatorDetectedUnchecked(string, string)"/>, but uses an alternate, simpler, <see cref="String.Contains(string)"/> logic that should give the same answer, but just in case provides and alternate test.</remarks>
        public static bool ContainsDirectorySeparatorUnchecked(string pathSegment, string directorySeparator)
        {
            var output = pathSegment.Contains(directorySeparator);
            return output;
        }

        /// <summary>
        /// Determines if a path segment contains a specified directory separator.
        /// Detecting the use of a directory-separator by a path-segment requires an extra step beyond just determining if the path-segment contains the directory-separator.
        /// A path-segment can contain both Windows and non-Windows directory-separators, in which case the first directory-separator is the detected directory-separator because it is dominant.
        /// Validation is performed on the directory separator.
        /// </summary>
        /// <remarks>Similar to <see cref="DirectorySeparator.IsDirectorySeparatorDetected(string, string)"/>, but uses an alternate, simpler, <see cref="String.Contains(string)"/> logic that should give the same answer, but just in case provides and alternate test.</remarks>
        public static bool ContainsDirectorySeparator(string pathSegment, string directorySeparator)
        {
            DirectorySeparator.Validate(directorySeparator);

            var output = DirectorySeparator.ContainsDirectorySeparatorUnchecked(pathSegment, directorySeparator);
            return output;
        }

        /// <summary>
        /// Determines if a path segment contains a Windows directory separator.
        /// </summary>
        /// <remarks>Similar to <see cref="DirectorySeparator.IsWindowsDirectorySeparatorDetected(string)"/>, but uses an alternate, simpler, <see cref="String.Contains(string)"/> logic that should give the same answer, but just in case provides and alternate test.</remarks>
        public static bool ContainsWindowsDirectorySeparator(string pathSegment)
        {
            var output = DirectorySeparator.ContainsDirectorySeparatorUnchecked(pathSegment, DirectorySeparator.Windows);
            return output;
        }

        /// <summary>
        /// Determines if a path segment contains a Windows directory separator.
        /// </summary>
        /// <remarks>Similar to <see cref="DirectorySeparator.IsNonWindowsDirectorySeparatorDetected(string)"/>, but uses an alternate, simpler, <see cref="String.Contains(string)"/> logic that should give the same answer, but just in case provides and alternate test.</remarks>
        public static bool ContainsNonWindowsDirectorySeparator(string pathSegment)
        {
            var output = DirectorySeparator.ContainsDirectorySeparatorUnchecked(pathSegment, DirectorySeparator.NonWindows);
            return output;
        }

        /// <summary>
        /// Determines if a path segment contains a Windows directory separator.
        /// </summary>
        /// <remarks>Similar to <see cref="DirectorySeparator.IsMixedDirectorySeparatorsDetected(string)"/>, but uses an alternate, simpler, <see cref="String.Contains(string)"/> logic that should give the same answer, but just in case provides and alternate test.</remarks>
        public static bool ContainsMixedDirectorySeparator(string pathSegment)
        {
            var output = DirectorySeparator.ContainsWindowsDirectorySeparator(pathSegment)
                && DirectorySeparator.ContainsNonWindowsDirectorySeparator(pathSegment);

            return output;
        }

        /// <summary>
        /// Tries to get the dominant directory separator in a path (the directory separator that occurs first in the path).
        /// If no directory separator is found in the path, returns the <see cref="DirectorySeparator.Invalid"/> value.
        /// </summary>
        /// <remarks>Identical to <see cref="DirectorySeparator.TryDetectDirectorySeparatorOrInvalid(string, out string)"/>. Just helpfully named.</remarks>
        public static bool TryGetDominantDirectorySeparator(string pathSegment, out string dominantDirectorySeparator)
        {
            var output = DirectorySeparator.TryDetectDirectorySeparatorOrInvalid(pathSegment, out dominantDirectorySeparator);
            return output;
        }

        /// <summary>
        /// Gets the dominant directory separator in a path (the directory separator that occurs first in the path).
        /// If no directory separator is found in the path, throws an exception.
        /// </summary>
        public static string GetDominantDirectorySeparator(string pathSegment)
        {
            var output = DirectorySeparator.DetectDirectorySeparator(pathSegment);
            return output;
        }

        public static bool TryGetDominantDirectorySeparatorPlatform(string pathSegment, out Platform platform)
        {
            var detectedDirectorySeparator = DirectorySeparator.TryDetectDirectorySeparatorOrInvalid(pathSegment, out var directorySeparator);
            if(!detectedDirectorySeparator)
            {
                platform = Platform.Unknown;
                return false;
            }

            platform = DirectorySeparator.GetPlatformForDirectorySeparator(directorySeparator);
            return true;
        }

        public static Platform GetDominantDirectorySeparatorPlatform(string pathSegment)
        {
            var directorySeparator = DirectorySeparator.DetectDirectorySeparator(pathSegment);

            var platform = DirectorySeparator.GetPlatformForDirectorySeparator(directorySeparator);
            return platform;
        }





        #region Exceptions

        public static string GetInvalidDirectorySeparatorExceptionMessage(string invalidDirectorySeparator)
        {
            var message = $"Invalid directory separator value.\nExpected the Windows ('{DirectorySeparator.Windows}') or non-Windows ('{DirectorySeparator.NonWindows}') directory separator value.\nFound: '{invalidDirectorySeparator}'.";
            return message;
        }

        public static Exception GetInvalidDirectorySeparatorException(string invalidDirectorySeparator)
        {
            var message = DirectorySeparator.GetInvalidDirectorySeparatorExceptionMessage(invalidDirectorySeparator);

            var exception = new Exception(message);
            return exception;
        }

        public static ArgumentException GetInvalidDirectorySeparatorArgumentException(string invalidDirectorySeparator, string parameterName)
        {
            var message = DirectorySeparator.GetInvalidDirectorySeparatorExceptionMessage(invalidDirectorySeparator);

            var exception = new ArgumentException(message, parameterName);
            return exception;
        }

        public static string GetWindowsDirectorySeparatorExpectedExceptionMessage(string notWindowsDirectorySeparator)
        {
            var message = $"Windows directory-separator value ('{DirectorySeparator.Windows}') expected.\nFound: '{notWindowsDirectorySeparator}'.";
            return message;
        }

        public static Exception GetWindowsDirectorySeparatorExpectedException(string notWindowsDirectorySeparator)
        {
            var message = DirectorySeparator.GetWindowsDirectorySeparatorExpectedExceptionMessage(notWindowsDirectorySeparator);

            var exception = new Exception(message);
            return exception;
        }

        public static ArgumentException GetWindowsDirectorySeparatorExpectedArgumentException(string found, string parameterName)
        {
            var message = DirectorySeparator.GetWindowsDirectorySeparatorExpectedExceptionMessage(found);

            var exception = new ArgumentException(message, parameterName);
            return exception;
        }

        public static string GetNonWindowsDirectorySeparatorExpectedExceptionMessage(string notNonWindowsDirectorySeparator)
        {
            var message = $"Non-Windows directory-separator value ('{DirectorySeparator.NonWindows}') expected.\nFound: '{notNonWindowsDirectorySeparator}'.";
            return message;
        }

        public static Exception GetNonWindowsDirectorySeparatorExpectedException(string notNonWindowsDirectorySeparator)
        {
            var message = DirectorySeparator.GetNonWindowsDirectorySeparatorExpectedExceptionMessage(notNonWindowsDirectorySeparator);

            var exception = new Exception(message);
            return exception;
        }

        public static ArgumentException GetNonWindowsDirectorySeparatorExpectedArgumentException(string found, string parameterName)
        {
            var message = DirectorySeparator.GetNonWindowsDirectorySeparatorExpectedExceptionMessage(found);

            var exception = new ArgumentException(message, parameterName);
            return exception;
        }

        public static string GetUnableToDetectDirectorySeparatorExceptionMessage(string pathSegment)
        {
            var message = $"Unable to detect platform for path '{pathSegment}'.";
            return message;
        }

        public static Exception GetUnableToDetectDirectorySeparatorException(string pathSegment)
        {
            var message = DirectorySeparator.GetUnableToDetectDirectorySeparatorExceptionMessage(pathSegment);

            var exception = new Exception(message);
            return exception;
        }

        public static ArgumentException GetUnableToDetectDirectorySeparatorArgumentException(string pathSegment, string parameterName)
        {
            var message = DirectorySeparator.GetUnableToDetectDirectorySeparatorExceptionMessage(pathSegment);

            var exception = new ArgumentException(message, parameterName);
            return exception;
        }

        #endregion
    }
}
