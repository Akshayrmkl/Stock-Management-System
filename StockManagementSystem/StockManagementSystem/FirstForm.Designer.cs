namespace StockManagementSystem
{
    partial class FirstForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>


        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.richTextBox_sqlQuery = new System.Windows.Forms.RichTextBox();
            this.FirstForm_button_insertQuery = new System.Windows.Forms.Button();
            this.FirstForm_button_Parse = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richTextBox_sqlQuery
            // 
            this.richTextBox_sqlQuery.Location = new System.Drawing.Point(147, 78);
            this.richTextBox_sqlQuery.Name = "richTextBox_sqlQuery";
            this.richTextBox_sqlQuery.Size = new System.Drawing.Size(468, 161);
            this.richTextBox_sqlQuery.TabIndex = 0;
            this.richTextBox_sqlQuery.Text = "select * from information_schema.tables";
            // 
            // FirstForm_button_insertQuery
            // 
            this.FirstForm_button_insertQuery.Location = new System.Drawing.Point(720, 78);
            this.FirstForm_button_insertQuery.Name = "FirstForm_button_insertQuery";
            this.FirstForm_button_insertQuery.Size = new System.Drawing.Size(125, 58);
            this.FirstForm_button_insertQuery.TabIndex = 1;
            this.FirstForm_button_insertQuery.Text = "insert into Db";
            this.FirstForm_button_insertQuery.UseVisualStyleBackColor = true;
            this.FirstForm_button_insertQuery.Click += new System.EventHandler(this.FirstForm_button_insertQuery_Click);
            // 
            // FirstForm_button_Parse
            // 
            this.FirstForm_button_Parse.Location = new System.Drawing.Point(720, 154);
            this.FirstForm_button_Parse.Name = "FirstForm_button_Parse";
            this.FirstForm_button_Parse.Size = new System.Drawing.Size(125, 58);
            this.FirstForm_button_Parse.TabIndex = 2;
            this.FirstForm_button_Parse.Text = "ParseDirectly";
            this.FirstForm_button_Parse.UseVisualStyleBackColor = true;
            this.FirstForm_button_Parse.Click += new System.EventHandler(this.FirstForm_button_Parse_Click);
            // 
            // FirstForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.ClientSize = new System.Drawing.Size(904, 500);
            this.Controls.Add(this.FirstForm_button_Parse);
            this.Controls.Add(this.FirstForm_button_insertQuery);
            this.Controls.Add(this.richTextBox_sqlQuery);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FirstForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox_sqlQuery;
        private System.Windows.Forms.Button FirstForm_button_insertQuery;
        private System.Windows.Forms.Button FirstForm_button_Parse;
    }
}

