namespace MyFormsHugeProgressJob
{
    partial class FormMain
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
            this.button_Close = new System.Windows.Forms.Button();
            this.button_Toggle = new System.Windows.Forms.Button();
            this.button_Cancel_Task = new System.Windows.Forms.Button();
            this.button_Start_Task = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_Close
            // 
            this.button_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Close.Location = new System.Drawing.Point(377, 146);
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(75, 23);
            this.button_Close.TabIndex = 0;
            this.button_Close.Text = "Close";
            this.button_Close.UseVisualStyleBackColor = true;
            this.button_Close.Click += new System.EventHandler(this.button_Close_Click);
            // 
            // button_Toggle
            // 
            this.button_Toggle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Toggle.Location = new System.Drawing.Point(377, 117);
            this.button_Toggle.Name = "button_Toggle";
            this.button_Toggle.Size = new System.Drawing.Size(75, 23);
            this.button_Toggle.TabIndex = 1;
            this.button_Toggle.Text = "Toggle";
            this.button_Toggle.UseVisualStyleBackColor = true;
            this.button_Toggle.Click += new System.EventHandler(this.button_Toggle_Click);
            // 
            // button_Cancel_Task
            // 
            this.button_Cancel_Task.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Cancel_Task.Location = new System.Drawing.Point(377, 88);
            this.button_Cancel_Task.Name = "button_Cancel_Task";
            this.button_Cancel_Task.Size = new System.Drawing.Size(75, 23);
            this.button_Cancel_Task.TabIndex = 2;
            this.button_Cancel_Task.Text = "Cancel Task";
            this.button_Cancel_Task.UseVisualStyleBackColor = true;
            this.button_Cancel_Task.Click += new System.EventHandler(this.button_Cancel_Task_Click);
            // 
            // button_Start_Task
            // 
            this.button_Start_Task.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Start_Task.Location = new System.Drawing.Point(377, 59);
            this.button_Start_Task.Name = "button_Start_Task";
            this.button_Start_Task.Size = new System.Drawing.Size(75, 23);
            this.button_Start_Task.TabIndex = 3;
            this.button_Start_Task.Text = "Start Task";
            this.button_Start_Task.UseVisualStyleBackColor = true;
            this.button_Start_Task.Click += new System.EventHandler(this.button_Start_Task_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 181);
            this.Controls.Add(this.button_Start_Task);
            this.Controls.Add(this.button_Cancel_Task);
            this.Controls.Add(this.button_Toggle);
            this.Controls.Add(this.button_Close);
            this.Name = "FormMain";
            this.Text = "MyFormsHugeProgressJob C#";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_Close;
        private System.Windows.Forms.Button button_Toggle;
        private System.Windows.Forms.Button button_Cancel_Task;
        private System.Windows.Forms.Button button_Start_Task;
    }
}

