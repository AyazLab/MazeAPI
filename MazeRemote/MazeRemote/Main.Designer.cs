namespace MazeRemote
{
    partial class Main
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
            this.ConnectButton = new System.Windows.Forms.Button();
            this.portTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.forwardButton = new System.Windows.Forms.Button();
            this.strafeRightButton = new System.Windows.Forms.Button();
            this.strafeLeftButton = new System.Windows.Forms.Button();
            this.backwardButton = new System.Windows.Forms.Button();
            this.turnRightButton = new System.Windows.Forms.Button();
            this.turnLeftButton = new System.Windows.Forms.Button();
            this.jumpButton = new System.Windows.Forms.Button();
            this.messageText = new System.Windows.Forms.TextBox();
            this.messageButton = new System.Windows.Forms.Button();
            this.cueButton = new System.Windows.Forms.Button();
            this.setPositionButton = new System.Windows.Forms.Button();
            this.xTextBox = new System.Windows.Forms.TextBox();
            this.yTextBox = new System.Windows.Forms.TextBox();
            this.zTextBox = new System.Windows.Forms.TextBox();
            this.angleTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.getPositionButton = new System.Windows.Forms.Button();
            this.updateText = new System.Windows.Forms.Label();
            this.nextButton = new System.Windows.Forms.Button();
            this.boundedCheck = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.turnSizeText = new System.Windows.Forms.TextBox();
            this.stepsizeText = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.setScoreButton = new System.Windows.Forms.Button();
            this.getScoreButton = new System.Windows.Forms.Button();
            this.scoreTextBox = new System.Windows.Forms.TextBox();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // ConnectButton
            // 
            this.ConnectButton.Location = new System.Drawing.Point(163, 16);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(75, 23);
            this.ConnectButton.TabIndex = 0;
            this.ConnectButton.Text = "Connect";
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // portTextBox
            // 
            this.portTextBox.Location = new System.Drawing.Point(95, 19);
            this.portTextBox.Name = "portTextBox";
            this.portTextBox.Size = new System.Drawing.Size(51, 20);
            this.portTextBox.TabIndex = 1;
            this.portTextBox.Text = "6350";
            this.portTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Port Number";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 402);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(451, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(292, 17);
            this.toolStripStatusLabel1.Text = "Press Start to listen for connection from MazeWalker...";
            // 
            // forwardButton
            // 
            this.forwardButton.Location = new System.Drawing.Point(94, 28);
            this.forwardButton.Name = "forwardButton";
            this.forwardButton.Size = new System.Drawing.Size(62, 54);
            this.forwardButton.TabIndex = 4;
            this.forwardButton.Text = "^";
            this.forwardButton.UseVisualStyleBackColor = true;
            this.forwardButton.Click += new System.EventHandler(this.forwardButton_Click);
            // 
            // strafeRightButton
            // 
            this.strafeRightButton.Location = new System.Drawing.Point(162, 88);
            this.strafeRightButton.Name = "strafeRightButton";
            this.strafeRightButton.Size = new System.Drawing.Size(62, 54);
            this.strafeRightButton.TabIndex = 5;
            this.strafeRightButton.Text = ">";
            this.strafeRightButton.UseVisualStyleBackColor = true;
            this.strafeRightButton.Click += new System.EventHandler(this.strafeRightButton_Click);
            // 
            // strafeLeftButton
            // 
            this.strafeLeftButton.Location = new System.Drawing.Point(26, 88);
            this.strafeLeftButton.Name = "strafeLeftButton";
            this.strafeLeftButton.Size = new System.Drawing.Size(62, 54);
            this.strafeLeftButton.TabIndex = 6;
            this.strafeLeftButton.Text = "<";
            this.strafeLeftButton.UseVisualStyleBackColor = true;
            this.strafeLeftButton.Click += new System.EventHandler(this.strafeLeftButton_Click);
            // 
            // backwardButton
            // 
            this.backwardButton.Location = new System.Drawing.Point(94, 148);
            this.backwardButton.Name = "backwardButton";
            this.backwardButton.Size = new System.Drawing.Size(62, 54);
            this.backwardButton.TabIndex = 7;
            this.backwardButton.Text = "V";
            this.backwardButton.UseVisualStyleBackColor = true;
            this.backwardButton.Click += new System.EventHandler(this.backwardButton_Click);
            // 
            // turnRightButton
            // 
            this.turnRightButton.Location = new System.Drawing.Point(162, 28);
            this.turnRightButton.Name = "turnRightButton";
            this.turnRightButton.Size = new System.Drawing.Size(62, 54);
            this.turnRightButton.TabIndex = 8;
            this.turnRightButton.Text = "Turn Right";
            this.turnRightButton.UseVisualStyleBackColor = true;
            this.turnRightButton.Click += new System.EventHandler(this.turnRightButton_Click);
            // 
            // turnLeftButton
            // 
            this.turnLeftButton.Location = new System.Drawing.Point(26, 28);
            this.turnLeftButton.Name = "turnLeftButton";
            this.turnLeftButton.Size = new System.Drawing.Size(62, 54);
            this.turnLeftButton.TabIndex = 9;
            this.turnLeftButton.Text = "Turn Left";
            this.turnLeftButton.UseVisualStyleBackColor = true;
            this.turnLeftButton.Click += new System.EventHandler(this.turnLeftButton_Click);
            // 
            // jumpButton
            // 
            this.jumpButton.Location = new System.Drawing.Point(94, 88);
            this.jumpButton.Name = "jumpButton";
            this.jumpButton.Size = new System.Drawing.Size(62, 54);
            this.jumpButton.TabIndex = 10;
            this.jumpButton.Text = "Jump";
            this.jumpButton.UseVisualStyleBackColor = true;
            this.jumpButton.Click += new System.EventHandler(this.jumpButton_Click);
            // 
            // messageText
            // 
            this.messageText.Location = new System.Drawing.Point(13, 382);
            this.messageText.Name = "messageText";
            this.messageText.Size = new System.Drawing.Size(313, 20);
            this.messageText.TabIndex = 15;
            // 
            // messageButton
            // 
            this.messageButton.Location = new System.Drawing.Point(330, 380);
            this.messageButton.Name = "messageButton";
            this.messageButton.Size = new System.Drawing.Size(93, 23);
            this.messageButton.TabIndex = 16;
            this.messageButton.Text = "Send Message";
            this.messageButton.UseVisualStyleBackColor = true;
            this.messageButton.Click += new System.EventHandler(this.messageButton_Click);
            // 
            // cueButton
            // 
            this.cueButton.Location = new System.Drawing.Point(8, 19);
            this.cueButton.Name = "cueButton";
            this.cueButton.Size = new System.Drawing.Size(100, 23);
            this.cueButton.TabIndex = 17;
            this.cueButton.Text = "Send Start Cue";
            this.cueButton.UseVisualStyleBackColor = true;
            this.cueButton.Click += new System.EventHandler(this.cueButton_Click);
            // 
            // setPositionButton
            // 
            this.setPositionButton.Location = new System.Drawing.Point(59, 132);
            this.setPositionButton.Name = "setPositionButton";
            this.setPositionButton.Size = new System.Drawing.Size(75, 23);
            this.setPositionButton.TabIndex = 18;
            this.setPositionButton.Text = "SetPosition";
            this.setPositionButton.UseVisualStyleBackColor = true;
            this.setPositionButton.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // xTextBox
            // 
            this.xTextBox.Location = new System.Drawing.Point(59, 24);
            this.xTextBox.MaxLength = 10;
            this.xTextBox.Name = "xTextBox";
            this.xTextBox.Size = new System.Drawing.Size(75, 20);
            this.xTextBox.TabIndex = 19;
            this.xTextBox.Text = "0";
            // 
            // yTextBox
            // 
            this.yTextBox.Location = new System.Drawing.Point(59, 50);
            this.yTextBox.MaxLength = 10;
            this.yTextBox.Name = "yTextBox";
            this.yTextBox.Size = new System.Drawing.Size(75, 20);
            this.yTextBox.TabIndex = 20;
            this.yTextBox.Text = "0";
            // 
            // zTextBox
            // 
            this.zTextBox.Location = new System.Drawing.Point(59, 76);
            this.zTextBox.MaxLength = 10;
            this.zTextBox.Name = "zTextBox";
            this.zTextBox.Size = new System.Drawing.Size(75, 20);
            this.zTextBox.TabIndex = 21;
            this.zTextBox.Text = "0";
            // 
            // angleTextBox
            // 
            this.angleTextBox.Location = new System.Drawing.Point(59, 106);
            this.angleTextBox.MaxLength = 10;
            this.angleTextBox.Name = "angleTextBox";
            this.angleTextBox.Size = new System.Drawing.Size(75, 20);
            this.angleTextBox.TabIndex = 22;
            this.angleTextBox.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "X:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "Y:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 79);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 13);
            this.label6.TabIndex = 25;
            this.label6.Text = "Z:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 109);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 13);
            this.label7.TabIndex = 26;
            this.label7.Text = "Angle:";
            // 
            // getPositionButton
            // 
            this.getPositionButton.Location = new System.Drawing.Point(59, 161);
            this.getPositionButton.Name = "getPositionButton";
            this.getPositionButton.Size = new System.Drawing.Size(75, 23);
            this.getPositionButton.TabIndex = 27;
            this.getPositionButton.Text = "GetPosition";
            this.getPositionButton.UseVisualStyleBackColor = true;
            this.getPositionButton.Click += new System.EventHandler(this.getPositionButton_Click);
            // 
            // updateText
            // 
            this.updateText.Location = new System.Drawing.Point(269, 215);
            this.updateText.Name = "updateText";
            this.updateText.Size = new System.Drawing.Size(159, 25);
            this.updateText.TabIndex = 28;
            this.updateText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nextButton
            // 
            this.nextButton.Location = new System.Drawing.Point(113, 19);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(75, 23);
            this.nextButton.TabIndex = 29;
            this.nextButton.Text = "NextLevel";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // boundedCheck
            // 
            this.boundedCheck.AutoSize = true;
            this.boundedCheck.Location = new System.Drawing.Point(11, 288);
            this.boundedCheck.Name = "boundedCheck";
            this.boundedCheck.Size = new System.Drawing.Size(122, 17);
            this.boundedCheck.TabIndex = 30;
            this.boundedCheck.Text = "Block Invalid Moves";
            this.boundedCheck.UseVisualStyleBackColor = true;
            this.boundedCheck.CheckedChanged += new System.EventHandler(this.boundedCheck_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.turnSizeText);
            this.groupBox1.Controls.Add(this.boundedCheck);
            this.groupBox1.Controls.Add(this.stepsizeText);
            this.groupBox1.Controls.Add(this.jumpButton);
            this.groupBox1.Controls.Add(this.turnLeftButton);
            this.groupBox1.Controls.Add(this.turnRightButton);
            this.groupBox1.Controls.Add(this.backwardButton);
            this.groupBox1.Controls.Add(this.strafeLeftButton);
            this.groupBox1.Controls.Add(this.strafeRightButton);
            this.groupBox1.Controls.Add(this.forwardButton);
            this.groupBox1.Location = new System.Drawing.Point(8, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(241, 315);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Remote Control";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 263);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Turn Size (degrees)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 237);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Step Size (mz units)";
            // 
            // turnSizeText
            // 
            this.turnSizeText.Location = new System.Drawing.Point(113, 260);
            this.turnSizeText.Name = "turnSizeText";
            this.turnSizeText.Size = new System.Drawing.Size(56, 20);
            this.turnSizeText.TabIndex = 16;
            this.turnSizeText.Text = "90";
            // 
            // stepsizeText
            // 
            this.stepsizeText.Location = new System.Drawing.Point(113, 234);
            this.stepsizeText.Name = "stepsizeText";
            this.stepsizeText.Size = new System.Drawing.Size(56, 20);
            this.stepsizeText.TabIndex = 15;
            this.stepsizeText.Text = "5";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 213);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 13);
            this.label9.TabIndex = 33;
            this.label9.Text = "Action Config";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.getPositionButton);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.angleTextBox);
            this.groupBox2.Controls.Add(this.zTextBox);
            this.groupBox2.Controls.Add(this.yTextBox);
            this.groupBox2.Controls.Add(this.xTextBox);
            this.groupBox2.Controls.Add(this.setPositionButton);
            this.groupBox2.Location = new System.Drawing.Point(289, 64);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(150, 196);
            this.groupBox2.TabIndex = 34;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Player Position";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.portTextBox);
            this.groupBox3.Controls.Add(this.ConnectButton);
            this.groupBox3.Location = new System.Drawing.Point(8, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(246, 54);
            this.groupBox3.TabIndex = 35;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Connection";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cueButton);
            this.groupBox4.Controls.Add(this.nextButton);
            this.groupBox4.Location = new System.Drawing.Point(254, 4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(192, 54);
            this.groupBox4.TabIndex = 36;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Level Control";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.scoreTextBox);
            this.groupBox5.Controls.Add(this.getScoreButton);
            this.groupBox5.Controls.Add(this.setScoreButton);
            this.groupBox5.Location = new System.Drawing.Point(289, 270);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(149, 102);
            this.groupBox5.TabIndex = 37;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Score Activation";
            // 
            // setScoreButton
            // 
            this.setScoreButton.Location = new System.Drawing.Point(104, 22);
            this.setScoreButton.Name = "setScoreButton";
            this.setScoreButton.Size = new System.Drawing.Size(39, 23);
            this.setScoreButton.TabIndex = 0;
            this.setScoreButton.Text = "Set";
            this.setScoreButton.UseVisualStyleBackColor = true;
            this.setScoreButton.Click += new System.EventHandler(this.setScoreButton_Click);
            // 
            // getScoreButton
            // 
            this.getScoreButton.Location = new System.Drawing.Point(57, 22);
            this.getScoreButton.Name = "getScoreButton";
            this.getScoreButton.Size = new System.Drawing.Size(44, 23);
            this.getScoreButton.TabIndex = 1;
            this.getScoreButton.Text = "Get";
            this.getScoreButton.UseVisualStyleBackColor = true;
            this.getScoreButton.Click += new System.EventHandler(this.getScoreButton_Click);
            // 
            // scoreTextBox
            // 
            this.scoreTextBox.Location = new System.Drawing.Point(13, 23);
            this.scoreTextBox.MaxLength = 10;
            this.scoreTextBox.Name = "scoreTextBox";
            this.scoreTextBox.Size = new System.Drawing.Size(39, 20);
            this.scoreTextBox.TabIndex = 23;
            this.scoreTextBox.Text = "0";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 424);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.updateText);
            this.Controls.Add(this.messageButton);
            this.Controls.Add(this.messageText);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MazeRemote";
            this.Load += new System.EventHandler(this.Main_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.TextBox portTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button forwardButton;
        private System.Windows.Forms.Button strafeRightButton;
        private System.Windows.Forms.Button strafeLeftButton;
        private System.Windows.Forms.Button backwardButton;
        private System.Windows.Forms.Button turnRightButton;
        private System.Windows.Forms.Button turnLeftButton;
        private System.Windows.Forms.Button jumpButton;
        private System.Windows.Forms.TextBox messageText;
        private System.Windows.Forms.Button messageButton;
        private System.Windows.Forms.Button cueButton;
        private System.Windows.Forms.Button setPositionButton;
        private System.Windows.Forms.TextBox xTextBox;
        private System.Windows.Forms.TextBox yTextBox;
        private System.Windows.Forms.TextBox zTextBox;
        private System.Windows.Forms.TextBox angleTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button getPositionButton;
        private System.Windows.Forms.Label updateText;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.CheckBox boundedCheck;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox turnSizeText;
        private System.Windows.Forms.TextBox stepsizeText;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox scoreTextBox;
        private System.Windows.Forms.Button getScoreButton;
        private System.Windows.Forms.Button setScoreButton;
    }
}

