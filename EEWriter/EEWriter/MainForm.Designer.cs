/*
 * Created by SharpDevelop.
 * User: Jordi
 * Date: 12/06/2019
 * Time: 22:19
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace EEWriter
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.ComboBox cbSerialPorts;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button bTest;
		private System.Windows.Forms.Label label2;
		private System.IO.Ports.SerialPort serialPort1;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem LoadROMtoolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem SaveROMtoolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem rescanPortsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem viewDataToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem setTo0x00ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem setTo0xFFToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem setToRandomToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem protectSPDToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem unprotectSPDToolStripMenuItem;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox cbEEPROMSize;
		private System.Windows.Forms.ProgressBar pbStatus;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button bReadEEPROM;
		private System.Windows.Forms.Button bWriteEEPROM;
		private System.Windows.Forms.Button bVerifyEEPROM;
		private System.Windows.Forms.TextBox tbHWVersion;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.CheckBox cbPageWrite;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.cbSerialPorts = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.bTest = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.tbHWVersion = new System.Windows.Forms.TextBox();
			this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.LoadROMtoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.SaveROMtoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.rescanPortsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.viewDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.setTo0x00ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.setTo0xFFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.setToRandomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.protectSPDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.unprotectSPDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.label3 = new System.Windows.Forms.Label();
			this.cbEEPROMSize = new System.Windows.Forms.ComboBox();
			this.pbStatus = new System.Windows.Forms.ProgressBar();
			this.label4 = new System.Windows.Forms.Label();
			this.bReadEEPROM = new System.Windows.Forms.Button();
			this.bWriteEEPROM = new System.Windows.Forms.Button();
			this.bVerifyEEPROM = new System.Windows.Forms.Button();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.cbPageWrite = new System.Windows.Forms.CheckBox();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// cbSerialPorts
			// 
			this.cbSerialPorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbSerialPorts.FormattingEnabled = true;
			this.cbSerialPorts.Location = new System.Drawing.Point(110, 38);
			this.cbSerialPorts.Name = "cbSerialPorts";
			this.cbSerialPorts.Size = new System.Drawing.Size(174, 21);
			this.cbSerialPorts.TabIndex = 0;
			this.cbSerialPorts.SelectedIndexChanged += new System.EventHandler(this.CbSerialPortsSelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 181);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(66, 21);
			this.label1.TabIndex = 1;
			this.label1.Text = "Progress:";
			// 
			// bTest
			// 
			this.bTest.Location = new System.Drawing.Point(322, 36);
			this.bTest.Name = "bTest";
			this.bTest.Size = new System.Drawing.Size(75, 23);
			this.bTest.TabIndex = 2;
			this.bTest.Text = "Test!";
			this.bTest.UseVisualStyleBackColor = true;
			this.bTest.Click += new System.EventHandler(this.bTestClick);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(12, 71);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(80, 21);
			this.label2.TabIndex = 1;
			this.label2.Text = "HW Version:";
			// 
			// tbHWVersion
			// 
			this.tbHWVersion.Location = new System.Drawing.Point(110, 68);
			this.tbHWVersion.Name = "tbHWVersion";
			this.tbHWVersion.ReadOnly = true;
			this.tbHWVersion.Size = new System.Drawing.Size(174, 20);
			this.tbHWVersion.TabIndex = 3;
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.toolStripMenuItem1,
			this.viewToolStripMenuItem,
			this.toolsToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(433, 24);
			this.menuStrip1.TabIndex = 4;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.LoadROMtoolStripMenuItem,
			this.SaveROMtoolStripMenuItem,
			this.rescanPortsToolStripMenuItem,
			this.exitToolStripMenuItem});
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
			this.toolStripMenuItem1.Text = "File";
			// 
			// LoadROMtoolStripMenuItem
			// 
			this.LoadROMtoolStripMenuItem.Name = "LoadROMtoolStripMenuItem";
			this.LoadROMtoolStripMenuItem.Size = new System.Drawing.Size(177, 22);
			this.LoadROMtoolStripMenuItem.Text = "Load ROM Image";
			this.LoadROMtoolStripMenuItem.Click += new System.EventHandler(this.LoadROMtoolStripMenuItemClick);
			// 
			// SaveROMtoolStripMenuItem
			// 
			this.SaveROMtoolStripMenuItem.Name = "SaveROMtoolStripMenuItem";
			this.SaveROMtoolStripMenuItem.Size = new System.Drawing.Size(177, 22);
			this.SaveROMtoolStripMenuItem.Text = "Save ROM Image";
			this.SaveROMtoolStripMenuItem.Click += new System.EventHandler(this.SaveROMtoolStripMenuItemClick);
			// 
			// rescanPortsToolStripMenuItem
			// 
			this.rescanPortsToolStripMenuItem.Name = "rescanPortsToolStripMenuItem";
			this.rescanPortsToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
			this.rescanPortsToolStripMenuItem.Text = "Re-scan COM ports";
			this.rescanPortsToolStripMenuItem.Click += new System.EventHandler(this.RescanPortsToolStripMenuItemClick);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
			this.exitToolStripMenuItem.Text = "Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItemClick);
			// 
			// viewToolStripMenuItem
			// 
			this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.viewDataToolStripMenuItem,
			this.setTo0x00ToolStripMenuItem,
			this.setTo0xFFToolStripMenuItem,
			this.setToRandomToolStripMenuItem});
			this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
			this.viewToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
			this.viewToolStripMenuItem.Text = "Data";
			// 
			// viewDataToolStripMenuItem
			// 
			this.viewDataToolStripMenuItem.Name = "viewDataToolStripMenuItem";
			this.viewDataToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.viewDataToolStripMenuItem.Text = "View";
			this.viewDataToolStripMenuItem.Click += new System.EventHandler(this.ViewDataToolStripMenuItemClick);
			// 
			// setTo0x00ToolStripMenuItem
			// 
			this.setTo0x00ToolStripMenuItem.Name = "setTo0x00ToolStripMenuItem";
			this.setTo0x00ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.setTo0x00ToolStripMenuItem.Text = "Set to 0x00";
			this.setTo0x00ToolStripMenuItem.Click += new System.EventHandler(this.SetTo0x00ToolStripMenuItemClick);
			// 
			// setTo0xFFToolStripMenuItem
			// 
			this.setTo0xFFToolStripMenuItem.Name = "setTo0xFFToolStripMenuItem";
			this.setTo0xFFToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.setTo0xFFToolStripMenuItem.Text = "Set to 0xFF";
			this.setTo0xFFToolStripMenuItem.Click += new System.EventHandler(this.SetTo0xFFToolStripMenuItemClick);
			// 
			// setToRandomToolStripMenuItem
			// 
			this.setToRandomToolStripMenuItem.Name = "setToRandomToolStripMenuItem";
			this.setToRandomToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.setToRandomToolStripMenuItem.Text = "Set to Random";
			this.setToRandomToolStripMenuItem.Click += new System.EventHandler(this.SetToRandomToolStripMenuItemClick);
			// 
			// toolsToolStripMenuItem
			// 
			this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.protectSPDToolStripMenuItem,
			this.unprotectSPDToolStripMenuItem});
			this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
			this.toolsToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
			this.toolsToolStripMenuItem.Text = "Tools";
			// 
			// protectSPDToolStripMenuItem
			// 
			this.protectSPDToolStripMenuItem.Name = "protectSPDToolStripMenuItem";
			this.protectSPDToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
			this.protectSPDToolStripMenuItem.Text = "Unprotect (SPD)";
			this.protectSPDToolStripMenuItem.Click += new System.EventHandler(this.UnprotectSPDToolStripMenuItemClick);
			// 
			// unprotectSPDToolStripMenuItem
			// 
			this.unprotectSPDToolStripMenuItem.Name = "unprotectSPDToolStripMenuItem";
			this.unprotectSPDToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
			this.unprotectSPDToolStripMenuItem.Text = "Protect (SPD)";
			this.unprotectSPDToolStripMenuItem.Click += new System.EventHandler(this.ProtectSPDToolStripMenuItemClick);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(12, 106);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(80, 19);
			this.label3.TabIndex = 1;
			this.label3.Text = "EEPROM Size:";
			// 
			// cbEEPROMSize
			// 
			this.cbEEPROMSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbEEPROMSize.FormattingEnabled = true;
			this.cbEEPROMSize.Items.AddRange(new object[] {
			"1K        (8 K)",
			"2K      (16 K)",
			"4K      (32 K)",
			"8K      (64 K)",
			"16K   (128 K)",
			"32K   (256 K)"});
			this.cbEEPROMSize.Location = new System.Drawing.Point(110, 103);
			this.cbEEPROMSize.Name = "cbEEPROMSize";
			this.cbEEPROMSize.Size = new System.Drawing.Size(174, 21);
			this.cbEEPROMSize.TabIndex = 5;
			this.cbEEPROMSize.SelectedIndexChanged += new System.EventHandler(this.CbEEPROMSizeSelectedIndexChanged);
			// 
			// pbStatus
			// 
			this.pbStatus.Location = new System.Drawing.Point(74, 174);
			this.pbStatus.Name = "pbStatus";
			this.pbStatus.Size = new System.Drawing.Size(347, 25);
			this.pbStatus.TabIndex = 6;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(12, 41);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(66, 21);
			this.label4.TabIndex = 7;
			this.label4.Text = "Serial Port:";
			// 
			// bReadEEPROM
			// 
			this.bReadEEPROM.Location = new System.Drawing.Point(74, 139);
			this.bReadEEPROM.Name = "bReadEEPROM";
			this.bReadEEPROM.Size = new System.Drawing.Size(101, 23);
			this.bReadEEPROM.TabIndex = 8;
			this.bReadEEPROM.Text = "Read EEPROM";
			this.bReadEEPROM.UseVisualStyleBackColor = true;
			this.bReadEEPROM.Click += new System.EventHandler(this.BReadEEPROMClick);
			// 
			// bWriteEEPROM
			// 
			this.bWriteEEPROM.Location = new System.Drawing.Point(320, 139);
			this.bWriteEEPROM.Name = "bWriteEEPROM";
			this.bWriteEEPROM.Size = new System.Drawing.Size(101, 23);
			this.bWriteEEPROM.TabIndex = 9;
			this.bWriteEEPROM.Text = "Write EEPROM";
			this.bWriteEEPROM.UseVisualStyleBackColor = true;
			this.bWriteEEPROM.Click += new System.EventHandler(this.BWriteEEPROMClick);
			// 
			// bVerifyEEPROM
			// 
			this.bVerifyEEPROM.Location = new System.Drawing.Point(198, 139);
			this.bVerifyEEPROM.Name = "bVerifyEEPROM";
			this.bVerifyEEPROM.Size = new System.Drawing.Size(101, 23);
			this.bVerifyEEPROM.TabIndex = 10;
			this.bVerifyEEPROM.Text = "Verify EEPROM";
			this.bVerifyEEPROM.UseVisualStyleBackColor = true;
			this.bVerifyEEPROM.Click += new System.EventHandler(this.BVerifyEEPROMClick);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// cbPageWrite
			// 
			this.cbPageWrite.Location = new System.Drawing.Point(320, 106);
			this.cbPageWrite.Name = "cbPageWrite";
			this.cbPageWrite.Size = new System.Drawing.Size(101, 24);
			this.cbPageWrite.TabIndex = 11;
			this.cbPageWrite.Text = "Use Page Write";
			this.cbPageWrite.UseVisualStyleBackColor = true;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(433, 211);
			this.Controls.Add(this.cbPageWrite);
			this.Controls.Add(this.bVerifyEEPROM);
			this.Controls.Add(this.bWriteEEPROM);
			this.Controls.Add(this.bReadEEPROM);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.pbStatus);
			this.Controls.Add(this.cbEEPROMSize);
			this.Controls.Add(this.tbHWVersion);
			this.Controls.Add(this.bTest);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cbSerialPorts);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.MaximumSize = new System.Drawing.Size(449, 250);
			this.MinimumSize = new System.Drawing.Size(449, 250);
			this.Name = "MainForm";
			this.Text = "EEWriter";
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
