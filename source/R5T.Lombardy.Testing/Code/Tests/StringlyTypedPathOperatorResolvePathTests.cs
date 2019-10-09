using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using R5T.Lombardy.Test;


namespace R5T.Lombardy.Testing
{
    [TestClass]
    public class StringlyTypedPathOperatorResolvePathTests : StringlyTypedPathOperatorResolvePathTestFixture
    {
        public StringlyTypedPathOperatorResolvePathTests()
            : base(new StringlyTypedPathOperator())
        {
        }
    }
}
