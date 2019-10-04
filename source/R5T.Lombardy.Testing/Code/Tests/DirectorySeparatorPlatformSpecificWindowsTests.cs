using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using R5T.Lombardy.Test;
using R5T.Rugia;


namespace R5T.Lombardy.Testing
{
    [TestClass]
    public class DirectorySeparatorPlatformSpecificWindowsTests : DirectorySeparatorPlatformSpecificTestFixture
    {
        public override char PlatformDirectorySeparatorChar => DirectorySeparator.WindowsChar;
        public override string PlatformDirectorySeparator => DirectorySeparator.Windows;


        public DirectorySeparatorPlatformSpecificWindowsTests()
            : base(new DirectorySeparatorOperator())
        {
        }

        /// <summary>
        /// Set the platform for use in testing.
        /// </summary>
        [ClassInitialize]
        public static void Initialization(TestContext testContext)
        {
            PlatformOperator.Platform = Platform.Windows;
        }

        [ClassCleanup]
        public static void Cleanup()
        {
            PlatformOperator.ResetPlatform();
        }
    }
}
