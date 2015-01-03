/*
 * Upload a series of binaries to an Arduino EEPROM and generate a list of offsets [draft]
 * Mastro Gippo 2015
 * Released under the WTFPL http://www.wtfpl.net/txt/copying/
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace eeprom
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            serialPort1.BaudRate = 57600;
            serialPort1.Open();
            foreach (string f in listBox1.Items)
            {
                byte[] fi = File.ReadAllBytes(f);
                serialPort1.Write(fi, 0, fi.Length);
            }
            serialPort1.Close();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int idx = 0;
            byte[] tmp;
            string[] gg = Directory.GetFiles(Application.StartupPath, "*.bin");
            foreach(string g in gg)
            {
                listBox1.Items.Add(g.Substring(g.LastIndexOf('\\')+1));
                textBox1.Text += "uint16_t idx_" + g.Substring(g.LastIndexOf('\\') + 1).Replace(".bin", "") + " = " + idx + ";\r\n";
                tmp = File.ReadAllBytes(g.Substring(g.LastIndexOf('\\')+1));
                idx += tmp.Length;
            }
            
        }
    }
}
