using System.ComponentModel;
using System.Windows.Forms;

namespace BaccaratClient
{
    partial class RoomForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.roomNumLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.userListBox = new System.Windows.Forms.ListBox();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.chatBox = new System.Windows.Forms.ListBox();
            this.chatInputBox = new System.Windows.Forms.TextBox();
            this.enterBox = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.bettingListBox = new System.Windows.Forms.ListBox();
            this.p1Box = new System.Windows.Forms.PictureBox();
            this.p2Box = new System.Windows.Forms.PictureBox();
            this.p3Box = new System.Windows.Forms.PictureBox();
            this.b1Box = new System.Windows.Forms.PictureBox();
            this.b2Box = new System.Windows.Forms.PictureBox();
            this.b3Box = new System.Windows.Forms.PictureBox();
            this.playerBettingButton = new System.Windows.Forms.Button();
            this.bankerBettingButton = new System.Windows.Forms.Button();
            this.logBox = new System.Windows.Forms.ListBox();
            this.drawBettingButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize) (this.p1Box)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.p2Box)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.p3Box)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.b1Box)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.b2Box)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.b3Box)).BeginInit();
            this.SuspendLayout();
            this.roomNumLabel.Font = new System.Drawing.Font("타이포_쌍문동 B", 15.75F, System.Drawing.FontStyle.Bold,
                System.Drawing.GraphicsUnit.Point, ((byte) (129)));
            this.roomNumLabel.ForeColor = System.Drawing.Color.White;
            this.roomNumLabel.Location = new System.Drawing.Point(320, 9);
            this.roomNumLabel.Name = "roomNumLabel";
            this.roomNumLabel.Size = new System.Drawing.Size(43, 44);
            this.roomNumLabel.TabIndex = 0;
            this.roomNumLabel.Text = "0";
            this.roomNumLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Font = new System.Drawing.Font("타이포_쌍문동 B", 15.75F, System.Drawing.FontStyle.Bold,
                System.Drawing.GraphicsUnit.Point, ((byte) (129)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(356, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 44);
            this.label1.TabIndex = 1;
            this.label1.Text = "번 방";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Font = new System.Drawing.Font("타이포_쌍문동 B", 15.75F, System.Drawing.FontStyle.Bold,
                System.Drawing.GraphicsUnit.Point, ((byte) (129)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(90, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 44);
            this.label2.TabIndex = 2;
            this.label2.Text = "플레이어";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label3.Font = new System.Drawing.Font("타이포_쌍문동 B", 15.75F, System.Drawing.FontStyle.Bold,
                System.Drawing.GraphicsUnit.Point, ((byte) (129)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(417, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 44);
            this.label3.TabIndex = 3;
            this.label3.Text = "뱅커";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.userListBox.DisplayMember = "Nickname";
            this.userListBox.FormattingEnabled = true;
            this.userListBox.ItemHeight = 15;
            this.userListBox.Location = new System.Drawing.Point(12, 366);
            this.userListBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.userListBox.Name = "userListBox";
            this.userListBox.Size = new System.Drawing.Size(136, 184);
            this.userListBox.TabIndex = 4;
            this.chatBox.FormattingEnabled = true;
            this.chatBox.ItemHeight = 15;
            this.chatBox.Location = new System.Drawing.Point(181, 366);
            this.chatBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chatBox.Name = "chatBox";
            this.chatBox.Size = new System.Drawing.Size(695, 154);
            this.chatBox.TabIndex = 5;
            this.chatInputBox.Location = new System.Drawing.Point(181, 528);
            this.chatInputBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chatInputBox.Name = "chatInputBox";
            this.chatInputBox.Size = new System.Drawing.Size(635, 23);
            this.chatInputBox.TabIndex = 6;
            this.chatInputBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.inputBox_KeyUp);
            this.enterBox.Location = new System.Drawing.Point(822, 526);
            this.enterBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.enterBox.Name = "enterBox";
            this.enterBox.Size = new System.Drawing.Size(54, 25);
            this.enterBox.TabIndex = 7;
            this.enterBox.Text = "입력";
            this.enterBox.UseVisualStyleBackColor = true;
            this.enterBox.Click += new System.EventHandler(this.enterBox_Click);
            this.label4.Font = new System.Drawing.Font("타이포_쌍문동 B", 15.75F, System.Drawing.FontStyle.Bold,
                System.Drawing.GraphicsUnit.Point, ((byte) (129)));
            this.label4.ForeColor = System.Drawing.Color.RosyBrown;
            this.label4.Location = new System.Drawing.Point(706, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 44);
            this.label4.TabIndex = 8;
            this.label4.Text = "베팅완료";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bettingListBox.DisplayMember = "Nickname";
            this.bettingListBox.FormattingEnabled = true;
            this.bettingListBox.ItemHeight = 15;
            this.bettingListBox.Location = new System.Drawing.Point(652, 55);
            this.bettingListBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bettingListBox.Name = "bettingListBox";
            this.bettingListBox.Size = new System.Drawing.Size(224, 79);
            this.bettingListBox.TabIndex = 9;
            this.p1Box.InitialImage = null;
            this.p1Box.Location = new System.Drawing.Point(12, 148);
            this.p1Box.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.p1Box.Name = "p1Box";
            this.p1Box.Size = new System.Drawing.Size(84, 126);
            this.p1Box.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.p1Box.TabIndex = 10;
            this.p1Box.TabStop = false;
            this.p2Box.Location = new System.Drawing.Point(102, 148);
            this.p2Box.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.p2Box.Name = "p2Box";
            this.p2Box.Size = new System.Drawing.Size(84, 126);
            this.p2Box.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.p2Box.TabIndex = 11;
            this.p2Box.TabStop = false;
            this.p3Box.Location = new System.Drawing.Point(192, 148);
            this.p3Box.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.p3Box.Name = "p3Box";
            this.p3Box.Size = new System.Drawing.Size(84, 126);
            this.p3Box.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.p3Box.TabIndex = 12;
            this.p3Box.TabStop = false;
            this.b1Box.Location = new System.Drawing.Point(341, 148);
            this.b1Box.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.b1Box.Name = "b1Box";
            this.b1Box.Size = new System.Drawing.Size(84, 126);
            this.b1Box.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.b1Box.TabIndex = 13;
            this.b1Box.TabStop = false;
            this.b2Box.Location = new System.Drawing.Point(431, 148);
            this.b2Box.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.b2Box.Name = "b2Box";
            this.b2Box.Size = new System.Drawing.Size(84, 126);
            this.b2Box.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.b2Box.TabIndex = 14;
            this.b2Box.TabStop = false;
            this.b3Box.Location = new System.Drawing.Point(521, 148);
            this.b3Box.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.b3Box.Name = "b3Box";
            this.b3Box.Size = new System.Drawing.Size(84, 126);
            this.b3Box.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.b3Box.TabIndex = 15;
            this.b3Box.TabStop = false;
            this.playerBettingButton.Location = new System.Drawing.Point(117, 279);
            this.playerBettingButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.playerBettingButton.Name = "playerBettingButton";
            this.playerBettingButton.Size = new System.Drawing.Size(78, 42);
            this.playerBettingButton.TabIndex = 16;
            this.playerBettingButton.Text = "베팅하기";
            this.playerBettingButton.UseVisualStyleBackColor = true;
            this.playerBettingButton.Click += new System.EventHandler(this.playerBettingButton_Click);
            this.bankerBettingButton.Location = new System.Drawing.Point(437, 279);
            this.bankerBettingButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bankerBettingButton.Name = "bankerBettingButton";
            this.bankerBettingButton.Size = new System.Drawing.Size(78, 42);
            this.bankerBettingButton.TabIndex = 17;
            this.bankerBettingButton.Text = "베팅하기";
            this.bankerBettingButton.UseVisualStyleBackColor = true;
            this.bankerBettingButton.Click += new System.EventHandler(this.bankerBettingButton_Click);
            this.logBox.DisplayMember = "Nickname";
            this.logBox.FormattingEnabled = true;
            this.logBox.ItemHeight = 15;
            this.logBox.Location = new System.Drawing.Point(652, 148);
            this.logBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.logBox.Name = "logBox";
            this.logBox.Size = new System.Drawing.Size(224, 184);
            this.logBox.TabIndex = 18;
            this.drawBettingButton.Location = new System.Drawing.Point(277, 279);
            this.drawBettingButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.drawBettingButton.Name = "drawBettingButton";
            this.drawBettingButton.Size = new System.Drawing.Size(64, 42);
            this.drawBettingButton.TabIndex = 19;
            this.drawBettingButton.Text = "무승부 베팅하기";
            this.drawBettingButton.UseVisualStyleBackColor = true;
            this.drawBettingButton.Click += new System.EventHandler(this.drawBettingButton_Click);
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(888, 562);
            this.Controls.Add(this.drawBettingButton);
            this.Controls.Add(this.logBox);
            this.Controls.Add(this.bankerBettingButton);
            this.Controls.Add(this.playerBettingButton);
            this.Controls.Add(this.b3Box);
            this.Controls.Add(this.b2Box);
            this.Controls.Add(this.b1Box);
            this.Controls.Add(this.p3Box);
            this.Controls.Add(this.p2Box);
            this.Controls.Add(this.p1Box);
            this.Controls.Add(this.bettingListBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.enterBox);
            this.Controls.Add(this.chatInputBox);
            this.Controls.Add(this.chatBox);
            this.Controls.Add(this.userListBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.roomNumLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "RoomForm";
            this.Text = "바카라 방";
            ((System.ComponentModel.ISupportInitialize) (this.p1Box)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.p2Box)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.p3Box)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.b1Box)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.b2Box)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.b3Box)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.PictureBox p1Box;
        private System.Windows.Forms.PictureBox p2Box;
        private System.Windows.Forms.PictureBox p3Box;
        private System.Windows.Forms.PictureBox b1Box;
        private System.Windows.Forms.PictureBox b2Box;
        private System.Windows.Forms.PictureBox b3Box;
        private System.Windows.Forms.Button playerBettingButton;
        private System.Windows.Forms.Button bankerBettingButton;
        private System.Windows.Forms.ListBox logBox;
        private System.Windows.Forms.Label roomNumLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox userListBox;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.ListBox chatBox;
        private System.Windows.Forms.TextBox chatInputBox;
        private System.Windows.Forms.Button enterBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox bettingListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button drawBettingButton;
    }
}