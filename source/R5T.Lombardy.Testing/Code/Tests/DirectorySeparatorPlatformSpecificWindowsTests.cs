using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using R5T.Lombardy.Test;
using R5T.Rugia;


namespace R5T.Lombardy.Testing
{
    [TestClass]
    public class DirectorySeparatorPlatformSpecificWindowsTests : DirectorySeparatorPlatformSpecificTestFixture
    {
        public override Platform Platform => Platform.Windows;
        public override char PlatformDirectorySeparatorChar => DirectorySeparator.WindowsChar;
        public override string PlatformDirectorySeparator => DirectorySeparator.Windows;


        public DirectorySeparatorPlatformSpecificWindowsTests()
            : base(new DirectorySeparatorOperator())
        {
        }
    }
}
