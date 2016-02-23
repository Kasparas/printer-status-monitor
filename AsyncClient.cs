//The validations is not thoroughly done so you may face some errors when executing the code.
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Net;
using System.Net.Sockets;

namespace AsyncClient
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		
		byte[] m_DataBuffer = new byte [10];
		IAsyncResult m_asynResult;
		public AsyncCallback pfnCallBack ;
		public Socket m_socClient;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtPort;
		private System.Windows.Forms.Button cmdSend;
		private System.Windows.Forms.TextBox txtDataReceive;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button cmdConnect;
		private System.Windows.Forms.Button cmdClose;
		private System.Windows.Forms.TextBox txtDataSend;
		private System.Windows.Forms.TextBox txtIPAddr;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.cmdClose = new System.Windows.Forms.Button();
			this.cmdConnect = new System.Windows.Forms.Button();
			this.txtPort = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtIPAddr = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txtDataSend = new System.Windows.Forms.TextBox();
			this.cmdSend = new System.Windows.Forms.Button();
			this.txtDataReceive = new System.Windows.Forms.TextBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.cmdClose);
			this.groupBox1.Controls.Add(this.cmdConnect);
			this.groupBox1.Controls.Add(this.txtPort);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.txtIPAddr);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(8, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(280, 80);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Settings";
			this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
			// 
			// cmdClose
			// 
			this.cmdClose.Enabled = false;
			this.cmdClose.Location = new System.Drawing.Point(160, 48);
			this.cmdClose.Name = "cmdClose";
			this.cmdClose.Size = new System.Drawing.Size(96, 24);
			this.cmdClose.TabIndex = 5;
			this.cmdClose.Text = "Close";
			this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
			// 
			// cmdConnect
			// 
			this.cmdConnect.Location = new System.Drawing.Point(160, 16);
			this.cmdConnect.Name = "cmdConnect";
			this.cmdConnect.Size = new System.Drawing.Size(96, 24);
			this.cmdConnect.TabIndex = 4;
			this.cmdConnect.Text = "Connect";
			this.cmdConnect.Click += new System.EventHandler(this.cmdConnect_Click);
			// 
			// txtPort
			// 
			this.txtPort.Location = new System.Drawing.Point(72, 48);
			this.txtPort.Name = "txtPort";
			this.txtPort.Size = new System.Drawing.Size(40, 20);
			this.txtPort.TabIndex = 3;
			this.txtPort.Text = "9100";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(32, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "Port:";
			// 
			// txtIPAddr
			// 
			this.txtIPAddr.Location = new System.Drawing.Point(72, 24);
			this.txtIPAddr.Name = "txtIPAddr";
			this.txtIPAddr.Size = new System.Drawing.Size(80, 20);
			this.txtIPAddr.TabIndex = 1;
			this.txtIPAddr.Text = "132.126.111.11";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Host IP:";
			// 
			// txtDataSend
			// 
			this.txtDataSend.Location = new System.Drawing.Point(16, 104);
			this.txtDataSend.Multiline = true;
			this.txtDataSend.Name = "txtDataSend";
			this.txtDataSend.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtDataSend.Size = new System.Drawing.Size(176, 16);
			this.txtDataSend.TabIndex = 1;
			this.txtDataSend.Text = "";
			this.txtDataSend.Visible = false;
			this.txtDataSend.TextChanged += new System.EventHandler(this.txtDataSend_TextChanged);
			// 
			// cmdSend
			// 
			this.cmdSend.Enabled = false;
			this.cmdSend.Location = new System.Drawing.Point(16, 96);
			this.cmdSend.Name = "cmdSend";
			this.cmdSend.Size = new System.Drawing.Size(264, 24);
			this.cmdSend.TabIndex = 2;
			this.cmdSend.Text = "Send Command";
			this.cmdSend.Click += new System.EventHandler(this.cmdSend_Click);
			// 
			// txtDataReceive
			// 
			this.txtDataReceive.Location = new System.Drawing.Point(16, 144);
			this.txtDataReceive.Multiline = true;
			this.txtDataReceive.Name = "txtDataReceive";
			this.txtDataReceive.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtDataReceive.Size = new System.Drawing.Size(264, 184);
			this.txtDataReceive.TabIndex = 3;
			this.txtDataReceive.Text = "";
			// 
			// groupBox2
			// 
			this.groupBox2.Location = new System.Drawing.Point(8, 128);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(280, 208);
			this.groupBox2.TabIndex = 4;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Data Arrived";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 349);
			this.Controls.Add(this.txtDataReceive);
			this.Controls.Add(this.cmdSend);
			this.Controls.Add(this.txtDataSend);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.groupBox2);
			this.Name = "Form1";
			this.Text = "Socket Client in C#";
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}
		private void EnableCommands( bool abEnableConnect ) 
		{
			cmdClose.Enabled = !abEnableConnect;
			cmdSend.Enabled=!abEnableConnect; 
			cmdConnect.Enabled = abEnableConnect;
		}
		private void cmdConnect_Click(object sender, System.EventArgs e)
		{
			
			try
			{
				EnableCommands(true);
				//Creating instance of Socket
				m_socClient = new Socket (AddressFamily.InterNetwork,SocketType.Stream ,ProtocolType.Tcp );

				// retrieve the remote machines IP address
				IPAddress ip = IPAddress.Parse (txtIPAddr.Text);
				//A printer has open port 9100 which can be used to connect to printer
				int iPortNo = System.Convert.ToInt16 ( txtPort.Text);
				//create the end point 
				IPEndPoint ipEnd = new IPEndPoint (ip.Address,iPortNo);
				//connect to the remote host
				m_socClient.Connect ( ipEnd );
				EnableCommands(false);
				//wait for data to arrive 
				WaitForData();
			}
			catch(SocketException se)
			{
				MessageBox.Show (se.Message );
				EnableCommands(true);
			}
		}
		public void WaitForData()
		{
			try
			{
				if  ( pfnCallBack == null ) 
				{
					pfnCallBack = new AsyncCallback (OnDataReceived);
				}
				CSocketPacket theSocPkt = new CSocketPacket ();
				theSocPkt.thisSocket = m_socClient;
				// now start to listen for any data which arrives
				m_asynResult = m_socClient.BeginReceive (theSocPkt.dataBuffer ,0,theSocPkt.dataBuffer.Length ,SocketFlags.None,pfnCallBack,theSocPkt);
			}
			catch(SocketException se)
			{
				MessageBox.Show (se.Message );
			}

		}

		private void cmdSend_Click(object sender, System.EventArgs e)
		{
			try
			{
				string sendString;
				//sendString=String.Format("\x1B%-12345X\r\n\@PJL INQUIRE PAGEPROTECT\r\n@PJL INQUIRE RESOLUTION\r\n@PJL INQUIRE PERSONALITY\r\n@PJL INQUIRE TIMEOUT\r\n@PJL ECHO 02:18:23.9 05-30-92\r\n@PJL INQUIRE LPARM : PCL PITCH\r\n@PJL INQUIRE LPARM : PCL PTSIZE\r\n@PJL INQUIRE LPARM : PCL SYMSET\r\nx1B%-12345X\r\n");
				//sendString = String.Format("\x1B%-12345X@PJL INFO PAGECOUNT \r\n\x1B%-12345X\r\n");
				//sendString = String.Format("\x1B%-12345X@PJL INQUIRE RESOLUTION \r\n\x1B%-12345X\r\n");
				//sendString = String.Format("\x1B%-12345X@PJL INQUIRE LPARM : PCL PITCH \r\n\x1B%-12345X\r\n");
				//sendString = String.Format("\x1B%-12345X@PJL INFO USTATUS \r\n\x1B%-12345X\r\n");
				sendString = String.Format("\x1B%-12345X@PJL INFO STATUS \r\n\x1B%-12345X\r\n");
				//sendString = String.Format("\x1B%-12345X@PJL INFO MEMORY \r\n\x1B%-12345X\r\n");
				//sendString = String.Format("\x1B%-12345X@PJL INFO FILESYS \r\n\x1B%-12345X\r\n");
				//sendString = String.Format("\x1B%-12345X@PJL INFO CONFIG  \r\n\x1B%-12345X\r\n");
				//sendString = String.Format("\x1B%-12345X@PJL DINQUIRE LOWTONER \r\n\x1B%-12345X\r\n");
				//sendString = String.Format("\x1B%-12345X@PJL INFO CONFIG \r\n\x1B%-12345X\r\n");

				Object objData = txtDataSend.Text;
				byte[] byData = System.Text.Encoding.ASCII.GetBytes(sendString); 
				m_socClient.Send (byData);
			}
			catch(SocketException se)
			{
				MessageBox.Show (se.Message );
			}
		
		}

		private void cmdClose_Click(object sender, System.EventArgs e)
		{
			if ( m_socClient != null )
			{
				m_socClient.Close ();//closing the connection to printer
				m_socClient = null;
				EnableCommands(true);
			}
		}

		public class CSocketPacket
		{
			public System.Net.Sockets.Socket thisSocket;
			public byte[] dataBuffer = new byte[1]; 
		}


		

		public  void OnDataReceived(IAsyncResult asyn)
		{
			try
			{

				CSocketPacket theSockId = (CSocketPacket)asyn.AsyncState ;//creating object of the class

				//end receive of data
				int iReceive  = 0 ;
				iReceive = theSockId.thisSocket.EndReceive (asyn);
				char[] chars = new char[iReceive +  1];
				System.Text.Decoder d = System.Text.Encoding.UTF8.GetDecoder(); //creating object for decoding
				int charLen = d.GetChars(theSockId.dataBuffer, 0, iReceive, chars, 0);
				System.String szData = new System.String(chars);
				txtDataReceive.Text = txtDataReceive.Text + szData;
				//as data arrives the bytes are appended to the existing string printer throws data in an ASCII format 1 byte at a time

				WaitForData();
			}
			catch (ObjectDisposedException )
			{
				System.Diagnostics.Debugger.Log(0,"1","\nOnDataReceived: Socket has been closed\n");
			}
			catch(SocketException se)
			{
				MessageBox.Show (se.Message ); //gives an error message if any exception has occured
			}
		}

		private void groupBox1_Enter(object sender, System.EventArgs e)
		{
		
		}

		private void txtDataSend_TextChanged(object sender, System.EventArgs e)
		{
		
		}


		
	
	}
}



