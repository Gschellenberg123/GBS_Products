namespace ACS_GSchellenbergM7
{
    partial class Help
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
            this.btnClose = new System.Windows.Forms.Button();
            this.cbxHelpOption = new System.Windows.Forms.ComboBox();
            this.lblNeedHelp = new System.Windows.Forms.Label();
            this.lblHelpInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(15, 95);
            this.btnClose.Margin = new System.Windows.Forms.Padding(6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 66);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // cbxHelpOption
            // 
            this.cbxHelpOption.FormattingEnabled = true;
            this.cbxHelpOption.Items.AddRange(new object[] {
            "Exit",
            "Shop",
            "Cart",
            "Check Out"});
            this.cbxHelpOption.Location = new System.Drawing.Point(15, 51);
            this.cbxHelpOption.Margin = new System.Windows.Forms.Padding(6);
            this.cbxHelpOption.Name = "cbxHelpOption";
            this.cbxHelpOption.Size = new System.Drawing.Size(260, 32);
            this.cbxHelpOption.TabIndex = 1;
            this.cbxHelpOption.SelectedIndexChanged += new System.EventHandler(this.cbxHelpOption_SelectedIndexChanged);
            // 
            // lblNeedHelp
            // 
            this.lblNeedHelp.AutoSize = true;
            this.lblNeedHelp.Location = new System.Drawing.Point(15, 21);
            this.lblNeedHelp.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblNeedHelp.Name = "lblNeedHelp";
            this.lblNeedHelp.Size = new System.Drawing.Size(260, 24);
            this.lblNeedHelp.TabIndex = 2;
            this.lblNeedHelp.Text = "What Do You Need Help With";
            // 
            // lblHelpInfo
            // 
            this.lblHelpInfo.AutoSize = true;
            this.lblHelpInfo.Location = new System.Drawing.Point(284, 51);
            this.lblHelpInfo.Name = "lblHelpInfo";
            this.lblHelpInfo.Size = new System.Drawing.Size(215, 24);
            this.lblHelpInfo.TabIndex = 3;
            this.lblHelpInfo.Text = "Select A tab To find help";
            // 
            // Help
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 224);
            this.Controls.Add(this.lblHelpInfo);
            this.Controls.Add(this.lblNeedHelp);
            this.Controls.Add(this.cbxHelpOption);
            this.Controls.Add(this.btnClose);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Help";
            this.Text = "Help";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ComboBox cbxHelpOption;
        private System.Windows.Forms.Label lblNeedHelp;
        private System.Windows.Forms.Label lblHelpInfo;
    }
}