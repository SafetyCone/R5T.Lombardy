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

        public string CombineTwo(string directorySeparator, string pathPart1, string pathPart2)
        {
            throw new NotImplementedException();
        }

        public string CombineTwo(string pathPart1, string pathPart2)
        {
            throw new NotImplementedException();
        }

        public string CombineTwoUnresolved(string directorySeparator, string pathPart1, string pathPart2)
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
        /// <param name="pathPart1">The first path part. This path part is checked to be non-directory indicated, and an exception is thrown if not.</param>
        /// <param name="pathPart2">The second path part. This path part is checked to be non root-indicated, and an exception is thrown if not.</param>
        public string CombineUnresolvedSimple(string directorySeparator, string pathPart1, string pathPart2)
        {


            var output = this.CombineUnresolvedUnchecked(directorySeparator, pathPart1, pathPart2);
            return output;
        }

        /// <summary>
        /// Combines path parts into a single path part using the provided directory separator.
        /// Literally just string concatentation of the inputs.
        /// All inputs are unchecked, and the resulting path part may be unresolved.
        /// </summary>
        /// <param name="directorySeparator">The directory separator to use in combining paths. This value is not checked to be one of the valid directory separators.</param>
        /// <param name="pathPart1">The first path part. This path part is not checked to be non-directory indicated. Multiple consecutive directory separator may result.</param>
        /// <param name="pathPart2">The second path part. This path part is not checked to be non root-indicated. Multiple consecutive directory separator may result.</param>
        public string CombineUnresolvedUnchecked(string directorySeparator, string pathPart1, string pathPart2)
        {
            var output = $"{pathPart1}{directorySeparator}{pathPart2}";
            return output;
        }
    }
}
