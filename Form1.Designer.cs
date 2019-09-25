namespace RapChessGui
{
	partial class FormChess
	{
		/// <summary>
		/// Wymagana zmienna projektanta.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Wyczyść wszystkie używane zasoby.
		/// </summary>
		/// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Kod generowany przez Projektanta formularzy systemu Windows

		/// <summary>
		/// Metoda wymagana do obsługi projektanta — nie należy modyfikować
		/// jej zawartości w edytorze kodu.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormChess));
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.playersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.panel2 = new System.Windows.Forms.Panel();
			this.labNameT = new System.Windows.Forms.Label();
			this.panTop = new System.Windows.Forms.Panel();
			this.panel4 = new System.Windows.Forms.Panel();
			this.panel5 = new System.Windows.Forms.Panel();
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.butStop = new System.Windows.Forms.Button();
			this.bStart = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.comboBoxB = new System.Windows.Forms.ComboBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.comboBoxW = new System.Windows.Forms.ComboBox();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.panel3 = new System.Windows.Forms.Panel();
			this.labNameB = new System.Windows.Forms.Label();
			this.panBottom = new System.Windows.Forms.Panel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.labLast = new System.Windows.Forms.Label();
			this.labMove = new System.Windows.Forms.Label();
			this.menuStrip1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel4.SuspendLayout();
			this.panel5.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.panel3.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "Pawn_White.gif");
			this.imageList1.Images.SetKeyName(1, "Knight_White.gif");
			this.imageList1.Images.SetKeyName(2, "Bishop_White.gif");
			this.imageList1.Images.SetKeyName(3, "Rook_White.gif");
			this.imageList1.Images.SetKeyName(4, "Queen_White.gif");
			this.imageList1.Images.SetKeyName(5, "King_White.gif");
			this.imageList1.Images.SetKeyName(6, "Pawn_Black.gif");
			this.imageList1.Images.SetKeyName(7, "Knight_Black.gif");
			this.imageList1.Images.SetKeyName(8, "Bishop_Black.gif");
			this.imageList1.Images.SetKeyName(9, "Rook_Black.gif");
			this.imageList1.Images.SetKeyName(10, "Queen_Black.gif");
			this.imageList1.Images.SetKeyName(11, "King_Black.gif");
			// 
			// timer1
			// 
			this.timer1.Interval = 10;
			this.timer1.Tick += new System.EventHandler(this.Timer1_Tick_1);
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem,
            this.playersToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(822, 24);
			this.menuStrip1.TabIndex = 1;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// newGameToolStripMenuItem
			// 
			this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
			this.newGameToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
			this.newGameToolStripMenuItem.Text = "New Game";
			this.newGameToolStripMenuItem.Click += new System.EventHandler(this.NewGameToolStripMenuItem_Click);
			// 
			// playersToolStripMenuItem
			// 
			this.playersToolStripMenuItem.Name = "playersToolStripMenuItem";
			this.playersToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
			this.playersToolStripMenuItem.Text = "Players";
			this.playersToolStripMenuItem.Click += new System.EventHandler(this.PlayersToolStripMenuItem_Click);
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.Silver;
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel2.Controls.Add(this.labNameT);
			this.panel2.Controls.Add(this.panTop);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(0, 24);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(822, 30);
			this.panel2.TabIndex = 7;
			// 
			// labNameT
			// 
			this.labNameT.BackColor = System.Drawing.Color.LightGray;
			this.labNameT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labNameT.Dock = System.Windows.Forms.DockStyle.Left;
			this.labNameT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labNameT.ForeColor = System.Drawing.Color.Black;
			this.labNameT.Location = new System.Drawing.Point(26, 0);
			this.labNameT.Name = "labNameT";
			this.labNameT.Size = new System.Drawing.Size(137, 26);
			this.labNameT.TabIndex = 2;
			this.labNameT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panTop
			// 
			this.panTop.BackColor = System.Drawing.Color.Silver;
			this.panTop.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panTop.Dock = System.Windows.Forms.DockStyle.Left;
			this.panTop.Location = new System.Drawing.Point(0, 0);
			this.panTop.Name = "panTop";
			this.panTop.Size = new System.Drawing.Size(26, 26);
			this.panTop.TabIndex = 1;
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.panel5);
			this.panel4.Controls.Add(this.pictureBox1);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel4.Location = new System.Drawing.Point(0, 54);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(822, 522);
			this.panel4.TabIndex = 9;
			// 
			// panel5
			// 
			this.panel5.Controls.Add(this.richTextBox1);
			this.panel5.Controls.Add(this.butStop);
			this.panel5.Controls.Add(this.bStart);
			this.panel5.Controls.Add(this.groupBox2);
			this.panel5.Controls.Add(this.groupBox1);
			this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel5.Location = new System.Drawing.Point(518, 0);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(304, 522);
			this.panel5.TabIndex = 9;
			// 
			// richTextBox1
			// 
			this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.richTextBox1.Location = new System.Drawing.Point(0, 139);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.Size = new System.Drawing.Size(304, 383);
			this.richTextBox1.TabIndex = 17;
			this.richTextBox1.Text = "";
			// 
			// butStop
			// 
			this.butStop.Dock = System.Windows.Forms.DockStyle.Top;
			this.butStop.Location = new System.Drawing.Point(0, 116);
			this.butStop.Name = "butStop";
			this.butStop.Size = new System.Drawing.Size(304, 23);
			this.butStop.TabIndex = 16;
			this.butStop.Text = "Stop";
			this.butStop.UseVisualStyleBackColor = true;
			this.butStop.Click += new System.EventHandler(this.ButStop_Click);
			// 
			// bStart
			// 
			this.bStart.Dock = System.Windows.Forms.DockStyle.Top;
			this.bStart.Location = new System.Drawing.Point(0, 93);
			this.bStart.Name = "bStart";
			this.bStart.Size = new System.Drawing.Size(304, 23);
			this.bStart.TabIndex = 15;
			this.bStart.Text = "Start";
			this.bStart.UseVisualStyleBackColor = true;
			this.bStart.Click += new System.EventHandler(this.ButStart_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.comboBoxB);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox2.Location = new System.Drawing.Point(0, 47);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(304, 46);
			this.groupBox2.TabIndex = 14;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Black";
			// 
			// comboBoxB
			// 
			this.comboBoxB.Dock = System.Windows.Forms.DockStyle.Top;
			this.comboBoxB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxB.FormattingEnabled = true;
			this.comboBoxB.Location = new System.Drawing.Point(3, 16);
			this.comboBoxB.Name = "comboBoxB";
			this.comboBoxB.Size = new System.Drawing.Size(298, 21);
			this.comboBoxB.Sorted = true;
			this.comboBoxB.TabIndex = 1;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.comboBoxW);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(304, 47);
			this.groupBox1.TabIndex = 13;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "White";
			// 
			// comboBoxW
			// 
			this.comboBoxW.Dock = System.Windows.Forms.DockStyle.Top;
			this.comboBoxW.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxW.Location = new System.Drawing.Point(3, 16);
			this.comboBoxW.Name = "comboBoxW";
			this.comboBoxW.Size = new System.Drawing.Size(298, 21);
			this.comboBoxW.Sorted = true;
			this.comboBoxW.TabIndex = 2;
			// 
			// pictureBox1
			// 
			this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
			this.pictureBox1.ErrorImage = global::RapChessGui.Properties.Resources.black;
			this.pictureBox1.Image = global::RapChessGui.Properties.Resources.black;
			this.pictureBox1.InitialImage = global::RapChessGui.Properties.Resources.black;
			this.pictureBox1.Location = new System.Drawing.Point(0, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(518, 522);
			this.pictureBox1.TabIndex = 8;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PictureBox1_MouseClick);
			// 
			// panel3
			// 
			this.panel3.BackColor = System.Drawing.Color.Silver;
			this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel3.Controls.Add(this.labNameB);
			this.panel3.Controls.Add(this.panBottom);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel3.Location = new System.Drawing.Point(0, 576);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(822, 30);
			this.panel3.TabIndex = 10;
			// 
			// labNameB
			// 
			this.labNameB.BackColor = System.Drawing.Color.LightGray;
			this.labNameB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labNameB.Dock = System.Windows.Forms.DockStyle.Left;
			this.labNameB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labNameB.ForeColor = System.Drawing.Color.Black;
			this.labNameB.Location = new System.Drawing.Point(26, 0);
			this.labNameB.Name = "labNameB";
			this.labNameB.Size = new System.Drawing.Size(137, 26);
			this.labNameB.TabIndex = 3;
			this.labNameB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panBottom
			// 
			this.panBottom.BackColor = System.Drawing.Color.Silver;
			this.panBottom.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panBottom.Dock = System.Windows.Forms.DockStyle.Left;
			this.panBottom.Location = new System.Drawing.Point(0, 0);
			this.panBottom.Name = "panBottom";
			this.panBottom.Size = new System.Drawing.Size(26, 26);
			this.panBottom.TabIndex = 0;
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.Black;
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel1.Controls.Add(this.labLast);
			this.panel1.Controls.Add(this.labMove);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.ForeColor = System.Drawing.Color.Gainsboro;
			this.panel1.Location = new System.Drawing.Point(0, 606);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(822, 31);
			this.panel1.TabIndex = 11;
			// 
			// labLast
			// 
			this.labLast.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labLast.Dock = System.Windows.Forms.DockStyle.Fill;
			this.labLast.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labLast.ForeColor = System.Drawing.Color.Gainsboro;
			this.labLast.Location = new System.Drawing.Point(137, 0);
			this.labLast.Name = "labLast";
			this.labLast.Size = new System.Drawing.Size(681, 27);
			this.labLast.TabIndex = 2;
			this.labLast.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labMove
			// 
			this.labMove.BackColor = System.Drawing.Color.Black;
			this.labMove.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labMove.Dock = System.Windows.Forms.DockStyle.Left;
			this.labMove.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labMove.ForeColor = System.Drawing.Color.Gainsboro;
			this.labMove.Location = new System.Drawing.Point(0, 0);
			this.labMove.Name = "labMove";
			this.labMove.Size = new System.Drawing.Size(137, 27);
			this.labMove.TabIndex = 1;
			this.labMove.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// FormChess
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(822, 637);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.panel4);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.menuStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MainMenuStrip = this.menuStrip1;
			this.MaximizeBox = false;
			this.Name = "FormChess";
			this.Text = "RapChessGui";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormChess_FormClosed);
			this.Load += new System.EventHandler(this.FormChess_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.panel5.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.panel3.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem playersToolStripMenuItem;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.RichTextBox richTextBox1;
		private System.Windows.Forms.Button butStop;
		private System.Windows.Forms.Button bStart;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.ComboBox comboBoxB;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.ComboBox comboBoxW;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label labLast;
		private System.Windows.Forms.Label labMove;
		private System.Windows.Forms.Panel panTop;
		private System.Windows.Forms.Panel panBottom;
		private System.Windows.Forms.Label labNameT;
		private System.Windows.Forms.Label labNameB;
	}
}

