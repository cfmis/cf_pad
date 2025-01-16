using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Timers;
using Modbus;
using Modbus.Device;
using cf_pad.CLS;

namespace cf_pad.Forms
{
    public partial class frmDemoRS485 : Form
    {
        /// <summary>
        /// 串行端口资源 端口名称 波特率 奇偶校验位 数据位 停止位
        /// </summary>
        public SerialPort port = new SerialPort("COM1", 9600, Parity.None, 8, StopBits.One);
        public frmDemoRS485()
        {
            InitializeComponent();

            ////串行端口号
            //seriaSettingPlay.PortName = "COM1";
            ////波特率
            //seriaSettingPlay.BaudRate = 115200;
            ////奇偶校验位
            //seriaSettingPlay.Parity = Parity.None;
            ////数据位
            //seriaSettingPlay.DataBits = 8;
            ////停止位
            //seriaSettingPlay.StopBits = StopBits.One;
            //textChanged += new UpdateTextEventHandler(ChangeText);
            //try
            //{
            //    //打开串口
            //    seriaSettingPlay.Open();
            //}
            //catch (Exception ex)
            //{
            //    //捕获的异常信息，没检查到串口或串口设置不正确。
            //    MessageBox.Show("请检查是否已经连接串口！\n" + ex.Message, "提示");
            //}
        }

        //定义委托
        private delegate void GetText(string text);
        //定义事件
        private event GetText textChanged;
        //事件处理方法
        private void ChangeText(string text)
        {
              //这里为处理接收到的值，赋值到控件上。
              //...........
        }
        //定义接收的字节
        private byte[] Data = new byte[8];
        private void frmDemoRS485_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// //设备全开、关
        /// </summary>
        protected void AllOpenOrClose()
        {
            //try
            //{
            //    //打开串口
            //    port.Open();
            //    //判断是否选中开
            //    if (chb_CheckAll.Checked == true)
            //    {
            //        //用字节的形式发送数据  全开 解释：order1 是控制命令，后面是2个byte的校验（高8位与低8位），0x00可以不写，直接写成(byte)((order1)>>8)
            //        byte[] b = { order1, (byte)((order1 + 0x00) >> 8), (byte)(order1 + 0x00) };
            //        //把b数组中的数据以字节的形式写入串行端口
            //        port.Write(b, 0, b.Length);
            //        //提示信息！
            //        lab_Message.Text = "设备已经全部打开!";
            //    }
            //    else
            //    {
            //        //用字节的形式发送数据  全关
            //        byte[] b = { order2, (byte)((order2 + 0x00) >> 8), (byte)(order2 + 0x00) };
            //        v.port.Write(b, 0, b.Length);
            //        lab_Message.Text = "设备已经全部关闭!";
            //    }

            //    //关闭串口  记得开启端口之后一定要关闭，和ADO.NET的Connection对象一样，用过之后必须关闭。
            //    port.Close();
            //}
            //catch (Exception ex)
            //{
            //    //捕获的异常信息
            //    MessageBox.Show(ex.Message, "提示");

            //}
        }

        private void seriaSettingPlay_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            ////读取来自监听到的字节
            //seriaSettingPlay.Read(be, 0, be.Length);
            ////把第一个命名赋值到text变量
            //text = be[0].Tostring();
            //seriaSettingPlay.DiscardInBuffer();
            //this.Invoke(textChanged, new string[] { text });
        }

