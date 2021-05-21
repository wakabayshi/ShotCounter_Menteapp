using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace ShotCounter_Tool
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            this.cmb_Portlist.Items.Add("");
            this.cmb_Portlist.Items.Add("COM3:USB To UART XP12");
            this.btn_save.Enabled = false;
            this.btn_reset.Enabled = false;
            this.textBox1.Enabled = false;
            this.textBox2.Enabled = false;
            this.textBox3.Enabled = false;
            this.textBox4.Enabled = false;
            this.textBox5.Enabled = false;
            this.textBox6.Enabled = false;
            this.textBox7.Enabled = false;
            this.textBox8.Enabled = false;
            this.textBox9.Enabled = false;
            this.checkBox1.Enabled = false;
            this.checkBox2.Enabled = false;
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void cmb_Portlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void gb_items_Enter(object sender, EventArgs e)
        {

        }

        private void btn_Connect_Click(object sender, EventArgs e)
        {
            SerialPort serialPorts1 = new SerialPort();
            serialPorts1.BaudRate = 115200;
            serialPorts1.DataBits = 8;
            serialPorts1.Parity = Parity.None;
            serialPorts1.StopBits = StopBits.One;
            serialPorts1.Handshake = Handshake.None;
            serialPorts1.PortName = "COM3";
            if (this.cmb_Portlist.SelectedIndex > 0)
            {
                this.btn_Connect.Text = "切断";
                this.btn_reset.Enabled = true;
                this.btn_save.Enabled = true;
                this.textBox1.Enabled = true;
                this.textBox2.Enabled = true;
                this.textBox3.Enabled = true;
                this.textBox4.Enabled = true;
                this.textBox5.Enabled = true;
                this.textBox6.Enabled = true;
                this.textBox7.Enabled = true;
                this.textBox8.Enabled = true;
                this.textBox9.Enabled = true;
                this.checkBox1.Enabled = true;
                this.checkBox2.Enabled = true;
                this.radioButton1.Enabled = true;
                this.radioButton2.Enabled = true;
                this.radioButton3.Enabled = true;
                this.radioButton4.Enabled = true;
                this.richTextBox2.Enabled = true;

                
                serialPorts1.Open();

                if (serialPorts1.IsOpen)
                {
                    //byte[] b = new byte[8];
                    //b[0] = (byte)'01';
                    var byteArray = new byte[] { 0x01, 0x03, 0x00, 0x09, 0x00, 0x03, 0xd5, 0xc9 };
                    //byte[] byteArray = {1, 3, 0, 9, 0, 13, 213, 201 };
                    Console.WriteLine(byteArray);
                    //int num = BitConverter.ToUInt32("01 03 00 09 00 03 d5 c9", 0);
                    serialPorts1.Write(byteArray, 0, byteArray.Length);
                    Console.WriteLine("送信");
                }
                serialPorts1.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
                Console.WriteLine("受信");
                //string str = serialPorts1.ReadLine();
                //this.label2.Text = str;


            }
            else
            {
                serialPorts1.Close();
                this.cmb_Portlist.Items.Add("");
                this.cmb_Portlist.Items.Add("COM3:USB To UART XP12");
                this.btn_save.Enabled = false;
                this.btn_reset.Enabled = false;
                this.textBox1.Enabled = false;
                this.textBox2.Enabled = false;
                this.textBox3.Enabled = false;
                this.textBox4.Enabled = false;
                this.textBox5.Enabled = false;
                this.textBox6.Enabled = false;
                this.textBox7.Enabled = false;
                this.textBox8.Enabled = false;
                this.textBox9.Enabled = false;
                this.checkBox1.Enabled = false;
                this.checkBox2.Enabled = false;
                
            }
        }
        private static void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string indata = sp.ReadExisting();
            Console.WriteLine("Data Received:");
            Console.WriteLine(indata);
        }
      

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
