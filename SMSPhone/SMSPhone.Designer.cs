namespace SMSPhone {
    partial class SMSPhone {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.CallListView = new System.Windows.Forms.ListView();
            this.ContactName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PhoneNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SMSButton = new System.Windows.Forms.Button();
            this.ChargeProgressBar = new System.Windows.Forms.ProgressBar();
            this.ChargeButton = new System.Windows.Forms.Button();
            this.CallType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // CallListView
            // 
            this.CallListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ContactName,
            this.PhoneNumber,
            this.CallType});
            this.CallListView.Location = new System.Drawing.Point(25, 250);
            this.CallListView.MaximumSize = new System.Drawing.Size(285, 335);
            this.CallListView.MinimumSize = new System.Drawing.Size(285, 335);
            this.CallListView.Name = "CallListView";
            this.CallListView.Size = new System.Drawing.Size(285, 335);
            this.CallListView.TabIndex = 7;
            this.CallListView.TileSize = new System.Drawing.Size(280, 50);
            this.CallListView.UseCompatibleStateImageBehavior = false;
            this.CallListView.View = System.Windows.Forms.View.Tile;
            // 
            // SMSButton
            // 
            this.SMSButton.Location = new System.Drawing.Point(25, 153);
            this.SMSButton.Name = "SMSButton";
            this.SMSButton.Size = new System.Drawing.Size(120, 21);
            this.SMSButton.TabIndex = 8;
            this.SMSButton.Text = "Generate calls";
            this.SMSButton.UseVisualStyleBackColor = true;
            this.SMSButton.Click += new System.EventHandler(this.SMSButton_Click);
            // 
            // ChargeProgressBar
            // 
            this.ChargeProgressBar.Location = new System.Drawing.Point(25, 35);
            this.ChargeProgressBar.Name = "ChargeProgressBar";
            this.ChargeProgressBar.Size = new System.Drawing.Size(120, 21);
            this.ChargeProgressBar.TabIndex = 9;
            // 
            // ChargeButton
            // 
            this.ChargeButton.Location = new System.Drawing.Point(25, 74);
            this.ChargeButton.Name = "ChargeButton";
            this.ChargeButton.Size = new System.Drawing.Size(120, 21);
            this.ChargeButton.TabIndex = 10;
            this.ChargeButton.Text = "Charge";
            this.ChargeButton.UseVisualStyleBackColor = true;
            this.ChargeButton.Click += new System.EventHandler(this.ChargeButton_Click);
            // 
            // SMSPhone
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 611);
            this.Controls.Add(this.ChargeButton);
            this.Controls.Add(this.ChargeProgressBar);
            this.Controls.Add(this.SMSButton);
            this.Controls.Add(this.CallListView);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(350, 650);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(350, 650);
            this.Name = "SMSPhone";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SMSPhone";
            this.Load += new System.EventHandler(this.SMSPhone_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListView CallListView;
        private System.Windows.Forms.ColumnHeader ContactName;
        private System.Windows.Forms.ColumnHeader PhoneNumber;
        private System.Windows.Forms.Button SMSButton;
        private System.Windows.Forms.ProgressBar ChargeProgressBar;
        private System.Windows.Forms.Button ChargeButton;
        private System.Windows.Forms.ColumnHeader CallType;
    }
}

