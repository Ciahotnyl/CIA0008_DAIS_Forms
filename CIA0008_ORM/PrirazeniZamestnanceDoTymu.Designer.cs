namespace CIA0008_ORM
{
    partial class PrirazeniZamestnanceDoTymu
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
            this.datum_od = new System.Windows.Forms.DateTimePicker();
            this.datum_do = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.TymyLB = new System.Windows.Forms.ListBox();
            this.TymZamestnanceLB = new System.Windows.Forms.ListBox();
            this.ZamestnanciLB = new System.Windows.Forms.ListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // datum_od
            // 
            this.datum_od.Location = new System.Drawing.Point(82, 13);
            this.datum_od.Name = "datum_od";
            this.datum_od.Size = new System.Drawing.Size(168, 20);
            this.datum_od.TabIndex = 0;
            // 
            // datum_do
            // 
            this.datum_do.Location = new System.Drawing.Point(82, 40);
            this.datum_do.Name = "datum_do";
            this.datum_do.Size = new System.Drawing.Size(168, 20);
            this.datum_do.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(256, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 47);
            this.button1.TabIndex = 2;
            this.button1.Text = "Vyhledat týmy";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TymyLB
            // 
            this.TymyLB.FormattingEnabled = true;
            this.TymyLB.Location = new System.Drawing.Point(13, 66);
            this.TymyLB.Name = "TymyLB";
            this.TymyLB.Size = new System.Drawing.Size(354, 134);
            this.TymyLB.TabIndex = 3;
            this.TymyLB.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // TymZamestnanceLB
            // 
            this.TymZamestnanceLB.FormattingEnabled = true;
            this.TymZamestnanceLB.Location = new System.Drawing.Point(196, 206);
            this.TymZamestnanceLB.Name = "TymZamestnanceLB";
            this.TymZamestnanceLB.Size = new System.Drawing.Size(171, 134);
            this.TymZamestnanceLB.TabIndex = 4;
            // 
            // ZamestnanciLB
            // 
            this.ZamestnanciLB.FormattingEnabled = true;
            this.ZamestnanciLB.Location = new System.Drawing.Point(13, 206);
            this.ZamestnanciLB.Name = "ZamestnanciLB";
            this.ZamestnanciLB.Size = new System.Drawing.Size(170, 134);
            this.ZamestnanciLB.TabIndex = 5;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(108, 346);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Přidat";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(151, 376);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 7;
            this.button3.Text = "Hotovo";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(196, 346);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 8;
            this.button4.Text = "Odebrat";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // PrirazeniZamestnanceDoTymu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 411);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.ZamestnanciLB);
            this.Controls.Add(this.TymZamestnanceLB);
            this.Controls.Add(this.TymyLB);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.datum_do);
            this.Controls.Add(this.datum_od);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.Name = "PrirazeniZamestnanceDoTymu";
            this.Text = "PrirazeniZamestnanceDoTymu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker datum_od;
        private System.Windows.Forms.DateTimePicker datum_do;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox TymyLB;
        private System.Windows.Forms.ListBox TymZamestnanceLB;
        private System.Windows.Forms.ListBox ZamestnanciLB;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}