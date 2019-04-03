namespace server
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
            this.Start = new System.Windows.Forms.Button();
            this.Stop = new System.Windows.Forms.Button();
            this.port_textbox = new System.Windows.Forms.TextBox();
            this.label_port = new System.Windows.Forms.Label();
            this.path_textbox = new System.Windows.Forms.TextBox();
            this.label_path = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(13, 227);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(75, 23);
            this.Start.TabIndex = 0;
            this.Start.Text = "Start";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // Stop
            // 
            this.Stop.Location = new System.Drawing.Point(193, 227);
            this.Stop.Name = "Stop";
            this.Stop.Size = new System.Drawing.Size(75, 23);
            this.Stop.TabIndex = 1;
            this.Stop.Text = "Stop";
            this.Stop.UseVisualStyleBackColor = true;
            this.Stop.Click += new System.EventHandler(this.Stop_Click);
            // 
            // port_textbox
            // 
            this.port_textbox.Location = new System.Drawing.Point(48, 42);
            this.port_textbox.Name = "port_textbox";
            this.port_textbox.Size = new System.Drawing.Size(100, 20);
            this.port_textbox.TabIndex = 2;
            this.port_textbox.TextChanged += new System.EventHandler(this.port_TextChanged);
            // 
            // label_port
            // 
            this.label_port.AutoSize = true;
            this.label_port.Location = new System.Drawing.Point(48, 23);
            this.label_port.Name = "label_port";
            this.label_port.Size = new System.Drawing.Size(55, 13);
            this.label_port.TabIndex = 3;
            this.label_port.Text = "Podaj port";
            // 
            // path_textbox
            // 
            this.path_textbox.Location = new System.Drawing.Point(48, 89);
            this.path_textbox.Name = "path_textbox";
            this.path_textbox.Size = new System.Drawing.Size(100, 20);
            this.path_textbox.TabIndex = 4;
            this.path_textbox.TextChanged += new System.EventHandler(this.path_TextChanged);
            // 
            // label_path
            // 
            this.label_path.AutoSize = true;
            this.label_path.Location = new System.Drawing.Point(48, 73);
            this.label_path.Name = "label_path";
            this.label_path.Size = new System.Drawing.Size(73, 13);
            this.label_path.TabIndex = 5;
            this.label_path.Text = "Podaj ścieżkę";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.label_path);
            this.Controls.Add(this.path_textbox);
            this.Controls.Add(this.label_port);
            this.Controls.Add(this.port_textbox);
            this.Controls.Add(this.Stop);
            this.Controls.Add(this.Start);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.Button Stop;
        private System.Windows.Forms.TextBox port_textbox;
        private System.Windows.Forms.Label label_port;
        private System.Windows.Forms.TextBox path_textbox;
        private System.Windows.Forms.Label label_path;
    }
}