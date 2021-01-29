namespace Notify.Notify.Forms
{
    partial class NewConnectionForm
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
        private void InitializeComponent(string ip)
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.LabelRequestToken = new System.Windows.Forms.Label();
            this.IPLabel = new System.Windows.Forms.Label();
            this.DenyButton = new System.Windows.Forms.Button();
            this.AcceptButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.LabelRequestToken);
            this.splitContainer1.Panel1.Controls.Add(this.IPLabel);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.DenyButton);
            this.splitContainer1.Panel2.Controls.Add(this.AcceptButton);
            this.splitContainer1.Size = new System.Drawing.Size(279, 148);
            this.splitContainer1.SplitterDistance = 75;
            this.splitContainer1.TabIndex = 0;
            // 
            // LabelRequestToken
            // 
            this.LabelRequestToken.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelRequestToken.Location = new System.Drawing.Point(12, 42);
            this.LabelRequestToken.Name = "LabelRequestToken";
            this.LabelRequestToken.Size = new System.Drawing.Size(257, 21);
            this.LabelRequestToken.TabIndex = 1;
            this.LabelRequestToken.Text = "LabelRequestToken";
            this.LabelRequestToken.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LabelRequestToken.UseCompatibleTextRendering = true;
            this.LabelRequestToken.Visible = false;
            // 
            // IPLabel
            // 
            this.IPLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IPLabel.Location = new System.Drawing.Point(9, 9);
            this.IPLabel.Name = "IPLabel";
            this.IPLabel.Size = new System.Drawing.Size(260, 22);
            this.IPLabel.TabIndex = 0;
            this.IPLabel.Text = "IP: "+ ip;
            this.IPLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DenyButton
            // 
            this.DenyButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.DenyButton.Location = new System.Drawing.Point(183, 15);
            this.DenyButton.Name = "DenyButton";
            this.DenyButton.Size = new System.Drawing.Size(89, 49);
            this.DenyButton.TabIndex = 3;
            this.DenyButton.Text = "Deny";
            this.DenyButton.UseVisualStyleBackColor = true;
            this.DenyButton.Click += new System.EventHandler(this.DenyButton_Click);
            // 
            // AcceptButton
            // 
            this.AcceptButton.Location = new System.Drawing.Point(12, 15);
            this.AcceptButton.Name = "AcceptButton";
            this.AcceptButton.Size = new System.Drawing.Size(89, 49);
            this.AcceptButton.TabIndex = 2;
            this.AcceptButton.Text = "Accept";
            this.AcceptButton.UseVisualStyleBackColor = true;
            this.AcceptButton.Click += new System.EventHandler(this.AcceptButton_Click);
            // 
            // NewConnectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.CancelButton = this.DenyButton;
            this.ClientSize = new System.Drawing.Size(279, 148);
            this.Controls.Add(this.splitContainer1);
            this.Name = "NewConnectionForm";
            this.Text = "Connection from ";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button DenyButton;
        private System.Windows.Forms.Button AcceptButton;
        private System.Windows.Forms.Label IPLabel;
        private System.Windows.Forms.Label LabelRequestToken;
    }
}