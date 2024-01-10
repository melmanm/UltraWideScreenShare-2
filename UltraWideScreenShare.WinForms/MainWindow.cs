using System.Diagnostics;

using Timer = System.Windows.Forms.Timer;

namespace UltraWideScreenShare.WinForms
{
    public partial class MainWindow : Form
    {
        private readonly Timer _dispatcherTimer = new Timer() { Interval = 5 };
        private Magnifier _magnifier;
        private bool _isTransparent = false;
        private Color _frameColor = Color.FromArgb(255, 53, 89, 224); //#3559E0
        const int _borderWidth = 8;
        public MainWindow()
        {
            InitializeComponent();
            controlPanel.BringToFront();
            controlPanel.BackColor = _frameColor;
            this.TransparencyKey = System.Drawing.Color.Magenta;
            this.BackColor = System.Drawing.Color.Magenta;
            FormBorderStyle = FormBorderStyle.None;
            DoubleBuffered = true;
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
        }

        const int WS_SIZEBOX = 0x40000;
        protected override CreateParams CreateParams
        {
            get
            {
                var @params = base.CreateParams;
                @params.Style |= WS_SIZEBOX;
                return @params;
            }
        }
        protected override void OnMove(EventArgs e)
        {
            MaximizedBounds = new Rectangle(Point.Empty, Screen.GetWorkingArea(Location).Size);
            base.OnMove(e);
        }
        private void MainWindow_Load(object sender, EventArgs e)
        {
            _magnifier = new Magnifier(magnifierPanel.Handle);
            _dispatcherTimer.Start();
            _dispatcherTimer.Tick += (s, a) =>
            {
                _magnifier.UpdateMagnifierWindow();
                if (magnifierPanel.Bounds.Contains(PointToClient(Cursor.Position)) && !controlPanel.Bounds.Contains(PointToClient(Cursor.Position)))
                {
                    if (!_isTransparent)
                    { Handle.SetTransparency(_isTransparent = true); Trace.WriteLine("enter"); }
                }
                else
                {
                    if (_isTransparent)
                    { Handle.SetTransparency(_isTransparent = false); Trace.WriteLine("leave"); }
                }

            };
        }

        private void MainWindow_ResizeBegin(object sender, EventArgs e) => _magnifier.HideMagnifier();

        private void MainWindow_ResizeEnd(object sender, EventArgs e) => _magnifier.ShowMagnifier();


        private void TittleBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Drag();
                SetupMaximizeButton();
            }
        }


        const int WM_NCCALCSIZE = 0x0083;
        const int WM_NCACTIVATE = 0x0086;
        const int WM_NCHITTEST = 0x0084;
        protected override void WndProc(ref Message m)
        {
            var message = m.Msg;
            if (message == WM_NCCALCSIZE)
            {
                return; 
            }

            if (message == WM_NCACTIVATE)
            {
                m.Result = new IntPtr(-1);
                return;
            }

            base.WndProc(ref m);

            if (message == WM_NCHITTEST)
            {
                this.TryResize(ref m, _borderWidth);
            }   
        }

        private void MainWindow_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle,
                _frameColor, 8, ButtonBorderStyle.Solid,
                _frameColor, 8, ButtonBorderStyle.Solid,
                _frameColor, 8, ButtonBorderStyle.Solid,
                _frameColor, 8, ButtonBorderStyle.Solid);
        }

        private void closeButton_Click(object sender, EventArgs e) => Close();

        private void minimizeButton_Click(object sender, EventArgs e) => WindowState = FormWindowState.Minimized;

        private void maximizeButton_Click(object sender, EventArgs e)
        {
            WindowState = WindowState == FormWindowState.Maximized 
                ? FormWindowState.Normal : FormWindowState.Maximized;
            SetupMaximizeButton();
        }

        private void SetupMaximizeButton()
        {
            if (WindowState == FormWindowState.Maximized)
            {
                maximizeButton.Image = Properties.Resources.restore;
            }
            else
            {
                maximizeButton.Image = Properties.Resources.maximize;
            }
        }
    }
}
