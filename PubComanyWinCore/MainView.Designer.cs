namespace PubCompanyWinCore
{
    partial class MainView
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

            this.components = new System.ComponentModel.Container();
            this.btnAuthor = new System.Windows.Forms.Button();
            this.btnArticle = new System.Windows.Forms.Button();
            this.btnPayroll = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAuthor
            // 
            this.btnAuthor.Location = new System.Drawing.Point(154, 140);
            this.btnAuthor.Name = "btnAuthor";
            this.btnAuthor.Size = new System.Drawing.Size(75, 23);
            this.btnAuthor.TabIndex = 0;
            this.btnAuthor.Text = "Author";
            this.btnAuthor.UseVisualStyleBackColor = true;
            this.btnAuthor.Click += new System.EventHandler(this.btnAuthor_Click);
            // 
            // btnAriticle
            // 
            this.btnArticle.Location = new System.Drawing.Point(309, 140);
            this.btnArticle.Name = "btnArticle";
            this.btnArticle.Size = new System.Drawing.Size(75, 23);
            this.btnArticle.TabIndex = 1;
            this.btnArticle.Text = "Article";
            this.btnArticle.UseVisualStyleBackColor = true;
            this.btnArticle.Click += new System.EventHandler(this.btnArticle_Click);
            // 
            // btnPayroll
            // 
            this.btnPayroll.Location = new System.Drawing.Point(474, 140);
            this.btnPayroll.Name = "btnPayroll";
            this.btnPayroll.Size = new System.Drawing.Size(75, 23);
            this.btnPayroll.TabIndex = 2;
            this.btnPayroll.Text = "PayRoll";
            this.btnPayroll.UseVisualStyleBackColor = true;
            this.btnPayroll.Click += new System.EventHandler(this.btnPayroll_Click);
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnPayroll);
            this.Controls.Add(this.btnArticle);
            this.Controls.Add(this.btnAuthor);
            this.Name = "MainView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "MainView";
            
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAuthor;
        private System.Windows.Forms.Button btnArticle;
        private System.Windows.Forms.Button btnPayroll;


    }

}

