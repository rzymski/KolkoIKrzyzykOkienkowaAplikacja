namespace KolkoIKrzyzykOkienkowaAplikacja
{
    partial class Save
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
            this.btnSave = new System.Windows.Forms.Button();
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.btnOpen = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.btnSaveVariable = new System.Windows.Forms.Button();
            this.btnOpenVariable = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(1102, 613);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // richTextBox
            // 
            this.richTextBox.Location = new System.Drawing.Point(285, 166);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.Size = new System.Drawing.Size(100, 96);
            this.richTextBox.TabIndex = 1;
            this.richTextBox.Text = "";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "Rich Text Format|*.rtf";
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(1001, 613);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 2;
            this.btnOpen.Text = "&Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            this.openFileDialog.Filter = "Rich Text Format|*.rtf";
            // 
            // btnSaveVariable
            // 
            this.btnSaveVariable.Location = new System.Drawing.Point(869, 613);
            this.btnSaveVariable.Name = "btnSaveVariable";
            this.btnSaveVariable.Size = new System.Drawing.Size(75, 23);
            this.btnSaveVariable.TabIndex = 3;
            this.btnSaveVariable.Text = "&Save";
            this.btnSaveVariable.UseVisualStyleBackColor = true;
            this.btnSaveVariable.Click += new System.EventHandler(this.btnSaveVariable_Click);
            // 
            // btnOpenVariable
            // 
            this.btnOpenVariable.Location = new System.Drawing.Point(764, 613);
            this.btnOpenVariable.Name = "btnOpenVariable";
            this.btnOpenVariable.Size = new System.Drawing.Size(75, 23);
            this.btnOpenVariable.TabIndex = 4;
            this.btnOpenVariable.Text = "&Open";
            this.btnOpenVariable.UseVisualStyleBackColor = true;
            this.btnOpenVariable.Click += new System.EventHandler(this.btnOpenVariable_Click);
            // 
            // Save
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1334, 720);
            this.Controls.Add(this.btnOpenVariable);
            this.Controls.Add(this.btnSaveVariable);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.richTextBox);
            this.Controls.Add(this.btnSave);
            this.Name = "Save";
            this.Text = "Save";
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnSave;
        private RichTextBox richTextBox;
        private SaveFileDialog saveFileDialog;
        private Button btnOpen;
        private OpenFileDialog openFileDialog;
        private Button btnSaveVariable;
        private Button btnOpenVariable;
    }
}