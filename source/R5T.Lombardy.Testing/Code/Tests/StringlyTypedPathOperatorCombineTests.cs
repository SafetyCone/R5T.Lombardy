using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using R5T.Lombardy.Test;


namespace R5T.Lombardy.Testing
{
    [TestClass]
    public class StringlyTypedPathOperatorCombineTests : StringlyTypedPathOperatorCombineTestFixture
    {
        public StringlyTypedPathOperatorCombineTests()
            : base(new StringlyTypedPathOperator())
        {
        }
    }
}
