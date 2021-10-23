using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace LenovoVantageTest.Utility
{
    public enum ICON_COLOR
    {
        Red = 0,
        Green = 1,
        Blue = 2,
        RedAndBlue = 3,
        RedAndGreen = 4,
        Unknown = 5
    };
    class CaptureScreen
    {
        public static void PrintScreen(string picPath)
        {
            float scaling = GetScalingFactor();
            int width = (int)(Screen.PrimaryScreen.Bounds.Width * scaling);
            int height = (int)(Screen.PrimaryScreen.Bounds.Height * scaling);
            Bitmap printscreen = new Bitmap(width, height);
            Graphics graphics = Graphics.FromImage(printscreen as Image);
            try
            {
                graphics.CopyFromScreen(0, 0, 0, 0, printscreen.Size);
            }
            catch (Exception)
            {
                //With remote desktop , NO screen could be caught.
                return;
            }
            string pt = Path.GetDirectoryName(picPath);
            if (!Directory.Exists(pt))
            {
                FileManager.CreateDirRecursive(pt);
            }
            try
            {
                printscreen.Save(picPath, ImageFormat.Png);
            }
            catch (System.Runtime.InteropServices.ExternalException)
            { }
        }

        public static void littleScreenShot(string initpath, string savepath, double targetwidth, double targetheight)
        {
            //创建目bai录
            string dir = Path.GetDirectoryName(savepath);
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);
            //原始图片（获取原始图片创建对象，并使用流中嵌入的颜色管理信息）
            Image initimage = Image.FromFile(initpath);
            //原图宽高均小于模版，不作处理，直接保存
            if (initimage.Width <= targetwidth && initimage.Height <= targetheight)
            {
                //保存
                initimage.Save(savepath, ImageFormat.Jpeg);
            }
            else
            {
                //缩略图宽、高计算
                double newwidth = initimage.Width;
                double newheight = initimage.Height;
                //宽大于高或宽等于高（横图或正方）
                if (initimage.Width > initimage.Height || initimage.Width == initimage.Height)
                {
                    //如果宽大于模版
                    if (initimage.Width > targetwidth)
                    {
                        //宽按模版，高按比例缩放
                        newwidth = targetwidth;
                        newheight = initimage.Height * (targetwidth / initimage.Width);
                    }
                }
                //高大于宽（竖图）
                else
                {
                    //如果高大于模版
                    if (initimage.Height > targetheight)
                    {
                        //高按模版，宽按比例缩放
                        newheight = targetheight;
                        newwidth = initimage.Width * (targetheight / initimage.Height);
                    }
                }
                //生成新图
                //新建一个bmp图片
                Image newimage = new Bitmap((int)newwidth, (int)newheight);
                //新建一个画板
                Graphics newg = Graphics.FromImage(newimage);
                //设置质量
                newg.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                newg.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                //置背景色
                newg.Clear(Color.White);
                //画图
                newg.DrawImage(initimage, new Rectangle(0, 0, newimage.Width, newimage.Height), new Rectangle(0, 0, initimage.Width, initimage.Height), GraphicsUnit.Pixel);
                //保存缩略图
                newimage.Save(savepath, ImageFormat.Jpeg);
                //释放资源
                newg.Dispose();
                newimage.Dispose();
                initimage.Dispose();
            }
        }

        public static void PrintThumbScreenShot(string _orgPicPath)
        {
            string tmpPath = _orgPicPath + ".original";
            PrintScreen(tmpPath);
            PictureDealer.GenerateHighThumbnail(tmpPath, _orgPicPath, Screen.PrimaryScreen.Bounds.Width / 2, Screen.PrimaryScreen.Bounds.Height / 2);
        }
        [DllImport("gdi32.dll")]
        static extern int GetDeviceCaps(IntPtr hdc, int nIndex);
        public enum DeviceCap
        {
            VERTRES = 10,
            DESKTOPVERTRES = 117,
        }
        public static float GetScalingFactor()
        {
            Graphics g = Graphics.FromHwnd(IntPtr.Zero);
            IntPtr desktop = g.GetHdc();
            int LogicalScreenHeight = GetDeviceCaps(desktop, (int)DeviceCap.VERTRES);
            int PhysicalScreenHeight = GetDeviceCaps(desktop, (int)DeviceCap.DESKTOPVERTRES);
            float ScreenScalingFactor = (float)PhysicalScreenHeight / (float)LogicalScreenHeight;
            return ScreenScalingFactor;
        }


        public static void PrintScreenX(int srcX, int srcY, int width, int height, string picPath)
        {
            float scaling = GetScalingFactor();
            try
            {
                Bitmap printscreen = new Bitmap(width, height);
                Graphics graphics = Graphics.FromImage(printscreen as Image);
                graphics.CopyFromScreen(srcX, srcY, 0, 0, printscreen.Size);
                string pt = Path.GetDirectoryName(picPath);
                if (!Directory.Exists(pt))
                {
                    FileManager.CreateDirRecursive(pt);
                }
                /*if (File.Exists(picPath))
                {
                    File.Delete(picPath);
                }*/
                printscreen.Save(picPath, ImageFormat.Jpeg);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }

        }
        //Marcus: Sometimes , we want to capture only a part of screen to deal with
        //It passed my test with Scale 125% on my P1
        public static Bitmap ScreenShotWithSpecificArea(int srcX, int srcY, int width, int height)
        {
            try
            {
                float scaling = GetScalingFactor();
                width = (int)(width * scaling);
                height = (int)(height * scaling);
                Bitmap printscreen = new Bitmap(width, height);
                Graphics graphics = Graphics.FromImage(printscreen as Image);
                graphics.CopyFromScreen((int)(srcX * scaling), (int)(srcY * scaling), 0, 0, new Size(width, height));
                return printscreen;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }
            return null;
        }

        public static ICON_COLOR GetColor(string picPath)
        {
            //PrintScreenX(300,300,"D:\\img\\test1.jpeg");
            Image img = Image.FromFile(picPath);
            Bitmap bm = new Bitmap(img);
            int Gcount = 0;
            int Rcount = 0;
            int Bcount = 0;
            for (int i = 0; i < bm.Height; i++)
                for (int j = 0; j < bm.Width; j++)
                {
                    Color color = bm.GetPixel(j, i);
                    byte R = color.R;
                    byte G = color.G;
                    byte B = color.B;
                    //string str = R.ToString() + ":" + G.ToString() + ":" + B.ToString();
                    //Console.WriteLine(str);
                    if (R < 100 && G > 150 && B < 150)
                    {
                        Gcount++;
                        // str = R.ToString() + ":" + G.ToString() + ":" + B.ToString();
                        //Console.WriteLine(str);
                    }
                    if (R > 150 && G < 100 && B < 100)
                    {
                        Rcount++;
                        //str = R.ToString() + ":" + G.ToString() + ":" + B.ToString();
                        //Console.WriteLine(str);
                    }
                    if ((R > 50 && R < 90) && G > 50 && B > 240)
                    {
                        Bcount++;
                        //str = R.ToString() + ":" + G.ToString() + ":" + B.ToString();
                        //Console.WriteLine(str);
                    }
                    // System.Diagnostics.Debug.WriteLine(str);
                }
            bool hasGreen = Gcount * 1.0 / (bm.Height * bm.Width) > 0.02;
            bool hasRed = Rcount * 1.0 / (bm.Height * bm.Width) > 0.02;
            bool hasBlue = Bcount * 1.0 / (bm.Height * bm.Width) > 0.02;
            if (hasRed && !hasGreen && !hasBlue)
            {
                return ICON_COLOR.Red;
            }
            if (hasGreen && !hasRed)
            {
                return ICON_COLOR.Green;
            }
            if (hasBlue && !hasRed)
            {
                return ICON_COLOR.Blue;
            }
            return ICON_COLOR.Unknown;
        }
        //https://cdc.tencent.com/2011/05/09/%E8%89%B2%E7%94%9F%E5%BF%83%E4%B8%AD%EF%BC%9A%E4%BA%BA%E6%80%A7%E5%8C%96%E7%9A%84hsl%E6%A8%A1%E5%9E%8B/
        public static ICON_COLOR GetColor_HSL(string picPath)
        {
            //PrintScreenX(300,300,"D:\\img\\test1.jpeg");
            bool hasGreen, hasRed, hasBlue;
            using (Image img = Image.FromFile(picPath))
            using (Bitmap bm = new Bitmap(img))
            {
                int Gcount = 0;
                int Rcount = 0;
                int Bcount = 0;
                for (int i = 0; i < bm.Height; i++)
                    for (int j = 0; j < bm.Width; j++)
                    {
                        Color color = bm.GetPixel(j, i);
                        byte R = color.R;
                        byte G = color.G;
                        byte B = color.B;
                        System.Drawing.Color hsl = System.Drawing.Color.FromArgb(color.ToArgb());
                        string str = string.Format("R={0} G={1}B={2}, H={3} S={4} L={5}", R, G, B, hsl.GetHue(), hsl.GetSaturation(), hsl.GetBrightness());

                        //Green
                        if ((hsl.GetHue() > 80 && hsl.GetHue() < 170) && hsl.GetSaturation() > 0.7 && (hsl.GetBrightness() > 0.35 && hsl.GetBrightness() < 0.6))
                        {
                            Gcount++;
                            //Console.WriteLine(str);
                        }

                        //朱红
                        if ((hsl.GetHue() > 0 && hsl.GetHue() < 10) && hsl.GetSaturation() > 0.6 && (hsl.GetBrightness() > 0.35 && hsl.GetBrightness() < 0.7))
                        {
                            Rcount++;
                            //Console.WriteLine(str);
                        }
                        //大红
                        if ((hsl.GetHue() >= 330) && hsl.GetSaturation() > 0.6 && (hsl.GetBrightness() > 0.45 && hsl.GetBrightness() < 0.7))
                        {
                            Rcount++;
                            //Console.WriteLine(str);
                        }
                        //Blue
                        if ((hsl.GetHue() >= 170 && hsl.GetHue() < 260) && hsl.GetSaturation() > 0.6 && (hsl.GetBrightness() > 0.35 && hsl.GetBrightness() < 0.6))
                        {
                            Bcount++;
                            str = R.ToString() + ":" + G.ToString() + ":" + B.ToString();
                            //Console.WriteLine(str);
                        }
                        HashSet<string> debugInfo = new HashSet<string>();
                        debugInfo.Add(str);
                        foreach (string _colorinfo in debugInfo)
                        {
                            //System.Diagnostics.Debug.WriteLine(_colorinfo);
                        }
                        //System.Diagnostics.Debug.WriteLine(str);
                    }
                hasGreen = Gcount * 1.0 / (bm.Height * bm.Width) > 0.02;
                hasRed = Rcount * 1.0 / (bm.Height * bm.Width) > 0.02;
                hasBlue = Bcount * 1.0 / (bm.Height * bm.Width) > 0.02;
            }
            if (hasRed && !hasGreen && !hasBlue)
            {
                return ICON_COLOR.Red;
            }
            if (hasGreen && !hasRed)
            {
                return ICON_COLOR.Green;
            }
            if (hasBlue && !hasRed)
            {
                return ICON_COLOR.Blue;
            }
            return ICON_COLOR.Unknown;
        }
        //https://www.cnblogs.com/lihaiping/p/RGB.html , How to create color by R.G.B
        //https://www.sojson.com/web/panel.html , watch how R.G.B change 
        //http://hslpicker.com/#f8a9a0
        public static ICON_COLOR GetColor(int srcX, int srcY, int width, int height)
        {
            float scaling = GetScalingFactor();

            Bitmap printscreen = new Bitmap(width, height);
            Graphics graphics = Graphics.FromImage(printscreen as Image);
            graphics.CopyFromScreen(srcX, srcY, 0, 0, printscreen.Size);

            int Gcount = 0;
            int Rcount = 0;
            int Bcount = 0;
            for (int i = 0; i < printscreen.Height; i++)
                for (int j = 0; j < printscreen.Width; j++)
                {
                    Color color = printscreen.GetPixel(j, i);
                    byte R = color.R;
                    byte G = color.G;
                    byte B = color.B;
                    string str = R.ToString() + ":" + G.ToString() + ":" + B.ToString();
                    //Console.WriteLine(str);
                    if (R < 100 && G > 150 && B < 150)
                    {
                        Gcount++;
                        str = R.ToString() + ":" + G.ToString() + ":" + B.ToString();
                        //Console.WriteLine(str);
                    }
                    if (R > 150 && G < 100 && B < 100)
                    {
                        Rcount++;
                        str = R.ToString() + ":" + G.ToString() + ":" + B.ToString();
                        //Console.WriteLine(str);
                    }
                    if ((R > 50 && R < 90) && G > 50 && B > 250)
                    {
                        Bcount++;
                        str = R.ToString() + ":" + G.ToString() + ":" + B.ToString();
                        //Console.WriteLine(str);
                    }

                }
            bool hasGreen = Gcount * 1.0 / (printscreen.Height * printscreen.Width) > 0.02;
            bool hasRed = Rcount * 1.0 / (printscreen.Height * printscreen.Width) > 0.02;
            bool hasBlue = Bcount * 1.0 / (printscreen.Height * printscreen.Width) > 0.02;
            if (hasRed && !hasGreen && !hasBlue)
            {
                return ICON_COLOR.Red;
            }
            if (hasGreen && !hasRed)
            {
                return ICON_COLOR.Green;
            }
            if (hasBlue && !hasRed)
            {
                return ICON_COLOR.Blue;
            }
            return ICON_COLOR.Unknown;
        }
        public static bool IsWindowsElementColorExpected(WindowsElement _element, ICON_COLOR _expectedColor, ref ICON_COLOR _realColor)
        {
            //https://github.com/Microsoft/WinAppDriver/issues/407
            if (!_element.Displayed && _element.Location.Y > (_element.WrappedDriver.Manage().Window.Size.Height - 50))
            {
                _element.SendKeys(OpenQA.Selenium.Keys.PageDown);
            }
            if (!_element.Displayed && _element.Location.Y < 50)
            {
                _element.SendKeys(OpenQA.Selenium.Keys.PageUp);
            }
            String savedImgPath = "";
            OpenQA.Selenium.Screenshot screeshot = _element.GetScreenshot();
            using (Bitmap elementImg = Image.FromStream(new System.IO.MemoryStream(screeshot.AsByteArray)) as Bitmap)
            {
                savedImgPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "automationImg.bmp");
                if (File.Exists(savedImgPath))
                {
                    File.Delete(savedImgPath);
                }
                elementImg.Save(savedImgPath, System.Drawing.Imaging.ImageFormat.Bmp);
            }
            LenovoVantageTest.Utility.ICON_COLOR color = GetColor_HSL(savedImgPath);
            if (color == _expectedColor)
            {
                return true;
            }
            _realColor = color;
            return false;
        }

    }
}
