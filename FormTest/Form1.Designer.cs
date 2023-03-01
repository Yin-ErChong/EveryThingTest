namespace FormTest
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.printDialog = new System.Windows.Forms.PrintDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.printDocument = new System.Drawing.Printing.PrintDocument();
            this.刹车1 = new YinDashboard.刹车();
            this.转速表1 = new YinDashboard.转速表();
            this.气压11 = new YinDashboard.气压1();
            this.油门条1 = new YinDashboard.油门条();
            this.油量条1 = new YinDashboard.油量条();
            this.水温1 = new YinDashboard.水温();
            this.转速表2 = new YinDashboard.转速表();
            this.speedDashBoard1 = new YinDashboard.SpeedDashBoard();
            this.SuspendLayout();
            // 
            // printDialog
            // 
            this.printDialog.UseEXDialog = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(695, 66);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // printDocument
            // 
            this.printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // 刹车1
            // 
            this.刹车1.BackColor = System.Drawing.Color.Transparent;
            this.刹车1.Location = new System.Drawing.Point(359, 239);
            this.刹车1.Name = "刹车1";
            this.刹车1.Real = 50;
            this.刹车1.Size = new System.Drawing.Size(442, 46);
            this.刹车1.TabIndex = 1;
            // 
            // 转速表1
            // 
            this.转速表1.BackColor = System.Drawing.Color.Transparent;
            this.转速表1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.转速表1.BottomTitleColor = System.Drawing.Color.Blue;
            this.转速表1.BottomTitleFont = new System.Drawing.Font("微软雅黑", 16F);
            this.转速表1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.转速表1.ForeColor = System.Drawing.Color.Red;
            this.转速表1.IndicatorAngle = 60;
            this.转速表1.IndicatorColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.转速表1.IndicatorFill = true;
            this.转速表1.InnerBackground = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(198)))), ((int)(((byte)(254)))));
            this.转速表1.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(106)))), ((int)(((byte)(168)))));
            this.转速表1.InnerRoundColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.转速表1.Location = new System.Drawing.Point(26, 46);
            this.转速表1.Name = "转速表1";
            this.转速表1.OuterColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.转速表1.ProgressColor = System.Drawing.Color.Gray;
            this.转速表1.ProgressDisplayModel = YinDashboard.转速表.ProgressModel.Inner;
            this.转速表1.Real = 0;
            this.转速表1.ScaleExpectedColor = System.Drawing.Color.Blue;
            this.转速表1.ScaleRealColor = System.Drawing.Color.Yellow;
            this.转速表1.Size = new System.Drawing.Size(196, 196);
            this.转速表1.TabIndex = 2;
            // 
            // 气压11
            // 
            this.气压11.BackColor = System.Drawing.Color.Transparent;
            this.气压11.BottomTitleColor = System.Drawing.Color.Blue;
            this.气压11.BottomTitleFont = new System.Drawing.Font("微软雅黑", 16F);
            this.气压11.Expected = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.气压11.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.气压11.ForeColor = System.Drawing.Color.Red;
            this.气压11.IndicatorAngle = 60;
            this.气压11.IndicatorColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.气压11.IndicatorFill = true;
            this.气压11.InnerBackground = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(198)))), ((int)(((byte)(254)))));
            this.气压11.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(106)))), ((int)(((byte)(168)))));
            this.气压11.InnerRoundColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.气压11.Location = new System.Drawing.Point(299, 46);
            this.气压11.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.气压11.Name = "气压11";
            this.气压11.OuterColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.气压11.ProgressColor = System.Drawing.Color.Gray;
            this.气压11.ProgressDisplayModel = YinDashboard.气压1.ProgressModel.Inner;
            this.气压11.Real = 12;
            this.气压11.ScaleExpectedColor = System.Drawing.Color.Blue;
            this.气压11.ScaleRealColor = System.Drawing.Color.Yellow;
            this.气压11.Size = new System.Drawing.Size(186, 186);
            this.气压11.TabIndex = 3;
            // 
            // 油门条1
            // 
            this.油门条1.BackColor = System.Drawing.Color.Transparent;
            this.油门条1.Location = new System.Drawing.Point(727, 401);
            this.油门条1.Name = "油门条1";
            this.油门条1.Real = 50;
            this.油门条1.Size = new System.Drawing.Size(434, 48);
            this.油门条1.TabIndex = 4;
            // 
            // 油量条1
            // 
            this.油量条1.BackColor = System.Drawing.Color.Transparent;
            this.油量条1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("油量条1.BackgroundImage")));
            this.油量条1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.油量条1.Location = new System.Drawing.Point(789, 161);
            this.油量条1.Name = "油量条1";
            this.油量条1.Real = 2;
            this.油量条1.Size = new System.Drawing.Size(800, 100);
            this.油量条1.TabIndex = 5;
            // 
            // 水温1
            // 
            this.水温1.BackColor = System.Drawing.Color.Transparent;
            this.水温1.Location = new System.Drawing.Point(124, 401);
            this.水温1.Name = "水温1";
            this.水温1.Real = 50;
            this.水温1.Size = new System.Drawing.Size(580, 48);
            this.水温1.TabIndex = 6;
            // 
            // 转速表2
            // 
            this.转速表2.BackColor = System.Drawing.Color.Transparent;
            this.转速表2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.转速表2.BottomTitleColor = System.Drawing.Color.Blue;
            this.转速表2.BottomTitleFont = new System.Drawing.Font("微软雅黑", 16F);
            this.转速表2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.转速表2.ForeColor = System.Drawing.Color.Red;
            this.转速表2.IndicatorAngle = 60;
            this.转速表2.IndicatorColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.转速表2.IndicatorFill = true;
            this.转速表2.InnerBackground = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(198)))), ((int)(((byte)(254)))));
            this.转速表2.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(106)))), ((int)(((byte)(168)))));
            this.转速表2.InnerRoundColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.转速表2.Location = new System.Drawing.Point(1354, 314);
            this.转速表2.Name = "转速表2";
            this.转速表2.OuterColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.转速表2.ProgressColor = System.Drawing.Color.Gray;
            this.转速表2.ProgressDisplayModel = YinDashboard.转速表.ProgressModel.Inner;
            this.转速表2.Real = 0;
            this.转速表2.ScaleExpectedColor = System.Drawing.Color.Blue;
            this.转速表2.ScaleRealColor = System.Drawing.Color.Yellow;
            this.转速表2.Size = new System.Drawing.Size(271, 271);
            this.转速表2.TabIndex = 7;
            // 
            // speedDashBoard1
            // 
            this.speedDashBoard1.BackColor = System.Drawing.Color.Transparent;
            this.speedDashBoard1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.speedDashBoard1.BottomTitleColor = System.Drawing.Color.Blue;
            this.speedDashBoard1.BottomTitleFont = new System.Drawing.Font("微软雅黑", 16F);
            this.speedDashBoard1.Expected = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.speedDashBoard1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.speedDashBoard1.ForeColor = System.Drawing.Color.Red;
            this.speedDashBoard1.IndicatorAngle = 60;
            this.speedDashBoard1.IndicatorColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.speedDashBoard1.IndicatorFill = true;
            this.speedDashBoard1.InnerBackground = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(198)))), ((int)(((byte)(254)))));
            this.speedDashBoard1.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(106)))), ((int)(((byte)(168)))));
            this.speedDashBoard1.InnerRoundColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.speedDashBoard1.Location = new System.Drawing.Point(1325, -12);
            this.speedDashBoard1.Name = "speedDashBoard1";
            this.speedDashBoard1.OuterColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.speedDashBoard1.ProgressColor = System.Drawing.Color.Gray;
            this.speedDashBoard1.ProgressDisplayModel = YinDashboard.SpeedDashBoard.ProgressModel.Inner;
            this.speedDashBoard1.Real = 69;
            this.speedDashBoard1.ScaleExpectedColor = System.Drawing.Color.Blue;
            this.speedDashBoard1.ScaleRealColor = System.Drawing.Color.Yellow;
            this.speedDashBoard1.Size = new System.Drawing.Size(138, 138);
            this.speedDashBoard1.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1718, 623);
            this.Controls.Add(this.speedDashBoard1);
            this.Controls.Add(this.转速表2);
            this.Controls.Add(this.水温1);
            this.Controls.Add(this.油量条1);
            this.Controls.Add(this.油门条1);
            this.Controls.Add(this.气压11);
            this.Controls.Add(this.转速表1);
            this.Controls.Add(this.刹车1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PrintDialog printDialog;
        private System.Windows.Forms.Button button1;
        private System.Drawing.Printing.PrintDocument printDocument;
        private YinDashboard.刹车 刹车1;
        private YinDashboard.转速表 转速表1;
        private YinDashboard.气压1 气压11;
        private YinDashboard.油门条 油门条1;
        private YinDashboard.油量条 油量条1;
        private YinDashboard.水温 水温1;
        private YinDashboard.转速表 转速表2;
        private YinDashboard.SpeedDashBoard speedDashBoard1;
    }
}

