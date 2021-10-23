using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using winformUI.Bean;
//=================================
//REG_SZ return object type is string
//REG_BINARY return object type is byte[]
//REG_DWORD return object is Int32
//REG_QWORD return object is Int64
//REG_MULTI_SZ return object is string[]
//REG_EXPAND_SZ return objecct is string
//===================================

namespace RegistryHelpTest.Utility
{
    class RegistryHelp
    {
        //
        // Summary:
        //     Specifies which registry view to target on a 64-bit operating system.
        public enum RegistryView
        {
            //
            // Summary:
            //     The default view.
            Default = 0,
            //
            // Summary:
            //     The 64-bit view.
            Registry64 = 256,
            //
            // Summary:
            //     The 32-bit view.
            Registry32 = 512
        }

        static readonly RegistryKey HKCU = Microsoft.Win32.Registry.CurrentUser;
        static readonly RegistryKey HKLM = Microsoft.Win32.Registry.LocalMachine;
        static readonly RegistryKey HKCR = Microsoft.Win32.Registry.ClassesRoot;
        static readonly RegistryKey HKCC = Microsoft.Win32.Registry.CurrentConfig;

        static Dictionary<string, RegistryHive> registryMapping = new Dictionary<string, RegistryHive>
            {
                { "hkcu", RegistryHive.CurrentUser },
                { "hklm", RegistryHive.LocalMachine },
                { "hkcr", RegistryHive.ClassesRoot },
                { "hkcc", RegistryHive.CurrentConfig }
            };

        #region 公共方法组

