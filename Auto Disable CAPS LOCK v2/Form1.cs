using Keystroke.API;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace Auto_Disable_CAPS_LOCK_v2
{
	public partial class Form1 : Form
	{
		#region Importing
		[DllImport("user32.dll")]
		static extern void keybd_event(byte bVk, byte bScan, uint dwFlags,
		UIntPtr dwExtraInfo);
		void PressCAPSLOCK()
		{
			keybd_event(0x14, 0x45, 0x1, (UIntPtr)0);
			keybd_event(0x14, 0x45, 0x1 | 0x2, (UIntPtr)0);
		}
		#endregion

		#region Variables
		KeystrokeAPI KeyStrokeAPI = new KeystrokeAPI();
		string[] args;
		Thread t;
		bool ProgrammaticallyPressed;
		#endregion


		public Form1(string[] _args)
		{
			args = _args;
			InitializeComponent();
			WindowState = FormWindowState.Minimized;
			Hide();
			ShowInTaskbar = false;
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			if (args.Length >= 1)
			{
				switch (args[0])
				{
					case "-timer": LoadTimer(); break;
					case "-loop": LoadLoop(); break;
					case "-press": LoadPress(); break;
					default: LoadTimer(); break;
				}
			}
			else
			{
				Application.Exit();
			}
		}

		#region Timer
		Timer timer = new Timer()
		{
			Enabled = true,
			Interval = 1000
		};

		void LoadTimer()
		{
			modeToolStripMenuItem.Text = "Mode: Timer";


			#region TimerMS Items
			ToolStripMenuItem TimerMS_1ms = new ToolStripMenuItem()
			{
				Text = "1ms"
			};
			TimerMS_1ms.Click += TimerMS_ItemClicked;

			ToolStripMenuItem TimerMS_10ms = new ToolStripMenuItem()
			{
				Text = "10ms"
			};
			TimerMS_10ms.Click += TimerMS_ItemClicked;

			ToolStripMenuItem TimerMS_50ms = new ToolStripMenuItem()
			{
				Text = "50ms"
			};
			TimerMS_50ms.Click += TimerMS_ItemClicked;

			ToolStripMenuItem TimerMS_100ms = new ToolStripMenuItem()
			{
				Text = "100ms"
			};
			TimerMS_100ms.Click += TimerMS_ItemClicked;

			ToolStripMenuItem TimerMS_125ms = new ToolStripMenuItem()
			{
				Text = "125ms"
			};
			TimerMS_125ms.Click += TimerMS_ItemClicked;

			ToolStripMenuItem TimerMS_250ms = new ToolStripMenuItem()
			{
				Text = "250ms"
			};
			TimerMS_250ms.Click += TimerMS_ItemClicked;

			ToolStripMenuItem TimerMS_333ms = new ToolStripMenuItem()
			{
				Text = "333ms"
			};
			TimerMS_333ms.Click += TimerMS_ItemClicked;

			ToolStripMenuItem TimerMS_500ms = new ToolStripMenuItem()
			{
				Text = "500ms"
			};
			TimerMS_500ms.Click += TimerMS_ItemClicked;

			ToolStripMenuItem TimerMS_750ms = new ToolStripMenuItem()
			{
				Text = "750ms"
			};
			TimerMS_750ms.Click += TimerMS_ItemClicked;

			ToolStripMenuItem TimerMS_1000ms = new ToolStripMenuItem()
			{
				Text = "1000ms"
			};
			TimerMS_1000ms.Click += TimerMS_ItemClicked;
			#endregion

			TimerMS.DropDownItems.AddRange(new ToolStripItem[]
			{
				TimerMS_1ms,
				TimerMS_10ms,
				TimerMS_50ms,
				TimerMS_100ms,
				TimerMS_125ms,
				TimerMS_250ms,
				TimerMS_333ms,
				TimerMS_500ms,
				TimerMS_750ms,
				TimerMS_1000ms
			});
			TimerMS.Text = "Interval";

			TimerMSCurrent.Text = "Interval: 1000ms";
			TimerMSCurrent.Enabled = false;

			enableToolStripMenuItem.CheckState = CheckState.Checked;
			enableToolStripMenuItem.Size = new Size(180, 22);
			enableToolStripMenuItem.Click += TimerEnable;
			enableToolStripMenuItem.Text = "Enable";

			disableToolStripMenuItem.CheckState = CheckState.Unchecked;
			disableToolStripMenuItem.Size = new Size(180, 22);
			disableToolStripMenuItem.Click += TimerDisable;
			disableToolStripMenuItem.Text = "Disable";

			exitToolStripMenuItem.Size = new Size(180, 22);
			exitToolStripMenuItem.Click += TimerExit;
			exitToolStripMenuItem.Text = "Exit";

			ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
			contextMenuStrip.Items.AddRange(new ToolStripItem[]
			{
				headerToolStripMenuItem,
				modeToolStripMenuItem,
				TimerMS,
				TimerMSCurrent,
				enableToolStripMenuItem,
				disableToolStripMenuItem,
				exitToolStripMenuItem
			});
			notifyIcon.ContextMenuStrip = contextMenuStrip;


			timer.Tick += TimerTick;

			ShowInTaskbar = false;
			Visible = false;
		}

		void TimerMS_ItemClicked(object sender, EventArgs e)
		{
			ToolStripItem item = (ToolStripItem)sender;
			int number = Convert.ToInt32(item.Text.Replace("ms", ""));
			TimerMSCurrent.Text = "Interval: " + number + "ms";
			timer.Interval = number;
		}

		void TimerTick(object sender, EventArgs e)
		{
			if (IsKeyLocked(Keys.CapsLock))
			{
				PressCAPSLOCK();
			}
		}

		void TimerEnable(object sender, EventArgs e)
		{
			timer.Start();
			enableToolStripMenuItem.CheckState = CheckState.Checked;
			disableToolStripMenuItem.CheckState = CheckState.Unchecked;
		}

		void TimerDisable(object sender, EventArgs e)
		{
			timer.Stop();
			enableToolStripMenuItem.CheckState = CheckState.Unchecked;
			disableToolStripMenuItem.CheckState = CheckState.Checked;
		}

		void TimerExit(object sender, EventArgs e)
		{
			timer.Stop();
			Application.Exit();
		}

		#endregion

		#region Loop
		public void LoadLoop()
		{
			modeToolStripMenuItem.Text = "Mode: Loop";

			enableToolStripMenuItem.CheckState = CheckState.Checked;
			enableToolStripMenuItem.Size = new Size(180, 22);
			enableToolStripMenuItem.Click += LoopEnable;
			enableToolStripMenuItem.Text = "Enable";

			disableToolStripMenuItem.CheckState = CheckState.Unchecked;
			disableToolStripMenuItem.Size = new Size(180, 22);
			disableToolStripMenuItem.Click += LoopDisable;
			disableToolStripMenuItem.Text = "Disable";

			exitToolStripMenuItem.Size = new Size(180, 22);
			exitToolStripMenuItem.Click += LoopExit;
			exitToolStripMenuItem.Text = "Exit";

			ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
			contextMenuStrip.Items.AddRange(new ToolStripItem[]
			{
				headerToolStripMenuItem,
				modeToolStripMenuItem,
				enableToolStripMenuItem,
				disableToolStripMenuItem,
				exitToolStripMenuItem
			});
			notifyIcon.ContextMenuStrip = contextMenuStrip;


			t = new Thread(() =>
			{
				while (true)
				{
					if (IsKeyLocked(Keys.CapsLock))
					{
						PressCAPSLOCK();
					}
				}
			});
			t.SetApartmentState(ApartmentState.MTA);
			t.Start();

		}

		void LoopEnable(object sender, EventArgs e)
		{
			t.Resume();
			enableToolStripMenuItem.CheckState = CheckState.Checked;
			disableToolStripMenuItem.CheckState = CheckState.Unchecked;
		}

		void LoopDisable(object sender, EventArgs e)
		{
			t.Suspend();
			enableToolStripMenuItem.CheckState = CheckState.Unchecked;
			disableToolStripMenuItem.CheckState = CheckState.Checked;
		}

		void LoopExit(object sender, EventArgs e)
		{
			t.Abort();
			Application.Exit();
		}
		#endregion

		#region Press
		bool PressEnabled = true;

		void LoadPress()
		{
			modeToolStripMenuItem.Text = "Mode: Press";

			enableToolStripMenuItem.CheckState = CheckState.Checked;
			enableToolStripMenuItem.Size = new Size(180, 22);
			enableToolStripMenuItem.Click += PressEnable;
			enableToolStripMenuItem.Text = "Enable";

			disableToolStripMenuItem.CheckState = CheckState.Unchecked;
			disableToolStripMenuItem.Size = new Size(180, 22);
			disableToolStripMenuItem.Click += PressDisable;
			disableToolStripMenuItem.Text = "Disable";

			exitToolStripMenuItem.Size = new Size(180, 22);
			exitToolStripMenuItem.Click += PressExit;
			exitToolStripMenuItem.Text = "Exit";

			ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
			contextMenuStrip.Items.AddRange(new ToolStripItem[]
			{
				headerToolStripMenuItem,
				modeToolStripMenuItem,
				enableToolStripMenuItem,
				disableToolStripMenuItem,
				exitToolStripMenuItem
			});
			notifyIcon.ContextMenuStrip = contextMenuStrip;


			if (IsKeyLocked(Keys.CapsLock))
				PressCAPSLOCK();
			ProgrammaticallyPressed = false;

			KeyStrokeAPI.CreateKeyboardHook((character) =>
			{
				if (PressEnabled)
					if (ProgrammaticallyPressed == false)
						if (IsKeyLocked(Keys.CapsLock) && character.KeyCode != KeyCode.CapsLock)
						{
							ProgrammaticallyPressed = true;
							PressCAPSLOCK();
							ProgrammaticallyPressed = false;
						}
						else
						{
							if (!IsKeyLocked(Keys.CapsLock) && character.KeyCode == KeyCode.CapsLock)
							{
								ProgrammaticallyPressed = true;
								PressCAPSLOCK();
								ProgrammaticallyPressed = false;
							}
						}
			});

		}

		void PressEnable(object sender, EventArgs e)
		{
			PressEnabled = true;
			enableToolStripMenuItem.CheckState = CheckState.Checked;
			disableToolStripMenuItem.CheckState = CheckState.Unchecked;
		}

		void PressDisable(object sender, EventArgs e)
		{
			PressEnabled = false;
			enableToolStripMenuItem.CheckState = CheckState.Unchecked;
			disableToolStripMenuItem.CheckState = CheckState.Checked;
		}

		void PressExit(object sender, EventArgs e)
		{
			Application.Exit();
		}

		#endregion
	}
}
