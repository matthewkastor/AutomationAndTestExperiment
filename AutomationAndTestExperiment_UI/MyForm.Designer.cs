namespace AutomationAndTestExperiment
{
    partial class MyForm
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
            this.MyStaticClass_SayHi_Btn = new System.Windows.Forms.Button();
            this.MessageDisplay = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // MyStaticClass_SayHi_Btn
            // 
            this.MyStaticClass_SayHi_Btn.Location = new System.Drawing.Point(12, 12);
            this.MyStaticClass_SayHi_Btn.Name = "MyStaticClass_SayHi_Btn";
            this.MyStaticClass_SayHi_Btn.Size = new System.Drawing.Size(260, 23);
            this.MyStaticClass_SayHi_Btn.TabIndex = 0;
            this.MyStaticClass_SayHi_Btn.Text = "MyStaticClass.SayHi";
            this.MyStaticClass_SayHi_Btn.UseVisualStyleBackColor = true;
            this.MyStaticClass_SayHi_Btn.Click += new System.EventHandler(this.MyStaticClass_SayHi_Btn_Click);
            // 
            // MessageDisplay
            // 
            this.MessageDisplay.AccessibleDescription = "MessageDisplay";
            this.MessageDisplay.AccessibleName = "MessageDisplay";
            this.MessageDisplay.Enabled = false;
            this.MessageDisplay.Location = new System.Drawing.Point(13, 42);
            this.MessageDisplay.Name = "MessageDisplay";
            this.MessageDisplay.Size = new System.Drawing.Size(100, 20);
            this.MessageDisplay.TabIndex = 1;
            // 
            // MyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.MessageDisplay);
            this.Controls.Add(this.MyStaticClass_SayHi_Btn);
            this.Name = "MyForm";
            this.Text = "MyForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button MyStaticClass_SayHi_Btn;
        private System.Windows.Forms.TextBox MessageDisplay;
    }
}

