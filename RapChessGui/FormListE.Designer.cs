﻿namespace RapChessGui
{
	partial class FormListE
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
			this.lvEngines = new System.Windows.Forms.ListView();
			this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.SuspendLayout();
			// 
			// lvEngines
			// 
			this.lvEngines.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader1,
            this.columnHeader2});
			this.lvEngines.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lvEngines.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvEngines.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.lvEngines.FullRowSelect = true;
			this.lvEngines.GridLines = true;
			this.lvEngines.HideSelection = false;
			this.lvEngines.Location = new System.Drawing.Point(0, 0);
			this.lvEngines.MultiSelect = false;
			this.lvEngines.Name = "lvEngines";
			this.lvEngines.ShowGroups = false;
			this.lvEngines.Size = new System.Drawing.Size(800, 450);
			this.lvEngines.TabIndex = 28;
			this.lvEngines.UseCompatibleStateImageBehavior = false;
			this.lvEngines.View = System.Windows.Forms.View.Details;
			this.lvEngines.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvEngines_ColumnClick);
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Engine";
			this.columnHeader3.Width = 200;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "Elo";
			this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.columnHeader4.Width = 100;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Trend";
			this.columnHeader1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.columnHeader1.Width = 100;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Change";
			this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.columnHeader2.Width = 100;
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "Index";
			this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// FormListE
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.lvEngines);
			this.MinimizeBox = false;
			this.Name = "FormListE";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Engines";
			this.VisibleChanged += new System.EventHandler(this.FormListE_VisibleChanged);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListView lvEngines;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader5;
	}
}