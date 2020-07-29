using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SkyCloudStorage.Modules {
    public static class NotifyIcon {

        private static System.Windows.Forms.NotifyIcon notifyIcon;

        public static string Tooltip { get; set; } = "";
        public static bool Visible { get; set; } = true;
        public static Icon Icon { get; set; } = System.Drawing.Icon.ExtractAssociatedIcon("SkyCloudStorage.exe");

        public static Action MouseDownAction { set; get; }

        public static void Set()
        {
            notifyIcon = new System.Windows.Forms.NotifyIcon();

            notifyIcon.Icon = Icon;
            notifyIcon.Text = Tooltip;
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
