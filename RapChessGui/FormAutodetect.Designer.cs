namespace RapChessGui
{
	partial class FormAutodetect
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
			this.tbConsole = new System.Windows.Forms.TextBox();
			this.bStart = new System.Windows.Forms.Button();
			this.testTimer = new System.Windows.Forms.Timer(this.components);
			this.SuspendLayout();
			// 
			// tbConsole
			// 
			this.tbConsole.BackColor = System.Drawing.Color.Black;
			this.tbConsole.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbConsole.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.tbConsole.ForeColor = System.Drawing.Color.White;
			this.tbConsole.Location = new System.Drawing.Point(0, 0);
			this.tbConsole.Multiline = true;
			this.tbConsole.Name = "tbConsole";
			this.tbConsole.ReadOnly = true;
			this.tbConsole.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbConsole.Size = new System.Drawing.Size(800, 422);
			this.tbConsole.TabIndex = 0;
			// 
			// bStart
			// 
			this.bStart.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.bStart.Location = new System.Drawing.Point(0, 422);
			this.bStart.Name = "bStart";
			this.bStart.Size = new System.Drawing.Size(800, 28);
			this.bStart.TabIndex = 1;
			this.bStart.Text = "Start test";
			this.bStart.UseVisualStyleBackColor = true;
			this.bStart.Click += new System.EventHandler(this.bStart_Click);
			// 
			// testTimer
			// 
			this.testTimer.Tick += new System.EventHandler(this.testTimer_Tick);
			// 
			// FormAutodetect
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.tbConsole);
			this.Controls.Add(this.bStart);
			this.MaximizeBox = false;
			this.Name = "FormAutodetect";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Autodetect";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormAutodetect_FormClosing);
			this.Shown += new System.EventHandler(this.FormAutodetect_Shown);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox tbConsole;
		private System.Windows.Forms.Button bStart;
		private System.Windows.Forms.Timer testTimer;
	}
}