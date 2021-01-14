namespace Monitor
{
    partial class FrmOutStoreDetailMonitor
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_Init_Code = new System.Windows.Forms.Label();
            this.btn_Use = new System.Windows.Forms.Button();
            this.lbl_Sum = new System.Windows.Forms.Label();
            this.lbl_Material_Name = new System.Windows.Forms.Label();
            this.lbl_BinStore = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pan_KW1 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btn_K1 = new System.Windows.Forms.Button();
            this.pan_KW2 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.btn_K2 = new System.Windows.Forms.Button();
            this.pan_KW3 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.btn_K3 = new System.Windows.Forms.Button();
            this.pan_KW4 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.btn_K4 = new System.Windows.Forms.Button();
            this.pan_KW5 = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.btn_K5 = new System.Windows.Forms.Button();
            this.pan_KW6 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.btn_K6 = new System.Windows.Forms.Button();
            this.pan_KW7 = new System.Windows.Forms.Panel();
            this.panel13 = new System.Windows.Forms.Panel();
            this.btn_K7 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.pan_KW1.SuspendLayout();
            this.pan_KW2.SuspendLayout();
            this.pan_KW3.SuspendLayout();
            this.pan_KW4.SuspendLayout();
            this.pan_KW5.SuspendLayout();
            this.pan_KW6.SuspendLayout();
            this.pan_KW7.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Controls.Add(this.btn_Init_Code);
            this.panel1.Controls.Add(this.btn_Use);
            this.panel1.Controls.Add(this.lbl_Sum);
            this.panel1.Controls.Add(this.lbl_Material_Name);
            this.panel1.Controls.Add(this.lbl_BinStore);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1920, 31);
            this.panel1.TabIndex = 66;
            // 
            // btn_Init_Code
            // 
            this.btn_Init_Code.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(38)))), ((int)(((byte)(110)))));
            this.btn_Init_Code.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btn_Init_Code.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_Init_Code.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Init_Code.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_Init_Code.Location = new System.Drawing.Point(602, 0);
            this.btn_Init_Code.Name = "btn_Init_Code";
            this.btn_Init_Code.Size = new System.Drawing.Size(107, 31);
            this.btn_Init_Code.TabIndex = 33;
            this.btn_Init_Code.Text = "产品入库";
            this.btn_Init_Code.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_Init_Code.Click += new System.EventHandler(this.btn_Init_Code_Click);
            // 
            // btn_Use
            // 
            this.btn_Use.BackColor = System.Drawing.Color.DimGray;
            this.btn_Use.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_Use.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_Use.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Use.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Use.ForeColor = System.Drawing.Color.Lime;
            this.btn_Use.Location = new System.Drawing.Point(478, 0);
            this.btn_Use.Name = "btn_Use";
            this.btn_Use.Size = new System.Drawing.Size(124, 31);
            this.btn_Use.TabIndex = 32;
            this.btn_Use.Text = "正常模式";
            this.btn_Use.UseVisualStyleBackColor = false;
            this.btn_Use.Click += new System.EventHandler(this.btn_Use_Click);
            // 
            // lbl_Sum
            // 
            this.lbl_Sum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_Sum.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbl_Sum.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_Sum.ForeColor = System.Drawing.Color.Gold;
            this.lbl_Sum.Location = new System.Drawing.Point(408, 0);
            this.lbl_Sum.Name = "lbl_Sum";
            this.lbl_Sum.Size = new System.Drawing.Size(70, 31);
            this.lbl_Sum.TabIndex = 6;
            this.lbl_Sum.Text = "1#";
            this.lbl_Sum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Material_Name
            // 
            this.lbl_Material_Name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_Material_Name.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbl_Material_Name.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_Material_Name.ForeColor = System.Drawing.Color.Aqua;
            this.lbl_Material_Name.Location = new System.Drawing.Point(78, 0);
            this.lbl_Material_Name.Name = "lbl_Material_Name";
            this.lbl_Material_Name.Size = new System.Drawing.Size(330, 31);
            this.lbl_Material_Name.TabIndex = 5;
            this.lbl_Material_Name.Text = "1#";
            this.lbl_Material_Name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_Material_Name.Click += new System.EventHandler(this.lbl_Material_Name_Click);
            // 
            // lbl_BinStore
            // 
            this.lbl_BinStore.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_BinStore.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbl_BinStore.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_BinStore.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbl_BinStore.Location = new System.Drawing.Point(0, 0);
            this.lbl_BinStore.Name = "lbl_BinStore";
            this.lbl_BinStore.Size = new System.Drawing.Size(78, 31);
            this.lbl_BinStore.TabIndex = 4;
            this.lbl_BinStore.Text = "1#";
            this.lbl_BinStore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pan_KW1
            // 
            this.pan_KW1.Controls.Add(this.btn_K1);
            this.pan_KW1.Controls.Add(this.panel7);
            this.pan_KW1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pan_KW1.Location = new System.Drawing.Point(0, 0);
            this.pan_KW1.Name = "pan_KW1";
            this.pan_KW1.Size = new System.Drawing.Size(242, 44);
            this.pan_KW1.TabIndex = 23;
            // 
            // panel7
            // 
            this.panel7.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel7.Location = new System.Drawing.Point(227, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(15, 44);
            this.panel7.TabIndex = 23;
            // 
            // btn_K1
            // 
            this.btn_K1.BackColor = System.Drawing.Color.Green;
            this.btn_K1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_K1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_K1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_K1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_K1.ForeColor = System.Drawing.Color.Gold;
            this.btn_K1.Location = new System.Drawing.Point(0, 0);
            this.btn_K1.Name = "btn_K1";
            this.btn_K1.Size = new System.Drawing.Size(227, 44);
            this.btn_K1.TabIndex = 24;
            this.btn_K1.Text = "物料";
            this.btn_K1.UseVisualStyleBackColor = false;
            // 
            // pan_KW2
            // 
            this.pan_KW2.Controls.Add(this.btn_K2);
            this.pan_KW2.Controls.Add(this.panel8);
            this.pan_KW2.Dock = System.Windows.Forms.DockStyle.Left;
            this.pan_KW2.Location = new System.Drawing.Point(242, 0);
            this.pan_KW2.Name = "pan_KW2";
            this.pan_KW2.Size = new System.Drawing.Size(270, 44);
            this.pan_KW2.TabIndex = 24;
            // 
            // panel8
            // 
            this.panel8.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel8.Location = new System.Drawing.Point(255, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(15, 44);
            this.panel8.TabIndex = 24;
            // 
            // btn_K2
            // 
            this.btn_K2.BackColor = System.Drawing.Color.Green;
            this.btn_K2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_K2.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_K2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_K2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_K2.ForeColor = System.Drawing.Color.Gold;
            this.btn_K2.Location = new System.Drawing.Point(0, 0);
            this.btn_K2.Name = "btn_K2";
            this.btn_K2.Size = new System.Drawing.Size(255, 44);
            this.btn_K2.TabIndex = 25;
            this.btn_K2.Text = "物料";
            this.btn_K2.UseVisualStyleBackColor = false;
            // 
            // pan_KW3
            // 
            this.pan_KW3.Controls.Add(this.btn_K3);
            this.pan_KW3.Controls.Add(this.panel9);
            this.pan_KW3.Dock = System.Windows.Forms.DockStyle.Left;
            this.pan_KW3.Location = new System.Drawing.Point(512, 0);
            this.pan_KW3.Name = "pan_KW3";
            this.pan_KW3.Size = new System.Drawing.Size(270, 44);
            this.pan_KW3.TabIndex = 25;
            // 
            // panel9
            // 
            this.panel9.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel9.Location = new System.Drawing.Point(255, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(15, 44);
            this.panel9.TabIndex = 24;
            // 
            // btn_K3
            // 
            this.btn_K3.BackColor = System.Drawing.Color.Green;
            this.btn_K3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_K3.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_K3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_K3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_K3.ForeColor = System.Drawing.Color.Gold;
            this.btn_K3.Location = new System.Drawing.Point(0, 0);
            this.btn_K3.Name = "btn_K3";
            this.btn_K3.Size = new System.Drawing.Size(255, 44);
            this.btn_K3.TabIndex = 25;
            this.btn_K3.Text = "物料";
            this.btn_K3.UseVisualStyleBackColor = false;
            // 
            // pan_KW4
            // 
            this.pan_KW4.Controls.Add(this.btn_K4);
            this.pan_KW4.Controls.Add(this.panel10);
            this.pan_KW4.Dock = System.Windows.Forms.DockStyle.Left;
            this.pan_KW4.Location = new System.Drawing.Point(782, 0);
            this.pan_KW4.Name = "pan_KW4";
            this.pan_KW4.Size = new System.Drawing.Size(270, 44);
            this.pan_KW4.TabIndex = 26;
            // 
            // panel10
            // 
            this.panel10.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel10.Location = new System.Drawing.Point(255, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(15, 44);
            this.panel10.TabIndex = 24;
            // 
            // btn_K4
            // 
            this.btn_K4.BackColor = System.Drawing.Color.Green;
            this.btn_K4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_K4.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_K4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_K4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_K4.ForeColor = System.Drawing.Color.Gold;
            this.btn_K4.Location = new System.Drawing.Point(0, 0);
            this.btn_K4.Name = "btn_K4";
            this.btn_K4.Size = new System.Drawing.Size(255, 44);
            this.btn_K4.TabIndex = 25;
            this.btn_K4.Text = "物料";
            this.btn_K4.UseVisualStyleBackColor = false;
            // 
            // pan_KW5
            // 
            this.pan_KW5.Controls.Add(this.btn_K5);
            this.pan_KW5.Controls.Add(this.panel11);
            this.pan_KW5.Dock = System.Windows.Forms.DockStyle.Left;
            this.pan_KW5.Location = new System.Drawing.Point(1052, 0);
            this.pan_KW5.Name = "pan_KW5";
            this.pan_KW5.Size = new System.Drawing.Size(270, 44);
            this.pan_KW5.TabIndex = 27;
            // 
            // panel11
            // 
            this.panel11.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel11.Location = new System.Drawing.Point(255, 0);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(15, 44);
            this.panel11.TabIndex = 24;
            // 
            // btn_K5
            // 
            this.btn_K5.BackColor = System.Drawing.Color.Green;
            this.btn_K5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_K5.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_K5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_K5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_K5.ForeColor = System.Drawing.Color.Gold;
            this.btn_K5.Location = new System.Drawing.Point(0, 0);
            this.btn_K5.Name = "btn_K5";
            this.btn_K5.Size = new System.Drawing.Size(255, 44);
            this.btn_K5.TabIndex = 25;
            this.btn_K5.Text = "物料";
            this.btn_K5.UseVisualStyleBackColor = false;
            // 
            // pan_KW6
            // 
            this.pan_KW6.Controls.Add(this.btn_K6);
            this.pan_KW6.Controls.Add(this.panel12);
            this.pan_KW6.Dock = System.Windows.Forms.DockStyle.Left;
            this.pan_KW6.Location = new System.Drawing.Point(1322, 0);
            this.pan_KW6.Name = "pan_KW6";
            this.pan_KW6.Size = new System.Drawing.Size(270, 44);
            this.pan_KW6.TabIndex = 28;
            // 
            // panel12
            // 
            this.panel12.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel12.Location = new System.Drawing.Point(255, 0);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(15, 44);
            this.panel12.TabIndex = 24;
            // 
            // btn_K6
            // 
            this.btn_K6.BackColor = System.Drawing.Color.Green;
            this.btn_K6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_K6.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_K6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_K6.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_K6.ForeColor = System.Drawing.Color.Gold;
            this.btn_K6.Location = new System.Drawing.Point(0, 0);
            this.btn_K6.Name = "btn_K6";
            this.btn_K6.Size = new System.Drawing.Size(255, 44);
            this.btn_K6.TabIndex = 25;
            this.btn_K6.Text = "物料";
            this.btn_K6.UseVisualStyleBackColor = false;
            // 
            // pan_KW7
            // 
            this.pan_KW7.Controls.Add(this.btn_K7);
            this.pan_KW7.Controls.Add(this.panel13);
            this.pan_KW7.Dock = System.Windows.Forms.DockStyle.Left;
            this.pan_KW7.Location = new System.Drawing.Point(1592, 0);
            this.pan_KW7.Name = "pan_KW7";
            this.pan_KW7.Size = new System.Drawing.Size(270, 44);
            this.pan_KW7.TabIndex = 29;
            // 
            // panel13
            // 
            this.panel13.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel13.Location = new System.Drawing.Point(255, 0);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(15, 44);
            this.panel13.TabIndex = 24;
            // 
            // btn_K7
            // 
            this.btn_K7.BackColor = System.Drawing.Color.Green;
            this.btn_K7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_K7.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_K7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_K7.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_K7.ForeColor = System.Drawing.Color.Gold;
            this.btn_K7.Location = new System.Drawing.Point(0, 0);
            this.btn_K7.Name = "btn_K7";
            this.btn_K7.Size = new System.Drawing.Size(255, 44);
            this.btn_K7.TabIndex = 25;
            this.btn_K7.Text = "物料";
            this.btn_K7.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel2.Controls.Add(this.pan_KW7);
            this.panel2.Controls.Add(this.pan_KW6);
            this.panel2.Controls.Add(this.pan_KW5);
            this.panel2.Controls.Add(this.pan_KW4);
            this.panel2.Controls.Add(this.pan_KW3);
            this.panel2.Controls.Add(this.pan_KW2);
            this.panel2.Controls.Add(this.pan_KW1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 31);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1920, 44);
            this.panel2.TabIndex = 67;
            // 
            // FrmOutStoreDetailMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 75);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmOutStoreDetailMonitor";
            this.Text = "FrmOutStoreDetailMonitor";
            this.Load += new System.EventHandler(this.FrmOutStoreDetailMonitor_Load);
            this.panel1.ResumeLayout(false);
            this.pan_KW1.ResumeLayout(false);
            this.pan_KW2.ResumeLayout(false);
            this.pan_KW3.ResumeLayout(false);
            this.pan_KW4.ResumeLayout(false);
            this.pan_KW5.ResumeLayout(false);
            this.pan_KW6.ResumeLayout(false);
            this.pan_KW7.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lbl_Sum;
        private System.Windows.Forms.Label lbl_Material_Name;
        private System.Windows.Forms.Label lbl_BinStore;
        private System.Windows.Forms.Button btn_Use;
        private System.Windows.Forms.Label btn_Init_Code;
        private System.Windows.Forms.Panel pan_KW1;
        private System.Windows.Forms.Button btn_K1;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel pan_KW2;
        private System.Windows.Forms.Button btn_K2;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel pan_KW3;
        private System.Windows.Forms.Button btn_K3;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel pan_KW4;
        private System.Windows.Forms.Button btn_K4;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel pan_KW5;
        private System.Windows.Forms.Button btn_K5;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Panel pan_KW6;
        private System.Windows.Forms.Button btn_K6;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Panel pan_KW7;
        private System.Windows.Forms.Button btn_K7;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Panel panel2;
    }
}