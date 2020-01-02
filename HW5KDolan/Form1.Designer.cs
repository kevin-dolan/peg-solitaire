namespace HW5KDolan
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
            this.moveListBox = new System.Windows.Forms.ListBox();
            this.startButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // moveListBox
            // 
            this.moveListBox.FormattingEnabled = true;
            this.moveListBox.Location = new System.Drawing.Point(12, 12);
            this.moveListBox.Name = "moveListBox";
            this.moveListBox.Size = new System.Drawing.Size(459, 355);
            this.moveListBox.TabIndex = 0;
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(212, 388);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 1;
            this.startButton.Text = "&Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 423);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.moveListBox);
            this.Name = "Form1";
            this.Text = "Peg Puzzle Solver";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox moveListBox;
        private System.Windows.Forms.Button startButton;
    }
}

