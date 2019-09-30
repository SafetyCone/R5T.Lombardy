using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using R5T.Lombardy.Test;


namespace R5T.Lombardy.Testing
{
    [TestClass]
    public class DirectorySeparatorOperatorTestArticleTests : DirectorySeparatorOperatorTestArticleTestFixture
    {
        public DirectorySeparatorOperatorTestArticleTests()
            : base(new DirectorySeparatorOperatorTestArticle())
        {
        }
    }
}
