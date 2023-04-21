namespace SharedMemoryTester.UI
{
    partial class SharedMemoryForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.cbMasterCaution = new System.Windows.Forms.CheckBox();
            this.cbTF = new System.Windows.Forms.CheckBox();
            this.cbOXY_BROW = new System.Windows.Forms.CheckBox();
            this.cbEQUIP_HOT = new System.Windows.Forms.CheckBox();
            this.cbONGROUND = new System.Windows.Forms.CheckBox();
            this.cbENG_FIRE = new System.Windows.Forms.CheckBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "LightBits";
            // 
            // cbMasterCaution
            // 
            this.cbMasterCaution.AutoSize = true;
            this.cbMasterCaution.Location = new System.Drawing.Point(15, 25);
            this.cbMasterCaution.Name = "cbMasterCaution";
            this.cbMasterCaution.Size = new System.Drawing.Size(94, 17);
            this.cbMasterCaution.TabIndex = 1;
            this.cbMasterCaution.Text = "MasterCaution";
            this.cbMasterCaution.UseVisualStyleBackColor = true;
            // 
            // cbTF
            // 
            this.cbTF.AutoSize = true;
            this.cbTF.Location = new System.Drawing.Point(15, 39);
            this.cbTF.Name = "cbTF";
            this.cbTF.Size = new System.Drawing.Size(39, 17);
            this.cbTF.TabIndex = 2;
            this.cbTF.Text = "TF";
            this.cbTF.UseVisualStyleBackColor = true;
            // 
            // cbOXY_BROW
            // 
            this.cbOXY_BROW.AutoSize = true;
            this.cbOXY_BROW.Location = new System.Drawing.Point(15, 53);
            this.cbOXY_BROW.Name = "cbOXY_BROW";
            this.cbOXY_BROW.Size = new System.Drawing.Size(88, 17);
            this.cbOXY_BROW.TabIndex = 3;
            this.cbOXY_BROW.Text = "OXY_BROW";
            this.cbOXY_BROW.UseVisualStyleBackColor = true;
            // 
            // cbEQUIP_HOT
            // 
            this.cbEQUIP_HOT.AutoSize = true;
            this.cbEQUIP_HOT.Location = new System.Drawing.Point(15, 67);
            this.cbEQUIP_HOT.Name = "cbEQUIP_HOT";
            this.cbEQUIP_HOT.Size = new System.Drawing.Size(88, 17);
            this.cbEQUIP_HOT.TabIndex = 4;
            this.cbEQUIP_HOT.Text = "EQUIP_HOT";
            this.cbEQUIP_HOT.UseVisualStyleBackColor = true;
            // 
            // cbONGROUND
            // 
            this.cbONGROUND.AutoSize = true;
            this.cbONGROUND.Location = new System.Drawing.Point(15, 81);
            this.cbONGROUND.Name = "cbONGROUND";
            this.cbONGROUND.Size = new System.Drawing.Size(90, 17);
            this.cbONGROUND.TabIndex = 5;
            this.cbONGROUND.Text = "ONGROUND";
            this.cbONGROUND.UseVisualStyleBackColor = true;
            // 
            // cbENG_FIRE
            // 
            this.cbENG_FIRE.AutoSize = true;
            this.cbENG_FIRE.Location = new System.Drawing.Point(15, 95);
            this.cbENG_FIRE.Name = "cbENG_FIRE";
            this.cbENG_FIRE.Size = new System.Drawing.Size(79, 17);
            this.cbENG_FIRE.TabIndex = 6;
            this.cbENG_FIRE.Text = "ENG_FIRE";
            this.cbENG_FIRE.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.Location = new System.Drawing.Point(713, 415);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 7;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // SharedMemoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.cbENG_FIRE);
            this.Controls.Add(this.cbONGROUND);
            this.Controls.Add(this.cbEQUIP_HOT);
            this.Controls.Add(this.cbOXY_BROW);
            this.Controls.Add(this.cbTF);
            this.Controls.Add(this.cbMasterCaution);
            this.Controls.Add(this.label1);
            this.Name = "SharedMemoryForm";
            this.Text = "BMS Shared Memory";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SharedMemoryForm_FormClosing);
            this.Load += new System.EventHandler(this.SharedMemoryForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbMasterCaution;
        private System.Windows.Forms.CheckBox cbTF;
        private System.Windows.Forms.CheckBox cbOXY_BROW;
        private System.Windows.Forms.CheckBox cbEQUIP_HOT;
        private System.Windows.Forms.CheckBox cbONGROUND;
        private System.Windows.Forms.CheckBox cbENG_FIRE;
        private System.Windows.Forms.Button btnUpdate;
    }
}

