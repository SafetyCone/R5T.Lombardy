using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using R5T.Lombardy.Test;
using R5T.Rugia;


namespace R5T.Lombardy.Testing
{
    [TestClass]
    public class DirectorySeparatorPlatformSpecificNonWindowsTests : DirectorySeparatorPlatformSpecificTestFixture
    {
        public override char PlatformDirectorySeparatorChar => DirectorySeparator.NonWindowsChar;
        public override string PlatformDirectorySeparator => DirectorySeparator.NonWindows;


        public DirectorySeparatorPlatformSpecificNonWindowsTests()
            : base(new DirectorySeparatorOperator())
        {
        }


        /// <summary>
        /// Set the platform for use in testing.
        /// </summary>
        [ClassInitialize]
        public static void Initialization(TestContext testContext)
        {
            PlatformOperator.Platform = Platform.NonWindows;
        }

        [ClassCleanup]
        public static void Cleanup()
        {
            PlatformOperator.ResetPlatform();
        }
    }
}
