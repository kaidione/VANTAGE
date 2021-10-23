using AventStack.ExtentReports;
using ICSharpCode.SharpZipLib.Checksums;
using ICSharpCode.SharpZipLib.Zip;
using LenovoVantageTest.Helper;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using System;
using System.IO;
using System.Reflection;

namespace LenovoVantageTest
{
    [TestFixture]
    public class BasicReport
    {
        public ExtentReports extent;
        public ExtentTest test;
        public string title;
        private string _projectPath;

        public BasicReport() { }

        public void StartReport(string reportName)
        {
            string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string actualPath = path.Substring(0, path.LastIndexOf("bin"));
            _projectPath = new Uri(actualPath).LocalPath + "\\Report";
            if (!Directory.Exists(_projectPath))
            {
                Directory.CreateDirectory(_projectPath);
            }
        }

        public void AddScreenshotToReport(string imageName, string pathName = ".", string componentName = "", bool needTakeScreenforPart = false, int srcX = 0, int srcY = 0, int width = 0, int height = 0)
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stackTrace = "<pre>" + TestContext.CurrentContext.Result.StackTrace + "</pre>";
            var message = TestContext.CurrentContext.Result.Message;
            string screenShotPath = string.Empty;
            var screenShotfilepath = string.Empty;
            var littleScreenshot = string.Empty;
            bool manualCheck = false;
            string saveFileNameIntoReport = string.Empty;
            DirectoryInfo littleScreenshotPath = null;
            string workingDirectory = Assembly.GetExecutingAssembly().Location;
            string projectDiectory = Directory.GetParent(workingDirectory).FullName;
            string artifactDirectory = string.Empty;
            if (!string.IsNullOrEmpty(componentName))
            {
                manualCheck = true;
                artifactDirectory = Path.Combine(projectDiectory, "Report", componentName, pathName);
                if (!Directory.Exists(artifactDirectory))
                {
                    Directory.CreateDirectory(artifactDirectory);
                }
                screenShotfilepath = artifactDirectory + "\\" + imageName + ".jpg";
                littleScreenshotPath = new DirectoryInfo(screenShotfilepath);
                saveFileNameIntoReport = Path.Combine(".", componentName, pathName, littleScreenshotPath.Name);
            }
            else
            {
                artifactDirectory = Path.Combine(projectDiectory, "Report");
                screenShotfilepath = Path.Combine(artifactDirectory, imageName + "_" + DateTime.Now.ToString(Constants.DATETIMEFORMATFORPATH) + ".jpg");
                littleScreenshotPath = new DirectoryInfo(screenShotfilepath);
                saveFileNameIntoReport = Path.Combine(".", littleScreenshotPath.Name);
            }
            if (needTakeScreenforPart)
            {
                VantageCommonHelper.ScreenShot(imageName, pathName, componentName, srcX, srcY, width, height);
            }
            else
            {
                CaptureScreen.PrintScreen(screenShotfilepath);
            }
            test.Log(manualCheck == true ? Status.Info : Status.Error, "Snapshot below: " + test.AddScreenCaptureFromPath(saveFileNameIntoReport));
        }

        public static void CreateZipFiles(string sourceFilePath, ZipOutputStream zipStream, string staticFile)
        {
            Crc32 crc = new Crc32();
            string[] filesArray = Directory.GetFileSystemEntries(sourceFilePath);
            foreach (string file in filesArray)
            {
                if (Directory.Exists(file))
                {
                    CreateZipFiles(file, zipStream, staticFile);
                }
                else
                {
                    FileStream fileStream = File.OpenRead(file);
                    byte[] buffer = new byte[fileStream.Length];
                    fileStream.Read(buffer, 0, buffer.Length);
                    string tempFile = file.Substring(staticFile.LastIndexOf("\\") + 1);
                    ZipEntry entry = new ZipEntry(tempFile);
                    entry.DateTime = DateTime.Now;
                    entry.Size = fileStream.Length;
                    fileStream.Close();
                    crc.Reset();
                    crc.Update(buffer);
                    entry.Crc = crc.Value;
                    zipStream.PutNextEntry(entry);
                    zipStream.Write(buffer, 0, buffer.Length);
                }
            }
        }

        public static void CreateZip(string sourceFilePath, string destinationZipFilePath)
        {
            if (sourceFilePath[sourceFilePath.Length - 1] != Path.DirectorySeparatorChar)
            {
                sourceFilePath += Path.DirectorySeparatorChar;
            }
            ZipOutputStream zipStream = new ZipOutputStream(File.Create(destinationZipFilePath));
            zipStream.SetLevel(6);  // 压缩级别 0-9
            CreateZipFiles(sourceFilePath, zipStream, sourceFilePath);
            zipStream.Finish();
            zipStream.Close();
        }

    }
}