namespace EmlakTakip
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.müşteriKayıtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.müstakilEvlerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.arsalarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.işYeriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.turistlikTesisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.çıkışToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.müşteriKayıtToolStripMenuItem,
            this.müstakilEvlerToolStripMenuItem,
            this.arsalarToolStripMenuItem,
            this.işYeriToolStripMenuItem,
            this.turistlikTesisToolStripMenuItem,
            this.çıkışToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(957, 28);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // müşteriKayıtToolStripMenuItem
            // 
            this.müşteriKayıtToolStripMenuItem.Name = "müşteriKayıtToolStripMenuItem";
            this.müşteriKayıtToolStripMenuItem.Size = new System.Drawing.Size(109, 24);
            this.müşteriKayıtToolStripMenuItem.Text = "Müşteri Kayıt";
            this.müşteriKayıtToolStripMenuItem.Click += new System.EventHandler(this.müşteriKayıtToolStripMenuItem_Click);
            // 
            // müstakilEvlerToolStripMenuItem
            // 
            this.müstakilEvlerToolStripMenuItem.Name = "müstakilEvlerToolStripMenuItem";
            this.müstakilEvlerToolStripMenuItem.Size = new System.Drawing.Size(114, 24);
            this.müstakilEvlerToolStripMenuItem.Text = "Müstakil Evler";
            this.müstakilEvlerToolStripMenuItem.Click += new System.EventHandler(this.müstakilEvlerToolStripMenuItem_Click);
            // 
            // arsalarToolStripMenuItem
            // 
            this.arsalarToolStripMenuItem.Name = "arsalarToolStripMenuItem";
            this.arsalarToolStripMenuItem.Size = new System.Drawing.Size(69, 24);
            this.arsalarToolStripMenuItem.Text = "Arsalar";
            this.arsalarToolStripMenuItem.Click += new System.EventHandler(this.arsalarToolStripMenuItem_Click);
            // 
            // işYeriToolStripMenuItem
            // 
            this.işYeriToolStripMenuItem.Name = "işYeriToolStripMenuItem";
            this.işYeriToolStripMenuItem.Size = new System.Drawing.Size(61, 24);
            this.işYeriToolStripMenuItem.Text = "İş Yeri";
            this.işYeriToolStripMenuItem.Click += new System.EventHandler(this.işYeriToolStripMenuItem_Click);
            // 
            // turistlikTesisToolStripMenuItem
            // 
            this.turistlikTesisToolStripMenuItem.Name = "turistlikTesisToolStripMenuItem";
            this.turistlikTesisToolStripMenuItem.Size = new System.Drawing.Size(109, 24);
            this.turistlikTesisToolStripMenuItem.Text = "Turistlik Tesis";
            this.turistlikTesisToolStripMenuItem.Click += new System.EventHandler(this.turistlikTesisToolStripMenuItem_Click);
            // 
            // çıkışToolStripMenuItem
            // 
            this.çıkışToolStripMenuItem.Name = "çıkışToolStripMenuItem";
            this.çıkışToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.çıkışToolStripMenuItem.Text = "Çıkış";
            this.çıkışToolStripMenuItem.Click += new System.EventHandler(this.çıkışToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(957, 496);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Emlakçı";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem müşteriKayıtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem müstakilEvlerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem çıkışToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem arsalarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem işYeriToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem turistlikTesisToolStripMenuItem;
    }
}

