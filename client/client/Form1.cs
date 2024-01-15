using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace client
{
    public partial class Form1 : Form
    {

        bool terminating = false;
        bool connected = false;
        Socket clientSocket;

        public Form1()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
            InitializeComponent();
        }

        private void button_connect_Click(object sender, EventArgs e)
        {
            Thread.Sleep(50);
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            string IP = textBox_ip.Text;
            string name = textBox_name.Text;

            int portNum;
            if(Int32.TryParse(textBox_port.Text, out portNum))
            {
                try
                {
                    clientSocket.Connect(IP, portNum);
                    button_connect.Enabled = false;
                    textBox_message.Enabled = true;
                    button_send.Enabled = true;
                    button_disconnect.Enabled = true;
                    connected = true;
					byte[] message = Encoding.Default.GetBytes(name);
					clientSocket.Send(message);
					// logs.AppendText("Connected to the server!\n");

					Thread receiveThread = new Thread(Receive);
                    receiveThread.Start();

                }
                catch
                {
                    logs.AppendText("Could not connect to the server!\n");
                }
            }
            else
            {
                logs.AppendText("Check the port\n");
            }

        }

        private void resetGrid()
        {
            box1.Text = "1";
            box2.Text = "2";
            box3.Text = "3";
            box4.Text = "4";
            box5.Text = "5";
            box6.Text = "6";
            box7.Text = "7";
            box8.Text = "8";
            box9.Text = "9";
        }
        private void resetscore()
        {
            winsx_label9.Text = "0";
            winsx_label9.ForeColor = Color.Blue;
            winso_label10.Text = "0";
            winso_label10.ForeColor = Color.Blue;
            rounds_label12.Text = "0";
            
            draw_label11.Text = "0";
            
        }
        private void Receive()
        {
            while(connected)
            {
                try
                {
                    Byte[] buffer = new Byte[64];
                    clientSocket.Receive(buffer);
                    string incomingMessage = Encoding.Default.GetString(buffer);
                    incomingMessage = incomingMessage.Substring(0, incomingMessage.IndexOf("\0"));

                    if ((incomingMessage.Substring(0, 1) == "X" || incomingMessage.Substring(0, 1) == "O") && incomingMessage.Length == 2)
                    {
                        string sign = incomingMessage.Substring(0, 1);
                        string position = incomingMessage.Substring(1, 1);
                        if (position == "1")
                        {
                            box1.Text = sign;
                        }
                        else if (position == "2")
                        {
                            box2.Text = sign;
                        }
                        else if (position == "3")
                        {
                            box3.Text = sign;
                        }
                        else if (position == "4")
                        {
                            box4.Text = sign;
                        }
                        else if (position == "5")
                        {
                            box5.Text = sign;
                        }
                        else if (position == "6")
                        {
                            box6.Text = sign;
                        }
                        else if (position == "7")
                        {
                            box7.Text = sign;
                        }
                        else if (position == "8")
                        {
                            box8.Text = sign;
                        }
                        else if (position == "9")
                        {
                            box9.Text = sign;
                        }

					}

                    else if (incomingMessage == "0001")
                    {
                        logs.AppendText("The server has already reached the max number of connected clients!\n");
                        button_connect.Enabled = true;
                        textBox_message.Enabled = false;
                        button_send.Enabled = false;
                        button_disconnect.Enabled = false;
                        clientSocket.Close();
                        connected = false;
                        break;
                    }
                    else if (incomingMessage == "0002")
                    {
                        logs.AppendText("It is not your turn\n");
                    }
                    else if (incomingMessage == "0003")
                    {
                        logs.AppendText("Invalid range of input\n");
                    }
                    else if (incomingMessage == "0004")
                    {
                        logs.AppendText("Cell already marked\n");
                    }
                    else if (incomingMessage == "0006")
                    {
                        resetGrid();

                    }
                    else if ((incomingMessage.Substring(0, 1) == "`"))
                    {
                        Byte[] buffer1 = Encoding.Default.GetBytes("`");
                        clientSocket.Send(buffer1);
                        logs.AppendText("Server: " + incomingMessage.Substring(1)  + "\n");
                    }
                    else if ((incomingMessage.Substring(0, 1) == "A" ))
                    {
                        winsx_label9.Text = incomingMessage.Substring(1);
                        if(Int16.Parse(winsx_label9.Text) < Int16.Parse(winso_label10.Text))
                        {
                            winsx_label9.ForeColor = Color.Red;
                            winso_label10.ForeColor = Color.Green;
                        }
                        else if (Int16.Parse(winsx_label9.Text) > Int16.Parse(winso_label10.Text))
                        {
                            winsx_label9.ForeColor = Color.Green;
                            winso_label10.ForeColor = Color.Red;

                        }
                        else if (Int16.Parse(winsx_label9.Text) == Int16.Parse(winso_label10.Text))
                        {
                            winsx_label9.ForeColor = Color.Blue;
                            winso_label10.ForeColor = Color.Blue;
                        }
                    }
                    else if ((incomingMessage.Substring(0, 1) == "B"))
                    {
                        winso_label10.Text = incomingMessage.Substring(1);
                        if (Int16.Parse(winsx_label9.Text) < Int16.Parse(winso_label10.Text))
                        {
                            winsx_label9.ForeColor = Color.Red;
                            winso_label10.ForeColor = Color.Green;
                        }
                        else if (Int16.Parse(winsx_label9.Text) > Int16.Parse(winso_label10.Text))
                        {
                            winsx_label9.ForeColor = Color.Green;
                            winso_label10.ForeColor = Color.Red;

                        }
                        else if (Int16.Parse(winsx_label9.Text) == Int16.Parse(winso_label10.Text))
                        {
                            winsx_label9.ForeColor = Color.Blue;
                            winso_label10.ForeColor = Color.Blue;
                        }
                    }
                    else if ((incomingMessage.Substring(0, 1) == "@"))
                    {
                        draw_label11.Text = incomingMessage.Substring(1);
                        if (Int16.Parse(winsx_label9.Text) < Int16.Parse(winso_label10.Text))
                        {
                            winsx_label9.ForeColor = Color.Red;
                            winso_label10.ForeColor = Color.Green;
                        }
                        else if (Int16.Parse(winsx_label9.Text) > Int16.Parse(winso_label10.Text))
                        {
                            winsx_label9.ForeColor = Color.Green;
                            winso_label10.ForeColor = Color.Red;

                        }
                        else if (Int16.Parse(winsx_label9.Text) == Int16.Parse(winso_label10.Text))
                        {
                            winsx_label9.ForeColor = Color.Blue;
                            winso_label10.ForeColor = Color.Blue;
                        }
                    }
                    else if ((incomingMessage.Substring(0, 1) == "R"))
                    {
                        rounds_label12.Text = incomingMessage.Substring(1);
                        if (Int16.Parse(winsx_label9.Text) < Int16.Parse(winso_label10.Text))
                        {
                            winsx_label9.ForeColor = Color.Red;
                            winso_label10.ForeColor = Color.Green;
                        }
                        else if (Int16.Parse(winsx_label9.Text) > Int16.Parse(winso_label10.Text))
                        {
                            winsx_label9.ForeColor = Color.Green;
                            winso_label10.ForeColor = Color.Red;

                        }
                        else if (Int16.Parse(winsx_label9.Text) == Int16.Parse(winso_label10.Text))
                        {
                            winsx_label9.ForeColor = Color.Blue;
                            winso_label10.ForeColor = Color.Blue;
                        }
                    }
                    else
                    {
						logs.AppendText("Server: " + incomingMessage + "\n");
					}
	
                }
                catch
                {
                    if (!terminating)
                    {
                        logs.AppendText("The server has disconnected\n");
                        resetGrid();
                        resetscore();
                        button_connect.Enabled = true;
                        textBox_message.Enabled = false;
                        button_send.Enabled = false;
                        button_disconnect.Enabled = false;
                    }

                    clientSocket.Close();
                    connected = false;
                }

            }
        }

        private void Form1_FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            connected = false;
            terminating = true;
            Environment.Exit(0);
        }

        private void button_send_Click(object sender, EventArgs e)
        {
            string message = textBox_message.Text;

            if(message != "" && message.Length <= 64)
            {
                Byte[] buffer = Encoding.Default.GetBytes(message);
                clientSocket.Send(buffer);
            }

        }

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		private void button_disconnect_Click(object sender, EventArgs e)
		{
            logs.AppendText("You disconnected from the server\n");
            resetGrid();
            resetscore();
            connected = false;
            terminating = true;
            clientSocket.Close();
			textBox_message.Enabled = false;
			button_send.Enabled = false;
            button_connect.Enabled = true;
            button_disconnect.Enabled = false;
            Thread.Sleep(50);

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}
