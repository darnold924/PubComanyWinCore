namespace PubCompanyWinCore
{
    partial class PayRollView
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
           
            this.cbxAuthor = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPayrollID = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nudSalary = new System.Windows.Forms.NumericUpDown();
            this.btnFirst = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnLast = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudSalary)).BeginInit();
            this.SuspendLayout();
            // 
            // cbxAuthor
            // 
            this.cbxAuthor.FormattingEnabled = true;
            this.cbxAuthor.Location = new System.Drawing.Point(282, 84);
            this.cbxAuthor.Name = "cbxAuthor";
            this.cbxAuthor.Size = new System.Drawing.Size(145, 21);
            this.cbxAuthor.TabIndex = 0;
            this.cbxAuthor.SelectedIndexChanged += new System.EventHandler(this.cbxAuthor_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(206, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Author";
            // 
            // lblPayrollID
            // 
            this.lblPayrollID.AutoSize = true;
            this.lblPayrollID.Location = new System.Drawing.Point(313, 148);
            this.lblPayrollID.Name = "lblPayrollID";
            this.lblPayrollID.Size = new System.Drawing.Size(35, 13);
            this.lblPayrollID.TabIndex = 2;
            this.lblPayrollID.Text = "label2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(209, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "PayRollId";
            // 
            // nudSalary
            // 
            this.nudSalary.Location = new System.Drawing.Point(282, 180);
            this.nudSalary.Name = "nudSalary";
            this.nudSalary.Size = new System.Drawing.Size(120, 20);
            this.nudSalary.Minimum = 0;
            this.nudSalary.Maximum = 10000;
            this.nudSalary.TabIndex = 4;
            this.nudSalary.ValueChanged += new System.EventHandler(this.nudSalary_ValueChanged);
            // 
            // btnFirst = 
            // 
            this.btnFirst.Location = new System.Drawing.Point(248, 237);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(41, 30);
            this.btnFirst.TabIndex = 5;
            this.btnFirst.Text = "<<";
            this.btnFirst.UseVisualStyleBackColor = true;
            this.btnFirst.Click += new System.EventHandler(this.btnFrist_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(212, 186);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Salary";
            // 
            // btnPrev
            // 
            this.btnPrev.Location = new System.Drawing.Point(295, 237);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(41, 30);
            this.btnPrev.TabIndex = 7;
            this.btnPrev.Text = "<";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(342, 234);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(41, 30);
            this.btnNext.TabIndex = 8;
            this.btnNext.Text = ">";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnLast
            // 
            this.btnLast.Location = new System.Drawing.Point(386, 233);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(41, 30);
            this.btnLast.TabIndex = 9;
            this.btnLast.Text = ">>";
            this.btnLast.UseVisualStyleBackColor = true;
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(200, 307);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 12;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(300, 308);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 10;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(400, 307);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 11;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // PayRollView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 450);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnLast);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnFirst);
            this.Controls.Add(this.nudSalary);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblPayrollID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxAuthor);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Name = "PayRollView";
            this.Text = "PayRollView";
            ((System.ComponentModel.ISupportInitialize)(this.nudSalary)).EndInit();
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PayRollView_FormClosing);

            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxAuthor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPayrollID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudSalary;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
    }
}

        
    


