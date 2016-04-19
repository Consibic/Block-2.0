namespace Blocks_2._0
{
    partial class BlockControl
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
            this.components = new System.ComponentModel.Container();
            this.startButton = new System.Windows.Forms.Button();
            this.blockPanel = new System.Windows.Forms.Panel();
            this.speedButton = new System.Windows.Forms.Button();
            this.leftButton = new System.Windows.Forms.Button();
            this.rightButton = new System.Windows.Forms.Button();
            this.turnButton = new System.Windows.Forms.Button();
            this.scoreDisplay = new System.Windows.Forms.Label();
            this.stopButton = new System.Windows.Forms.Button();
            this.blockPlate = new System.Windows.Forms.Panel();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.blockPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.startButton.Location = new System.Drawing.Point(136, 498);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(81, 39);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "START";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // blockPanel
            // 
            this.blockPanel.Controls.Add(this.speedButton);
            this.blockPanel.Controls.Add(this.leftButton);
            this.blockPanel.Controls.Add(this.rightButton);
            this.blockPanel.Controls.Add(this.turnButton);
            this.blockPanel.Controls.Add(this.scoreDisplay);
            this.blockPanel.Controls.Add(this.stopButton);
            this.blockPanel.Controls.Add(this.blockPlate);
            this.blockPanel.Controls.Add(this.startButton);
            this.blockPanel.Location = new System.Drawing.Point(0, 0);
            this.blockPanel.Name = "blockPanel";
            this.blockPanel.Size = new System.Drawing.Size(480, 560);
            this.blockPanel.TabIndex = 0;
            // 
            // speedButton
            // 
            this.speedButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.speedButton.Location = new System.Drawing.Point(381, 520);
            this.speedButton.Name = "speedButton";
            this.speedButton.Size = new System.Drawing.Size(42, 28);
            this.speedButton.TabIndex = 7;
            this.speedButton.Text = "-S-";
            this.speedButton.UseVisualStyleBackColor = true;
            this.speedButton.Click += new System.EventHandler(this.speedButton_Click);
            // 
            // leftButton
            // 
            this.leftButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.leftButton.Location = new System.Drawing.Point(333, 520);
            this.leftButton.Name = "leftButton";
            this.leftButton.Size = new System.Drawing.Size(42, 28);
            this.leftButton.TabIndex = 6;
            this.leftButton.Text = "<--";
            this.leftButton.UseVisualStyleBackColor = true;
            this.leftButton.Click += new System.EventHandler(this.leftButton_Click);
            // 
            // rightButton
            // 
            this.rightButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rightButton.Location = new System.Drawing.Point(429, 520);
            this.rightButton.Name = "rightButton";
            this.rightButton.Size = new System.Drawing.Size(42, 28);
            this.rightButton.TabIndex = 5;
            this.rightButton.Text = "-->";
            this.rightButton.UseVisualStyleBackColor = true;
            this.rightButton.Click += new System.EventHandler(this.rightButton_Click);
            // 
            // turnButton
            // 
            this.turnButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.turnButton.Location = new System.Drawing.Point(381, 486);
            this.turnButton.Name = "turnButton";
            this.turnButton.Size = new System.Drawing.Size(42, 28);
            this.turnButton.TabIndex = 4;
            this.turnButton.Text = "-T-";
            this.turnButton.UseVisualStyleBackColor = true;
            this.turnButton.Click += new System.EventHandler(this.turnButton_Click);
            // 
            // scoreDisplay
            // 
            this.scoreDisplay.AutoSize = true;
            this.scoreDisplay.ForeColor = System.Drawing.SystemColors.Control;
            this.scoreDisplay.Location = new System.Drawing.Point(43, 511);
            this.scoreDisplay.Name = "scoreDisplay";
            this.scoreDisplay.Size = new System.Drawing.Size(47, 13);
            this.scoreDisplay.TabIndex = 3;
            this.scoreDisplay.Text = "Score: 0";
            // 
            // stopButton
            // 
            this.stopButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.stopButton.Location = new System.Drawing.Point(223, 498);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(77, 39);
            this.stopButton.TabIndex = 2;
            this.stopButton.Text = "STOP";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // blockPlate
            // 
            this.blockPlate.Location = new System.Drawing.Point(0, 0);
            this.blockPlate.Name = "blockPlate";
            this.blockPlate.Size = new System.Drawing.Size(480, 480);
            this.blockPlate.TabIndex = 1;
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // BlockControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.blockPanel);
            this.Name = "BlockControl";
            this.Size = new System.Drawing.Size(480, 560);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BlockControl_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.BlockControl_KeyUp);
            this.blockPanel.ResumeLayout(false);
            this.blockPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Panel blockPanel;
        private System.Windows.Forms.Panel blockPlate;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Label scoreDisplay;
        private System.Windows.Forms.Button speedButton;
        private System.Windows.Forms.Button leftButton;
        private System.Windows.Forms.Button rightButton;
        private System.Windows.Forms.Button turnButton;
    }
}
