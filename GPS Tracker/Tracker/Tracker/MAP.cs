using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Tracker
{
    public partial class MAP : Form
    {
        public MAP()
        {
            InitializeComponent();
        }

        int time = 50000;
        int timeCounter = 1000;
        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            time = 50000;
            StringBuilder querryAddress = new StringBuilder();
            try
            {

                textBox2.AppendText(serialPort1.ReadLine());
                

            }
            catch (Exception ex)
            {
                label2.Text = "ERROR";
            }
            
            if (textBox2.Text.Length > 5)
            {
                try
                {
                    querryAddress.Append("http://maps.google.co.in/maps?q=" + textBox2.Text);
                    webBrowser1.Navigate(querryAddress.ToString());
                }
                catch
                {
                    MessageBox.Show("Error in Fetching Page");
                }
            }
        }


        private void MAP_Load(object sender, EventArgs e)
        {
           
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            label4.Text = (time - timeCounter).ToString();
        }

        private void MAP_FormClosed(object sender, FormClosedEventArgs e)
        {
            serialPort1.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            serialPort1.PortName = textBox1.Text.Trim();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Start();
            try
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();
                }
                serialPort1.Open();
                label2.Text = "READING";
            }
            catch (Exception ex)
            {
                label2.Text = "ERROR";
                serialPort1.Close();
            }
        }
    }
}