        private void btnCrc_Click(object sender, EventArgs e)
        {
            List<byte> b1 = new List<byte>();
            //for (int i=0;i<2;i++)
            //{
            //    byte a1 = (byte)i;
            //    b1.Add(a1);
            //}01 10 00 0F 00 04 08 00 00 00 10 00 00 00 20 
            string strVal = "010300000001";
            var dd = Encoding.UTF8.GetBytes("0F");
            List<byte> byteList = new List<byte> { 01,03,00,00,00,01 };
            //List<byte> byteList = new List<byte> {};
            //byteList.AddRange(Encoding.UTF8.GetBytes(strVal));
            //byteList.AddRange(Encoding.UTF8.GetBytes("01"));
            //byteList.AddRange(Encoding.UTF8.GetBytes("10"));
            //byteList.AddRange(Encoding.UTF8.GetBytes("00"));
            //byteList.AddRange(Encoding.UTF8.GetBytes("0F"));
            //byteList.AddRange(Encoding.UTF8.GetBytes("0F"));
            //byteList.AddRange(Encoding.UTF8.GetBytes("00"));
            //byteList.AddRange(Encoding.UTF8.GetBytes("08"));
            //byteList.AddRange(Encoding.UTF8.GetBytes("00"));
            //byteList.AddRange(Encoding.UTF8.GetBytes("00"));
            //byteList.AddRange(Encoding.UTF8.GetBytes("00"));
            //byteList.AddRange(Encoding.UTF8.GetBytes("10"));
            //byteList.AddRange(Encoding.UTF8.GetBytes("00"));
            //byteList.AddRange(Encoding.UTF8.GetBytes("00"));
            //byteList.AddRange(Encoding.UTF8.GetBytes("00"));
            //byteList.AddRange(Encoding.UTF8.GetBytes("20"));
            //byteList.ForEach(b => MessageBox.Show(b.ToString()));
            //string a11 = "";
            //a11 = "00";
            //a1 = (byte)0;
            //b1.Add(a1);
            //a1 = (byte)99;
            //b1.Add(a1);
            //a1 = (byte)99;
            //b1.Add(a1);
            //a1 = (byte)99;
            //b1.Add(a1);
            //a1 = (byte)0;
            //b1.Add(a1);
            //a1 = (byte)99;
            //b1.Add(a1);
            //a1 = (byte)99;
            //b1.Add(a1);
            //a1 = (byte)99;

            var crc16 = ModbusCrc16(byteList, false);
            txtCrc16.Text = crc16.ToString();
        }


        private static UInt16 ModbusCrc16(List<byte> Frame, bool Append)
        {
            int Length = Append ? Frame.Count : Frame.Count - 2;
            UInt16 crc16 = 0xffff;
            for (int ByteIndex = 0; ByteIndex < Length; ByteIndex++)
            {
                crc16 ^= Frame[ByteIndex];
                for (int n = 0; n < 8; n++)
                {
                    if ((crc16 & 1) == 1)
                    {
                        crc16 >>= 1;
                        crc16 ^= 0xA001;
                    }
                    else
                    {
                        crc16 >>= 1;
                    }
                }
            }
            if (Append)
            {
                Frame.Add((byte)(crc16 & 0xff));
                Frame.Add((byte)(crc16 >> 8));
            }
            else
            {
                Frame[Frame.Count - 2] = (byte)(crc16 & 0xff);
                Frame[Frame.Count - 1] = (byte)(crc16 >> 8);
            }
            return crc16;
        }

        private void ReadWrite485()
        {
            //string portName = "COM3"; // 修改为实际使用的串口名称
            //int baudRate = 9600;
            //Parity parity = Parity.None;
            //int dataBits = 8;
            //StopBits stopBits = StopBits.One;
            using (SerialPort port = new SerialPort("COM3"))
            {
                // configure serial port
                port.BaudRate = 9600;
                port.DataBits = 8;
                port.Parity = Parity.None;
                port.StopBits = StopBits.One;
                port.Open();

                //var adapter = new SerialPortAdapter(port);
                // create modbus master
                IModbusSerialMaster master = ModbusSerialMaster.CreateRtu(port);

                byte slaveId = 1;
                ushort startAddress = 100;
                ushort[] registers = new ushort[] { 1, 2, 3 };

                // write three registers
                master.WriteMultipleRegisters(slaveId, startAddress, registers);

                //读取数据函数：
                slaveId = 1;
                startAddress = 0;
                ushort numRegisters = 10;
                registers = master.ReadHoldingRegisters(slaveId, startAddress, numRegisters);
                //读取寄存器数据到register数组中
                //需要处理数据的话 后面可能就需要数据的转化
                //写数据函数：
                byte slaveID = 1;
                ushort registerAddress = 0;
                ushort value = 100;//你要写的值
                master.WriteSingleRegister(slaveID, registerAddress, value);
            }



        }

        private void btnRW485_Click(object sender, EventArgs e)
        {
            ReadWrite485();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string a1 = "012345678";
            //textBox1.Text=CRC.ToCRC16("012345678", true);          //结果为：C3CD
            ////textBox1.Text = CRC.ToCRC16("012345678", false);           //结果为：CDC3

            //a1 = "0110000F0004080000001000000020";
            a1 = "0110000F00040800000030000000406275";
            a1 = "01 03 00 21 00 02";
            a1 = "01 03 00 00 00 01";
            a1 = "01 06 00 00 00 02";
            textBox1.Text = CRC.ToModbusCRC16(a1, true);      //结果为：2801

            //textBox1.Text = CRC.ToCRC16("你好，我们测试一下CRC16算法", true);　  //结果为：0182
        }
    }
}
