namespace DcvKeyLogger
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_UID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_Keys = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label_DCV = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "LicenseUID:";
            // 
            // textBox_UID
            // 
            this.textBox_UID.Location = new System.Drawing.Point(103, 12);
            this.textBox_UID.Name = "textBox_UID";
            this.textBox_UID.Size = new System.Drawing.Size(469, 27);
            this.textBox_UID.TabIndex = 1;
            this.textBox_UID.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 186);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Key:";
            // 
            // textBox_Keys
            // 
            this.textBox_Keys.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Keys.Location = new System.Drawing.Point(55, 150);
            this.textBox_Keys.Multiline = true;
            this.textBox_Keys.Name = "textBox_Keys";
            this.textBox_Keys.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_Keys.Size = new System.Drawing.Size(518, 100);
            this.textBox_Keys.TabIndex = 3;
            this.textBox_Keys.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label_DCV);
            this.panel1.Location = new System.Drawing.Point(12, 45);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(560, 100);
            this.panel1.TabIndex = 4;
            // 
            // label_DCV
            // 
            this.label_DCV.AllowDrop = true;
            this.label_DCV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_DCV.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_DCV.Location = new System.Drawing.Point(0, 0);
            this.label_DCV.Name = "label_DCV";
            this.label_DCV.Size = new System.Drawing.Size(558, 98);
            this.label_DCV.TabIndex = 0;
            this.label_DCV.Text = "Drag && Drop DCV here";
            this.label_DCV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_DCV.Click += new System.EventHandler(this.label_DCV_Click);
            this.label_DCV.DragDrop += new System.Windows.Forms.DragEventHandler(this.label_DCV_DragDrop);
            this.label_DCV.DragEnter += new System.Windows.Forms.DragEventHandler(this.label_DCV_DragEnter);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 261);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textBox_Keys);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_UID);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "DcvKeyLogger";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_UID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_Keys;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label_DCV;
    }
}

