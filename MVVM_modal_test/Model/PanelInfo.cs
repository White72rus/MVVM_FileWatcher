using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using SkyCloudStorage.Properties;

namespace SkyCloudStorage.Model {
    public class PanelInfo : Grid {

        private double _height;
        private double _width;
        public PanelInfo(double height, double width, string text)
        {
            _height = height;
            _width = width;

            //this.Width = width;
            this.Height = height;
            this.Style = Application.Current.TryFindResource("TostInfoStyle") as Style;
            Label label = new Label();
            label.Content = text;
            this.Children.Add(label);
        }
    }
}
