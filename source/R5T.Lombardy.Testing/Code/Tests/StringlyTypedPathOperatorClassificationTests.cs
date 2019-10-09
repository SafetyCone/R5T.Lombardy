using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using R5T.Lombardy.Test;


namespace R5T.Lombardy.Testing
{
    [TestClass]
    public class StringlyTypedPathOperatorClassificationTests : StringlyTypedPathOperatorClassificationTestFixture
    {
        public StringlyTypedPathOperatorClassificationTests()
            : base(new StringlyTypedPathOperator())
        {
        }
    }
}
