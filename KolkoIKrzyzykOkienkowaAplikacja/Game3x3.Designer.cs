namespace KolkoIKrzyzykOkienkowaAplikacja
{
    partial class Game3x3
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblTurnDisplay = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnMenu = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(25, 511);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1616, 455);
            this.flowLayoutPanel1.TabIndex = 2;
            this.flowLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
            // 
            // lblTurnDisplay
            // 
            this.lblTurnDisplay.AutoSize = true;
            this.lblTurnDisplay.Font = new System.Drawing.Font("Arial Black", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTurnDisplay.Location = new System.Drawing.Point(647, 354);
            this.lblTurnDisplay.Name = "lblTurnDisplay";
            this.lblTurnDisplay.Size = new System.Drawing.Size(307, 90);
            this.lblTurnDisplay.TabIndex = 3;
            this.lblTurnDisplay.Text = "Ruch: X";
            this.lblTurnDisplay.Paint += new System.Windows.Forms.PaintEventHandler(this.lblTurnDisplay_Paint);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnExit.ForeColor = System.Drawing.Color.Red;
            this.btnExit.Location = new System.Drawing.Point(1562, 12);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(79, 46);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "X";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            this.btnExit.Paint += new System.Windows.Forms.PaintEventHandler(this.btnExit_Paint);
            // 
            // btnMenu
            // 
            this.btnMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMenu.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnMenu.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnMenu.Location = new System.Drawing.Point(1459, 12);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(97, 46);
            this.btnMenu.TabIndex = 6;
            this.btnMenu.Text = "Menu";
            this.btnMenu.UseVisualStyleBackColor = true;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            this.btnMenu.Paint += new System.Windows.Forms.PaintEventHandler(this.btnMenu_Paint);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSave.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnSave.Location = new System.Drawing.Point(25, 12);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(97, 46);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Zapisz grę";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.Paint += new System.Windows.Forms.PaintEventHandler(this.btnSave_Paint);
            // 
            // Game3x3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2544, 1401);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnMenu);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblTurnDisplay);
            this.Controls.Add(this.flowLayoutPanel1);
            this.KeyPreview = true;
            this.Name = "Game3x3";
            this.Text = "Game3x3";
            this.Load += new System.EventHandler(this.Game3x3_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Game3x3_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private FlowLayoutPanel flowLayoutPanel1;
        private Label lblTurnDisplay;
        private Button btnExit;
        private Button btnMenu;
        private Button btnSave;
    }
}