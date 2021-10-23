using LenovoVantageTest.LogHelper;
using System;
using System.Collections;
using System.IO;
namespace LenovoVantageTest.Utility
{
    class FileManager
    {
        // <summary>
        // Copy all subforlders and files to destination folder
        // </summary>
        // <param name="sourceDir">source directory</param>
        // <param name="destinationDir">destination directory</param>
        // <returns>action result: true - success, exception - failed/returns>
        public static bool CopyDirectoryRecursive(string sourceDir, string destinationDir)
        {
            DirectoryInfo source = new DirectoryInfo(sourceDir);
            DirectoryInfo[] dirList = source.GetDirectories();
            FileInfo[] fileList = source.GetFiles();
            if (!Directory.Exists(destinationDir))
            {
                CreateDirRecursive(destinationDir);
            }

            //copy file first
            foreach (FileInfo fi in fileList)
            {
                File.Copy(fi.FullName, Path.Combine(destinationDir, fi.Name), true);
            }

            //copy directory
            if (dirList.Length > 0)
            {
                foreach (DirectoryInfo di in dirList)
                {
                    CopyDirectoryRecursive(di.FullName, Path.Combine(destinationDir, di.Name));
                }
            }
            return true;
        }

        // <summary>
        // Create directory recursively
        // </summary>
        // <param name="path">path to be created</param>
        // <returns>true - success, false - failed</returns>
        public static bool CreateDirRecursive(string path)
        {
            if (!Directory.Exists(Directory.GetParent(path).FullName))
            {
                CreateDirRecursive(Directory.GetParent(path).FullName);
            }
            Directory.CreateDirectory(path);
            if (Directory.Exists(path))
                return true;
            else
                return false;
        }

        // <summary>
        // Replace username with current user in the path of %LocalApplicationData%
        // </summary>
        // <param name="path">path to %LocalApplicationData%</param>
        // <returns>%LocalApplicationData% of the current user</returns>
        public static string ReplaceUserInLocalApplicationData(string path)
        {
            string[] sourceItems = path.Split('\\');
            //check if match the format: "C:\Users\LocalAdmin\AppData\Local\"
            if (path.StartsWith(@"C:\Users\") && sourceItems[3] == "AppData" && sourceItems[4] == "Local")
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                for (int i = 5; i < sourceItems.Length; i++)
                {
                    path = Path.Combine(path, sourceItems[i]);
                }
            }
            return path;
        }

        // <summary>
        // 清空文件夹内所有文件夹及文件
        // </summary>
        // <param name="folder"></param>
        // <returns></returns>
        public static bool EmptyAFolder(string folder)
        {
            try
            {
                if (Directory.Exists(folder))
                {
                    //delete all sub folder
                    foreach (string sf in Directory.GetDirectories(folder))
                    {
                        Directory.Delete(sf, true);
                    }

                    //delete all file
                    foreach (string file in Directory.GetFiles(folder))
                    {
                        File.Delete(file);
                    }
                }
                Logger.Instance.WriteLog("Folder is emptied!", LogType.Information);
                return true;
            }
            catch (Exception e)
            {
                Logger.Instance.WriteLog("Failed to empty folder：" + e.Message, LogType.Error);
                return false;
            }
        }

    }


    public class MyDateSorter : IComparer
    {
        public int Compare(object x, object y)
        {
            if (x == null && y == null)
            {
                return 0;
            }
            if (x == null)
            {
                return -1;
            }
            if (y == null)
            {
                return 1;
            }
            FileInfo xInfo = (FileInfo)x;
            FileInfo yInfo = (FileInfo)y;

            //按文件创建时间排序，由新到旧
            return yInfo.CreationTime.CompareTo(xInfo.CreationTime);
        }
    }
}
