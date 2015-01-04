namespace Wolcano
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.wolPortLabel = new System.Windows.Forms.Label();
            this.wolPortTextBox = new System.Windows.Forms.TextBox();
            this.wolMacLabel = new System.Windows.Forms.Label();
            this.wolMacTextBox = new System.Windows.Forms.TextBox();
            this.wolIpLabel = new System.Windows.Forms.Label();
            this.wolIpTextBox = new System.Windows.Forms.TextBox();
            this.wolButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // wolPortLabel
            // 
            this.wolPortLabel.AutoSize = true;
            this.wolPortLabel.Location = new System.Drawing.Point(330, 19);
            this.wolPortLabel.Name = "wolPortLabel";
            this.wolPortLabel.Size = new System.Drawing.Size(28, 13);
            this.wolPortLabel.TabIndex = 13;
            this.wolPortLabel.Text = "port:";
            // 
            // wolPortTextBox
            // 
            this.wolPortTextBox.Location = new System.Drawing.Point(360, 12);
            this.wolPortTextBox.Name = "wolPortTextBox";
            this.wolPortTextBox.Size = new System.Drawing.Size(54, 20);
            this.wolPortTextBox.TabIndex = 12;
            // 
            // wolMacLabel
            // 
            this.wolMacLabel.AutoSize = true;
            this.wolMacLabel.Location = new System.Drawing.Point(14, 45);
            this.wolMacLabel.Name = "wolMacLabel";
            this.wolMacLabel.Size = new System.Drawing.Size(59, 13);
            this.wolMacLabel.TabIndex = 11;
            this.wolMacLabel.Text = "WOL Mac:";
            // 
            // wolMacTextBox
            // 
            this.wolMacTextBox.Location = new System.Drawing.Point(81, 38);
            this.wolMacTextBox.Name = "wolMacTextBox";
            this.wolMacTextBox.Size = new System.Drawing.Size(240, 20);
            this.wolMacTextBox.TabIndex = 10;
            // 
            // wolIpLabel
            // 
            this.wolIpLabel.AutoSize = true;
            this.wolIpLabel.Location = new System.Drawing.Point(26, 19);
            this.wolIpLabel.Name = "wolIpLabel";
            this.wolIpLabel.Size = new System.Drawing.Size(47, 13);
            this.wolIpLabel.TabIndex = 9;
            this.wolIpLabel.Text = "WOL Ip:";
            // 
            // wolIpTextBox
            // 
            this.wolIpTextBox.Location = new System.Drawing.Point(81, 12);
            this.wolIpTextBox.Name = "wolIpTextBox";
            this.wolIpTextBox.Size = new System.Drawing.Size(240, 20);
            this.wolIpTextBox.TabIndex = 8;
            // 
            // wolButton
            // 
            this.wolButton.Location = new System.Drawing.Point(11, 64);
            this.wolButton.Name = "wolButton";
            this.wolButton.Size = new System.Drawing.Size(403, 166);
            this.wolButton.TabIndex = 7;
            this.wolButton.Text = "Wake it!";
            this.wolButton.UseVisualStyleBackColor = true;
            this.wolButton.Click += new System.EventHandler(this.wolButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 239);
            this.Controls.Add(this.wolPortLabel);
            this.Controls.Add(this.wolPortTextBox);
            this.Controls.Add(this.wolMacLabel);
            this.Controls.Add(this.wolMacTextBox);
            this.Controls.Add(this.wolIpLabel);
            this.Controls.Add(this.wolIpTextBox);
            this.Controls.Add(this.wolButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.Text = "WOLcano";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label wolPortLabel;
        private System.Windows.Forms.TextBox wolPortTextBox;
        private System.Windows.Forms.Label wolMacLabel;
        private System.Windows.Forms.TextBox wolMacTextBox;
        private System.Windows.Forms.Label wolIpLabel;
        private System.Windows.Forms.TextBox wolIpTextBox;
        private System.Windows.Forms.Button wolButton;
    }
}

