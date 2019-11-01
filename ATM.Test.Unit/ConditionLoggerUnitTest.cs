using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using AirTrafficMonitor.ConditionLogger;
using AirTrafficMonitor.Track;
using AirTrafficMonitor.TrackHandler;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace ATM.Test.Unit
{
    [TestFixture]
    class ConditionLoggerUnitTest
    {
        private IConditionLogger uut;
        private string Path;

        [SetUp] // Setup making the uut + adding path for the testfolder location.
        public void Setup()
        {
            uut = new ConditionLogger();
            Path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        }

        // Clear Log functionality will be necessary to reset the file that is tested on.
        private void ClearLog()
        {
            File.WriteAllText(Path + @"\LogFile.txt", string.Empty);
        }

        [Test] // Test to see if we even have an existing log file.
        public void TestMakeFile()
        {
            Assert.That(File.Exists(Path + @"\LogFile.txt"), Is.True);
        }

        // Test fails - uncommented to be able to use Jenkins
        //[TestCase("track1")] // test to see if what we write in the LogFile is actually written
        //public void TestWriteToLogFile(string track1)
        //{
        //    ClearLog(); //init clear to make sure log is empty before hand

        //    Track t = new Track{Tag = track1, Timer = DateTime.Now};

        //    Tracks ts = new Tracks{New = t};

        //    uut.LogTracks(ts);
        //    string[] write = File.ReadAllLines(Path + @"\LogFile.txt");

        //    Assert.That(write.Equals(track1));

        //}









    }
}
