namespace Auto_Disable_CAPS_LOCK_v2
{
	partial class Form1
	{
		/// <summary>
		/// Variable del diseñador necesaria.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Limpiar los recursos que se estén usando.
		/// </summary>
		/// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Código generado por el Diseñador de Windows Forms

		/// <summary>
		/// Método necesario para admitir el Diseñador. No se puede modificar
		/// el contenido de este método con el editor de código.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
			this.headerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.modeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.enableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.disableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.TimerMS = new System.Windows.Forms.ToolStripMenuItem();
			this.TimerMSCurrent = new System.Windows.Forms.ToolStripMenuItem();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// notifyIcon
			// 
			this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
			this.notifyIcon.Text = "Auto Disable CAPS LOCK v2";
			this.notifyIcon.Visible = true;
			// 
			// headerToolStripMenuItem
			// 
			this.headerToolStripMenuItem.Enabled = false;
			this.headerToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
			this.headerToolStripMenuItem.Name = "headerToolStripMenuItem";
			this.headerToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
			this.headerToolStripMenuItem.Text = "Auto Disable CAPS LOCK v2";
			// 
			// modeToolStripMenuItem
			// 
			this.modeToolStripMenuItem.Enabled = false;
			this.modeToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
			this.modeToolStripMenuItem.Name = "modeToolStripMenuItem";
			this.modeToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
			// 
			// enableToolStripMenuItem
			// 
			this.enableToolStripMenuItem.Name = "enableToolStripMenuItem";
			this.enableToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
			// 
			// disableToolStripMenuItem
			// 
			this.disableToolStripMenuItem.Name = "disableToolStripMenuItem";
			this.disableToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
			// 
			// TimerMS
			// 
			this.TimerMS.Name = "TimerMS";
			this.TimerMS.Size = new System.Drawing.Size(32, 19);
			// 
			// TimerMSCurrent
			// 
			this.TimerMSCurrent.Name = "TimerMSCurrent";
			this.TimerMSCurrent.Size = new System.Drawing.Size(32, 19);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(1, -2);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(0, 13);
			this.label1.TabIndex = 0;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(289, 22);
			this.Controls.Add(this.label1);
			this.Name = "Form1";
			this.Text = "Auto Disable CAPS LOCK v2";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.NotifyIcon notifyIcon;
		private System.Windows.Forms.ToolStripMenuItem headerToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem modeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem enableToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem disableToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;

		private System.Windows.Forms.ToolStripMenuItem TimerMS;
		private System.Windows.Forms.ToolStripMenuItem TimerMSCurrent;

		private System.Windows.Forms.Label label1;
	}
}

