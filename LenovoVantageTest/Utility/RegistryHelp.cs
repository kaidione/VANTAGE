using LenovoVantageTest.LogHelper;
using LenovoVantageTest.Steps.UWP.IntelligentCooling;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

//=================================
//REG_SZ return object type is string
//REG_BINARY return object type is byte[]
//REG_DWORD return object is Int32
//REG_QWORD return object is Int64
//REG_MULTI_SZ return object is string[]
//REG_EXPAND_SZ return objecct is string
//===================================

namespace LenovoVantageTest.Utility
{
    class RegistryHelp
    {
        static readonly RegistryKey HKCU = Registry.CurrentUser;
        static readonly RegistryKey HKLM = Registry.LocalMachine;
        static readonly RegistryKey HKCR = Registry.ClassesRoot;
        static readonly RegistryKey HKCC = Registry.CurrentConfig;

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
            if (Environment.Is64BitOperatingSystem)
            {
                if (Environment.Is64BitProcess)
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
        public static RegistryKey OpenKey(string regeditPath)
        {
            try
            {
                RegistryKey hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, Environment.Is64BitOperatingSystem ? RegistryView.Registry64 : RegistryView.Registry32);
                RegistryKey cv = hklm.OpenSubKey(regeditPath, true);
                return cv;
            }
            catch
            {
                throw new Exception("Failed: get value from regedit.");
            }
        }

