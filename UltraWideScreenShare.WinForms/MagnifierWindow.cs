using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UltraWideScreenShare.WinForms
{
    public partial class MagnifierWindow : Form
    {
        public MagnifierWindow()
        {
            InitializeComponent();
            this.TransparencyKey = System.Drawing.Color.Magenta;
            this.BackColor = System.Drawing.Color.Magenta;
            FormBorderStyle = FormBorderStyle.None;
            this.SetTransparency(true);
            //ShowInTaskbar = false;

        }
    }
}
