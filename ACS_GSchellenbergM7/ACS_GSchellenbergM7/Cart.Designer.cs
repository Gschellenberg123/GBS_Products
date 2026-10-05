namespace ACS_GSchellenbergM7
{
    partial class Cart
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
            this.lbxCart = new System.Windows.Forms.ListBox();
            this.btnContinueShopping = new System.Windows.Forms.Button();
            this.btnClearCart = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnCheckout = new System.Windows.Forms.Button();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.lblWriteSubtotal = new System.Windows.Forms.Label();
            this.lblWriteTaxAmount = new System.Windows.Forms.Label();
            this.lblTaxAmount = new System.Windows.Forms.Label();
            this.lblWriteTotalDue = new System.Windows.Forms.Label();
            this.lblTotalDue = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbxCart
            // 
            this.lbxCart.FormattingEnabled = true;
            this.lbxCart.ItemHeight = 22;
            this.lbxCart.Location = new System.Drawing.Point(14, 14);
            this.lbxCart.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.lbxCart.Name = "lbxCart";
            this.lbxCart.Size = new System.Drawing.Size(1101, 334);
            this.lbxCart.TabIndex = 0;
            this.lbxCart.TabStop = false;
            // 
            // btnContinueShopping
            // 
            this.btnContinueShopping.Location = new System.Drawing.Point(14, 367);
            this.btnContinueShopping.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnContinueShopping.Name = "btnContinueShopping";
            this.btnContinueShopping.Size = new System.Drawing.Size(113, 72);
            this.btnContinueShopping.TabIndex = 1;
            this.btnContinueShopping.TabStop = false;
            this.btnContinueShopping.Text = "&Continue Shopping";
            this.btnContinueShopping.UseVisualStyleBackColor = true;
            this.btnContinueShopping.Click += new System.EventHandler(this.btnContinueShopping_Click);
            // 
            // btnClearCart
            // 
            this.btnClearCart.Location = new System.Drawing.Point(150, 367);
            this.btnClearCart.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnClearCart.Name = "btnClearCart";
            this.btnClearCart.Size = new System.Drawing.Size(113, 72);
            this.btnClearCart.TabIndex = 2;
            this.btnClearCart.TabStop = false;
            this.btnClearCart.Text = "C&lear Cart";
            this.btnClearCart.UseVisualStyleBackColor = true;
            this.btnClearCart.Click += new System.EventHandler(this.btnClearCart_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(274, 367);
            this.btnRemove.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(113, 72);
            this.btnRemove.TabIndex = 3;
            this.btnRemove.TabStop = false;
            this.btnRemove.Text = "&Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnCheckout
            // 
            this.btnCheckout.Location = new System.Drawing.Point(408, 367);
            this.btnCheckout.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnCheckout.Name = "btnCheckout";
            this.btnCheckout.Size = new System.Drawing.Size(113, 72);
            this.btnCheckout.TabIndex = 4;
            this.btnCheckout.TabStop = false;
            this.btnCheckout.Text = "Chec&k Out";
            this.btnCheckout.UseVisualStyleBackColor = true;
            this.btnCheckout.Click += new System.EventHandler(this.btnCheckout_Click);
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.AutoSize = true;
            this.lblSubtotal.Location = new System.Drawing.Point(726, 367);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(100, 22);
            this.lblSubtotal.TabIndex = 5;
            this.lblSubtotal.Text = "Subtotal:";
            // 
            // lblWriteSubtotal
            // 
            this.lblWriteSubtotal.AutoSize = true;
            this.lblWriteSubtotal.Location = new System.Drawing.Point(832, 367);
            this.lblWriteSubtotal.Name = "lblWriteSubtotal";
            this.lblWriteSubtotal.Size = new System.Drawing.Size(100, 22);
            this.lblWriteSubtotal.TabIndex = 6;
            this.lblWriteSubtotal.Text = "sdfsfdsdf";
            // 
            // lblWriteTaxAmount
            // 
            this.lblWriteTaxAmount.AutoSize = true;
            this.lblWriteTaxAmount.Location = new System.Drawing.Point(832, 406);
            this.lblWriteTaxAmount.Name = "lblWriteTaxAmount";
            this.lblWriteTaxAmount.Size = new System.Drawing.Size(110, 22);
            this.lblWriteTaxAmount.TabIndex = 8;
            this.lblWriteTaxAmount.Text = "asddadfasd";
            // 
            // lblTaxAmount
            // 
            this.lblTaxAmount.AutoSize = true;
            this.lblTaxAmount.Location = new System.Drawing.Point(706, 406);
            this.lblTaxAmount.Name = "lblTaxAmount";
            this.lblTaxAmount.Size = new System.Drawing.Size(120, 22);
            this.lblTaxAmount.TabIndex = 7;
            this.lblTaxAmount.Text = "Tax Amount:";
            // 
            // lblWriteTotalDue
            // 
            this.lblWriteTotalDue.AutoSize = true;
            this.lblWriteTotalDue.Location = new System.Drawing.Point(832, 451);
            this.lblWriteTotalDue.Name = "lblWriteTotalDue";
            this.lblWriteTotalDue.Size = new System.Drawing.Size(100, 22);
            this.lblWriteTotalDue.TabIndex = 10;
            this.lblWriteTotalDue.Text = "asdasdasd";
            // 
            // lblTotalDue
            // 
            this.lblTotalDue.AutoSize = true;
            this.lblTotalDue.Location = new System.Drawing.Point(716, 451);
            this.lblTotalDue.Name = "lblTotalDue";
            this.lblTotalDue.Size = new System.Drawing.Size(110, 22);
            this.lblTotalDue.TabIndex = 9;
            this.lblTotalDue.Text = "Total Due:";
            // 
            // Cart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1129, 490);
            this.Controls.Add(this.lblWriteTotalDue);
            this.Controls.Add(this.lblTotalDue);
            this.Controls.Add(this.lblWriteTaxAmount);
            this.Controls.Add(this.lblTaxAmount);
            this.Controls.Add(this.lblWriteSubtotal);
            this.Controls.Add(this.lblSubtotal);
            this.Controls.Add(this.btnCheckout);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnClearCart);
            this.Controls.Add(this.btnContinueShopping);
            this.Controls.Add(this.lbxCart);
            this.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "Cart";
            this.Text = "Cart";
            this.Load += new System.EventHandler(this.Cart_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbxCart;
        private System.Windows.Forms.Button btnContinueShopping;
        private System.Windows.Forms.Button btnClearCart;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnCheckout;
        private System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.Label lblWriteSubtotal;
        private System.Windows.Forms.Label lblWriteTaxAmount;
        private System.Windows.Forms.Label lblTaxAmount;
        private System.Windows.Forms.Label lblWriteTotalDue;
        private System.Windows.Forms.Label lblTotalDue;
    }
}