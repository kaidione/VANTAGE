using Microsoft.Win32.SafeHandles;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace Lenovo.SpecFlow.Utility
{
    public class PowerManagement
    {
        //This internal class does NOT enter S3/S4 , it only is in responsible for time up event.
        class TimeManager
        {
            [DllImport("kernel32.dll")]
            public static extern SafeWaitHandle CreateWaitableTimer(IntPtr lpTimerAttributes,
                                                                      bool bManualReset,
                                                                    string lpTimerName);

            [DllImport("kernel32.dll", SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool SetWaitableTimer(SafeWaitHandle hTimer,
                                                        [In] ref long pDueTime,
                                                                  int lPeriod,
                                                               IntPtr pfnCompletionRoutine,
                                                               IntPtr lpArgToCompletionRoutine,
                                                                 bool fResume);

            public event EventHandler eventHandler;

            private BackgroundWorker bgWorker = new BackgroundWorker();

            public TimeManager()
            {
                //Here , Nothing happens.
                bgWorker.DoWork += new DoWorkEventHandler(WaitingTimeUp);
                bgWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Callback_WhenWakeUp);
            }

            public void SetWakeUpTime(DateTime time)
            {
                //start counting time 
                bgWorker.RunWorkerAsync(time.ToFileTime());
            }

            void Callback_WhenWakeUp(object sender, RunWorkerCompletedEventArgs e)
            {
                if (eventHandler != null)
                {
                    eventHandler(this, new EventArgs());
                }
            }

            private void WaitingTimeUp(object sender, DoWorkEventArgs e)
            {
                long waketime = (long)e.Argument;

                using (SafeWaitHandle handle = CreateWaitableTimer(IntPtr.Zero, true, this.GetType().Assembly.GetName().Name.ToString() + "Timer"))
                {
                    if (SetWaitableTimer(handle, ref waketime, 0, IntPtr.Zero, IntPtr.Zero, true))
                    {
                        using (EventWaitHandle wh = new EventWaitHandle(false, EventResetMode.AutoReset))
                        {
                            wh.SafeWaitHandle = handle;
                            wh.WaitOne();
                        }
                    }
                    else
                    {
                        throw new Win32Exception(Marshal.GetLastWin32Error());
                    }
                }
            }

        }
        [DllImport("user32.dll")]
        static extern void mouse_event(Int32 dwFlags, Int32 dx, Int32 dy, Int32 dwData, UIntPtr dwExtraInfo);
        private const int MOUSEEVENTF_MOVE = 0x0001;
        //https://social.msdn.microsoft.com/Forums/en-US/4b366a2a-2930-43f6-82a8-2dbfb76fd760/window-10-c-code-to-wake-and-turn-on-monitor
        internal static void MonitorOn()
        {
            mouse_event(MOUSEEVENTF_MOVE, 0, 1, 0, UIntPtr.Zero);
        }
        public static void Sleep(DateTime _dtWakeUpTime, EventHandler _lambReturnWakenTime)
        {
            EnterS3S4(true, _dtWakeUpTime, _lambReturnWakenTime);
            MonitorOn();
        }
        public static void Hibernate(DateTime _dtWakeUpTime, EventHandler _lambReturnWakenTime)
        {
            EnterS3S4(false, _dtWakeUpTime, _lambReturnWakenTime);
            MonitorOn();
        }
        static void EnterS3S4(bool _Sleep, DateTime _dtWakeUpTime, EventHandler _lambReturnWakenTime)
        {
            TimeManager wup = new TimeManager();
            wup.eventHandler += _lambReturnWakenTime;
            wup.SetWakeUpTime(_dtWakeUpTime);
            if (_Sleep)
            {
                Application.SetSuspendState(PowerState.Suspend, true, false);
            }
            else
            {
                Application.SetSuspendState(PowerState.Hibernate, true, false);
            }
        }
    }
}
