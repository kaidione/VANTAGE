using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace LenovoVantageTest.Utility
{
    class KeyboardMouse
    {
        // 鼠标事件
        // </summary>
        // <param name="flags">事件类型</param>
        // <param name="dx">x坐标值(0~65535)</param>
        // <param name="dy">y坐标值(0~65535)</param>
        // <param name="data">滚动值(120一个单位)</param>
        // <param name="extraInfo">不支持</param>
        [DllImport("user32.dll")]
        static extern void mouse_event(MouseEventFlag flags, int dx, int dy, int data, UIntPtr extraInfo);

        // <summary>
        // 鼠标操作标志位集合
        // </summary>
        [Flags]
        enum MouseEventFlag : uint
        {
            // <summary>
            // 鼠标移动事件
            // </summary>
            Move = 0x0001,

            // <summary>
            // 鼠标左键按下事件
            // </summary>
            LeftDown = 0x0002,
            LeftUp = 0x0004,
            RightDown = 0x0008,
            RightUp = 0x0010,
            MiddleDown = 0x0020,
            MiddleUp = 0x0040,
            XDown = 0x0080,
            XUp = 0x0100,
            Wheel = 0x0800,
            VirtualDesk = 0x4000,
            // <summary>
            // 设置鼠标坐标为绝对位置（dx,dy）,否则为距离最后一次事件触发的相对位置
            // </summary>
            Absolute = 0x8000
        }

        // <summary>
        // 触发鼠标事件
        // </summary>
        // <param name="x"></param>
        // <param name="y"></param>
        public static void DoMouseClick(int x, int y)
        {
            float scaling = CaptureScreen.GetScalingFactor();//Screen.PrimaryScreen.Bounds的大小=分辨率/缩放比，即1920x1080的分辨率 & 1.25缩放比 =>屏幕大小是1536*1.25
            int dx = (int)((double)x / (Screen.PrimaryScreen.Bounds.Width * scaling) * 65535); //屏幕分辨率映射到0~65535(0xffff,即16位)之间
            int dy = (int)((double)y / (Screen.PrimaryScreen.Bounds.Height * scaling) * 0xffff); //转换为double类型运算，否则值为0、1
            mouse_event(MouseEventFlag.Move | MouseEventFlag.LeftDown | MouseEventFlag.Absolute, dx, dy, 0, new UIntPtr(0)); //点击
            mouse_event(MouseEventFlag.LeftUp | MouseEventFlag.Absolute, dx, dy, 0, new UIntPtr(0)); //点击
        }

        public static void DoMouseMove(int x, int y)
        {
            float scaling = CaptureScreen.GetScalingFactor();//Screen.PrimaryScreen.Bounds的大小=分辨率/缩放比，即1920x1080的分辨率 & 1.25缩放比 =>屏幕大小是1536*1.25
            int dx = (int)((double)x / (Screen.PrimaryScreen.Bounds.Width * scaling) * 65535); //屏幕分辨率映射到0~65535(0xffff,即16位)之间
            int dy = (int)((double)y / (Screen.PrimaryScreen.Bounds.Height * scaling) * 0xffff); //转换为double类型运算，否则值为0、1
            mouse_event(MouseEventFlag.Move | MouseEventFlag.Absolute, dx, dy, 0, new UIntPtr(0)); //move to x,y
        }

        public static void DoMouseScrollDown1Fourth()
        {
            float scaling = CaptureScreen.GetScalingFactor();//Screen.PrimaryScreen.Bounds的大小=分辨率/缩放比，即1920x1080的分辨率 & 1.25缩放比 =>屏幕大小是1536*1.25
            mouse_event(MouseEventFlag.Move | MouseEventFlag.Absolute, 0, 0, int.Parse((Screen.PrimaryScreen.Bounds.Height * scaling / 4).ToString()), new UIntPtr(0)); //scroll a little
            System.Threading.Thread.Sleep(1500);
        }

        public static void DoMouseScrollUp1Fourth()
        {
            float scaling = CaptureScreen.GetScalingFactor();//Screen.PrimaryScreen.Bounds的大小=分辨率/缩放比，即1920x1080的分辨率 & 1.25缩放比 =>屏幕大小是1536*1.25
            mouse_event(MouseEventFlag.Move | MouseEventFlag.Absolute, 0, 0, (-1) * int.Parse((Screen.PrimaryScreen.Bounds.Height * scaling / 4).ToString()), new UIntPtr(0)); //scroll a little
            System.Threading.Thread.Sleep(1500);
        }
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
        //Simulate the keyboard pressing Win+D to show the Desktop
        public static void ShowDesktop()
        {
            keybd_event((byte)Keys.LWin, 0, 0, 0);
            keybd_event((byte)Keys.D, 0, 0, 0);
            keybd_event((byte)Keys.LWin, 0, 2, 0);
            keybd_event((byte)Keys.D, 0, 2, 0);
            Thread.Sleep(1000);
        }
    }
}
