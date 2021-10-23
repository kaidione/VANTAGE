using System.Collections.Generic;
using System.IO;
using System.Security.AccessControl;

namespace LenovoVantageTest.Pages
{
    public class PermissionManager
    {
        public static void AddSecurityControll2File(string filePath)
        {

            FileInfo fileInfo = new FileInfo(filePath);
            System.Security.AccessControl.FileSecurity fileSecurity = fileInfo.GetAccessControl();
            fileSecurity.AddAccessRule(new FileSystemAccessRule("Everyone", FileSystemRights.FullControl, AccessControlType.Allow));
            //添加Users用户组的访问权限规则 完全控制权限
            fileSecurity.AddAccessRule(new FileSystemAccessRule("Users", FileSystemRights.FullControl, AccessControlType.Allow));
            //设置访问权限
            fileInfo.SetAccessControl(fileSecurity);
        }

        /// <summary>
        ///为文件夹添加users，everyone用户组的完全控制权限
        /// </summary>
        /// <param name="dirPath"></param>
        public static void AddSecurityControll2Folder(string dirPath)
        {
            DirectoryInfo dir = new DirectoryInfo(dirPath);
            System.Security.AccessControl.DirectorySecurity dirSecurity = dir.GetAccessControl(AccessControlSections.All);
            InheritanceFlags inherits = InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit;
            FileSystemAccessRule everyoneFileSystemAccessRule = new FileSystemAccessRule("Everyone", FileSystemRights.FullControl, inherits, PropagationFlags.None, AccessControlType.Allow);
            FileSystemAccessRule usersFileSystemAccessRule = new FileSystemAccessRule("Users", FileSystemRights.FullControl, inherits, PropagationFlags.None, AccessControlType.Allow);
            bool isModified = false;
            dirSecurity.ModifyAccessRule(AccessControlModification.Add, everyoneFileSystemAccessRule, out isModified);
            dirSecurity.ModifyAccessRule(AccessControlModification.Add, usersFileSystemAccessRule, out isModified);
            dir.SetAccessControl(dirSecurity);
        }

        public static List<string> FindFile(string sSourcePath)
        {
            List<string> list = new List<string>();
            DirectoryInfo theFolder = new DirectoryInfo(sSourcePath);
            FileInfo[] thefileInfo = theFolder.GetFiles("*.*", SearchOption.TopDirectoryOnly);
            foreach (FileInfo NextFile in thefileInfo)  //遍历文件
                list.Add(NextFile.FullName);

            //遍历子文件夹
            DirectoryInfo[] dirInfo = theFolder.GetDirectories();
            foreach (DirectoryInfo NextFolder in dirInfo)
            {
                //list.Add(NextFolder.ToString());
                FileInfo[] fileInfo = NextFolder.GetFiles("*.*", SearchOption.AllDirectories);
                foreach (FileInfo NextFile in fileInfo)  //遍历文件
                    list.Add(NextFile.FullName);
            }
            return list;
        }

        public static void ModifyFileControll(string sSourcePath)
        {
            //在指定目录及子目录下查找文件,在list中列出子目录及文件
            DirectoryInfo Dir = new DirectoryInfo(sSourcePath);
            AddSecurityControll2Folder(sSourcePath);
            DirectoryInfo[] DirSub = Dir.GetDirectories();
            if (DirSub.Length <= 0)
            {
                foreach (FileInfo f in Dir.GetFiles("*.*", SearchOption.TopDirectoryOnly)) //查找文件
                {
                    //listBox1.Items.Add(Dir+f.ToString()); //listBox1中填加文件名
                    string childFile = Dir + @"\" + f.ToString();
                    AddSecurityControll2File(childFile);
                }
            }

            int t = 1;
            foreach (DirectoryInfo d in DirSub)//查找子目录 
            {
                FindFile(Dir + @"\" + d.ToString());
                string childDirectory = (Dir + @"\" + d.ToString());
                AddSecurityControll2Folder(childDirectory);
                if (t == 1)
                {
                    foreach (FileInfo f in Dir.GetFiles("*.*", SearchOption.TopDirectoryOnly)) //查找文件
                    {
                        string childFile = Dir + @"\" + f.ToString();
                        AddSecurityControll2File(childFile);
                    }
                    t = t + 1;
                }
            }
        }
    }
}
