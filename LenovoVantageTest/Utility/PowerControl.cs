using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace LenovoVantageTest.Utility
{
    internal class PowerControl
    {
        static IntPtr SleepTimeHandle = IntPtr.Zero;
        static IntPtr HibTimeHandle = IntPtr.Zero;
        [DllImport("powrprof.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetSuspendState(bool hibernate, bool forceCritical, bool disableWakeEvent);

        public static bool Hibernate()
        {
            EnableWaitableTimer();
            HibTimeHandle = SetWakeAt(DateTime.Now);
            bool result = SetSuspendState(true, false, false);
            if (!result)
            {
                return false;
            }
            CancelWaitableTimer(HibTimeHandle);
            SetThreadExecutionState(EXECUTION_STATE.ES_DISPLAY_REQUIRED);
            return true;
        }

        public static bool Sleep()
        {
            EnableWaitableTimer();
            SleepTimeHandle = SetWakeAt(DateTime.Now);
            bool result = SetSuspendState(false, false, false);
            if (!result)
            {
                return false;
            }
            CancelWaitableTimer(SleepTimeHandle);
            SetThreadExecutionState(EXECUTION_STATE.ES_DISPLAY_REQUIRED);
            return true;
        }
        static void EnableWaitableTimer()
        {

            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = "powercfg";
            info.Arguments = string.Format("SETACVALUEINDEX SCHEME_CURRENT SUB_SLEEP bd3b718a-0680-4d9d-8ab2-e1d2b4ac806d 1");
            Process proc = new Process();
            proc.StartInfo = info;
            proc.Start();
            proc.WaitForExit();
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr CreateWaitableTimer(IntPtr lpTimerAttributes, bool bManualReset, string lpTimerName);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool SetWaitableTimer(IntPtr hTimer, [In] ref long pDueTime, int lPeriod, Delegate pfnCompletionRoutine, IntPtr pArgToCompletionRoutine, bool fResume);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool CancelWaitableTimer(IntPtr hTimer);
        static IntPtr SetWakeAt(DateTime dt)
        {
            // read the manual for SetWaitableTimer to understand how this number is interpreted.
            long interval = dt.ToFileTimeUtc();
            long neg = -4 * 1000 * 1000 * 10;//neg*100nanosecond=neg/10^9 seconds
            IntPtr handle = CreateWaitableTimer(IntPtr.Zero, true, "WaitableTimer");
            bool result = SetWaitableTimer(handle, ref neg, 0, null, IntPtr.Zero, true);
            return handle;
        }
        [FlagsAttribute]
        enum EXECUTION_STATE : uint
        {
            ES_AWAYMODE_REQUIRED = 0x00000040,
            ES_CONTINUOUS = 0x80000000,
            ES_DISPLAY_REQUIRED = 0x00000002,
            ES_SYSTEM_REQUIRED = 0x00000001
            // Legacy flag, should not be used.
            // ES_USER_PRESENT = 0x00000004
        }
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern EXECUTION_STATE SetThreadExecutionState(EXECUTION_STATE esFlags);
    }
}
