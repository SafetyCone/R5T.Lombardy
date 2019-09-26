using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using R5T.Lombardy.Test;


namespace R5T.Lombardy.Testing
{
    [TestClass]
    public class StringlyTypedPathOperatorTestArticleTests : StringlyTypedPathOperatorTestArticleTestFixture
    {
        public StringlyTypedPathOperatorTestArticleTests()
            : base(new StringlyTypedPathOperatorTestArticle())
        {
        }
    }
}
