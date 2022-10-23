namespace HouseRentalAndSales
{
    partial class ViewData
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvView = new System.Windows.Forms.DataGridView();
            this.btnCust = new System.Windows.Forms.Button();
            this.btnPictures = new System.Windows.Forms.Button();
            this.btnProperty = new System.Windows.Forms.Button();
            this.btnOwner = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvView)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvView
            // 
            this.dgvView.Dock = System.Windows.Forms.DockStyle.Right;
            this.dgvView.Location = new System.Drawing.Point(310, 0);
            this.dgvView.Name = "dgvView";
            this.dgvView.Size = new System.Drawing.Size(675, 580);
            this.dgvView.TabIndex = 0;
            // 
            // btnCust
            // 
            this.btnCust.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCust.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnCust.Location = new System.Drawing.Point(4, 52);
            this.btnCust.Name = "btnCust";
            this.btnCust.Size = new System.Drawing.Size(300, 53);
            this.btnCust.TabIndex = 1;
            this.btnCust.Text = "Customer";
            this.btnCust.UseVisualStyleBackColor = true;
            this.btnCust.Click += new System.EventHandler(this.btnCust_Click);
            // 
            // btnPictures
            // 
            this.btnPictures.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPictures.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnPictures.Location = new System.Drawing.Point(0, 385);
            this.btnPictures.Name = "btnPictures";
            this.btnPictures.Size = new System.Drawing.Size(300, 53);
            this.btnPictures.TabIndex = 2;
            this.btnPictures.Text = "Pictures";
            this.btnPictures.UseVisualStyleBackColor = true;
            this.btnPictures.Click += new System.EventHandler(this.btnPictures_Click);
            // 
            // btnProperty
            // 
            this.btnProperty.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProperty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnProperty.Location = new System.Drawing.Point(4, 274);
            this.btnProperty.Name = "btnProperty";
            this.btnProperty.Size = new System.Drawing.Size(300, 53);
            this.btnProperty.TabIndex = 3;
            this.btnProperty.Text = "Property";
            this.btnProperty.UseVisualStyleBackColor = true;
            this.btnProperty.Click += new System.EventHandler(this.btnProperty_Click);
            // 
            // btnOwner
            // 
            this.btnOwner.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOwner.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnOwner.Location = new System.Drawing.Point(4, 163);
            this.btnOwner.Name = "btnOwner";
            this.btnOwner.Size = new System.Drawing.Size(300, 53);
            this.btnOwner.TabIndex = 4;
            this.btnOwner.Text = "Owner";
            this.btnOwner.UseVisualStyleBackColor = true;
            this.btnOwner.Click += new System.EventHandler(this.btnOwner_Click);
            // 
            // ViewData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnOwner);
            this.Controls.Add(this.btnProperty);
            this.Controls.Add(this.btnPictures);
            this.Controls.Add(this.btnCust);
            this.Controls.Add(this.dgvView);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "ViewData";
            this.Size = new System.Drawing.Size(985, 580);
            ((System.ComponentModel.ISupportInitialize)(this.dgvView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvView;
        private System.Windows.Forms.Button btnCust;
        private System.Windows.Forms.Button btnPictures;
        private System.Windows.Forms.Button btnProperty;
        private System.Windows.Forms.Button btnOwner;
    }
}
