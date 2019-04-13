namespace CIA0008_ORM
{
    partial class NovyTym
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
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.Nazev_tymu = new System.Windows.Forms.TextBox();
            this.Min_zamestnancu = new System.Windows.Forms.TextBox();
            this.ID_prac = new System.Windows.Forms.TextBox();
            this.Datum = new System.Windows.Forms.DateTimePicker();
            this.ZpetBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID_pracoviště:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Datum:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Nazev týmu:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Min. zaměstnanců:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(197, 110);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Vytvořit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Nazev_tymu
            // 
            this.Nazev_tymu.Location = new System.Drawing.Point(120, 58);
            this.Nazev_tymu.Name = "Nazev_tymu";
            this.Nazev_tymu.Size = new System.Drawing.Size(152, 20);
            this.Nazev_tymu.TabIndex = 7;
            // 
            // Min_zamestnancu
            // 
            this.Min_zamestnancu.Location = new System.Drawing.Point(120, 84);
            this.Min_zamestnancu.Name = "Min_zamestnancu";
            this.Min_zamestnancu.Size = new System.Drawing.Size(152, 20);
            this.Min_zamestnancu.TabIndex = 8;
            // 
            // ID_prac
            // 
            this.ID_prac.Location = new System.Drawing.Point(120, 6);
            this.ID_prac.Name = "ID_prac";
            this.ID_prac.Size = new System.Drawing.Size(152, 20);
            this.ID_prac.TabIndex = 10;
            // 
            // Datum
            // 
            this.Datum.Location = new System.Drawing.Point(120, 33);
            this.Datum.Name = "Datum";
            this.Datum.Size = new System.Drawing.Size(152, 20);
            this.Datum.TabIndex = 11;
            // 
            // ZpetBtn
            // 
            this.ZpetBtn.Location = new System.Drawing.Point(120, 110);
            this.ZpetBtn.Name = "ZpetBtn";
            this.ZpetBtn.Size = new System.Drawing.Size(75, 23);
            this.ZpetBtn.TabIndex = 12;
            this.ZpetBtn.Text = "Zpět";
            this.ZpetBtn.UseVisualStyleBackColor = true;
            this.ZpetBtn.Click += new System.EventHandler(this.ZpetBtn_Click);
            // 
            // NovyTym
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(281, 143);
            this.Controls.Add(this.ZpetBtn);
            this.Controls.Add(this.Datum);
            this.Controls.Add(this.ID_prac);
            this.Controls.Add(this.Min_zamestnancu);
            this.Controls.Add(this.Nazev_tymu);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.Name = "NovyTym";
            this.Text = "Nový tým";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox Nazev_tymu;
        private System.Windows.Forms.TextBox Min_zamestnancu;
        private System.Windows.Forms.TextBox ID_prac;
        private System.Windows.Forms.DateTimePicker Datum;
        private System.Windows.Forms.Button ZpetBtn;
    }
}