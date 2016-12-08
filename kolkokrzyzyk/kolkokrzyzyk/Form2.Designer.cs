namespace kolkokrzyzyk
{
    partial class Form2
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
            this.label2 = new System.Windows.Forms.Label();
            this.g1 = new System.Windows.Forms.TextBox();
            this.g2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(331, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Imię gracza 2:";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(26, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Imię gracza 1:";
            // 
            // g1
            // 
            this.g1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.g1.Location = new System.Drawing.Point(12, 58);
            this.g1.Name = "g1";
            this.g1.Size = new System.Drawing.Size(199, 26);
            this.g1.TabIndex = 3;
            this.g1.TextChanged += new System.EventHandler(this.g1_TextChanged);
            // 
            // g2
            // 
            this.g2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.g2.Location = new System.Drawing.Point(314, 101);
            this.g2.Name = "g2";
            this.g2.Size = new System.Drawing.Size(199, 26);
            this.g2.TabIndex = 4;
            this.g2.TextChanged += new System.EventHandler(this.g2_TextChanged);
            this.g2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.g2_KeyPress);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(236, 73);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(53, 54);
            this.button1.TabIndex = 5;
            this.button1.Text = "OK!";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(348, 21);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(130, 29);
            this.button2.TabIndex = 6;
            this.button2.Text = "Gra przeciw SI";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 139);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.g2);
            this.Controls.Add(this.g1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(555, 178);
            this.MinimumSize = new System.Drawing.Size(555, 178);
            this.Name = "Form2";
            this.ShowIcon = false;
            this.Text = "Kółko i Krzyżyk";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox g1;
        private System.Windows.Forms.TextBox g2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}