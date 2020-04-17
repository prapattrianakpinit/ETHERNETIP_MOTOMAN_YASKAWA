using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sres.Net.EEIP;

namespace EIP_YASKAWA_ROBOT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EEIPClient eeipClient = new EEIPClient();
            eeipClient.IPAddress = "192.168.255.1";
            eeipClient.RegisterSession();
            int B = 1;
            while (B == 1)
            {
                double value = 0;
                int[] V2 = { 9876543, 0 };
                byte[] bb = BitConverter.GetBytes(V2[0]);
                eeipClient.SetAttributeSingle(0x78, 2701, 1, new byte[] { 255 });
                eeipClient.SetAttributeSingle(0x7F, 2, 1, new byte[] { 16, 0, 0, 0 });// set P002 to base type
                //eipClient.SetAttributeSingle(0x7F(P-var), Var no. 2, arrtibute 1, data send new byte[] { 16, 0, 0, 0 });
                // X,Y,Z 0.000 
                byte[] A = eeipClient.SetAttributeSingle(0x7F, 2, 6, new byte[] { bb[0], bb[1], bb[2], bb[3] });// 1st axis IN{BYTE SEND}SEPARATE DOUBLE DATA TO BINARY}
                eeipClient.SetAttributeSingle(0x7F, 2, 7, new byte[] { 15, 39, (byte)value, 0 });// 2nd axis
                eeipClient.SetAttributeSingle(0x7F, 2, 8, new byte[] { 15, 39, (byte)value, 0 });// 3rd axis
                // degree is 0.0000 
                eeipClient.SetAttributeSingle(0x7F, 2, 9, new byte[] { 15, 39, (byte)value, 0 });// 4th axis
                eeipClient.SetAttributeSingle(0x7F, 2, 10, new byte[] { 15, 39, (byte)value, 0 });// 5th axis
                eeipClient.SetAttributeSingle(0x7F, 2, 11, new byte[] { 15, 39, (byte)value, 0 });// 6th axis
                eeipClient.SetAttributeSingle(0x7A, 2, 1, new byte[] { 255 });// 
                byte[] response = eeipClient.GetAttributeSingle(0x78, 2701, 1);
                //byte[] response = eeipClient.GetAttributeSingle(0x78, 1001, 1);
                eeipClient.UnRegisterSession();
                //if (response[0] <= 1)
                //    Environment.Exit(0);
                B = 0;


            }

        }
    }
}
