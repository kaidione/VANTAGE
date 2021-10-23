using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Security.Principal;

namespace LenovoVantageTest.Utility
{
    /// <summary>
    /// Author: Marcus 代码来源于https://web.archive.org/web/20150613031724/http://michiel.vanotegem.nl/2006/07/windowsimpersonationcontext-made-easy/
    /// 用作者的方法做impersonation。在特定情况下，logged in windows的user与启动我们automation的user不一定一样，为了能访问正确的registry和folder，必须做impersonation。
    /// 下面类的使用方法见最后的UsageDemo()。
    /// </summary>
    public class WrapperImpersonationContext
    {
        [DllImport("advapi32.dll", SetLastError = true)]
        public static extern bool LogonUser(String lpszUsername, String lpszDomain,
        String lpszPassword, int dwLogonType, int dwLogonProvider, ref IntPtr phToken);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public extern static bool CloseHandle(IntPtr handle);

        private const int LOGON32_PROVIDER_DEFAULT = 0;
        private const int LOGON32_LOGON_INTERACTIVE = 2;

        private string m_Domain;
        private string m_Password;
        private string m_Username;
        private IntPtr m_Token;

        private WindowsImpersonationContext m_Context = null;

        protected bool IsInContext
        {
            get { return m_Context != null; }
        }

        public WrapperImpersonationContext(string domain, string username, string password)
        {
            m_Domain = domain;
            m_Username = username;
            m_Password = password;
        }

        [PermissionSetAttribute(SecurityAction.Demand, Name = "FullTrust")]
        public void Enter()
        {
            if (this.IsInContext) return;
            m_Token = new IntPtr(0);
            try
            {
                m_Token = IntPtr.Zero;
                bool logonSuccessfull = LogonUser(
                   m_Username,
                   m_Domain,
                   m_Password,
                   LOGON32_LOGON_INTERACTIVE,
                   LOGON32_PROVIDER_DEFAULT,
                   ref m_Token);
                if (logonSuccessfull == false)
                {
                    int error = Marshal.GetLastWin32Error();
                    throw new Win32Exception(error);
                }
                WindowsIdentity identity = new WindowsIdentity(m_Token);
                m_Context = identity.Impersonate();
            }
            catch (Exception exception)
            {
                // Catch exceptions here
            }
        }

        [PermissionSetAttribute(SecurityAction.Demand, Name = "FullTrust")]
        public void Leave()
        {
            if (this.IsInContext == false) return;
            m_Context.Undo();

            if (m_Token != IntPtr.Zero) CloseHandle(m_Token);
            m_Context = null;
        }
        public static void UsageDemo(string _domainName, string _userName, string _password)
        {
            Console.WriteLine("Current user: " + WindowsIdentity.GetCurrent().Name);
            WrapperImpersonationContext context = new WrapperImpersonationContext(_domainName, _userName, _password);
            context.Enter();
            // Execute code under other uses context
            Console.WriteLine("Current user: " + WindowsIdentity.GetCurrent().Name);
            context.Leave();
            Console.WriteLine("Current user: " + WindowsIdentity.GetCurrent().Name);
        }
    }
}
