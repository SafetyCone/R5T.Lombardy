using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using R5T.Lombardy.Test;


namespace R5T.Lombardy.Testing
{
    [TestClass]
    public class StringlyTypedPathGetFileNameTests : StringlyTypedPathGetFileNameTestFixture
    {
        public StringlyTypedPathGetFileNameTests()
            : base(new StringlyTypedPathOperator())
        {
        }
    }
}
