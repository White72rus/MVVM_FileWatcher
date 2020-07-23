using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SkyCloudStorage.Modules {
    public static class NotifyIcon {

        private static Icon icon = System.Drawing.Icon.ExtractAssociatedIcon("SkyCloudStorage.exe");

        private static string tooltip = "";

        private static bool visible = true;

        private static System.Windows.Forms.NotifyIcon notifyIcon;

        public static string Tooltip { get => tooltip; set => tooltip = value; }
        public static bool Visible { get => visible; set => visible = value; }
        public static Icon Icon { get => icon; set => icon = value; }

        public static Action MouseDownAction { set; get; }

        public static void Set()
        {
            notifyIcon = new System.Windows.Forms.NotifyIcon();

            //if (icon == null)
            //{
            //    throw new NullReferenceException("Не указана иконка значка");
            //}
            notifyIcon.Icon = Icon;
            notifyIcon.Text = tooltip;
            notifyIcon.Visible = Visible;
            notifyIcon.BalloonTipText = "BalloonTipText";
            notifyIcon.BalloonTipTitle = "TitleBalloonTipText";
            notifyIcon.MouseDown += NotifyIcon_MouseDown;
        }

        private static void NotifyIcon_MouseDown(object sender, MouseEventArgs e)
        {
            MouseDownAction.Invoke();
        }

        public static void Remove()
        {
            notifyIcon.Visible = false;
            notifyIcon.Dispose();
        }
    }
}
