﻿using System.Drawing;
using System.Windows.Forms;

namespace winformUI.CustomControls
{
    public class DragControl
    {
        public static bool isMouseDown = false;
        public static Point mouseOffset;
        public static Form _form;
        public DragControl() { }
        /**//// <summary>
            　　　　/// 在窗体上增加拖拽事件
            　　　　/// </summary>
            　　　　/// <param name="control">控件对象</param>
        public static void bindControl(Control control)
        {
            //如果控件为空　
            if (control == null)
            {
                return;
            }
            _form = control.FindForm();
            //增加鼠标拖动窗体移动事件
            control.MouseMove += new MouseEventHandler(control_MouseMove);
            control.MouseDown += new MouseEventHandler(control_MouseDown);
            control.MouseUp += new MouseEventHandler(control_MouseUp);
        }
        /**//// <summary>
            　　　　/// 鼠标按下之时，保存鼠标相对于窗体的位置
            　　　　/// </summary>
            　　　　/// <param name="sender"></param>
            　　　　/// <param name="e"></param>
        public static void control_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Control control = sender as Control;
                int offsetX = -e.X;
                int offsetY = -e.Y;
                //判断是窗体还是控件，从而改进鼠标相对于窗体的位置
                if (!(control is System.Windows.Forms.Form))
                {
                    offsetX = offsetX - control.Left;
                    offsetY = offsetY - control.Top;
                }
                //判断窗体有没有标题栏，从而改进鼠标相对于窗体的位置
                if (_form.FormBorderStyle != FormBorderStyle.None)
                {
                    offsetX = offsetX - SystemInformation.FrameBorderSize.Width;
                    offsetY = offsetY - SystemInformation.FrameBorderSize.Height - SystemInformation.CaptionHeight;
                }
                mouseOffset = new Point(offsetX, offsetY);
                isMouseDown = true;
            }
        }
        /**//// <summary>
            　　　　/// 移动鼠标的时候改变窗体位置
            　　　　/// </summary>
            　　　　/// <param name="sender"></param>
            　　　　/// <param name="e"></param>
        public static void control_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                Point mouse = Control.MousePosition;
                mouse.Offset(mouseOffset.X, mouseOffset.Y);
                _form.Location = mouse;
            }
        }
        /**//// <summary>
            　　　　/// 松开鼠标的时候，重设事件
            　　　　/// </summary>
            　　　　/// <param name="sender"></param>
            　　　　/// <param name="e"></param>
        public static void control_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = false;
            }
        }
    }
}
