namespace INTERPRETER
{
    partial class Form1
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
            this.textboxMain = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textboxMain
            // 
            this.textboxMain.Location = new System.Drawing.Point(12, 12);
            this.textboxMain.Multiline = true;
            this.textboxMain.Name = "textboxMain";
            this.textboxMain.Size = new System.Drawing.Size(460, 208);
            this.textboxMain.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(309, 226);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(163, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "INTERPRET";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 261);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textboxMain);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "INTERPRETER";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textboxMain;
        private System.Windows.Forms.Button button1;
    }
}