        // <summary>
        // 检查注册表键值是否存在或检查键值的值是否正确
        // </summary>
        // <param name="target">目标键值</param>
        // <param name="isRedirect">是否重定向，默认为false。当传入的目标键值是完整路径或已包含"WOW6432Node"，则保持默认值。</param>
        // <param name="value">待判断的键值的值</param>
        // <param name="detectvalue">是否判断键值的值</param>
        // <returns>存在/不存在，正确/不正确</returns>
        public static bool IsRegistryKeyExist(string target, bool isRedirect = false, object value = null, bool detectvalue = false)
        {
            bool ret = false;
            if (Environment.HasShutdownStarted)
            {
                if (Environment.HasShutdownStarted)
                {
                    ret = RegistryKeyExist(target, isRedirect, value, detectvalue);
                }
                else
                {
                    ret = RegistryKeyExistRedirect(target, isRedirect, value, detectvalue);
                }
            }
            else
            {
                ret = RegistryKeyExist(target, isRedirect, value, detectvalue);
            }
            return ret;
        }
        public static bool Is64BitOperatingSystem()
        {
            SelectQuery query = new SelectQuery("select AddressWidth from Win32_Processor");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
            ManagementObjectCollection moCollection = searcher.Get();
            foreach (ManagementObject mo in moCollection)
            {
                foreach (PropertyData property in mo.Properties)
                {
                    if (property.Name.Equals("AddressWidth"))
                    {
                        if (property.Value.ToString() == "64")
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        // <summary>
        // 检查注册表子健是否存在
        // </summary>
        // <param name="target">目标子健</param>
        // <param name="isRedirect">默认为false。如果传入true, 将自动为路径加上WOW6432Node节点。如传入的目标子健已包含"WOW6432Node"时，此值应为false。</param>
        // <returns>存在/不存在</returns>
        public static bool IsRegistrySubKeyExist(string target, bool isRedirect = false)
        {
            bool ret = false;
            RegistryKey key = null;
            string headerOfParentKey = target.ToLower().Substring(0, 4);
            string tailOfParentKey = target.Substring(5);
            if (!isRedirect)
            {
                if (Is64BitOperatingSystem())
                {
                    key = key.OpenSubKey(registryMapping[headerOfParentKey].ToString(), true)
                        .OpenSubKey(tailOfParentKey, true);
                }
                else
                {
                    key = key.OpenSubKey(registryMapping[headerOfParentKey].ToString(), false)
                        .OpenSubKey(tailOfParentKey, true);
                }
            }
            else
            {
                switch (target.ToLower().Substring(0, 4))
                {
                    case "hkcu":
                        key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(target.Substring(5).Insert(9, @"WOW6432Node\"), true);
                        break;
                    case "hklm":
                        key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(target.Substring(5).Insert(9, @"WOW6432Node\"), true);
                        break;
                    case "hkcr":
                        key = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(target.Substring(5).Insert(9, @"WOW6432Node\"), true);
                        break;
                    case "hkcc":
                        key = Microsoft.Win32.Registry.CurrentConfig.OpenSubKey(target.Substring(5).Insert(9, @"WOW6432Node\"), true);
                        break;
                    default:
                        break;
                }
            }
            if (key != null)
            {
                ret = true;
                key.Close();
            }
            return ret;
        }

        // <summary>
        // 获取注册表键值的值
        // </summary>
        // <param name="target">目标键值</param>
        // <param name="isRedirect">是否重定向，默认为false</param>
        // <returns></returns>
        public static object GetRegistryKeyValue(string target, bool isRedirect = false)
        {
            object ret = null;
            ret = RegistryKeyGetValueRedirect(target, isRedirect);
            return ret;
        }

        // <summary>
        // 设置/创建注册表键值。若上级路径不存在，会抛出异常
        // </summary>
        // <param name="target">目标键值</param>
        // <param name="value">目标键值的值</param>
        // <param name="isRedirect">是否重定向，默认为false</param>
        public static void SetRegistryKeyValue(string target, object value, bool isRedirect = false)
        {
            RegistryKeySetValue(target, value, isRedirect);

        }

        public static void CreateRegistry(string target)
        {
            string[] temp = null;
            if (null != target)
            {
                temp = target.Split('\\');
                if (!(temp[0].Equals("SOFTWARE") || temp[0].ToLower().Equals("hklm") || temp[0].ToLower().Equals("hkcu") || temp[0].ToLower().Equals("hkcr") || temp[0].ToLower().Equals("hkcc")))
                {
                    return;
                }
                string subkeypath = temp[0] + "\\";
                int i = 1;
                while (i < temp.Length)
                {
                    subkeypath += temp[i] + "\\";
                    RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(subkeypath, true);
                    if (key == null)
                    {
                        //不存在子健，则创建
                        Microsoft.Win32.Registry.CurrentUser.CreateSubKey(subkeypath);
                    }
                    i++;
                }
            }
        }

        // <summary>
        // 创建多级注册表键值
        // </summary>
        // <param name="target">键值全路径</param>
        // <param name="value">值</param>
        // <param name="isRedirect">是否重定向</param>
        public static void SetRegistryKeyValuePlus(string target, object value, bool isRedirect = false)
        {
            string[] temp = null;
            if (null != target)
            {
                temp = target.Split('\\');
                if (!(temp[0].ToLower().Equals("hklm") || temp[0].ToLower().Equals("hkcu") || temp[0].ToLower().Equals("hkcr") || temp[0].ToLower().Equals("hkcc")))
                {
                    return;
                }
                string subkeypath = temp[0] + "\\";
                int i = 1;
                while (i < temp.Length - 1)
                {
                    subkeypath += temp[i] + "\\";
                    if (!IsRegistrySubKeyExist(subkeypath, isRedirect))
                    {
                        //不存在子健，则创建
                        RCreateRegistrySubKey(subkeypath, isRedirect);
                    }
                    i++;
                }
            }

            RecursiveRegistryKeySetValue(target, value, isRedirect);

        }

        // <summary>
        // 创建注册表子健
        // </summary>
        // <param name="subKeyName">注册表子健路径</param>
        // <param name="isRedirect">默认为false。如果传入true, 将自动为路径加上WOW6432Node节点。如传入的目标子健已包含"WOW6432Node"时，此值应为false。</param>
        // <returns>运行结果成功/失败</returns>
        public static bool CreateRegistrySubKey(string subKeyName, bool isRedirect = false)
        {
            bool ret = false;
            string parentKeyName = subKeyName.Substring(0, subKeyName.LastIndexOf("\\") + 1);
            string subName = subKeyName.Substring(subKeyName.LastIndexOf("\\") + 1);
            string headerOfParentKey = parentKeyName.ToLower().Substring(0, 4);
            string tailOfParentKey = parentKeyName.Substring(5);
            RegistryKey parentKey = null;
            //if (!isRedirect)
            //{
            //    if (Environment.Is64BitOperatingSystem)
            //    {
            //        parentKey = RegistryKey.OpenSubKey(registryMapping[headerOfParentKey], RegistryView.Registry64).OpenSubKey(tailOfParentKey, true);
            //    }
            //    else
            //    {
            //        parentKey = RegistryKey.OpenSubKey(registryMapping[headerOfParentKey], RegistryView.Registry32).OpenSubKey(tailOfParentKey, true);
            //    }
            //}
            //else
            {
                switch (subKeyName.ToLower().Substring(0, 4))
                {
                    case "hkcu":
                        parentKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(parentKeyName.Substring(5).Insert(9, @"WOW6432Node\"), true);
                        break;
                    case "hklm":
                        parentKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(parentKeyName.Substring(5).Insert(9, @"WOW6432Node\"), true);
                        break;
                    case "hkcr":
                        parentKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(parentKeyName.Substring(5).Insert(9, @"WOW6432Node\"), true);
                        break;
                    case "hkcc":
                        parentKey = Microsoft.Win32.Registry.CurrentConfig.OpenSubKey(parentKeyName.Substring(5).Insert(9, @"WOW6432Node\"), true);
                        break;
                    default:
                        break;
                }
            }
            if (parentKey != null)
            {
                parentKey.CreateSubKey(subName);
                //ret = RenameSubKey(parentKey, subKeyName.Substring(subKeyName.LastIndexOf("\\") + 1), subKeyNewName.Substring(subKeyName.LastIndexOf("\\") + 1));
                parentKey.Close();
                ret = true;
            }
            return ret;
        }

        // <summary>
        // 删除注册表键值
        // </summary>
        // <param name="target">目标键值</param>
        // <param name="isRedirect">是否重定向，默认为false</param>
        public static void DeleteRegistryKeyValue(string target, bool isRedirect = false)
        {
            RegistryKeyDeleteValue(target, isRedirect);

        }

        // <summary>
        // 删除注册表子健
        // </summary>
        // <param name="subKeyName">子健名称</param>
        // <param name="isRedirect">默认为false。如果传入true, 将自动为路径加上WOW6432Node节点。当传入的目标子健已包含"WOW6432Node"时，此值应为false。</param>
        // <returns>成功/失败</returns>
        public static bool DeleteRegistrySubKey(string subKeyName, bool isRedirect = false)
        {
            bool ret = false;
            string parentKeyName = subKeyName.Substring(0, subKeyName.LastIndexOf("\\") + 1);

            string headerOfParentKey = parentKeyName.ToLower().Substring(0, 4);
            string tailOfParentKey = parentKeyName.Substring(5);

            RegistryKey parentKey = null;
            if (!isRedirect)
            {
                //if (Environment.Is64BitOperatingSystem)
                //{
                //    parentKey = RegistryKey.OpenSubKey(registryMapping[headerOfParentKey], RegistryView.Registry64).OpenSubKey(tailOfParentKey, true);
                //}
                //else
                //{
                //    parentKey = RegistryKey.OpenSubKey(registryMapping[headerOfParentKey], RegistryView.Registry32).OpenSubKey(tailOfParentKey, true);
                //}
            }
            else
            {
                switch (subKeyName.ToLower().Substring(0, 4))
                {
                    case "hkcu":
                        parentKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(parentKeyName.Substring(5).Insert(9, @"WOW6432Node\"), true);
                        break;
                    case "hklm":
                        parentKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(parentKeyName.Substring(5).Insert(9, @"WOW6432Node\"), true);
                        break;
                    case "hkcr":
                        parentKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(parentKeyName.Substring(5).Insert(9, @"WOW6432Node\"), true);
                        break;
                    case "hkcc":
                        parentKey = Microsoft.Win32.Registry.CurrentConfig.OpenSubKey(parentKeyName.Substring(5).Insert(9, @"WOW6432Node\"), true);
                        break;
                    default:
                        break;
                }
            }
            if (parentKey != null)
            {
                string[] temp = subKeyName.Split('\\');
                if (parentKey.OpenSubKey(temp[temp.Length - 1]) == null)
                {
                    return true;
                }
                parentKey.DeleteSubKeyTree(temp[temp.Length - 1]);
                parentKey.Close();
                ret = true;
            }
            return ret;
        }

        public static bool RegistryKeyExistRedirect(string target, bool isRedirect, object value = null, bool detectvalue = false)
        {
            bool ret = false;
            RegistryKey key = null;
            string valueName = null;
            key = RKeyRedirect(target, ref valueName, isRedirect);
            if (null != key)
            {
                string[] subKey = key.GetValueNames();
                foreach (string k in subKey)
                {
                    if (k.ToLower() == valueName.ToLower())
                    {
                        ret = true;
                        if (detectvalue)
                        {
                            if (key.GetValue(valueName).GetType().Equals(typeof(Byte[])) && value.GetType().Equals(typeof(Byte[])))
                            {
                                ret = ((Byte[])value).SequenceEqual((Byte[])key.GetValue(valueName));
                            }
                            else if (key.GetValue(valueName).GetType().Equals(typeof(string[])) && value.GetType().Equals(typeof(string[])))
                            {
                                ret = ((string[])value).SequenceEqual((string[])key.GetValue(valueName));
                            }
                            else if (value.Equals(key.GetValue(valueName)))
                            { ret = true; }
                            else
                            { ret = false; }
                        }
                    }
                }
                key.Close();
            }
            return ret;
        }

        public static bool RegistryKeyExist(string target, bool isRedirect, object value = null, bool detectvalue = false)
        {
            bool ret = false;
            RegistryKey key = null;
            string valueName = null;
            key = RKey(target, ref valueName, isRedirect);
            if (null != key)
            {
                string[] subKey = key.GetValueNames();
                foreach (string k in subKey)
                {
                    if (k.ToLower() == valueName.ToLower())
                    {
                        ret = true;
                        if (detectvalue)
                        {
                            if (key.GetValue(valueName).GetType().Equals(typeof(Byte[])) && value.GetType().Equals(typeof(Byte[])))
                            {
                                ret = ((Byte[])value).SequenceEqual((Byte[])key.GetValue(valueName));
                            }
                            else if (key.GetValue(valueName).GetType().Equals(typeof(string[])) && value.GetType().Equals(typeof(string[])))
                            {
                                ret = ((string[])value).SequenceEqual((string[])key.GetValue(valueName));
                            }
                            else if (value.Equals(key.GetValue(valueName)))
                            { ret = true; }
                            else
                            { ret = false; }
                        }
                    }
                }
                key.Close();
            }

            return ret;
        }

        public static object RegistryKeyGetValueRedirect(string target, bool isRedirect)
        {
            object ret = null;
            RegistryKey key = null;
            string valueName = null;
            key = RKeyRedirect(target, ref valueName, isRedirect);
            if (null != key)
            {
                ret = key.GetValue(valueName);
                key.Close();
            }
            return ret;
        }

        public static int[] GetSubStrCountInStr(string str, string substr, int StartPos)
        {
            int foundPos = -1;
            int count = 0;
            List<int> foundItems = new List<int>();
            do
            {
                foundPos = str.IndexOf(substr, StartPos);
                if (foundPos > -1)
                {
                    StartPos = foundPos + 1;
                    count++;
                    foundItems.Add(foundPos);
                }
            } while (foundPos > -1 && StartPos < str.Length);

            return ((int[])foundItems.ToArray());
        }

        public static RegistryKey GetRegistryKey(string path)
        {
            RegistryKey pregkey = null;
            RegistryHive registryHive = new RegistryHive();
            string currentUser = "HKEY_CURRENT_USER";
            string localMachine = "HKEY_LOCAL_MACHINE"; // HKLM
            string users = "HKEY_USER";

            if (path.Contains(currentUser))
            {
                registryHive = RegistryHive.CurrentUser;
            }
            else if (path.Contains("HKLM") || path.Contains(localMachine))
            {
                if (path.Contains("HKLM"))
                {
                    localMachine.Replace("HKLM", localMachine);
                }
                registryHive = RegistryHive.LocalMachine;
            }
            else if (path.Contains(users))
            {
                registryHive = RegistryHive.Users;
            }

            int locatoinValue = 0;
            int len = 0;
            if (path.Contains(currentUser))
            {
                int[] location = GetSubStrCountInStr(path, currentUser, 0);
                if (location.Length > 0)
                {
                    locatoinValue = location[0];
                }
                len = currentUser.Length;
            }
            else if (path.Contains(users))
            {
                int[] location = GetSubStrCountInStr(path, users, 0);
                if (location.Length > 0)
                {
                    locatoinValue = location[0];
                }
                len = users.Length;
            }
            else if (path.Contains(localMachine))
            {
                int[] location = GetSubStrCountInStr(path, localMachine, 0);
                if (location.Length > 0)
                {
                    locatoinValue = location[0];
                }
                len = localMachine.Length;
            }
            else
            {

            }

            string str = path.Substring(locatoinValue + len + 1, path.Length - locatoinValue - len - 1);
            pregkey = SystemInfo.GetRegistryKey(registryHive, str); // Microsoft.Win32.Registry.CurrentUser.OpenSubKey(str);
            return pregkey;
        }


        public static object RegistryKeyGetValue(string target, bool isRedirect)
        {
            object ret = null;
            RegistryKey key = null;
            string valueName = null;
            key = RKey(target, ref valueName, isRedirect);
            if (null != key)
            {
                ret = key.GetValue(valueName);
                key.Close();
            }
            return ret;
        }

        public static void RegistryKeySetValue(string target, object value, bool isRedirect)
        {
            RegistryKey key = null;
            string valueName = null;
            key = RKey(target, ref valueName, isRedirect);
            if (null != key)
            {
                key.SetValue(valueName, value);
                key.Close();
            }
            else
            {
            }
        }

        public static void RegistryKeyDeleteValueRedirect(string target, bool isRedirect)
        {
            RegistryKey key = null;
            string valueName = null;
            key = RKeyRedirect(target, ref valueName, isRedirect);
            if (null != key)
            {
                try
                {
                    key.DeleteValue(valueName);
                    key.Close();
                }
                catch (Exception e)
                {
                }

            }
            else
            {
            }
        }

        public static void RegistryKeyDeleteValue(string target, bool isRedirect)
        {
            RegistryKey key = null;
            string valueName = null;
            key = RKey(target, ref valueName, isRedirect);
            if (null != key)
            {
                key.DeleteValue(valueName);
                key.Close();
            }
            else
            {
            }
        }

        public static RegistryKey RKeyRedirect(string target, ref string valueName, bool isRedirect = false)
        {
            RegistryKey key = null;
            string[] temp = null;
            try
            {
                if (null != target)
                {
                    temp = target.Split('\\');
                }
                if (!(temp[0].ToLower().Equals("hklm") || temp[0].ToLower().Equals("hkcu") || temp[0].ToLower().Equals("hkcr") || temp[0].ToLower().Equals("hkcc")))
                {
                    return key;
                }
                valueName = temp.Last();
                switch (temp[0].ToLower())
                {
                    case "hklm":
                        {
                            string path = null;
                            if (temp[1].ToLower() == "software" && isRedirect)
                            {
                                for (int i = 1; i < temp.Length - 1; i++)
                                {
                                    path += (temp[i] + "\\");
                                }
                                path = path.TrimEnd('\\');
                                key = HKLM.OpenSubKey(path, true);
                            }
                            else
                            {
                                for (int i = 1; i < temp.Length - 1; i++)
                                {
                                    path += (temp[i] + "\\");
                                }
                                path = path.TrimEnd('\\');
                                key = HKLM.OpenSubKey(path, true);
                            }
                        }
                        break;
                    case "hkcu":
                        {
                            string path = null;
                            if (temp[1].ToLower() == "software" && isRedirect)
                            {
                                for (int i = 1; i < temp.Length - 1; i++)
                                {
                                    path += (temp[i] + "\\");
                                }
                                path = path.TrimEnd('\\');
                                key = HKCU.OpenSubKey(path, true);
                            }
                            else
                            {
                                for (int i = 1; i < temp.Length - 1; i++)
                                {
                                    path += (temp[i] + "\\");
                                }
                                path = path.TrimEnd('\\');
                                //key = RegistryKey.OpenSubKey(RegistryHive.CurrentUser, RegistryView.Registry64);
                                key = key.OpenSubKey(path, true);
                            }
                        }
                        break;
                    case "hkcr":
                        {
                            string path = null;
                            for (int i = 1; i < temp.Length - 1; i++)
                            {
                                path += (temp[i]) + "\\";
                            }
                            path = path.TrimEnd('\\');
                            key = HKCR.OpenSubKey(path, true);
                            break;
                        }
                    case "hkcc":
                        {
                            string path = null;
                            for (int i = 1; i < temp.Length - 1; i++)
                            {
                                path += (temp[i]) + "\\";
                            }
                            path = path.TrimEnd('\\');
                            key = HKCC.OpenSubKey(path, true);
                            break;
                        }
                }
                return key;
            }
            catch (Exception ex)
            {
                if (null != key)
                { key.Close(); }
                throw (ex);
            }
        }

        public static RegistryKey RKey(string target, ref string valueName, bool isRedirect = false)
        {
            RegistryKey key = null;
            string[] temp = null;
            try
            {
                if (null != target)
                {
                    temp = target.Split('\\');
                }
                if (!(temp[0].ToLower().Equals("hklm") || temp[0].ToLower().Equals("hkcu") || temp[0].ToLower().Equals("hkcr") || temp[0].ToLower().Equals("hkcc")))
                {
                    return key;
                }
                valueName = temp.Last();
                switch (temp[0].ToLower())
                {
                    case "hklm":
                        {
                            string path = null;
                            if (temp[1].ToLower() == "software" && isRedirect)
                            {
                                for (int i = 2; i < temp.Length - 1; i++)
                                { path += (temp[i] + "\\"); }
                                path = path.TrimEnd('\\');
                                key = HKLM.OpenSubKey("SOFTWARE\\WOW6432Node", true).OpenSubKey(path, true);
                            }
                            else
                            {
                                for (int i = 1; i < temp.Length - 1; i++)
                                { path += (temp[i] + "\\"); }
                                path = path.TrimEnd('\\');
                                key = HKLM.OpenSubKey(path, true);
                            }
                        }
                        break;
                    case "hkcu":
                        {
                            string path = null;
                            if (temp[1].ToLower() == "software" && isRedirect)
                            {
                                for (int i = 2; i < temp.Length - 1; i++)
                                { path += (temp[i] + "\\"); }
                                path = path.TrimEnd('\\');
                                key = HKCU.OpenSubKey("SOFTWARE\\WOW6432Node", true).OpenSubKey(path, true);
                            }
                            else
                            {
                                for (int i = 1; i < temp.Length - 1; i++)
                                { path += (temp[i] + "\\"); }
                                path = path.TrimEnd('\\');
                                key = HKCU.OpenSubKey(path, true);
                            }
                        }
                        break;
                    case "hkcr":
                        {
                            string path = null;
                            for (int i = 1; i < temp.Length - 1; i++)
                            { path += (temp[i]) + "\\"; }
                            path = path.TrimEnd('\\');
                            key = HKCR.OpenSubKey(path, true);
                            break;
                        }
                    case "hkcc":
                        {
                            string path = null;
                            for (int i = 1; i < temp.Length - 1; i++)
                            { path += (temp[i]) + "\\"; }
                            path = path.TrimEnd('\\');
                            key = HKCC.OpenSubKey(path, true);
                            break;
                        }
                }
                return key;
            }
            catch (Exception ex)
            {
                if (null != key)
                { key.Close(); }
                throw (ex);
            }
        }
        //In case wow6432node is used for hklm\software OR hkcu , Registry32 is open ,otherwise Registry64 is open
        public static RegistryKey OpenRegistryKey_IgnoreOurArchitect(string target)
        {
            RegistryKey key = null;
            string[] temp = null;
            try
            {
                if (null != target)
                {
                    temp = target.Split('\\');
                }
                if (!(temp[0].ToLower().Equals("hklm") || temp[0].ToLower().Equals("hkcu") || temp[0].ToLower().Equals("hkcr") || temp[0].ToLower().Equals("hkcc")))
                {
                    return key;
                }
                string path = string.Empty;
                RegistryKey root = null;
                switch (temp[0].ToLower())
                {
                    case "hklm":
                        {
                            //

                        }
                        break;
                    case "hkcu":
                        {

                        }
                        break;
                    case "hkcr":
                        {
                            root = HKCR;
                            break;
                        }
                    case "hkcc":
                        {
                            root = HKCC;
                            break;
                        }
                }
                for (int i = 1; i < temp.Length; i++)
                {
                    path = System.IO.Path.Combine(path, temp[i]);
                }
                key = root.OpenSubKey(path, true);
                return key;
            }
            catch (Exception ex)
            {
                if (null != key)
                { key.Close(); }
                throw (ex);
            }
        }
        public static bool RenameSubKey(RegistryKey parentKey, string subKeyName, string newSubKeyName)
        {
            CopyKey(parentKey, subKeyName, newSubKeyName);
            parentKey.DeleteSubKeyTree(subKeyName);
            return true;
        }

        public static bool CopyKey(RegistryKey parentKey, string keyNameToCopy, string newKeyName)
        {
            //Create new key
            RegistryKey destinationKey = parentKey.CreateSubKey(newKeyName);

            //Open the sourceKey we are copying from
            RegistryKey sourceKey = parentKey.OpenSubKey(keyNameToCopy);
            RecurseCopyKey(sourceKey, destinationKey);
            return true;
        }

        public static void RecurseCopyKey(RegistryKey sourceKey, RegistryKey destinationKey)
        {
            //copy all the values
            foreach (string valueName in sourceKey.GetValueNames())
            {
                object objValue = sourceKey.GetValue(valueName);
                RegistryValueKind valKind = sourceKey.GetValueKind(valueName);
                destinationKey.SetValue(valueName, objValue, valKind);
            }

            //For Each subKey 
            //Create a new subKey in destinationKey 
            //Call myself 
            foreach (string sourceSubKeyName in sourceKey.GetSubKeyNames())
            {
                RegistryKey sourceSubKey = sourceKey.OpenSubKey(sourceSubKeyName);
                RegistryKey destSubKey = destinationKey.CreateSubKey(sourceSubKeyName);
                RecurseCopyKey(sourceSubKey, destSubKey);
            }
        }

        public static void RecursiveRegistryKeySetValueRedirect(string target, object value, bool isRedirect)
        {
            RegistryKey key = null;
            string valueName = null;
            key = RKeyRedirect(target, ref valueName, isRedirect);
            if (null != key)
            {
                key.SetValue(valueName, value);
                key.Close();
            }
            else
            {
            }
        }

        public static void RecursiveRegistryKeySetValue(string target, object value, bool isRedirect)
        {
            RegistryKey key = null;
            string valueName = null;
            key = RKey(target, ref valueName, isRedirect);
            if (null != key)
            {
                key.SetValue(valueName, value);
                key.Close();
            }
            else
            {
            }
        }

        public static bool RCreateRegistrySubKey(string subKeyName, bool isRedirect = false)
        {
            bool ret = false;
            subKeyName = subKeyName.Substring(0, subKeyName.LastIndexOf("\\"));
            string parentKeyName = subKeyName.Substring(0, subKeyName.LastIndexOf("\\") + 1);
            string subName = subKeyName.Substring(subKeyName.LastIndexOf("\\") + 1);
            string headerOfParentKey = parentKeyName.ToLower().Substring(0, 4);
            string tailOfParentKey = parentKeyName.Substring(5);
            RegistryKey parentKey = null;
            if (!isRedirect)
            {

            }
            else
            {
                switch (subKeyName.ToLower().Substring(0, 4))
                {
                    case "hkcu":
                        parentKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(parentKeyName.Substring(5).Insert(9, @"WOW6432Node\"), true);
                        break;
                    case "hklm":
                        parentKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(parentKeyName.Substring(5).Insert(9, @"WOW6432Node\"), true);
                        break;
                    case "hkcr":
                        parentKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(parentKeyName.Substring(5).Insert(9, @"WOW6432Node\"), true);
                        break;
                    case "hkcc":
                        parentKey = Microsoft.Win32.Registry.CurrentConfig.OpenSubKey(parentKeyName.Substring(5).Insert(9, @"WOW6432Node\"), true);
                        break;
                    default:
                        break;
                }
            }
            if (parentKey != null)
            {
                parentKey.CreateSubKey(subName);
                parentKey.Close();
                ret = true;
            }
            return ret;
        }

        public static void RecursiveRegistryKeySetValueRedirect(string target, object value, RegistryValueKind valueType, bool isRedirect)
        {
            RegistryKey key = null;
            string valueName = null;
            key = RKeyRedirect(target, ref valueName, isRedirect);
            if (null != key)
            {
                //key.SetValue(valueName, value, valueType);

                if (valueType == RegistryValueKind.Binary)
                {
                    key.SetValue(valueName, new byte[] { Convert.ToByte(value) }, valueType);
                }
                else if (valueType == RegistryValueKind.DWord || valueType == RegistryValueKind.QWord)
                {
                    key.SetValue(valueName, Convert.ToInt64(value), valueType);
                }
                else
                { key.SetValue(valueName, value, valueType); }


                key.Close();
            }
            else
            {
            }
        }

        public static void RecursiveRegistryKeySetValue(string target, object value, RegistryValueKind valueType, bool isRedirect)
        {
            RegistryKey key = null;
            string valueName = null;
            key = RKey(target, ref valueName, isRedirect);
            if (null != key)
            {
                key.SetValue(valueName, value, valueType);
                key.Close();
            }
            else
            {
            }
        }

        #endregion
    }
}
