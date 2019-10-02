using System;


namespace R5T.Lombardy
{
    public class StringlyTypedPathOperator : IStringlyTypedPathOperator
    {
        public string Combine(params string[] paths)
        {
            throw new NotImplementedException();
        }

        public string CombineSpecifySeparator(string directorySeparator, params string[] paths)
        {
            throw new NotImplementedException();
        }

        public string CombineTwo(string directorySeparator, string pathSegment1, string pathSegment2)
        {
            throw new NotImplementedException();
        }

        public string CombineTwo(string pathSegment1, string pathSegment2)
        {
            throw new NotImplementedException();
        }

        public string CombineTwoUnresolved(string directorySeparator, string pathSegment1, string pathSegment2)
        {
            throw new NotImplementedException();
        }

        public string CombineUnresolved(string directorySeparator, params string[] paths)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Combines path parts into a single path part using the provided directory separator.
        /// All input arguments are checked, but invalid inputs are not manipulated to ensure correctness, and instead exceptions are thrown.
        /// </summary>
        /// <param name="directorySeparator">The directory separator to use in combining paths. This value is checked to be one of the valid directory separators, and an exception is thrown if not.</param>
        /// <param name="pathSegment1">The first path part. This path part is checked to be non-directory indicated, and an exception is thrown if not.</param>
        /// <param name="pathSegment2">The second path part. This path part is checked to be non root-indicated, and an exception is thrown if not.</param>
        public string CombineUnresolvedSimple(string directorySeparator, string pathSegment1, string pathSegment2)
        {
            DirectorySeparator.Validate(directorySeparator);
            // Validate pathSegment1 is NOT directory indicated.
            // Validate pathSegment2 is NOT root indicated.

            var output = this.CombineUnresolvedUnchecked(directorySeparator, pathSegment1, pathSegment2);
            return output; // No resolution of output.
        }

        /// <summary>
        /// Combines path parts into a single path part using the provided directory separator.
        /// Literally just string concatentation of the inputs.
        /// All inputs are unchecked, and the resulting path part may be unresolved.
        /// </summary>
        /// <param name="directorySeparator">The directory separator to use in combining paths. This value is not checked to be one of the valid directory separators.</param>
        /// <param name="pathSegment1">The first path part. This path part is not checked to be non-directory indicated. Multiple consecutive directory separator may result.</param>
        /// <param name="pathSegment2">The second path part. This path part is not checked to be non root-indicated. Multiple consecutive directory separator may result.</param>
        public string CombineUnresolvedUnchecked(string directorySeparator, string pathSegment1, string pathSegment2)
        {
            var output = $"{pathSegment1}{directorySeparator}{pathSegment2}";
            return output;
        }
    }
}
