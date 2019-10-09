using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using R5T.Lombardy.Test;
using R5T.Rugia;


namespace R5T.Lombardy.Testing
{
    [TestClass]
    public class DirectorySeparatorPlatformSpecificNonWindowsTests : DirectorySeparatorPlatformSpecificTestFixture
    {
        public override Platform Platform => Platform.NonWindows;
        public override char PlatformDirectorySeparatorChar => DirectorySeparator.NonWindowsChar;
        public override string PlatformDirectorySeparator => DirectorySeparator.NonWindows;


        public DirectorySeparatorPlatformSpecificNonWindowsTests()
            : base(new DirectorySeparatorOperator())
        {
        }
    }
}
