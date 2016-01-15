namespace XInputMapper
{
    partial class Debug_Console
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
            this._Console = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // _Console
            // 
            this._Console.BackColor = System.Drawing.SystemColors.MenuText;
            this._Console.ForeColor = System.Drawing.SystemColors.Info;
            this._Console.Location = new System.Drawing.Point(0, 0);
            this._Console.Name = "_Console";
            this._Console.Size = new System.Drawing.Size(553, 306);
            this._Console.TabIndex = 0;
            this._Console.Text = "";
            // 
            // Debug_Console
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 305);
            this.Controls.Add(this._Console);
            this.Name = "Debug_Console";
            this.Text = "Debug_Console";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox _Console;
    }
}