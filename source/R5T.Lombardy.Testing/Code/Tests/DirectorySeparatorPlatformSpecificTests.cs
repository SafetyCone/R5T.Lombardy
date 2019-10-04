using System;
using System.Runtime.InteropServices;

using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace R5T.Lombardy.Testing
{
    [TestClass]
    public class DirectorySeparatorPlatformSpecificTests
    {
        /// <summary>
        /// Can only be tested on a machine of the ACTUAL platform.
        /// </summary>
        [TestMethod]
        public void ExecutingMachineDefaultDirectorySeparatorChar()
        {
            var executingMachineDefaultDirectorySeparactorChar = DirectorySeparator.ExecutingMachineDefaultChar;
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Assert.AreEqual(executingMachineDefaultDirectorySeparactorChar, DirectorySeparator.WindowsChar);
            }
            else
            {
                Assert.AreEqual(executingMachineDefaultDirectorySeparactorChar, DirectorySeparator.NonWindowsChar);
            }
        }
    }
}
