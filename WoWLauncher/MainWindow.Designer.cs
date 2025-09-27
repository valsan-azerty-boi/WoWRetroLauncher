using System;
using System.Windows.Forms;

namespace WoWRetroLauncher
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.optionSkinVanilla = new ToolStripMenuItem();
            this.gameDetailsLarge = new Label();
            this.gameDetailsShort = new Label();
            this.buttonPlay = new LauncherButton();
            this.webView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
            ((System.ComponentModel.ISupportInitialize)(this.webView21)).BeginInit();
            this.SuspendLayout();
            // 
            // optionSkinVanilla
            // 
            this.optionSkinVanilla.Name = "optionSkinVanilla";
            this.optionSkinVanilla.Size = new System.Drawing.Size(67, 22);
            // 
            // gameDetailsLarge
            // 
            this.gameDetailsLarge.AutoSize = false;
            this.gameDetailsLarge.BackColor = System.Drawing.Color.Transparent;
            this.gameDetailsLarge.Font = new System.Drawing.Font("Cambria", 14.25F);
            this.gameDetailsLarge.ForeColor = System.Drawing.Color.Goldenrod;
            this.gameDetailsLarge.Location = new System.Drawing.Point(12, 524);
            this.gameDetailsLarge.Name = "gameDetailsLarge";
            this.gameDetailsLarge.Size = new System.Drawing.Size(400, 44);
            this.gameDetailsLarge.TabIndex = 2;
            this.gameDetailsLarge.Text = string.Empty;
            // 
            // gameDetailsShort
            // 
            this.gameDetailsShort.AutoSize = false;
            this.gameDetailsShort.BackColor = System.Drawing.Color.Transparent;
            this.gameDetailsShort.Font = new System.Drawing.Font("Cambria", 14.25F);
            this.gameDetailsShort.ForeColor = System.Drawing.Color.Goldenrod;
            this.gameDetailsShort.Location = new System.Drawing.Point(31, 534);
            this.gameDetailsShort.Name = "gameDetailsShort";
            this.gameDetailsShort.Size = new System.Drawing.Size(300, 22);
            this.gameDetailsShort.TabIndex = 3;
            this.gameDetailsShort.Text = " ";
            // 
            // buttonPlay
            // 
            this.buttonPlay.BackColor = System.Drawing.Color.Transparent;
            this.buttonPlay.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonPlay.BackgroundImage")));
            this.buttonPlay.BackgroundImageLayout = ImageLayout.Stretch;
            this.buttonPlay.Cursor = Cursors.Hand;
            this.buttonPlay.FlatAppearance.BorderSize = 0;
            this.buttonPlay.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonPlay.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonPlay.FlatStyle = FlatStyle.Flat;
            this.buttonPlay.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F, System.Drawing.FontStyle.Bold);
            this.buttonPlay.ForeColor = System.Drawing.Color.Transparent;
            this.buttonPlay.Location = new System.Drawing.Point(649, 506);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(130, 74);
            this.buttonPlay.TabIndex = 0;
            this.buttonPlay.TabStop = false;
            this.buttonPlay.Type = LauncherButton.ButtonType.Play;
            this.buttonPlay.UseMnemonic = false;
            this.buttonPlay.UseVisualStyleBackColor = false;
            this.buttonPlay.Click += new System.EventHandler(this.Click_play);
            // 
            // webView21
            // 
            this.webView21.AllowExternalDrop = true;
            this.webView21.BackColor = System.Drawing.SystemColors.Window;
            this.webView21.CreationProperties = null;
            this.webView21.DefaultBackgroundColor = System.Drawing.Color.Transparent;
            this.webView21.Location = new System.Drawing.Point(1, 39);
            this.webView21.Name = "webView21";
            this.webView21.Size = new System.Drawing.Size(798, 443);
            this.webView21.TabIndex = 4;
            this.webView21.ZoomFactor = 1D;
            // 
            // MainWindow
            // 
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::WoWRetroLauncher.Properties.Resources.default_background;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 601);
            this.Controls.Add(this.gameDetailsLarge);
            this.Controls.Add(this.gameDetailsShort);
            this.Controls.Add(this.buttonPlay);
            this.Controls.Add(this.webView21);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.Transparent;
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "World of Warcraft";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.Resize += new System.EventHandler(this.MainWindow_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.webView21)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private LauncherButton buttonPlay;
        private ToolStripMenuItem optionSkinVanilla;
        private Label gameDetailsLarge;
        private Label gameDetailsShort;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView21;
    }
}
