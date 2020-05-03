using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PropertyGridTest
{
    public partial class ColorPanel : UserControl
    {
        private Color hatchColor = Color.Black;

        public delegate void ColorChangedEventHandler(object sender, ColorChangedEventArgs e);//事件所需的委托

        public event ColorChangedEventHandler ColorChanged;

        #region
        public ColorPanel()
        {
            InitializeComponent();
        }
        #endregion

        protected virtual void OnColorChanged(ColorChangedEventArgs e)
        {
            if (ColorChanged != null)
            {
                ColorChanged(this, e);
            }
        }

        private void panel_Click(object sender, EventArgs e)
        {
            Panel p = sender as Panel;
            if (p != null)
            {
                hatchColor = p.BackColor;
                panel1.BackColor = hatchColor;
                OnColorChanged(new ColorChangedEventArgs(hatchColor));//因为颜色改变所以触发事件
            }
        }

        private void panel_MouseEnter(object sender, EventArgs e)
        {
            Panel p = sender as Panel;
            if (p != null)
            {
                p.BorderStyle = BorderStyle.FixedSingle;
            }
        }

        private void panel_MouseLeave(object sender, EventArgs e)
        {
            Panel p = sender as Panel;
            if (p != null)
            {
                p.BorderStyle = BorderStyle.None;
            }
        }

        #region
        [Description("Set Current Color")]　//显示在属性设计视图中的描述
        [DefaultValue(typeof(Color), "Black")]
        public Color HatchColor
        {
            get { return hatchColor; }
            set 
            {
                hatchColor = value;
                panel1.BackColor = hatchColor;
            }
        }
        #endregion

        private void btnMore_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                hatchColor = cd.Color;
                panel1.BackColor = hatchColor;
                OnColorChanged(new ColorChangedEventArgs(hatchColor));//因为颜色改变所以触发事件
            }
        }
    }

    public class ColorChangedEventArgs : EventArgs
    {
        private Color color;
        /// <summary>
        /// 颜色改变事件数据
        /// </summary>
        /// <param name="c">改变后的颜色</param>
        public ColorChangedEventArgs(Color c)
        {
            color = c;
        }
        /// <summary>
        /// 获取颜色
        /// </summary>
        public Color GetColor
        {
            get { return color; }
        }
    }
}