        public static string GetValueFromRegedit(string names, string regeditPath)
        {
            string value = null;
            RegistryKey cv = OpenKey(regeditPath);
            if (cv != null)
            {
                try
                {
                    value = cv.GetValue(names, null).ToString();
                }
                catch
                {
                    value = null;
                }
            }
            return value;

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
                if (Environment.Is64BitOperatingSystem)
                {
                    key = RegistryKey.OpenBaseKey(registryMapping[headerOfParentKey], RegistryView.Registry64).OpenSubKey(tailOfParentKey, true);
                }
                else
                {
                    key = RegistryKey.OpenBaseKey(registryMapping[headerOfParentKey], RegistryView.Registry32).OpenSubKey(tailOfParentKey, true);
                }
            }
            else
            {
                switch (target.ToLower().Substring(0, 4))
                {
                    case "hkcu":
                        key = Registry.CurrentUser.OpenSubKey(target.Substring(5).Insert(9, @"WOW6432Node\"), true);
                        break;
                    case "hklm":
                        key = Registry.LocalMachine.OpenSubKey(target.Substring(5).Insert(9, @"WOW6432Node\"), true);
                        break;
                    case "hkcr":
                        key = Registry.ClassesRoot.OpenSubKey(target.Substring(5).Insert(9, @"WOW6432Node\"), true);
                        break;
                    case "hkcc":
                        key = Registry.CurrentConfig.OpenSubKey(target.Substring(5).Insert(9, @"WOW6432Node\"), true);
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
            if (Environment.Is64BitOperatingSystem)
            {
                if (Environment.Is64BitProcess)
                {
                    ret = RegistryKeyGetValue(target, isRedirect);
                }
                else
                {
                    ret = RegistryKeyGetValueRedirect(target, isRedirect);
                }
            }
            else
            {
                ret = RegistryKeyGetValue(target, isRedirect);
            }
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
            if (Environment.Is64BitOperatingSystem)
            {
                if (Environment.Is64BitProcess)
                {
                    RegistryKeySetValue(target, value, isRedirect);
                }
                else
                {
                    RegistryKeySetValueRedirect(target, value, isRedirect);
                }
            }
            else
            {
                RegistryKeySetValue(target, value, isRedirect);
            }
        }

        public static void CreateRegistry(string target)
        {
            string[] temp = null;
            if (null != target)
            {
                temp = target.Split('\\');
                if (!(temp[0].Equals("SOFTWARE") || temp[0].ToLower().Equals("hklm") || temp[0].ToLower().Equals("hkcu") || temp[0].ToLower().Equals("hkcr") || temp[0].ToLower().Equals("hkcc")))
                {
                    Logger.Instance.WriteLog("Wrong registry key", LogType.Error);
                    return;
                }
                string subkeypath = temp[0] + "\\";
                int i = 1;
                while (i < temp.Length)
                {
                    subkeypath += temp[i] + "\\";
                    RegistryKey key = Registry.CurrentUser.OpenSubKey(subkeypath, true);
                    if (key == null)
                    {
                        //不存在子健，则创建
                        Registry.CurrentUser.CreateSubKey(subkeypath);
                    }
                    i++;
                }
            }
        }
        // <summary>
        // 递归设置/创建注册表键值。若上级路径不存在，则创建。
        // </summary>
        // <param name="target">目标键值</param>
        // <param name="value">目标键值的值</param>
        // <param name="valueType">目标键值的值类型</param>
        // <param name="isRedirect">是否重定向，默认为false</param>
        public static void SetRegistryKeyValuePlus(string target, object value, RegistryValueKind valueType, bool isRedirect = false)
        {
            string[] temp = null;
            if (null != target)
            {
                temp = target.Split('\\');
                if (!(temp[0].ToLower().Equals("hklm") || temp[0].ToLower().Equals("hkcu") || temp[0].ToLower().Equals("hkcr") || temp[0].ToLower().Equals("hkcc")))
                {
                    Logger.Instance.WriteLog("Wrong registry key", LogType.Error);
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

            if (Environment.Is64BitOperatingSystem)
            {
                if (Environment.Is64BitProcess)
                {
                    RecursiveRegistryKeySetValue(target, value, valueType, isRedirect);
                }
                else
                {
                    RecursiveRegistryKeySetValueRedirect(target, value, valueType, isRedirect);
                }
            }
            else
            {
                RecursiveRegistryKeySetValue(target, value, valueType, isRedirect);
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
                    Logger.Instance.WriteLog("Wrong registry key", LogType.Error);
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

            if (Environment.Is64BitOperatingSystem)
            {
                if (Environment.Is64BitProcess)
                {
                    RecursiveRegistryKeySetValue(target, value, isRedirect);
                }
                else
                {
                    RecursiveRegistryKeySetValueRedirect(target, value, isRedirect);
                }
            }
            else
            {
                RecursiveRegistryKeySetValue(target, value, isRedirect);
            }
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
            if (!isRedirect)
            {
                if (Environment.Is64BitOperatingSystem)
                {
                    parentKey = RegistryKey.OpenBaseKey(registryMapping[headerOfParentKey], RegistryView.Registry64).OpenSubKey(tailOfParentKey, true);
                }
                else
                {
                    parentKey = RegistryKey.OpenBaseKey(registryMapping[headerOfParentKey], RegistryView.Registry32).OpenSubKey(tailOfParentKey, true);
                }
            }
            else
            {
                switch (subKeyName.ToLower().Substring(0, 4))
                {
                    case "hkcu":
                        parentKey = Registry.CurrentUser.OpenSubKey(parentKeyName.Substring(5).Insert(9, @"WOW6432Node\"), true);
                        break;
                    case "hklm":
                        parentKey = Registry.LocalMachine.OpenSubKey(parentKeyName.Substring(5).Insert(9, @"WOW6432Node\"), true);
                        break;
                    case "hkcr":
                        parentKey = Registry.ClassesRoot.OpenSubKey(parentKeyName.Substring(5).Insert(9, @"WOW6432Node\"), true);
                        break;
                    case "hkcc":
                        parentKey = Registry.CurrentConfig.OpenSubKey(parentKeyName.Substring(5).Insert(9, @"WOW6432Node\"), true);
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
            if (Environment.Is64BitOperatingSystem)
            {
                if (Environment.Is64BitProcess)
                {
                    RegistryKeyDeleteValue(target, isRedirect);
                }
                else
                {
                    RegistryKeyDeleteValueRedirect(target, isRedirect);
                }
            }
            else
            {
                RegistryKeyDeleteValue(target, isRedirect);
            }
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
                if (Environment.Is64BitOperatingSystem)
                {
                    parentKey = RegistryKey.OpenBaseKey(registryMapping[headerOfParentKey], RegistryView.Registry64).OpenSubKey(tailOfParentKey, true);
                }
                else
                {
                    parentKey = RegistryKey.OpenBaseKey(registryMapping[headerOfParentKey], RegistryView.Registry32).OpenSubKey(tailOfParentKey, true);
                }
            }
            else
            {
                switch (subKeyName.ToLower().Substring(0, 4))
                {
                    case "hkcu":
                        parentKey = Registry.CurrentUser.OpenSubKey(parentKeyName.Substring(5).Insert(9, @"WOW6432Node\"), true);
                        break;
                    case "hklm":
                        parentKey = Registry.LocalMachine.OpenSubKey(parentKeyName.Substring(5).Insert(9, @"WOW6432Node\"), true);
                        break;
                    case "hkcr":
                        parentKey = Registry.ClassesRoot.OpenSubKey(parentKeyName.Substring(5).Insert(9, @"WOW6432Node\"), true);
                        break;
                    case "hkcc":
                        parentKey = Registry.CurrentConfig.OpenSubKey(parentKeyName.Substring(5).Insert(9, @"WOW6432Node\"), true);
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

        // <summary>
        // 重命名注册表键值
        // </summary>
        // <param name="target">目标键值</param>
        // <param name="isRedirect">是否重定向，默认为false</param>
        public static void RenameRegistryKeyValueName(string target, bool isRedirect = false)
        {
            if (Environment.Is64BitOperatingSystem)
            {
                if (Environment.Is64BitProcess)
                {
                    RegistryKeyRenameValueName(target, isRedirect);
                }
                else
                {
                    RegistryKeyRenameValueNameRedirect(target, isRedirect);
                }
            }
            else
            {
                RegistryKeyRenameValueName(target, isRedirect);
            }
        }

        // <summary>
        // 重命名注册表子健
        // </summary>
        // <param name="subKeyName">目标子健</param>
        // <param name="subKeyNewName">子健新名称</param>
        // <returns>成功/失败</returns>
        public static bool RenameRegistrySubKey(string subKeyName, string subKeyNewName)
        {
            bool ret = false;
            string parentKeyName = subKeyName.Substring(0, subKeyName.LastIndexOf("\\") + 1);
            string headerOfParentKey = parentKeyName.ToLower().Substring(0, 4);
            string tailOfParentKey = parentKeyName.Substring(5);

            RegistryKey parentKey = null;
            if (Environment.Is64BitOperatingSystem)
            {
                parentKey = RegistryKey.OpenBaseKey(registryMapping[headerOfParentKey], RegistryView.Registry64).OpenSubKey(tailOfParentKey, true);
            }
            else
            {
                parentKey = RegistryKey.OpenBaseKey(registryMapping[headerOfParentKey], RegistryView.Registry32).OpenSubKey(tailOfParentKey, true);
            }

            if (parentKey != null)
            {
                ret = RenameSubKey(parentKey, subKeyName.Substring(subKeyName.LastIndexOf("\\") + 1), subKeyNewName.Substring(subKeyName.LastIndexOf("\\") + 1));
                parentKey.Close();
            }
            return ret;
        }

        [Obsolete]
        public static bool CreateRegistrySubKey_old(string subKeyName, bool isRedirect = false)
        {
            bool ret = false;
            string parentKeyName = subKeyName.Substring(0, subKeyName.LastIndexOf("\\") + 1);
            string subName = subKeyName.Substring(subKeyName.LastIndexOf("\\") + 1);
            RegistryKey parentKey = null;
            if (!isRedirect)
            {
                switch (parentKeyName.ToLower().Substring(0, 4))
                {
                    case "hkcu":
                        //parentKey = Registry.CurrentUser.OpenSubKey(parentKeyName.Substring(5), true);
                        if (Environment.Is64BitOperatingSystem)
                        {
                            parentKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64).OpenSubKey(parentKeyName.Substring(5), true);
                        }
                        else
                        {
                            parentKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry32).OpenSubKey(parentKeyName.Substring(5), true);
                        }
                        break;
                    case "hklm":
                        //parentKey = Registry.LocalMachine.OpenSubKey(parentKeyName.Substring(5), true);
                        if (Environment.Is64BitOperatingSystem)
                        {
                            parentKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey(parentKeyName.Substring(5), true);
                        }
                        else
                        {
                            parentKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey(parentKeyName.Substring(5), true);
                        }
                        break;
                    case "hkcr":
                        //parentKey = Registry.ClassesRoot.OpenSubKey(parentKeyName.Substring(5), true);
                        if (Environment.Is64BitOperatingSystem)
                        {
                            parentKey = RegistryKey.OpenBaseKey(RegistryHive.ClassesRoot, RegistryView.Registry64).OpenSubKey(parentKeyName.Substring(5), true);
                        }
                        else
                        {
                            parentKey = RegistryKey.OpenBaseKey(RegistryHive.ClassesRoot, RegistryView.Registry32).OpenSubKey(parentKeyName.Substring(5), true);
                        }
                        break;
                    case "hkcc":
                        //parentKey = Registry.CurrentConfig.OpenSubKey(parentKeyName.Substring(5), true);
                        if (Environment.Is64BitOperatingSystem)
                        {
                            parentKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentConfig, RegistryView.Registry64).OpenSubKey(parentKeyName.Substring(5), true);
                        }
                        else
                        {
                            parentKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentConfig, RegistryView.Registry32).OpenSubKey(parentKeyName.Substring(5), true);
                        }
                        break;
                    default:
                        break;
                }
            }
            else
            {
                switch (subKeyName.ToLower().Substring(0, 4))
                {
                    case "hkcu":
                        parentKey = Registry.CurrentUser.OpenSubKey(parentKeyName.Substring(5).Insert(9, @"WOW6432Node\"), true);
                        break;
                    case "hklm":
                        parentKey = Registry.LocalMachine.OpenSubKey(parentKeyName.Substring(5).Insert(9, @"WOW6432Node\"), true);
                        break;
                    case "hkcr":
                        parentKey = Registry.ClassesRoot.OpenSubKey(parentKeyName.Substring(5).Insert(9, @"WOW6432Node\"), true);
                        break;
                    case "hkcc":
                        parentKey = Registry.CurrentConfig.OpenSubKey(parentKeyName.Substring(5).Insert(9, @"WOW6432Node\"), true);
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

        [Obsolete]
        public static bool RenameRegistrySubKey_old(string subKeyName, string subKeyNewName)
        {
            bool ret = false;
            string parentKeyName = subKeyName.Substring(0, subKeyName.LastIndexOf("\\") + 1);
            RegistryKey parentKey = null;
            switch (parentKeyName.ToLower().Substring(0, 4))
            {
                case "hkcu":
                    if (Environment.Is64BitOperatingSystem)
                    {
                        parentKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64).OpenSubKey(parentKeyName.Substring(5), true);
                    }
                    else
                    {
                        parentKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry32).OpenSubKey(parentKeyName.Substring(5), true);
                    }
                    break;
                case "hklm":
                    if (Environment.Is64BitOperatingSystem)
                    {
                        parentKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey(parentKeyName.Substring(5), true);
                    }
                    else
                    {
                        parentKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey(parentKeyName.Substring(5), true);
                    }
                    break;
                case "hkcr":
                    if (Environment.Is64BitOperatingSystem)
                    {
                        parentKey = RegistryKey.OpenBaseKey(RegistryHive.ClassesRoot, RegistryView.Registry64).OpenSubKey(parentKeyName.Substring(5), true);
                    }
                    else
                    {
                        parentKey = RegistryKey.OpenBaseKey(RegistryHive.ClassesRoot, RegistryView.Registry32).OpenSubKey(parentKeyName.Substring(5), true);
                    }
                    break;
                case "hkcc":
                    if (Environment.Is64BitOperatingSystem)
                    {
                        parentKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentConfig, RegistryView.Registry64).OpenSubKey(parentKeyName.Substring(5), true);
                    }
                    else
                    {
                        parentKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentConfig, RegistryView.Registry32).OpenSubKey(parentKeyName.Substring(5), true);
                    }
                    break;
                default:
                    break;
            }
            if (parentKey != null)
            {
                ret = RenameSubKey(parentKey, subKeyName.Substring(subKeyName.LastIndexOf("\\") + 1), subKeyNewName.Substring(subKeyName.LastIndexOf("\\") + 1));
                parentKey.Close();
            }
            return ret;
        }

        [Obsolete]
        public static bool DeleteRegistrySubKey_old(string subKeyName, bool isRedirect = false)
        {
            bool ret = false;
            string parentKeyName = subKeyName.Substring(0, subKeyName.LastIndexOf("\\") + 1);
            RegistryKey parentKey = null;
            if (!isRedirect)
            {
                switch (parentKeyName.ToLower().Substring(0, 4))
                {
                    case "hkcu":
                        //parentKey = Registry.CurrentUser.OpenSubKey(parentKeyName.Substring(5), true);
                        if (Environment.Is64BitOperatingSystem)
                        {
                            parentKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64).OpenSubKey(parentKeyName.Substring(5), true);
                        }
                        else
                        {
                            parentKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry32).OpenSubKey(parentKeyName.Substring(5), true);
                        }
                        break;
                    case "hklm":
                        //parentKey = Registry.LocalMachine.OpenSubKey(parentKeyName.Substring(5), true);
                        if (Environment.Is64BitOperatingSystem)
                        {
                            parentKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey(parentKeyName.Substring(5), true);
                        }
                        else
                        {
                            parentKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey(parentKeyName.Substring(5), true);
                        }
                        break;
                    case "hkcr":
                        //parentKey = Registry.ClassesRoot.OpenSubKey(parentKeyName.Substring(5), true);
                        if (Environment.Is64BitOperatingSystem)
                        {
                            parentKey = RegistryKey.OpenBaseKey(RegistryHive.ClassesRoot, RegistryView.Registry64).OpenSubKey(parentKeyName.Substring(5), true);
                        }
                        else
                        {
                            parentKey = RegistryKey.OpenBaseKey(RegistryHive.ClassesRoot, RegistryView.Registry32).OpenSubKey(parentKeyName.Substring(5), true);
                        }
                        break;
                    case "hkcc":
                        //parentKey = Registry.CurrentConfig.OpenSubKey(parentKeyName.Substring(5), true);
                        if (Environment.Is64BitOperatingSystem)
                        {
                            parentKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentConfig, RegistryView.Registry64).OpenSubKey(parentKeyName.Substring(5), true);
                        }
                        else
                        {
                            parentKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentConfig, RegistryView.Registry32).OpenSubKey(parentKeyName.Substring(5), true);
                        }
                        break;
                    default:
                        break;
                }
            }
            else
            {
                switch (subKeyName.ToLower().Substring(0, 4))
                {
                    case "hkcu":
                        parentKey = Registry.CurrentUser.OpenSubKey(parentKeyName.Substring(5).Insert(9, @"WOW6432Node\"), true);
                        break;
                    case "hklm":
                        parentKey = Registry.LocalMachine.OpenSubKey(parentKeyName.Substring(5).Insert(9, @"WOW6432Node\"), true);
                        break;
                    case "hkcr":
                        parentKey = Registry.ClassesRoot.OpenSubKey(parentKeyName.Substring(5).Insert(9, @"WOW6432Node\"), true);
                        break;
                    case "hkcc":
                        parentKey = Registry.CurrentConfig.OpenSubKey(parentKeyName.Substring(5).Insert(9, @"WOW6432Node\"), true);
                        break;
                    default:
                        break;
                }
            }
            if (parentKey != null)
            {
                string[] temp = subKeyName.Split('\\');
                parentKey.DeleteSubKeyTree(temp[temp.Length - 1]);
                parentKey.Close();
                ret = true;
            }
            return ret;
        }

        [Obsolete]
        public static bool RCreateRegistrySubKey_old(string subKeyName, bool isRedirect = false)
        {
            subKeyName = subKeyName.Substring(0, subKeyName.LastIndexOf("\\"));
            bool ret = false;
            string parentKeyName = subKeyName.Substring(0, subKeyName.LastIndexOf("\\") + 1);
            string subName = subKeyName.Substring(subKeyName.LastIndexOf("\\") + 1);
            RegistryKey parentKey = null;
            if (!isRedirect)
            {
                switch (parentKeyName.ToLower().Substring(0, 4))
                {
                    case "hkcu":
                        //parentKey = Registry.CurrentUser.OpenSubKey(parentKeyName.Substring(5), true);
                        if (Environment.Is64BitOperatingSystem)
                        {
                            parentKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64).OpenSubKey(parentKeyName.Substring(5), true);
                        }
                        else
                        {
                            parentKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry32).OpenSubKey(parentKeyName.Substring(5), true);
                        }
                        break;
                    case "hklm":
                        //parentKey = Registry.LocalMachine.OpenSubKey(parentKeyName.Substring(5), true);
                        if (Environment.Is64BitOperatingSystem)
                        {
                            parentKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey(parentKeyName.Substring(5), true);
                        }
                        else
                        {
                            parentKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey(parentKeyName.Substring(5), true);
                        }
                        break;
                    case "hkcr":
                        //parentKey = Registry.ClassesRoot.OpenSubKey(parentKeyName.Substring(5), true);
                        if (Environment.Is64BitOperatingSystem)
                        {
                            parentKey = RegistryKey.OpenBaseKey(RegistryHive.ClassesRoot, RegistryView.Registry64).OpenSubKey(parentKeyName.Substring(5), true);
                        }
                        else
                        {
                            parentKey = RegistryKey.OpenBaseKey(RegistryHive.ClassesRoot, RegistryView.Registry32).OpenSubKey(parentKeyName.Substring(5), true);
                        }
                        break;
                    case "hkcc":
                        //parentKey = Registry.CurrentConfig.OpenSubKey(parentKeyName.Substring(5), true);
                        if (Environment.Is64BitOperatingSystem)
                        {
                            parentKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentConfig, RegistryView.Registry64).OpenSubKey(parentKeyName.Substring(5), true);
                        }
                        else
                        {
                            parentKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentConfig, RegistryView.Registry32).OpenSubKey(parentKeyName.Substring(5), true);
                        }
                        break;
                    default:
                        break;
                }
            }
            else
            {
                switch (subKeyName.ToLower().Substring(0, 4))
                {
                    case "hkcu":
                        parentKey = Registry.CurrentUser.OpenSubKey(parentKeyName.Substring(5).Insert(9, @"WOW6432Node\"), true);
                        break;
                    case "hklm":
                        parentKey = Registry.LocalMachine.OpenSubKey(parentKeyName.Substring(5).Insert(9, @"WOW6432Node\"), true);
                        break;
                    case "hkcr":
                        parentKey = Registry.ClassesRoot.OpenSubKey(parentKeyName.Substring(5).Insert(9, @"WOW6432Node\"), true);
                        break;
                    case "hkcc":
                        parentKey = Registry.CurrentConfig.OpenSubKey(parentKeyName.Substring(5).Insert(9, @"WOW6432Node\"), true);
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
            }
            return ret;
        }

        [Obsolete]
        public static bool IsRegistrySubKeyExist_old(string target, bool isRedirect = false)
        {
            bool ret = false;
            RegistryKey key = null;
            if (!isRedirect)
            {
                switch (target.ToLower().Substring(0, 4))
                {
                    case "hkcu":
                        //parentKey = Registry.CurrentUser.OpenSubKey(parentKeyName.Substring(5), true);
                        if (Environment.Is64BitOperatingSystem)
                        {
                            key = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64).OpenSubKey(target.Substring(5), true);
                        }
                        else
                        {
                            key = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry32).OpenSubKey(target.Substring(5), true);
                        }
                        break;
                    case "hklm":
                        //parentKey = Registry.LocalMachine.OpenSubKey(parentKeyName.Substring(5), true);
                        if (Environment.Is64BitOperatingSystem)
                        {
                            key = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey(target.Substring(5), true);
                        }
                        else
                        {
                            key = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey(target.Substring(5), true);
                        }
                        break;
                    case "hkcr":
                        //parentKey = Registry.ClassesRoot.OpenSubKey(parentKeyName.Substring(5), true);
                        if (Environment.Is64BitOperatingSystem)
                        {
                            key = RegistryKey.OpenBaseKey(RegistryHive.ClassesRoot, RegistryView.Registry64).OpenSubKey(target.Substring(5), true);
                        }
                        else
                        {
                            key = RegistryKey.OpenBaseKey(RegistryHive.ClassesRoot, RegistryView.Registry32).OpenSubKey(target.Substring(5), true);
                        }
                        break;
                    case "hkcc":
                        //parentKey = Registry.CurrentConfig.OpenSubKey(parentKeyName.Substring(5), true);
                        if (Environment.Is64BitOperatingSystem)
                        {
                            key = RegistryKey.OpenBaseKey(RegistryHive.CurrentConfig, RegistryView.Registry64).OpenSubKey(target.Substring(5), true);
                        }
                        else
                        {
                            key = RegistryKey.OpenBaseKey(RegistryHive.CurrentConfig, RegistryView.Registry32).OpenSubKey(target.Substring(5), true);
                        }
                        break;
                    default:
                        break;
                }
            }
            else
            {
                switch (target.ToLower().Substring(0, 4))
                {
                    case "hkcu":
                        key = Registry.CurrentUser.OpenSubKey(target.Substring(5).Insert(9, @"WOW6432Node\"), true);
                        break;
                    case "hklm":
                        key = Registry.LocalMachine.OpenSubKey(target.Substring(5).Insert(9, @"WOW6432Node\"), true);
                        break;
                    case "hkcr":
                        key = Registry.ClassesRoot.OpenSubKey(target.Substring(5).Insert(9, @"WOW6432Node\"), true);
                        break;
                    case "hkcc":
                        key = Registry.CurrentConfig.OpenSubKey(target.Substring(5).Insert(9, @"WOW6432Node\"), true);
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
        #endregion

        #region 私有方法组

        private static bool RegistryKeyExistRedirect(string target, bool isRedirect, object value = null, bool detectvalue = false)
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

        private static bool RegistryKeyExist(string target, bool isRedirect, object value = null, bool detectvalue = false)
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

        private static object RegistryKeyGetValueRedirect(string target, bool isRedirect)
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

        private static object RegistryKeyGetValue(string target, bool isRedirect)
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

        private static void RegistryKeySetValueRedirect(string target, object value, bool isRedirect)
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
                Logger.Instance.WriteLog("Key is null", LogType.Error);
            }
        }

        private static void RegistryKeySetValue(string target, object value, bool isRedirect)
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
                Logger.Instance.WriteLog("Key is null", LogType.Error);
            }
        }

        private static void RegistryKeyDeleteValueRedirect(string target, bool isRedirect)
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
                    Logger.Instance.WriteLog($"Exception when delete registry key {target}, and isRedirect is {isRedirect}. More info: " + e.Message, LogType.Error);
                }

            }
            else
            {
                Logger.Instance.WriteLog("Key is null", LogType.Error);
            }
        }

        private static void RegistryKeyDeleteValue(string target, bool isRedirect)
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
                Logger.Instance.WriteLog("Key is null", LogType.Error);
            }
        }

        private static void RegistryKeyRenameValueNameRedirect(string target, bool isRedirect)
        {
            RegistryKey key = null;
            string valueName = null;
            key = RKeyRedirect(target, ref valueName, isRedirect);
            string newValueName = valueName + "Backup";
            if (null != key)
            {
                key.SetValue(newValueName, key.GetValue(valueName));
                key.DeleteValue(valueName);
                key.Close();
            }
            else
            {
                Logger.Instance.WriteLog("Key is null", LogType.Error);
            }
        }

        private static void RegistryKeyRenameValueName(string target, bool isRedirect)
        {
            RegistryKey key = null;
            string valueName = null;
            key = RKey(target, ref valueName, isRedirect);
            string newValueName = valueName + "Backup";
            if (null != key)
            {
                if (key.GetValue(valueName) != null)
                {
                    key.SetValue(newValueName, key.GetValue(valueName));
                    key.DeleteValue(valueName);
                }

                key.Close();
            }
            else
            {
                Logger.Instance.WriteLog("Key is null", LogType.Error);
            }
        }

        private static void RegistryKeyRestoreValueNameRedirect(string target, bool isRedirect)
        {
            RegistryKey key = null;
            string valueName = null;
            key = RKeyRedirect(target, ref valueName, isRedirect);
            string newValueName = valueName + "Backup";
            if (null != key)
            {
                foreach (string s in key.GetValueNames())
                {
                    if (s.ToLower() == newValueName.ToLower())
                    {
                        key.SetValue(valueName, key.GetValue(newValueName));
                        key.DeleteValue(newValueName);
                    }
                }
                key.Close();
            }
            else
            {
                Logger.Instance.WriteLog("Key is null", LogType.Error);
            }
        }

        private static void RegistryKeyRestoreValueName(string target, bool isRedirect)
        {
            RegistryKey key = null;
            string valueName = null;
            key = RKey(target, ref valueName, isRedirect);
            string newValueName = valueName + "Backup";
            if (null != key)
            {
                foreach (string s in key.GetValueNames())
                {
                    if (s.ToLower() == newValueName.ToLower())
                    {
                        key.SetValue(valueName, key.GetValue(newValueName));
                        key.DeleteValue(newValueName);
                    }
                }
                key.Close();
            }
            else
            {
                Logger.Instance.WriteLog("Key is null", LogType.Error);
            }
        }

        private static RegistryKey RKeyRedirect(string target, ref string valueName, bool isRedirect = false)
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
                    Logger.Instance.WriteLog("Wrong registry key", LogType.Error);
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
                                key = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
                                key = key.OpenSubKey(path, true);
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
                                key = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64);
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

        private static RegistryKey RKey(string target, ref string valueName, bool isRedirect = false)
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
                    Logger.Instance.WriteLog("Wrong registry key", LogType.Error);
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
                    Logger.Instance.WriteLog("Wrong registry key", LogType.Error);
                    return key;
                }
                string path = string.Empty;
                RegistryKey root = null;
                switch (temp[0].ToLower())
                {
                    case "hklm":
                        {
                            if ((temp[1].ToLower() == "software" && temp[2].ToLower().Equals("wow6432node") && Environment.Is64BitOperatingSystem) || !Environment.Is64BitOperatingSystem)
                            {
                                root = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32);

                            }
                            else
                            {
                                root = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);

                            }

                        }
                        break;
                    case "hkcu":
                        {
                            if ((temp[1].ToLower() == "software" && temp[2].ToLower().Equals("wow6432node") && Environment.Is64BitOperatingSystem) || !Environment.Is64BitOperatingSystem)
                            {
                                root = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry32);

                            }
                            else
                            {
                                root = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64);

                            }
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
        private static bool RenameSubKey(RegistryKey parentKey, string subKeyName, string newSubKeyName)
        {
            CopyKey(parentKey, subKeyName, newSubKeyName);
            parentKey.DeleteSubKeyTree(subKeyName);
            return true;
        }

        private static bool CopyKey(RegistryKey parentKey, string keyNameToCopy, string newKeyName)
        {
            //Create new key
            RegistryKey destinationKey = parentKey.CreateSubKey(newKeyName);

            //Open the sourceKey we are copying from
            RegistryKey sourceKey = parentKey.OpenSubKey(keyNameToCopy);
            RecurseCopyKey(sourceKey, destinationKey);
            return true;
        }

        private static void RecurseCopyKey(RegistryKey sourceKey, RegistryKey destinationKey)
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

        private static void RecursiveRegistryKeySetValueRedirect(string target, object value, bool isRedirect)
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
                Logger.Instance.WriteLog("Key is null", LogType.Error);
            }
        }

        private static void RecursiveRegistryKeySetValue(string target, object value, bool isRedirect)
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
                Logger.Instance.WriteLog("Key is null", LogType.Error);
            }
        }

        private static bool RCreateRegistrySubKey(string subKeyName, bool isRedirect = false)
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
                if (Environment.Is64BitOperatingSystem)
                {
                    parentKey = RegistryKey.OpenBaseKey(registryMapping[headerOfParentKey], RegistryView.Registry64).OpenSubKey(tailOfParentKey, true);
                }
                else
                {
                    parentKey = RegistryKey.OpenBaseKey(registryMapping[headerOfParentKey], RegistryView.Registry32).OpenSubKey(tailOfParentKey, true);
                }
            }
            else
            {
                switch (subKeyName.ToLower().Substring(0, 4))
                {
                    case "hkcu":
                        parentKey = Registry.CurrentUser.OpenSubKey(parentKeyName.Substring(5).Insert(9, @"WOW6432Node\"), true);
                        break;
                    case "hklm":
                        parentKey = Registry.LocalMachine.OpenSubKey(parentKeyName.Substring(5).Insert(9, @"WOW6432Node\"), true);
                        break;
                    case "hkcr":
                        parentKey = Registry.ClassesRoot.OpenSubKey(parentKeyName.Substring(5).Insert(9, @"WOW6432Node\"), true);
                        break;
                    case "hkcc":
                        parentKey = Registry.CurrentConfig.OpenSubKey(parentKeyName.Substring(5).Insert(9, @"WOW6432Node\"), true);
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

        private static void RecursiveRegistryKeySetValueRedirect(string target, object value, RegistryValueKind valueType, bool isRedirect)
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
                Logger.Instance.WriteLog("Key is null", LogType.Error);
            }
        }

        private static void RecursiveRegistryKeySetValue(string target, object value, RegistryValueKind valueType, bool isRedirect)
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
                Logger.Instance.WriteLog("Key is null", LogType.Error);
            }
        }

        public static void SetVantageLogState(bool setEnable = true)
        {
            try
            {
                string regeditLenovoVantageServiceName = "LenovoVantageService";
                string regeditLenovoVantageShellName = "LenovoVantageShell";
                string regeditVantageInstallName = "Lenovo.Vantage.InstallerHelper";
                string regeditVantageAllLogsName = "AllLogs";

                string regeditPath = @"SOFTWARE\WOW6432Node\Lenovo\VantageService\FileLogger";
                string setValue = "Trace";
                string regeditValue = IntelligentCoolingBaseHelper.GetLocalMachineRegeditValue(regeditLenovoVantageServiceName, regeditPath);

                if (setEnable)
                {
                    if (string.IsNullOrEmpty(regeditValue))
                    {
                        IntelligentCoolingBaseHelper.SetLocalMachineRegeditValue(regeditLenovoVantageServiceName, regeditPath, setValue);
                        IntelligentCoolingBaseHelper.SetLocalMachineRegeditValue(regeditLenovoVantageShellName, regeditPath, setValue);
                        IntelligentCoolingBaseHelper.SetLocalMachineRegeditValue(regeditVantageInstallName, regeditPath, setValue);
                        IntelligentCoolingBaseHelper.SetLocalMachineRegeditValue(regeditVantageAllLogsName, regeditPath, setValue);
                    }
                }
                else
                {
                    string regeditLogFilePath = @"hklm\SOFTWARE\WOW6432Node\Lenovo\VantageService\FileLogger";
                    DeleteRegistrySubKey(regeditLogFilePath);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }

        }

        #endregion
    }
}
