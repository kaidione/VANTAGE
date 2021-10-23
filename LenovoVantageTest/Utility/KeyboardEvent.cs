namespace LenovoVantageTest.Utility
{
    using System;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    public sealed class KeyboardEvent
    {
        // <summary>
        // 键盘事件
        // </summary>
        // <param name="bVk"> virtual-key code</param>
        // <param name="bScan">hardware scan code</param>
        // <param name="dwFlags"> flags specifying various function options</param>
        // <param name="dwExtraInfo"> additional data associated with keystroke</param>
        [DllImport("user32.dll")]
        public static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

        public static void InputText(string text)
        {
            SendKeys.SendWait(text);
        }


        [DllImport("user32.dll", EntryPoint = "keybd_event", SetLastError = true)]
        public static extern void keybd_event(Keys bVk, byte bScan, uint dwFlags, uint dwExtraInfo);

        public void button1_Click(object sender, EventArgs e)
        {

            //textBox1.Focus();
            keybd_event(Keys.A, 0, 0, 0);

        }

        public const int KEYEVENTF_KEYUP = 2;

        public void button2_Click(object sender, EventArgs e)
        {
            //webBrowser1.Focus();

            keybd_event(Keys.ControlKey, 0, 0, 0);

            keybd_event(Keys.A, 0, 0, 0);

            keybd_event(Keys.ControlKey, 0, KEYEVENTF_KEYUP, 0);

        }

        public static void Press_FnAndF12(object sender, EventArgs e)
        {
            //webBrowser1.Focus();
            keybd_event(Keys.Enter, 0, 0, 0);

        }
    }
}
