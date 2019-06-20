/*
 * Created by SharpDevelop.
 * User: Jordi
 * Date: 12/06/2019
 * Time: 22:19
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.IO.Ports;
using System.Security.Cryptography;

namespace EEWriter
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		int statusCom;
		int memSize;
		byte [] buffer;
		const int MAXBUFFER=32768;
		const int BLOCK=0x80;
		
		public MainForm()
		{
			InitializeComponent();			
			statusCom = 0;
			cbEEPROMSize.SelectedIndex=5;			
			buffer = new byte[MAXBUFFER];
			fillBuffer(0xff);
		}

		void MainFormLoad(object sender, EventArgs e)
		{
			LoadPorts();
			ToolTip ttPort = new ToolTip();
			ttPort.ShowAlways=true;
			ttPort.SetToolTip(bTest, "Better scan ports, then connect ArduinoMega and scan again\n" +
			                          "New port is the ArduinoMega one");
		}
		
		void fillBuffer(byte dat)
		{
			for(int i=0; i < MAXBUFFER; i++)
			{
				buffer[i]=dat;
			}
		}
		
		void CbSerialPortsSelectedIndexChanged(object sender, EventArgs e)
		{
			tbHWVersion.Text= "";
			statusCom = 0;
			bTest.BackColor = SystemColors.Control;
		}		
				
		void RescanPortsToolStripMenuItemClick(object sender, EventArgs e)
		{
			LoadPorts();
		}
		
		void LoadPorts()
		{
			statusCom = 0;
			tbHWVersion.Text= "";
			bTest.BackColor = SystemColors.Control;
			// Get a list of serial port names.
            string[] ports = SerialPort.GetPortNames();
            Array.Sort(ports);
            cbSerialPorts.SuspendLayout();
            cbSerialPorts.Items.Clear();

            // Display each port name to the console.
            foreach(string port in ports)
            {
            	if (cbSerialPorts.Items.Contains(port)==false)
            		cbSerialPorts.Items.Add(port);
            }
            cbSerialPorts.ResumeLayout();
		}
		
		void bTestClick(object sender, EventArgs e)
		{
			bTest.BackColor = SystemColors.Control;
			tbHWVersion.Text= "";
			if (cbSerialPorts.SelectedItem==null)
				MessageBox.Show("Seleccionar un puerto COM");
			else
			{
				serialPort1.PortName = cbSerialPorts.SelectedItem.ToString();
				serialPort1.BaudRate = 9600;
				serialPort1.Parity = Parity.None;
				serialPort1.DataBits = 8;
				serialPort1.StopBits = StopBits.One;
				try
				{
					serialPort1.ReadTimeout = 1000;
					serialPort1.WriteTimeout= 1000;
					serialPort1.Open();
					serialPort1.WriteLine("V");
					tbHWVersion.Text = serialPort1.ReadLine(); 
					serialPort1.Close();
					if (tbHWVersion.Text.StartsWith("EEPROM Version="))
					{
						statusCom = 1;
						bTest.BackColor = Color.PaleGreen;
					}
					else
					{
						statusCom = -1;
						MessageBox.Show("Answer is not expeted one!");
					}
				}
				catch (Exception ex)
				{
					statusCom = -1;
					tbHWVersion.Text = "TimeOut";
					MessageBox.Show("Port not OK\n" + ex.Message, "Error");
					serialPort1.Close();
				}
			}	
		}
		
		void ExitToolStripMenuItemClick(object sender, EventArgs e)
		{
			Application.Exit();	
		}
		
		void ProtectSPDToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (statusCom==1)
			{
				try
				{
					serialPort1.Open();
					serialPort1.WriteLine("P");
					serialPort1.ReadTimeout = 2000;
					string msg = serialPort1.ReadLine();
					MessageBox.Show(msg);
					serialPort1.Close();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "Error");
					serialPort1.Close();
					bTest.BackColor= SystemColors.Control;
					statusCom = -1;
				}
			}
			else
				MessageBox.Show("No Test COM Port","Warning");
		}
		
		void UnprotectSPDToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (statusCom==1)
			{
				try
				{
					serialPort1.Open();
					serialPort1.WriteLine("U");
					serialPort1.ReadTimeout = 2000;
					string msg = serialPort1.ReadLine();
					MessageBox.Show(msg);
					serialPort1.Close();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "Error");
					serialPort1.Close();
					bTest.BackColor= SystemColors.Control;
					statusCom = -1;
				}
			}
			else
				MessageBox.Show("No Test COM Port","Warning");
		}
		
		void SetTo0x00ToolStripMenuItemClick(object sender, EventArgs e)
		{
			fillBuffer(0x00);
		}
		
		void SetTo0xFFToolStripMenuItemClick(object sender, EventArgs e)
		{
			fillBuffer(0xFF);	
		}
		
		void SetToRandomToolStripMenuItemClick(object sender, EventArgs e)
		{
            // Nothing special, just really random numbers 
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetBytes(buffer); // The array is now filled with cryptographically strong random bytes
		}
		
		void ViewDataToolStripMenuItemClick(object sender, EventArgs e)
		{
            using (Form form = new Form())
            {
	            string lineH = "";
	            string lineA = "";
	            char c=' ';
	            
	            form.Text = "Visualize Data";
	            form.Size = new Size(510, 325);
	            form.MinimumSize = new Size(510, 325);
	            TextBox textBox1;
	            textBox1 = new TextBox();
	            textBox1.Anchor = (System.Windows.Forms.AnchorStyles)(AnchorStyles.Top     |
	                                                                  AnchorStyles.Bottom  |
	                                                                  AnchorStyles.Left    |
	                                                                  AnchorStyles.Right     );
	            textBox1.Location = new System.Drawing.Point(13, 13);
	            textBox1.Multiline = true;
	            textBox1.Size = new Size(470, 260);
	            textBox1.TabIndex = 1;
	            textBox1.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
	            textBox1.ScrollBars = ScrollBars.Vertical;
	            textBox1.ReadOnly = true;
	            form.Controls.Add(textBox1);
	            for (int line =0 ; line < memSize ; line=line+16)
	            {
	                  lineH = line.ToString("X").PadLeft(4,'0') + ":"; // base address
	                  lineA = "    ";
	                  for (int idx=0; idx < 16; idx++)
	                  { 
	                        lineH  += " " + buffer[line+idx ].ToString("X").PadLeft(2,'0');   // HEX data                 
	                        c = Convert.ToChar(buffer[line+idx]);                                           // AASCII
	                        if (Char.IsControl(c))
	                              c='.';
	                        lineA += c.ToString();                 
	                  }
	                  textBox1.AppendText(lineH + lineA + Environment.NewLine);
	            }
	            form.ShowDialog();
            }
		}

		void LoadROMtoolStripMenuItemClick(object sender, EventArgs e)
		{
			//openFileDialog.InitialDirectory = "c:\\";
            //openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            //openFileDialog.FilterIndex = 2;
            //openFileDialog.RestoreDirectory = true;
			
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				String inputFilename = openFileDialog1.FileName;
				byte[] fileBytes = File.ReadAllBytes(inputFilename);
				Array.Copy(fileBytes, buffer, fileBytes.Length);				
			}
		}
		
		void CbEEPROMSizeSelectedIndexChanged(object sender, EventArgs e)
		{
			switch (cbEEPROMSize.SelectedIndex)
			{
				case (0):       				//  1K     (8 K)
					memSize=MAXBUFFER / 32;
					break;
				case (1):     					//  2K    (16 K)
					memSize=MAXBUFFER / 16;
					break;
				case (2):						//  4K    (32 K)
					memSize=MAXBUFFER /  8;
					break;
				case (3):						//  8K    (64 K)
					memSize=MAXBUFFER /  4;
					break;
				case (4):						// 16K   (128 K)
					memSize=MAXBUFFER /  2;
					break;
				case (5):						// 32K   (256 K)
					memSize=MAXBUFFER;   
					break;
				default:
					memSize=MAXBUFFER;
					break;					
			}			
		}
		
		void SaveROMtoolStripMenuItemClick(object sender, EventArgs e)
		{
			saveFileDialog1.OverwritePrompt = true;
			if (saveFileDialog1.ShowDialog() == DialogResult.OK)
			{
				byte[] fileBytes = new byte[memSize];
				Array.Copy(buffer, fileBytes, memSize);
				File.WriteAllBytes(saveFileDialog1.FileName, fileBytes);
			}
		}

		void BReadEEPROMClick(object sender, EventArgs e)
		{
			ReadOrVerifyEEPROM(false);  // FALSE => READ
		}
		
		void BVerifyEEPROMClick(object sender, EventArgs e)
		{
			ReadOrVerifyEEPROM(true);  // TRUE => VERIFY
		}
		
		void ReadOrVerifyEEPROM(bool operation)
		{
			string data="";
			string result="";
			int ntry=0;
			bool bFi=false;
			int addr=0;
			byte crcI=0;
			byte crcE=0;
			byte [] dat={0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
			
			if (statusCom==1)
			{
				try
				{
					serialPort1.Open();
					serialPort1.ReadTimeout  = 1000;
					serialPort1.WriteTimeout = 1000;
					pbStatus.Maximum = memSize;
					pbStatus.Step = 16;
				    for (int line =0 ; line < memSize ; line=line+16)
	                {
                        pbStatus.PerformStep();
				    	ntry=0;
				    	bFi=false;
				    	do
				    	{
				    		ntry++;
				    		crcI =0;
				    		serialPort1.WriteLine("R"+ line.ToString("X"));
				    		data = serialPort1.ReadLine().TrimEnd('\r');
				    		result = serialPort1.ReadLine().TrimEnd('\r');
				    		if (ntry++ > 5)
				    		{
				    			serialPort1.Close();
				    			MessageBox.Show("Too munch reading errors","ERROR");				    			
                 				pbStatus.Value=0;
                 				return;
				    		}
				    		else if (result.Equals("OK") && data.Length==40 && data.Substring(4,1).Equals(":") && data.Substring(37,1).Equals(",") )
				    		{
				    			addr = int.Parse(data.Substring(0,4), System.Globalization.NumberStyles.HexNumber);
				    			crcE  = byte.Parse(data.Substring(38), System.Globalization.NumberStyles.HexNumber);
				    			for (int idx=0; idx<16; idx++)
				    			{
				    			   dat[idx] = byte.Parse(data.Substring(5+idx*2,2), System.Globalization.NumberStyles.HexNumber);
				    			   crcI = (byte)((int)crcI ^ (int)dat[idx]);
				    			}
				    			if (crcE==crcI)    // Check CRC
				    			{
				    				for (int idx=0; idx<16; idx++)
			    					{
			    						if (operation==false)  // READ
			    				        {
			    							buffer[addr+idx] = dat[idx];
			    						}
			    						else                  // VERIFY
			    						{
			    							if (buffer[addr+idx] != dat[idx])
			    							{
			    								serialPort1.Close();
			    								MessageBox.Show("VERIFY error at "+(addr+idx).ToString("X"),"ERROR");
			    								pbStatus.Value=0;
			    								return;
			    							}
			    						}
				    				}
				    				bFi = true;
				    			}
				    			else
				    				MessageBox.Show("CRC compare error reading " + line.ToString("X"),"ERROR");
				    		}
				    	} 	while (bFi==false);
				    		
				    }
					serialPort1.Close();
					if (operation)
						MessageBox.Show("Verification OK!!","END");
					else
						MessageBox.Show("Reading done!!","END");
						
					pbStatus.Value=0;
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "Error");
					serialPort1.Close();
					bTest.BackColor= SystemColors.Control;
					statusCom = -1;
				}
			}
			else
				MessageBox.Show("No Test COM Port","Warning");
		}

		void BWriteEEPROMClick(object sender, EventArgs e)
		{
            string data="";
			string result="";
			int ntry=0;
			bool bFi=false;
			byte crcI=0;
					
			if (statusCom==1)
			{
				try
				{
					if (cbPageWrite.Checked==false)  			// Writting gropus of 0xF bytes 
					{
						serialPort1.Open();
						serialPort1.ReadTimeout  = 1000;
						serialPort1.WriteTimeout = 1000;
						pbStatus.Maximum = memSize;
						pbStatus.Step = 16;
					    for (int line =0 ; line < memSize ; line=line+16)
		                {
					    	crcI=0;
	                        pbStatus.PerformStep();
	                        //W[hex address]:[data in two-char hex]  - writes up to 16 bytes of data to the EEPROM
	                        data = "W"+ line.ToString("X")+":" ;
	                        for (int idx=0; idx<16; idx++)
	    					{
	                        	data += buffer[line+idx].ToString("X").PadLeft(2,'0');
	                        	crcI = (byte)((int)crcI ^ (int)buffer[line+idx]);
	  						}
	                        data += "," + crcI.ToString("X").PadLeft(2,'0');
	                        ntry=0;
					    	bFi=false;
	                        do 
	                        {
	                            serialPort1.WriteLine(data);
	                            result = serialPort1.ReadLine().TrimEnd('\r');
	                            if (result.StartsWith("OK"))
	                            	bFi=true;
	                            else   // ERR
	                            {
	                            	if (ntry++ > 3)
	                            	{
	                            		serialPort1.Close();
					    				MessageBox.Show("Writting ERROR:"+result ,"ERROR");				    			
	                 					pbStatus.Value=0;
	                 					return;
	                            	}
	                            }
	                            
	                        } while (bFi==false);
					    }
					    serialPort1.Close();
						MessageBox.Show("Writting done!!","END");
						pbStatus.Value=0;
					}
					else   									  // Writting gropus of 0x7F bytes
					{
						serialPort1.Open();
						serialPort1.ReadTimeout  = 1000;
						serialPort1.WriteTimeout = 1000;
						pbStatus.Maximum = memSize;
						pbStatus.Step = BLOCK;						
						for (int bloc=0; bloc<memSize; bloc=bloc+BLOCK)
						{
							pbStatus.PerformStep();
							data = "N"+ bloc.ToString("X").PadLeft(4,'0')+":" ;
							serialPort1.WriteLine(data);           // case 'N': PrepareBuffer();    break;  // N[hex address]
							result = serialPort1.ReadLine().TrimEnd('\r');
	                        if (result.StartsWith("OK")==false)
	                        {
	                            serialPort1.Close();
					    		MessageBox.Show("Order N ERROR:"+result ,"ERROR");				    			
	                 			pbStatus.Value=0;
	                 			return;
	                        }	                            	
							for(int lin=0; lin<0x80; lin=lin+0x10)
							{
								// case 'S': FillBuffer();       break;  // S[hex address]:[data in two-char hex]
								data = "S"+ (lin).ToString("X").PadLeft(4,'0')+":" ;
								crcI=0;
	                            for (int idx=0; idx<16; idx++)
	    					    {
	                        	   data += buffer[bloc+lin+idx].ToString("X").PadLeft(2,'0');
	                        	   crcI = (byte)((int)crcI ^ (int)buffer[bloc+lin+idx]);
	  						    }
	                            data += "," + crcI.ToString("X").PadLeft(2,'0');
	                            serialPort1.WriteLine(data);                            
	                            result = serialPort1.ReadLine().TrimEnd('\r');
	                            if (result.StartsWith("OK")==false)
		                        {
		                            serialPort1.Close();
						    		MessageBox.Show("Order S ERROR:"+result ,"ERROR");		// A3 18 		    			
		                 			pbStatus.Value=0;
		                 			return;
		                        }
							}
							serialPort1.WriteLine("T");	//  case 'T': ProgramBuffer();    break;								
	                        result = serialPort1.ReadLine().TrimEnd('\r');
	                        if (result.StartsWith("OK")==false)							
	                        {
	                            serialPort1.Close();
					    		MessageBox.Show("Order T ERROR:"+result ,"ERROR");				    			
	                 			pbStatus.Value=0;
	                 			return;
	                        }	                        	
						}
						serialPort1.Close();
						MessageBox.Show("Writting done!!","END");
						pbStatus.Value=0;
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "Error");
					serialPort1.Close();
					bTest.BackColor= SystemColors.Control;
					statusCom = -1;
				}
			}
			else
				MessageBox.Show("No Test COM Port","Warning");
		}
	}
}
