
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;

namespace UltraWideScreenShare.WinForms
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.magnifierPanel = new System.Windows.Forms.Panel();
            this.controlPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.shareButton = new System.Windows.Forms.Button();
            this.tittleButton = new System.Windows.Forms.Button();
            this.dragButton = new System.Windows.Forms.Button();
            this.minimizeButton = new System.Windows.Forms.Button();
            this.maximizeButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.controlPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // magnifierPanel
            // 
            this.magnifierPanel.BackColor = System.Drawing.Color.Transparent;
            this.magnifierPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.magnifierPanel.Location = new System.Drawing.Point(9, 11);
            this.magnifierPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.magnifierPanel.Name = "magnifierPanel";
            this.magnifierPanel.Padding = new System.Windows.Forms.Padding(9, 11, 9, 11);
            this.magnifierPanel.Size = new System.Drawing.Size(896, 578);
            this.magnifierPanel.TabIndex = 0;
            // 
            // controlPanel
            // 
            this.controlPanel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.controlPanel.BackColor = System.Drawing.Color.White;
            this.controlPanel.Controls.Add(this.shareButton);
            this.controlPanel.Controls.Add(this.tittleButton);
            this.controlPanel.Controls.Add(this.dragButton);
            this.controlPanel.Controls.Add(this.minimizeButton);
            this.controlPanel.Controls.Add(this.maximizeButton);
            this.controlPanel.Controls.Add(this.closeButton);
            this.controlPanel.Location = new System.Drawing.Point(206, 0);
            this.controlPanel.Size = new System.Drawing.Size(500, 50);
            this.controlPanel.Padding = new System.Windows.Forms.Padding(10, 0, 10, 10);
            this.controlPanel.Name = "controlPanel";
            this.controlPanel.AutoScroll = false;
            this.controlPanel.FlowDirection = FlowDirection.LeftToRight;
            this.controlPanel.WrapContents = false;
            this.controlPanel.TabIndex = 1;
            // 
            // shareButton
            // 
            this.shareButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.shareButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.shareButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.shareButton.FlatAppearance.BorderSize = 0;
            this.shareButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.shareButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.shareButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.shareButton.Image = global::UltraWideScreenShare.WinForms.Properties.Resources.share;
            this.shareButton.Location = new System.Drawing.Point(10, 0);
            this.shareButton.Margin = new System.Windows.Forms.Padding(0);
            this.shareButton.Name = "shareButton";
            this.shareButton.Size = new System.Drawing.Size(50, 40);
            this.shareButton.TabIndex = 5;
            this.shareButton.UseVisualStyleBackColor = false;
            this.shareButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TittleBar_MouseDown);
            // 
            // tittleButton
            // 
            this.tittleButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.tittleButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tittleButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.tittleButton.FlatAppearance.BorderSize = 0;
            this.tittleButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.tittleButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.tittleButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tittleButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tittleButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tittleButton.Location = new System.Drawing.Point(60, 0);
            this.tittleButton.Margin = new System.Windows.Forms.Padding(0);
            this.tittleButton.Name = "tittleButton";
            this.tittleButton.Size = new System.Drawing.Size(230, 40);
            this.tittleButton.TabIndex = 4;
            this.tittleButton.Text = "Ultra Wide Screen Share 2.0";
            this.tittleButton.UseVisualStyleBackColor = false;
            this.tittleButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TittleBar_MouseDown);
            // 
            // dragButton
            // 
            this.dragButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.dragButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.dragButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.dragButton.FlatAppearance.BorderSize = 0;
            this.dragButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.dragButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.dragButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dragButton.Image = global::UltraWideScreenShare.WinForms.Properties.Resources.drag;
            this.dragButton.Location = new System.Drawing.Point(290, 0);
            this.dragButton.Margin = new System.Windows.Forms.Padding(0);
            this.dragButton.Name = "dragButton";
            this.dragButton.Size = new System.Drawing.Size(50, 40);
            this.dragButton.TabIndex = 3;
            this.dragButton.UseVisualStyleBackColor = false;
            this.dragButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TittleBar_MouseDown);
            // 
            // minimizeButton
            // 
            this.minimizeButton.BackColor = System.Drawing.Color.White;
            this.minimizeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.minimizeButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.minimizeButton.FlatAppearance.BorderSize = 0;
            this.minimizeButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.minimizeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.minimizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minimizeButton.Image = global::UltraWideScreenShare.WinForms.Properties.Resources.minimize;
            this.minimizeButton.Location = new System.Drawing.Point(340, 0);
            this.minimizeButton.Margin = new System.Windows.Forms.Padding(0);
            this.minimizeButton.Name = "minimizeButton";
            this.minimizeButton.Size = new System.Drawing.Size(50, 40);
            this.minimizeButton.TabIndex = 2;
            this.minimizeButton.UseVisualStyleBackColor = false;
            this.minimizeButton.Click += new System.EventHandler(this.minimizeButton_Click);
            // 
            // maximizeButton
            // 
            this.maximizeButton.BackColor = System.Drawing.Color.White;
            this.maximizeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.maximizeButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.maximizeButton.FlatAppearance.BorderSize = 0;
            this.maximizeButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.maximizeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.maximizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.maximizeButton.Image = global::UltraWideScreenShare.WinForms.Properties.Resources.maximize;
            this.maximizeButton.Location = new System.Drawing.Point(390, 0);
            this.maximizeButton.Margin = new System.Windows.Forms.Padding(0);
            this.maximizeButton.Name = "maximizeButton";
            this.maximizeButton.Size = new System.Drawing.Size(50, 40);
            this.maximizeButton.TabIndex = 1;
            this.maximizeButton.UseVisualStyleBackColor = false;
            this.maximizeButton.Click += new System.EventHandler(this.maximizeButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.BackColor = System.Drawing.Color.White;
            this.closeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.closeButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.closeButton.FlatAppearance.BorderSize = 0;
            this.closeButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(17)))), ((int)(((byte)(35)))));
            this.closeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(17)))), ((int)(((byte)(35)))));
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.Image = global::UltraWideScreenShare.WinForms.Properties.Resources.dismiss;
            this.closeButton.Location = new System.Drawing.Point(440, 0);
            this.closeButton.Margin = new System.Windows.Forms.Padding(0);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(50, 40);
            this.closeButton.TabIndex = 0;
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Magenta;
            this.TransparencyKey = System.Drawing.Color.Magenta;
            this.ClientSize = new System.Drawing.Size(914, 600);
            this.ControlBox = false;
            this.Controls.Add(this.controlPanel);
            this.Controls.Add(this.magnifierPanel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(571, 267);
            this.Name = "MainWindow";
            this.Padding = new System.Windows.Forms.Padding(9, 11, 9, 11);
            this.Text = "Ultra Wide Screen Share 2.0";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.ResizeBegin += new System.EventHandler(this.MainWindow_ResizeBegin);
            this.ResizeEnd += new System.EventHandler(this.MainWindow_ResizeEnd);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainWindow_Paint);
            this.controlPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel magnifierPanel;
        private FlowLayoutPanel controlPanel;
        private Button closeButton;
        private Button maximizeButton;
        private Button minimizeButton;
        private Button tittleButton;
        private Button dragButton;
        private Button shareButton;
    }
}