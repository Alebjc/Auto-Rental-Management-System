
namespace ARMSWinClient
{
    partial class frmMailWelcomeForm
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnPOS = new System.Windows.Forms.Button();
            this.btnERP = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(212, 44);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(133, 13);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "EZRental POS System";
            // 
            // btnPOS
            // 
            this.btnPOS.Location = new System.Drawing.Point(143, 80);
            this.btnPOS.Name = "btnPOS";
            this.btnPOS.Size = new System.Drawing.Size(275, 35);
            this.btnPOS.TabIndex = 1;
            this.btnPOS.Text = "Point-of-Sales && Rentals";
            this.btnPOS.UseVisualStyleBackColor = true;
            // 
            // btnERP
            // 
            this.btnERP.Location = new System.Drawing.Point(143, 134);
            this.btnERP.Name = "btnERP";
            this.btnERP.Size = new System.Drawing.Size(275, 35);
            this.btnERP.TabIndex = 2;
            this.btnERP.Text = "Enterprise Resource Planning (ERP) System Portal";
            this.btnERP.UseVisualStyleBackColor = true;
            this.btnERP.Click += new System.EventHandler(this.btnERP_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(215, 187);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(130, 35);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Exit Application";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // frmMailWelcomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 325);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnERP);
            this.Controls.Add(this.btnPOS);
            this.Controls.Add(this.lblTitle);
            this.Name = "frmMailWelcomeForm";
            this.Text = "EZRental POS System";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMailWelcomeForm_FormClosing);
            this.Load += new System.EventHandler(this.frmMailWelcomeForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnPOS;
        private System.Windows.Forms.Button btnERP;
        private System.Windows.Forms.Button btnExit;
    }
}

