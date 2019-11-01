using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using AirTrafficMonitor.ConditionLogger;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace ATM.Test.Unit
{
    //[TestFixture]
    //class ConditionLoggerUnitTest
    //{
    //    private IConditionLogger uut;
    //    private string Path;

    //    [SetUp] // Setup making the uut + adding path for the testfolder location.
    //    public void Setup()
    //    {
    //        uut = new ConditionLogger();
    //        Path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
    //    }

    //    // Clear Log functionality will be necessary to reset the file that is tested on.
    //    private void ClearLog()
    //    {
    //        File.WriteAllText(Path + @"\LogFile.txt", string.Empty);
    //    }

    //    [Test] // Test to see if we even have an existing log file.
    //    public void TestMakeFile()
    //    {
    //        Assert.That(File.Exists(Path + @"\LogFile.txt"), Is.True);
    //    }


    //}
}
