using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using R5T.Lombardy.Test;


namespace R5T.Lombardy.Testing
{
    [TestClass]
    public class StringlyTypedPathOperatorMiscellaneousTests : StringlyTypedPathOperatorMiscellaneousTestFixture
    {
        public StringlyTypedPathOperatorMiscellaneousTests()
            : base(new DirectorySeparatorOperator(), new StringlyTypedPathOperator())
        {
        }
    }
}
